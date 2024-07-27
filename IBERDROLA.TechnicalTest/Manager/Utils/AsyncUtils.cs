namespace IBERDROLA.TechnicalTest.Manager.Utils
{
    internal static class AsyncUtils
    {
        /// <summary>
        /// ContinueWith Function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        internal static async Task<TResult> Map<T, TResult>(this Task<T> task,
            Func<T, TResult> mapping)
        {
            return mapping(await task);
        }

        /// <summary>
        /// ContinueWith Function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        internal static async Task<TResult> FlatMap<T, TResult>(this Task<T> task,
            Func<T, Task<TResult>> mapping)
        {
            return await mapping(await task);
        }

        /// <summary>
        /// string pageContents = await RetryOnFault(
        ///     () => DownloadStringAsync(url), 3);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function"></param>
        /// <param name="maxTries"></param>
        /// <returns></returns>
        internal static async Task<T> RetryOnFault<T>(
            Func<Task<T>> function, int maxTries)
        {

            for (int i = 0; i < maxTries; i++)
            {
                try { return await function(); }
                catch { if (i == maxTries - 1) throw; }
            }
            return default;
        }

        /// <summary>
        ///string pageContents = await RetryOnFault(
        ///    () => DownloadStringAsync(url), 3, () => Task.Delay(1000));
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function"></param>
        /// <param name="maxTries"></param>
        /// <param name="retryWhen"></param>
        /// <returns></returns>
        internal static async Task<T> RetryOnFault<T>(
            Func<Task<T>> function, int maxTries, Func<Task> retryWhen)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { return await function().ConfigureAwait(false); }
                catch { if (i == maxTries - 1) throw; }
                await retryWhen();
            }
            return default;
        }

        /// <summary>
        ///            IEnumerable Task int>> tasks = ...;
        ///            foreach (var task in Interleaved(tasks))
        ///            {
        ///                int result = await task;
        ///                …
        ///            }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks"></param>
        /// <returns></returns>
        internal static IEnumerable<Task<T>> Interleaved<T>(IEnumerable<Task<T>> tasks)
        {

            var inputTasks = tasks.ToList();
            var sources = (from _ in Enumerable.Range(0, inputTasks.Count)
                           select new TaskCompletionSource<T>()).ToList();
            int nextTaskIndex = -1;
            foreach (var inputTask in inputTasks)
            {
                inputTask.ContinueWith(completed =>
                {
                    var source = sources[Interlocked.Increment(ref nextTaskIndex)];
                    if (completed.IsFaulted)
                        source.TrySetException(completed.Exception.InnerExceptions);
                    else if (completed.IsCanceled)
                        source.TrySetCanceled();
                    else
                        source.TrySetResult(completed.Result);
                }, CancellationToken.None,
                   TaskContinuationOptions.ExecuteSynchronously,
                   TaskScheduler.Default);
            }
            return from source in sources
                   select source.Task;
        }

        /// <summary>
        ///            IEnumerable Task int>> tasks = ...;
        ///            foreach (var task in WhenAllOrFirstException(tasks))
        ///            {
        ///                int result = await task;
        ///                …
        ///            }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks"></param>
        /// <returns></returns>
        internal static Task<T[]> WhenAllOrFirstException<T>(IEnumerable<Task<T>> tasks)
        {
            var inputs = tasks.ToList();
            var ce = new CountdownEvent(inputs.Count);
            var tcs = new TaskCompletionSource<T[]>();

            void onCompleted(Task completed)
            {
                if (completed.IsFaulted)
                    tcs.TrySetException(completed.Exception.InnerExceptions);
                if (ce.Signal() && !tcs.Task.IsCompleted)
                    tcs.TrySetResult(inputs.Select(t => t.Result).ToArray());
            }

            foreach (var t in inputs) t.ContinueWith(onCompleted);
            return tcs.Task;
        }
    }
}

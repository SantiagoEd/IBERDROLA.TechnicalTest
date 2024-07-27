namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Allotment.Queries
{
    internal static class AllotmentQueries
    {
        internal const string AllotmentValidate = @"
        Select
            idAllotmentReserva      AllotmentReservationId,
        	feCaduca                Expire,
        	isnull(idVenta,0)                 Reservation,
        	idAllotment             AllotmentId,
            CASE WHEN getdate() >= feCaduca THEN 1 ELSE 0 END Expired
        from 
        	cAllotmentReserva 
        Where idAllotmentReserva IN @Allotments
        ";
    }
}

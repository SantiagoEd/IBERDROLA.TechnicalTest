namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Allotment.Models
{
    public class AllotmentValidate
    {
        public int AllotmentReservationId { get; set; }
        public DateTime Expire { get; set; }
        public int Reservation { get; set; }
        public int AllotmentId { get; set; }
        public bool Expired { get; set; }
    }
}

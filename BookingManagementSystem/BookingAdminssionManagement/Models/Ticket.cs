namespace BookingAdminssionManagement.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public Guid Code { get; set; }

        public int SeatNumber { get; set; }

        public int ID_Film { get; set; }

        public int ID_Customer { get; set; }
    }
}

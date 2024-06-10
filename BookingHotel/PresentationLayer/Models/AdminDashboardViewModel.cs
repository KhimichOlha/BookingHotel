namespace PresentationLayer.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public double OccupancyRate { get; set; }

        public int PendingBookings { get; set; }
        public int ConfirmedBookings { get; set; }
        public int CancelledBookings { get; set; }

        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }

        public int TotalGuests { get; set; }
    }
}

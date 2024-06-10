using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ConfirmedBookingState : IBookingState
    {
        private readonly INotificationService _notificationService;
        public ConfirmedBookingState(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void Cancel(Booking booking)
        {
            booking.Status = BookingStatus.Cancelled;
            _notificationService.Send(booking.Guest.Email, $"Бронювання{booking.Room.Number}", $"Заїзд  {booking.CheckInDate.ToShortDateString()} скасоано");

        }

        public void Confirm(Booking booking)
        {
           
            throw new InvalidOperationException("Бронювання вже підтверджено.");
        }
    }
}

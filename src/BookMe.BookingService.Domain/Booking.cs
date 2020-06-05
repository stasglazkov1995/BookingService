using System;
using BookMe.BookingService.Domain.Abstractions;
using BookMe.BookingService.Domain.enumStatus;

namespace BookMe.BookingService.Domain
{
    public class Booking : Entity
    {
        public Guid EventId { get; set; }

        public Event Event { get; set; }

        public Guid CustomerId { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public DateTime BookingDate { get; set; }
    
        protected Booking()
        {

        }
     
        public Booking(Guid customerId, Event _event, DateTime bookingDate)
        {
            Event = _event;
            EventId = _event.Id;
            CustomerId = customerId;
            BookingDate = bookingDate;
            BookingStatus = BookingStatus.Placed;
        }

        public void ApproveBooking(BookingStatus bookingStatus)
        {
            #region CheckBookingStatus
            switch (bookingStatus)
            {
                case (BookingStatus.Placed):

                    BookingStatus = BookingStatus.Approved;
                    break;

                case (BookingStatus.Approved):
                    throw new Exception($"Booking was approved yet");

                case (BookingStatus.Rejected):
                    throw new Exception($"Booking was reject");

                case (BookingStatus.Canceled):
                    throw new Exception($"Booking  was canceled");
            }
            #endregion
        }

        public void RejectedBooking()
        {
            BookingStatus = BookingStatus.Rejected;
        }

        public void CanceledBooking()
        {
            BookingStatus = BookingStatus.Canceled;
        }
    }
}

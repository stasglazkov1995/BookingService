namespace BookMe.BookingService.Application.Commands.Abstractions
{
    public interface IValidatabe
    {
        bool IsValid();

        void Validate();
    }
}

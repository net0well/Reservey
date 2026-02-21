using Application.Guest.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Exceptions;
using Domain.Ports;
namespace Application
{
    public class GuestManager : IGuestManager
    {
        private readonly IGuestRepository _guestRepository;
        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);

                await guest.Save(_guestRepository);

                request.Data.Id = guest.Id;

                return new GuestResponse
                {
                    Data = request.Data,
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                var errorCode = ex switch
                {
                    InvalidEmailException => ErrorCodes.INVALID_EMAIL_ADDRESS,
                    InvalidPersonDocumentIdException => ErrorCodes.INVALID_PERSON_ID,
                    MissingRequiredInformation => ErrorCodes.MISSING_REQUIRED_INFORMATION,
                    _ => ErrorCodes.COULD_NOT_STORE_DATA
                };

                return new GuestResponse
                {
                    IsSuccess = false,
                    ErrorCode = errorCode,
                    Message = ex.Message
                };
            }
        }
    }
}

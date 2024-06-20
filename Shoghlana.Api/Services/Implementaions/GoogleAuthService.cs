//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.SignalR;
//using NuGet.Protocol.Core.Types;
//using Shoghlana.Api.Hubs;
//using Shoghlana.Api.Response;
//using Shoghlana.Api.Services.Implementations;
//using Shoghlana.Api.Services.Interfaces;
//using Shoghlana.Core.DTO;
//using Shoghlana.Core.Interfaces;
//using Shoghlana.Core.Models;

//namespace Shoghlana.Api.Services.Implementaions
//{
//    public class GoogleAuthService : IGoogleAuthService
//    {
//        private readonly IUnitOfWork unitOfWork;
//        private readonly IFreelancerService freelancerService;
//        private readonly IHubContext<NotificationHub> _hubContext;

//        public GoogleAuthService(IUnitOfWork unitOfWork, IFreelancerService freelancerService, IHubContext<NotificationHub> hubContext)
//        {
//            this.unitOfWork = unitOfWork;
//            this.freelancerService = freelancerService;
//            this._hubContext = hubContext;
//        }

//        public async Task<ApplicationUser> GetByIdAsync(string id) 
//        {
//            return await unitOfWork.ApplicationUserRepository.GetByIdAsync(id);
//        }


//        public async Task<ApplicationUser> GetByEmailAsync(string email) 
//        {
//            return await unitOfWork.ApplicationUserRepository.GetByEmailAsync(email);
//        }


//        public async Task<GeneralResponse> RegisterAsync(GoogleSignupDto googleSignupDto) 
//        {
//          ApplicationUser? User = await unitOfWork.ApplicationUserRepository.GetByEmailAsync(googleSignupDto.email);
//            if(User == null)
//            {
//                //// apply login logic here
//                //return await Task.FromResult(new GeneralResponse()
//                //{
//                //    IsSuccess = false,
//                //    Data = null,
//                //    Message = "This email has already been registered before"
//                //});


//                Freelancer freelancer = new Freelancer()  // consider it is a freelancer for testing
//                {
//                    Name = googleSignupDto.firstName
//                    // convert img from string to bytes and save it in freelancer
//                };

//                try
//                {
//                    freelancerService.Add(freelancer);   // add + save inside the same method
//                }
//                catch (Exception ex)
//                {
//                    return new GeneralResponse()
//                    {
//                        IsSuccess = false,
//                        Data = null,
//                        Message = ex.Message
//                    };
//                }

//                User = new ApplicationUser()
//                {
//                    UserName = googleSignupDto.firstName,     // should add guid as suffix as gmail allow username duplication but identity user doesnot
//                    Email = googleSignupDto.email,
//                    FreeLancerId = freelancer.Id,
//                    EmailConfirmed = true                      // as he registered using gmail
//                };

//                try
//                {
//                    await unitOfWork.ApplicationUserRepository.InsertAsync(User);
//                }
//                catch(Exception ex)
//                {
//                    return await Task.FromResult(new GeneralResponse()
//                    {
//                        IsSuccess = false,
//                        Data = ex.Message,
//                        Message = "Error on account creation"
//                    });
//                }

//                try
//                {
//                   await SendWelcomeNotificationAsync(User);
//                }
//                catch(Exception ex)
//                {
//                    return new GeneralResponse()
//                    {
//                        IsSuccess = false,
//                        Data = ex.Message,
//                        Message = "Error on sending welcome notification"
//                    };
//                }

//            }

//            // logic for login




//        }




//        private async Task SendWelcomeNotificationAsync(ApplicationUser user)
//        {
//            var notification = new NotificationDTO
//            {
//                Title = "Welcome to Shoglana!",
//                description = $"Welcome, {user.UserName}! Thank you for joining us.",
//                sentTime = DateTime.Now,
//                // You can include the user's image in the notification if available

//            };

//            await _hubContext.Clients.User(user.Id).SendAsync("ReceiveNotification", notification);
//        }
//    }
//}

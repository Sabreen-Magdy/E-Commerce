using Contract;
using Domain.Entities;
using Domain.Entities.Other;
using Domain.Enums;
using Domain.Exceptions;
using Domain.External;
using Services.Abstraction;
using Services.Abstraction.External;
using Services.Extenstions;
using System.Security.Cryptography;

namespace Persistence.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IExternalRepository _repository;
        private readonly IAdminService _adminService;

        public AuthenticationService(IExternalRepository repository,
            IAdminService adminService)
        {
            _repository = repository;
            _adminService = adminService;
        }
        private string GenerateOtp() =>
            RandomNumberGenerator.GetHexString(6);
        public async Task ChangePassword(ChangePasswordDto passwordDto)
        {
            var customer = _adminService.CustomerService.Get(passwordDto.Id);
            if (customer == null)
                throw new NotFoundException("Cusromer");
            else
            {
                await _repository.AuthenticationRepository
                            .ChangePassword(customer.UserId,
                             passwordDto.NewPassword, passwordDto.OldPassword);
            }
        }
        public async Task RestPassword(ForgetPasswordDto passwordDto)
        {
            var customer = _adminService.CustomerService.GetAll().Find(c => c.Email== passwordDto.Email );
            if (customer == null)
                throw new NotFoundException("Cusromer");
            else
            {
                await _repository.AuthenticationRepository
                            .RestPassword(passwordDto.OTP, passwordDto.Token,
                                customer.UserId, passwordDto.NewPassword);
            }
        }
        public async Task<OtpToken> RestPassword(string email)
        {
            string otp = GenerateOtp();
            var token = await _repository.AuthenticationRepository
                        .RestPassword(email, otp);
            return new(token, otp);
        }
        public async Task DeleteCustomer(int customerId)
        {
            var customer = _adminService.CustomerService.Get(customerId);
            if (customer == null)
                throw new NotFoundException("Customer");
                 await _repository.AuthenticationRepository.Remove(customer.UserId);

            _adminService.CustomerService.Delete(customerId);
          
        }
        public async Task<User> Login(LoginDto login)
        {
            var user = await _repository.AuthenticationRepository.Login(login.Email, login.Password);
            if (user.Role.Contains(UserRole.Saller.ToString()))
                user.Id = _adminService.SallerService.GetByEmail(login.Email)!.Id;
            else

                user.Id = _adminService.CustomerService.GetByEmail(login.Email)!.Id;
            return user;
        }
        public async Task<User> Register(CustomerAddDto customer)
        {
            var customerEntity = customer.ToCustomerEntity();

          
        var user = await _repository.AuthenticationRepository
            .Register(customerEntity, customer.Password);

            try
            {

                _adminService.CustomerService.Add(customerEntity);

                user.Id = customerEntity.Id;

                return user;
            }
            catch(Exception ex)
            {
                await _repository.AuthenticationRepository.Remove(customerEntity.UserId);
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> CanRegister(string email) =>
            await _repository.AuthenticationRepository.CanRegister(email);
    }
}

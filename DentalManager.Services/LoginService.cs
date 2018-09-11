namespace DentalManager.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using DentalManager.Common.Constants;
    using DentalManager.Services.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;

    public class LoginService : ILoginService
    {
        private readonly UserManager<IdentityUser> userManager;

        public LoginService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await this.userManager.FindByEmailAsync(username);
            if (user == null)
            {
                throw new ArgumentException(nameof(username));
            }

            if (!await this.userManager.CheckPasswordAsync(user, password))
            {
                throw new ArgumentException(nameof(password));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtContansts.SECRET);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Issuer = JwtContansts.ISSUER,
                Audience = JwtContansts.AUDIENCE,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}

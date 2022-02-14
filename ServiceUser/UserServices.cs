using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NCPHARMACY.Models;
using NCPHARMACY.Models.Auth;
using NCPHARMACY.Models.Common;
using NCPHARMACY.Models.Response;
using NCPHARMACY.Tools;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NCPHARMACY.ServiceUser
{
    public class UserServices : IUserServices
    {
        private readonly AppSettings _appsettings;

        public UserServices(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();
            using (var db = new NCPHARMACYContext())
            {
                string spasword = Encrypt.GetSHA256(model.Password);

                var usuario = db.Usuarios.Where(d => d.Nombre == model.Nombre &&
                d.Contraseña== spasword).FirstOrDefault();
                if (usuario == null) return null;

                userResponse.Email = usuario.Nombre;
                userResponse.Token = GetToken(usuario);

            }

            return userResponse;


        }
        private string GetToken(Usuario usuario)
        {
            var tokenHadler = new JwtSecurityTokenHandler();
            var LLave = Encoding.ASCII.GetBytes(_appsettings.Secreto);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Nombre.ToString())

                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(LLave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHadler.CreateToken(TokenDescriptor);
            return tokenHadler.WriteToken(token);
        }
    }
}

using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accesTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
        }
        public AccesToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
			_accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
			var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt=CreateJwtSecurityToken(_tokenOptions,user,signingCredentials,operationClaims);
            var jwtHandler = new JwtSecurityTokenHandler();
            var token=jwtHandler.WriteToken(jwt);
            return new AccesToken
            {
                Token = token,
                ExpirationDate=_accesTokenExpiration
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accesTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;



        }
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> claims)
        {
            var claimsList = new List<Claim>();
            claimsList.AddNameIdentifier(user.UserId.ToString());
            claimsList.AddName($"{user.FirstName} {user.LastName}");
            claimsList.AddEmail(user.Email);
            claimsList.AddRoles(claims.Select(c=>c.Name).ToArray());
            return claimsList;
            

        }
    }

}



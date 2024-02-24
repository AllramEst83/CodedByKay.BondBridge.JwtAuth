using CodedByKay.BondBridge.JwtAuth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CodedByKay.BondBridge.JwtAuth
{
    public static class JwtAuthExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, string secretKey, string issuer, string audience)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.ClaimsIssuer = issuer;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
            {
                //Add more roles here to handel diffrent type of users: admin, user, editUser
                options.AddPolicy(
                    TokenValidationConstants.Policies.AuthAPIAdmin,
                    policy => policy.RequireClaim(
                        TokenValidationConstants.Roles.Role,
                        TokenValidationConstants.Roles.AdminAccess));

                options.AddPolicy(
                    TokenValidationConstants.Policies.AuthAPICommonUser,
                    policy => policy.RequireClaim(
                        TokenValidationConstants.Roles.Role,
                        TokenValidationConstants.Roles.CommonUserAccess));

                options.AddPolicy(
                TokenValidationConstants.Policies.AuthAPIEditUser,
                policy => policy.RequireClaim(
                    TokenValidationConstants.Roles.Role,
                    TokenValidationConstants.Roles.EditUserAccess));
            });

            return services;
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Project_ASP.Net_And_Angular.Helper;

public class Startup
{


    public void ConfigureServices(IServiceCollection services)
    {
        // ...

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

        // ...
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ...

        app.UseAuthentication();
        app.UseAuthorization();

        // ...
    }
}

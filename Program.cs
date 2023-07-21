using Microsoft.EntityFrameworkCore;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;

var builder = WebApplication.CreateBuilder(args);
var stringConnect = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<DatabaseContext>(option =>option.UseLazyLoadingProxies().UseSqlServer(stringConnect));
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddScoped<ICompanyDetail,CompanyDetailImpl>();
builder.Services.AddScoped<IPolicy, PolicyImpl>();
builder.Services.AddScoped<IEmpRegister,EmpRegisterImpl>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
app.Run();




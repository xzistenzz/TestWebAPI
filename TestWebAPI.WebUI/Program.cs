using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using System.Reflection;
using TestWebAPI.Application.Services;
using TestWebAPI.Persistance.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddApplicationService();
builder.Services.AddMSSQL(builder.Configuration["ConnectionString:MSSQL"]!);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(configuration =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    configuration.IncludeXmlComments(filePath);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAuthorization();
#endregion

var app = builder.Build();

#region Middleware
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");
#endregion

app.Run();
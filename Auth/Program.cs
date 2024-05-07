using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Auth.Authorisation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();



// Add authentication services
builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", config =>
    {
        config.Cookie.Name = "MyCookieAuth";
        config.LoginPath = "/account/login";
        config.AccessDeniedPath = "/account/AccessDenied";
    });

builder.Services.AddAuthorization( options => {
    options.AddPolicy("MustBeAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("MustBelongToHR", policy => policy.RequireClaim(ClaimTypes.Role, "HR"));
    options.AddPolicy("HRManager", policy => policy.RequireClaim(ClaimTypes.Role, "HR").RequireClaim(ClaimTypes.Role, "Manager").AddRequirements(new HRManagerProbationRequirement(3)));

});

builder.Services.AddSingleton<IAuthorizationHandler, HRManagerProbationRequirement.HRManagerProbationRequirementHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

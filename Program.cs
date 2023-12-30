using FluentValidation.AspNetCore;
using LibraryProject.Context;
using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Concrete;
using LibraryProject.RepositoryPattern.Interfaces;
using LibraryProject.RepositoryPattern.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration["ConnectionStrings:MsSQL"]));
builder.Services.AddControllersWithViews().AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<Program>());
//generic and concrete repository pattern
//builder.Services.AddScoped<IRepository<BookTypes>, Repository<BookTypes>>();
//builder.Services.AddScoped<IRepository<Authors>, Repository<Authors>>(); 
builder.Services.AddScoped<IBookRepository, BookRepository>();  
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookTypeRepository, BookTypeRepository>();
builder.Services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();

//cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/Auth/LogIn";
        options.Cookie.Name = "UserDetail";
        options.AccessDeniedPath = "/Auth/LogIn"; 
    });

builder.Services.AddAuthorization(options => {
    //following line creates a new policy for admin role, in controller when I use this policy only admin will have access to this controller on web
    options.AddPolicy("AdminPolicy", policy=>policy.RequireClaim("role", "admin"));

    //following line creates a new policy for both user and admin role, in controller when I use this policy both type of user will have access to this controller on web
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("role", "admin", "user"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//this is for being able used the static files inside wwwroot
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
//for Authorization annotation and its functionalities 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=LogIn}/{id?}"
	);

app.Run();

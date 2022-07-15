using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.CustomMiddleware;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;
using TechBuddy.Middlewares.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataAccessLayer.ApiDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>

{ //Authorization i�lemi yapabilmek i�in buton ekliyoruz ve do�rulama i�in gereken alanlar� ekliyoruz.

    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "CEMSAHIN", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//Kulland���m interface'lerden �retti�im s�n�flar� tan�ml�yorum.
builder.Services.AddSingleton<IMoviesService, MoviesManager>();
builder.Services.AddSingleton<IGenresService, GenresManager>();
builder.Services.AddSingleton<IListService, ListManager>();
builder.Services.AddSingleton<IMoviesRepository, MoviesRepository>();
builder.Services.AddSingleton<IGenresRepository, GenresRepository>();
builder.Services.AddSingleton<IListRepository,ListRepository>();
builder.Services.AddSingleton<IRedisHelper, RedisHelper>();
var key = Encoding.ASCII.GetBytes(builder.Configuration["Application:JWTSecret"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  


}).AddJwtBearer(x =>
{
   
    x.Audience = "ARVATO";
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.ClaimsIssuer = "ARVATO.Issuer.Development";
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

//Custom bir exception handling middleware'i olu�turup al�nacak hatalara kar�� nas�l bir mesaj d�nece�imizi ve hangi hatalara kar�� d�nece�imizi yaz�yoruz.Handle edilmeyen hatalar� yakalayacakt�r.Bu bize hatalar� merkezi bir yerden yakalamak konusunda yard�mc� olacakt�r.O y�zden try catch metodu ile bir yakalama i�lemi yapm�yorum.
app.AddTBExceptionHandlingMiddleware(opt=>
{
    opt.DefaultHttpStatusCode = HttpStatusCode.NotFound;
    opt.ContentType = "application/json";
    opt.DefaultMessage = "My Custom middleware default message";
    opt.ExceptionTypeList.Add<Exception>();
    opt.ExceptionTypeList.Add<ArgumentNullException>();
    opt.ExceptionTypeList.Add<NullReferenceException>();
    opt.ExceptionTypeList.Add<SecurityTokenCompressionFailedException>();
    opt.UseResponseModelCreator<CustomExceptionHandlingCreator>();
});
app.MapControllers();
app.Run();

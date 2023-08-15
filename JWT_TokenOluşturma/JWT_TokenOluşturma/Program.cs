using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
    (options =>
    {
        options.TokenValidationParameters = new
        Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true, //izin verilecek sitelerin denetlemesi
            ValidateIssuer = true, //hangi sitelerin izin verileceðinin denetimi
            ValidateLifetime = true, //Yaþam kontrolü
            ValidateIssuerSigningKey = true, //tokenin bize ait olup olmadýðýný anlarýz
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (builder.Configuration["Token:SecurityKey"])),
            ClockSkew = TimeSpan.Zero //Token üzerine ekstra süre eklenip eklenmeme durumunu gösterir.
        };


    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapControllers();

app.Run();

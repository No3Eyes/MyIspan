using Microsoft.EntityFrameworkCore;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string ProconString = builder.Configuration.GetConnectionString("SweetMouth");
builder.Services.AddDbContext<SweetMouthContext>(a => a.UseSqlServer(ProconString));

builder.Services.AddControllers();

var MyAllowSpecificOrigins = "AllowAny";    //�������}�������W��(���F¶�LCOR����)
builder.Services.AddCors(x =>
{
    x.AddPolicy(                            //�s�W�v��(�ѼƦ�name�Mpolicy)
        name: MyAllowSpecificOrigins,
        policy => policy.WithOrigins("https://localhost:7146", "https://localhost:7101").WithHeaders("*").WithMethods("*")
        );              //�ӷ��O��API��X�����}�A�p�G�n�����}�N��*�N�n�A�n���wHeaders��Methods���ܤ]�O
});


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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.mocks;
using WebAPITask_1.Data.Models;
using WebAPITask_1.Data;
using WebAPITask_1.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Newtonsoft;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("dbSettings.json")
    .AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IAllStudents, StudentRepository>();
builder.Services.AddTransient<IStudentGroup, GroupRepository>();
builder.Services.AddTransient<IMainCRUD<Main>, MockMainCRUD>();
builder.Services.AddDbContext<AppDBContent>(op => op.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());
});
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
//builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseCors("MyPolicy");

//app cors
//app.UseRouting();
//app.UseCors(options => options.AllowAnyOrigin());

DBObjects.Initial(app);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
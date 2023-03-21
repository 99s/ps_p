using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PS_Portal_Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//costom code start ---
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<FormOptions>(x =>
{
    x.MultipartBodyLengthLimit = Int64.MaxValue;
    x.MultipartHeadersLengthLimit = int.MaxValue;
    x.ValueLengthLimit = int.MaxValue;
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = Int64.MaxValue;

});

builder.Services.AddScoped<SessionManager>();

builder.Services.AddDbContext<psportal_dbContext>(options => options
 //.UseLazyLoadingProxies(false)
 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
 .UseSqlServer("Server=H0ME_IG;Database=psportal_db;Trusted_Connection=True;"));

//costom code end ---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//custom code start
//var configuration = new MapperConfiguration(cfg =>
//{
//    cfg.CreateMap<ReplyTbl, ReplyTblResponse>();
//    cfg.CreateMap<ActionTbl, ActionTblResponse>();
//});
//// only during development, validate your mappings; remove it before release
//#if DEBUG
//try
//{
//    configuration.AssertConfigurationIsValid();
//}
//catch(Exception e)
//{
//    Console.WriteLine(e.Message);
//    throw;
//}
//#endif
//// use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
//var mapper = configuration.CreateMapper();
//custom code end--------

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

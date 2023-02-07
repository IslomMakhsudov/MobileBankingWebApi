using MobileBankingWebApi.Middleware;
using MobileBankingWebApi.Modules.Payment.Services;
using MobileBankingWebApi.Modules.Terminal.Services;
using MobileBankingWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc()
    .AddXmlSerializerFormatters()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<ITerminalService, TerminalService>();
builder.Services.AddTransient<Decrypter>();
builder.Services.AddSingleton<StaticData>();
var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
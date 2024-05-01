using AutoMapper;
using MeuProjetoMinimalAPI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
        options.SerializerSettings.DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset;
        options.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
    });

builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

app.MapPost("/", (IMapper mapper, [FromBody] Root rootObject) =>
{

    string dateValue = rootObject.d.results.FirstOrDefault()?.BonusStatement?.results.FirstOrDefault()?.Date.ToString();
    DateTime? date = null;

    if (!string.IsNullOrEmpty(dateValue))
    {
        // "/Date(numero)/"
        long milliseconds;
        if (long.TryParse(Regex.Match(dateValue, @"\d+").Value, out milliseconds))
        {
            date = UnixTimeStampToDateTime(milliseconds / 1000);
        }
    }


    var clienteModel = mapper.Map<ClienteDTO>(rootObject.d.results.FirstOrDefault());
    return clienteModel;
});

static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
{
    DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    return unixEpoch.AddSeconds(unixTimeStamp).ToLocalTime();
}
app.Run();





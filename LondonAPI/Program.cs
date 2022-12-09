using LondonAPI;
using LondonAPI.Filters;
using LondonAPI.Models;
using LondonAPI.Utilities;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// for adding action filters
builder.Services.AddMvc(options =>
{
    options.Filters.Add<JsonExceptionFilter>();
    options.Filters.Add<RequireHttpsOrCloseAttribute>();

});

builder.Services.Configure<HotelInfo>(builder.Configuration.GetSection("Info"));

builder.Services.AddDbContext<HotelApiDbContext>(options => options.UseInMemoryDatabase("LondonHotelDb"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//for APi versioning by using the default version but as supplied to as media type this version might change accordigly 


builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);

    options.ApiVersionReader = new MediaTypeApiVersionReader();
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
});
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowMyPolicy",
    policy => policy.AllowAnyOrigin()
    );
    //policy => policy.WithOrigins("exapmle.com"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{// for live do not use localhost etc
    app.UseHsts();
}
//instead of redirecting to enhance transport level security stop http request

//app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowMyPolicy");

try
{
    SeedData.InitializeDataAsync(builder.Services.BuildServiceProvider());
}
catch (Exception ex)
{
    //Logger logger;
    //logger.LogInformation(ex);
    
    throw ex;
}

app.Run();

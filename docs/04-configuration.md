# How to get data from a configuration file
In this session we learn how to store data in a configuration file and how to get hold of these data in the different layers without adding strong dependencis.

### Configure swagger title
The main title in your api documentation should be configurable. 

Add config in appsetting.json
```C#
  "OpenApi": {
    "Title" :  "My Weather api"
  }
```
Send ConfigurationManager as an parameter into your api documentation class.
```C#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi(builder.Configuration);
```
Read title from configuration file
```C#
public static void AddOpenApi(this IServiceCollection services, IConfiguration configuration)
{
    var title = configuration.GetSection("OpenApi")["Title"];
    .....
```  
Use title variable instead of hardcoded string when you set title in swagger

### Configure connection string to your database
Make the connection to database configurable and avoid dependencies between each layer.

Set your connection string in your appseteting.json
```C#
"ConnectionStrings": {
  "WeatherDb": "Data source=weather.db"
}
```
In your database access layer you need to use ConfigurationBuilder to read your config file.
To esealy read config from json file add two nuget packages
```XML
<PackageReference Include="Microsoft.Extensions.Configuration" Version="5.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="5.0.0" />
```
Get connection string and use it when you set up your DbContext
```C#
public static void AddDataAccess(this IServiceCollection services)
{
    services.AddDbContext<WeatherDbContext>(options => options.UseSqlite(GetConnectionString()));

    services.AddTransient<IWeatherRepository, WeatherRepository>();
}

private static string GetConnectionString()
{
    var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    return builder.GetConnectionString("WeatherDb");
}
```
        

# Introducing service layer and dependency injection
In this session we start hammering into the application architecture and we introduce a service layer.
The purpose is to have a clean api layer that is responsible only for exposing endpoints and api doucmentation.
The service layer will be responsible for the business logic.

We also introduce dependency injection to have loosly copled layers, easy to change an implementation and manage futured changes.

### Create service layer
- Right click solution folder and Add New Project
- Select class library, click Next
- Fill in project name, click Next
- Click Create

### Add interface
In the service layer add an interface and add this contract
```C#
public List<WeatherModel> WeatherForcast(int days);
```

### Add implementation
Add a new class that inherit from the interface and implement contract
```C#
public List<WeatherModel> WeatherForcast(int days)
{
    throw new NotImplementedException("service layer not implemented");
}
```
### Connect api layer and service layer by using constructor injection
Add reference from api layer to the service layer into you project file
```XML
<ProjectReference Include="..\Forte.Weather.Services\Forte.Weather.Services.csproj" />
```
In the pipeline (Program.cs) you need to wire up this injection
```C#
services.AddTransient<IWeatherService, WeatherService>();
```
Use constructor injection in controller
```C#
private readonly IWeatherService _weatherService;

public WeatherController(IWeatherService weatherService)
{
    _weatherService = weatherService;
}
```
Copy the code from your Get method and put it in your clipboard.
Replace this code with a service call to WeatherForcast.
```C#
[HttpGet]
public IEnumerable<WeatherModel> Get()
{
    return _weatherService.WeatherForcast(5);
}
```
Now you should try to build and run your solutioin and if your api call is returning "service layer not implemented" you know that your injection is working correctley.

### Place the forecast generation into service
Paste code from clipboard into WeatherForecast method. 
Build and run to verify that it's work correctley

### Refactor
- Place Summary into an data class (Creator)
- Place injection into a service installer
- Improve code

Next up - [Introduce data access layer and use of database](03-data-access-layer.md)

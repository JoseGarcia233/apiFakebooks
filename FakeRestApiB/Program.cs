using FakeRestApiB;

var builder = WebApplication.CreateBuilder(args);


var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:44394/");
        });
});

builder.Services.AddCors();

var app = builder.Build();

startup.Configure(app, app.Environment);    

app.Run();

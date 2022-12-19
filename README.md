Follow these steps;

1. Go to your appsettings.json and add "Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware": "Information"
2. Go to your program.cs and configure logging options according to your needs, for example;

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
    HttpLoggingFields.ResponsePropertiesAndHeaders |
    HttpLoggingFields.ResponseStatusCode |
    HttpLoggingFields.RequestQuery |
    HttpLoggingFields.RequestBody;
});

3. Next if you want to log all api calls then setup middleware app.UseHttpLogging(); Or if you want to exclude a controller(api) then setup middleware like;

app.UseWhen(
    context => !context.Request.Path.StartsWithSegments("/Sensitive"), //SensitiveController.cs
    builder => builder.UseHttpLogging());

I hope this helps you. All the best!! :)
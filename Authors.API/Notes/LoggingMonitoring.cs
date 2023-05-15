/*

var builder = webApplication.CreateBuilder(args);
will create default logger as belowe

    .ConfigureLogging((hostingContext, loggingBuilder) =>
            {
                loggingBuilder.Configure(options =>
                {
                    options.ActivityTrackingOptions = ActivityTrackingOptions.SpanId
                                                        | ActivityTrackingOptions.TraceId
                                                        | ActivityTrackingOptions.ParentId;
                });
                loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
                loggingBuilder.AddEventSourceLogger();
            }).


Log levals
Log categories
Filtering log entries

Why logging?
    support and analysis
    easy to find an issue
    provilde all information
    Dont leak sensitive data
    too much log will lead rto cost 

Log levals
    -   Trace (lot of data log, so can contain sencitive data , no production)
    -   Debug (common leval)
    -   Information 
    -   Warning
    -   Errpr
    -   Critical

Log filter from appSetting.json
    
"Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information",
      "ProjectName.Doamin" : "Debug" // will show all debug message from doamin namesapce
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }


same thing can achive from LaunSetting.json in "env" section
    "env" : {
        Logging__LogLeval__ProjectName.Api.Controller : "Debug"
    }


desitnation -> where to write a log (Console or Debug and many more)

    advance logging
    
    "Logging": {
        "Console" : {
            "LogLevel": {
              "Default": "Information",
              "Microsoft": "Warning",
              "Microsoft.Hosting.Lifetime": "Information",
              "ProjectName.Doamin" : "Debug" // will show all debug message from doamin namesapce
              "Microsoft.EntityFrameworkCore.Database.Command": "Information"
                }
            },
        "Debug": {
            "LogLevel": {
              "Default": "Information",
              "Microsoft.EntityFrameworkCore": "Debug",
            }
        }
    }

Add logging config from code
    builder.Logging.AddFilter("ProjectName.Api", LogLeval.Debug);

ExceptionHamdling
    app.UseExceptionHnadler("/Error");
    and
    in appsetting.json > DetailedErrors :  true , that reason we see stack trace in exception page
*/ 
﻿using System.Diagnostics;
using System.Text;
using SisMedico.Mvc.Extensions.Filters;
using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.RequestLogsListener;

namespace SisMedico.Mvc.Configuration;

public static class KissLogConfig
{
    public static void AddLoggerConfig(this IServiceCollection services)
    {

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<AuditoriaIloggerFilter>();

        services.AddScoped<IKLogger>((context) =>
        {
            return Logger.Factory.Get();
        });

        services.AddLogging(logging =>
        {
            logging.AddKissLog();
        });
    }

    public static void AddLoggerConfig(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseKissLogMiddleware(options =>
        {
            ConfigureKissLog(options, configuration);
        });
    }

    private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
    {
        options.Options
            .AppendExceptionDetails((Exception ex) =>
            {
                StringBuilder sb = new StringBuilder();

                if (ex is System.NullReferenceException nullRefException)
                {
                    sb.AppendLine("Important: check for null references");
                }

                return sb.ToString();
            });

        // KissLog internal logs
        options.InternalLog = (message) =>
        {
            Debug.WriteLine(message);
        };

        // register logs output
        RegisterKissLogListeners(options, configuration);
    }

    private static void RegisterKissLogListeners(IOptionsBuilder options, IConfiguration configuration)
    {
        // multiple listeners can be registered using options.Listeners.Add() method
        options.Listeners.Add(new RequestLogsApiListener(new KissLog.CloudListeners.Auth.Application(
                                                        configuration["KissLog.OrganizationId"],
                                                        configuration["KissLog.ApplicationId"])
        )
        {
            ApiUrl = configuration["KissLog.ApiUrl"]
        });
    }
}

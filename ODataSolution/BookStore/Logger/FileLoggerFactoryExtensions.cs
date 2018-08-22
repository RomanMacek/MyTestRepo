using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Options;

namespace BookStore.Logger
{
    //public static class FileLoggerFactoryExtensions
    //{
    //    public static ILoggingBuilder AddFile(this ILoggingBuilder builder)
    //    {
    //        builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();
    //        return builder;
    //    }

    //    public static ILoggingBuilder AddFile(this ILoggingBuilder builder, Action<FileLoggerOptions> configure)
    //    {
    //        builder.AddFile();
    //        builder.Services.Configure(configure);

    //        return builder;
    //    }
    //}

    //public class FileLoggerOptions
    //{
    //    public string FileName { get; set; }
    //    public int FileSizeLimit { get; set; }
    //}
}
﻿using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Extension
{
    public static class DbInstaller
    {
        public static IServiceCollection InstallDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = $"Server = ;Port = ;Database = ;Uid = ; Pwd = ; ";
            services.AddDbContext<TempContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            return services;
        }
    }
}

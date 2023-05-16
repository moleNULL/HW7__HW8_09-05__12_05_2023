﻿using Microsoft.EntityFrameworkCore;

namespace HomeAccounting
{
    internal static class ConfigurationHelper
    {
        public static string? GetConnectionString()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                .Build()
                .GetConnectionString("DbConnection");
        }
    }
}

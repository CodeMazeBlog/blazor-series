﻿using BlazorProducts.Server.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazorProducts.Server.MigrationManager;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<ProductContext>();

        try
        {
            appContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            //Log errors or do anything you think it's needed
            throw;
        }

        return host;
    }
}
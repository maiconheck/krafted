using System;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using Microsoft.AspNetCore.Builder;
using static System.Console;

namespace Krafted.Infrastructure.IntegrationTest.Migration
{
    internal static class KraftedInfrastructureDataBase
    {
        public static void UseMigration(this IApplicationBuilder app, string connectionString)
        {
            DropDatabase.For.SqlDatabase(connectionString);
            EnsureDatabase.For.SqlDatabase(connectionString);

            UpgradeEngine upgrader = DeployChanges.To
                                .SqlDatabase(connectionString)
                                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                                .LogToConsole()
                                .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            ShowMessage(result);
        }

        private static void ShowMessage(DatabaseUpgradeResult result)
        {
            if (result.Successful)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Success!");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Error!");
                WriteLine(result.Error);
            }

            ResetColor();
        }
    }
}
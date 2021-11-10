﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocialNetwork.core.players.domain;
using SocialNetwork.infrastructure;
using System;

namespace SocialNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SocialNetworkDbContext>();
                    if (!context.Database.EnsureCreated())
                        DbInit(context); // Para teste

                    Console.WriteLine(context.Players.Find((long)1)); // Para teste
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        public static void DbInit(SocialNetworkDbContext context)
        {
            Player playerA = new Player(Email.ValueOf("1190948@isep.ipp.opt"), PhoneNumber.ValueOf("911111111"), DateOfBirth.ValueOf(1994, 10, 2),
                Name.ValueOf("Pedro Vieira", "Pedro F S Vieira"));

            context.Players.Add(playerA);
            context.SaveChanges();
        }
    }
}



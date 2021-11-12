﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.posts.domain.post;
using SocialNetwork.core.model.shared;
using SocialNetwork.infrastructure;
using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;

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
                    context.Database.EnsureCreated();
                    // DbInit(context); // Para teste
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
            Player playerA = new Player(Email.ValueOf("1019456@isep.ipp.pt"), PhoneNumber.ValueOf("912345678"),
                DateOfBirth.ValueOf(1994, 10, 2));
            playerA.SetNameTo(Name.ValueOf("Zé Manuel", "Zé Sá Pinto Manuel"));

            List<Tag> tags = new List<Tag>();
            tags.Add(Tag.ValueOf("tag1"));
            tags.Add(Tag.ValueOf("tag2"));
            Post post = new Post(TextBox.ValueOf("abc"), playerA, tags);
            context.Posts.Add(post);

            context.Players.Add(playerA);
            /*ConnectionRequest connectionRequest =
                new ConnectionRequest(new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold), playerA, playerA, new TextBox("ola"));
            context.ConnectionRequests.Add(connectionRequest);*/

            IntroductionRequest introductionRequest = new IntroductionRequest(
                new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold),
                playerA, playerA, new TextBox("ola"), new TextBox("ola1"), playerA,
                new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold));
            context.IntroductionRequests.Add(introductionRequest);
            context.SaveChanges();
        }
    }
}
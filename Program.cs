using Microsoft.AspNetCore;
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
using SocialNetwork.core.model.relationships.domain;

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
            Player playerA = new Player(Email.ValueOf(
                    String.Format("123456789@isep.ipp.pt", new Guid())), PhoneNumber.ValueOf("912345678"),
                DateOfBirth.ValueOf(1994, 10, 2));
            playerA.SetNameTo(Name.ValueOf("Zé", "Zé Miguel"));

            List<Tag> tags = new List<Tag>();
            tags.Add(Tag.ValueOf("tag1"));
            tags.Add(Tag.ValueOf("tag2"));
            Post post = new Post(TextBox.ValueOf("text box test"), playerA, tags);
            context.Posts.Add(post);

            context.Players.Add(playerA);
            /*ConnectionRequest connectionRequest =
                new ConnectionRequest(new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold), playerA, playerA, new TextBox("ola"));
            context.ConnectionRequests.Add(connectionRequest);*/

            Player playerB = new Player(Email.ValueOf(
                    String.Format("1200606@isep.ipp.pt", new Guid())), PhoneNumber.ValueOf("914391980"),
                DateOfBirth.ValueOf(1994, 10, 2));
            playerB.SetNameTo(Name.ValueOf("Antonio", "Antonio Barros"));
            context.Players.Add(playerB);
            Player playerC = new Player(Email.ValueOf(
                    String.Format("1200608@isep.ipp.pt", new Guid())), PhoneNumber.ValueOf("914391981"),
                DateOfBirth.ValueOf(1994, 10, 2));
            playerC.SetNameTo(Name.ValueOf("Daniel", "Daniel Reis"));
            context.Players.Add(playerC);

            IntroductionRequest introductionRequest = new IntroductionRequest(new ConnectionRequestStatus( ConnectionRequestStatusEnum.Approved), 
                playerA, playerB, new TextBox("ola"),new TextBox("ola1"),
                playerC,  new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold),new ConnectionStrenght(10),tags);




            context.IntroductionRequests.Add(introductionRequest);
            context.SaveChanges();
        }
    }
}
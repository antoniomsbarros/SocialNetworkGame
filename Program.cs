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
            playerA.ChangeName(Name.ValueOf("Zé", "Zé Miguel"));


            /*ConnectionRequest connectionRequest =
                new ConnectionRequest(new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold), playerA, playerA, new TextBox("ola"));
            context.ConnectionRequests.Add(connectionRequest);*/

            Player playerB = new Player(Email.ValueOf(
                    String.Format("1200606@isep.ipp.pt", new Guid())), PhoneNumber.ValueOf("914391980"),
                DateOfBirth.ValueOf(1994, 10, 2));
            playerB.ChangeName(Name.ValueOf("Antonio", "Antonio Barros"));
            Player playerC = new Player(Email.ValueOf(
                    String.Format("1200608@isep.ipp.pt", new Guid())), PhoneNumber.ValueOf("914391981"),
                DateOfBirth.ValueOf(1994, 10, 2));
            playerC.ChangeName(Name.ValueOf("Daniel", "Daniel Reis"));

            Player playerD = new Player(Email.ValueOf(String.Format("1100000@isep.ipp.pt", new Guid())), 
                PhoneNumber.ValueOf("910000000"), DateOfBirth.ValueOf(1994, 10, 2));
            playerD.ChangeName(Name.ValueOf("Player D", "Player D"));

            Player playerE = new Player(Email.ValueOf(String.Format("1100001@isep.ipp.pt", new Guid())),
                PhoneNumber.ValueOf("910000001"), DateOfBirth.ValueOf(1994, 10, 2));
            playerE.ChangeName(Name.ValueOf("Player E", "Player E"));


            playerA.TagsList.Add(Tag.ValueOf("tag1A"));
            playerD.TagsList.Add(Tag.ValueOf("tag1D"));

            context.Players.Add(playerA);
            context.Players.Add(playerB);
            context.Players.Add(playerC);
            context.Players.Add(playerD);
            context.Players.Add(playerE);
            context.SaveChanges();


            List<Tag> tags = new List<Tag>();
            tags.Add(Tag.ValueOf("tag1"));
            tags.Add(Tag.ValueOf("tag2"));
            Post post = new Post(TextBox.ValueOf("text box test"), playerA, tags);
            context.Posts.Add(post);
            context.SaveChanges();


           /* Relationship connectionAB = new Relationship(new PlayerId(playerB.Id.AsString()), new PlayerId(playerA.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "a1", "a2" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionBA = new Relationship(new PlayerId(playerA.Id.AsString()), new PlayerId(playerB.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "b1", "b2" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionBC = new Relationship(new PlayerId(playerC.Id.AsString()), new PlayerId(playerB.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "b1" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionCB = new Relationship(new PlayerId(playerB.Id.AsString()), new PlayerId(playerC.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "c3" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionCD = new Relationship(new PlayerId(playerD.Id.AsString()), new PlayerId(playerC.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "c1" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionDC = new Relationship(new PlayerId(playerC.Id.AsString()), new PlayerId(playerD.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "d2" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionCE = new Relationship(new PlayerId(playerE.Id.AsString()), new PlayerId(playerC.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "c2" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionEC = new Relationship(new PlayerId(playerC.Id.AsString()), new PlayerId(playerE.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "e1" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionAD = new Relationship(new PlayerId(playerD.Id.AsString()), new PlayerId(playerA.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "a3" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionDA = new Relationship(new PlayerId(playerA.Id.AsString()), new PlayerId(playerD.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "d1" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionBE = new Relationship(new PlayerId(playerE.Id.AsString()), new PlayerId(playerB.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "b2" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            Relationship connectionEB = new Relationship(new PlayerId(playerB.Id.AsString()), new PlayerId(playerE.Id.AsString()), ConnectionStrenght.ValueOf(10),new List<string> { "e2" }.ConvertAll<Tag>(l => Tag.ValueOf(l)));
            context.Relationships.Add(connectionAB);
            context.Relationships.Add(connectionBA);
            context.Relationships.Add(connectionBC);
            context.Relationships.Add(connectionCB);
            context.Relationships.Add(connectionCD);
            context.Relationships.Add(connectionDC);
            context.Relationships.Add(connectionCE);
            context.Relationships.Add(connectionEC);
            context.Relationships.Add(connectionAD);
            context.Relationships.Add(connectionDA);
            context.Relationships.Add(connectionBE);
            context.Relationships.Add(connectionEB);*/
            context.SaveChanges();


            
            IntroductionRequest introductionRequest = new IntroductionRequest(
                new ConnectionRequestStatus(ConnectionRequestStatusEnum.Approved),
                playerA.Id, playerB.Id, new TextBox("ola"), new TextBox("ola1"),
                playerC.Id, new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold), new ConnectionStrenght(10),
                tags);


            context.IntroductionRequests.Add(introductionRequest);
            context.SaveChanges();
            
        }
    }
}
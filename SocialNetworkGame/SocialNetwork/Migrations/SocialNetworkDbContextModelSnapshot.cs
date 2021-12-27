﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.infrastructure;

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(SocialNetworkDbContext))]
    partial class SocialNetworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlayerReceiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerSender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConnectionRequest");
                });

            modelBuilder.Entity("SocialNetwork.core.model.missions.domain.Mission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ObjectivePlayer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("SocialNetwork.core.model.players.domain.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.comment.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlayerCreator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.post.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlayerCreator")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.reaction.Reaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Player")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("SocialNetwork.core.model.relationships.domain.Relationship", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Relationship");
                });

            modelBuilder.Entity("SocialNetwork.core.model.systemUsers.domain.SystemUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("SystemUser");
                });

            modelBuilder.Entity("SocialNetwork.core.model.tags.domain.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("SocialNetwork.core.model.connectionRequests.domain.DirectRequest", b =>
                {
                    b.HasBaseType("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequest");

                    b.ToTable("DirectRequest");
                });

            modelBuilder.Entity("SocialNetwork.core.model.connectionRequests.domain.IntroductionRequest", b =>
                {
                    b.HasBaseType("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequest");

                    b.Property<string>("PlayerIntroduction")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("IntroductionRequest");
                });

            modelBuilder.Entity("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequest", b =>
                {
                    b.OwnsOne("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequestStatus", "ConnectionRequestStatus", b1 =>
                        {
                            b1.Property<string>("ConnectionRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("CurrentStatus")
                                .HasColumnType("int");

                            b1.HasKey("ConnectionRequestId");

                            b1.ToTable("ConnectionRequest");

                            b1.WithOwner()
                                .HasForeignKey("ConnectionRequestId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.relationships.domain.ConnectionStrength", "ConnectionStrengthConf", b1 =>
                        {
                            b1.Property<string>("ConnectionRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Strength")
                                .HasColumnType("int");

                            b1.HasKey("ConnectionRequestId");

                            b1.ToTable("ConnectionRequest");

                            b1.WithOwner()
                                .HasForeignKey("ConnectionRequestId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.shared.CreationDate", "CreationDate", b1 =>
                        {
                            b1.Property<string>("ConnectionRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("ConnectionRequestId");

                            b1.ToTable("ConnectionRequest");

                            b1.WithOwner()
                                .HasForeignKey("ConnectionRequestId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.shared.TextBox", "Text", b1 =>
                        {
                            b1.Property<string>("ConnectionRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Content")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ConnectionRequestId");

                            b1.ToTable("ConnectionRequest");

                            b1.WithOwner()
                                .HasForeignKey("ConnectionRequestId");
                        });

                    b.OwnsMany("SocialNetwork.core.model.tags.domain.TagId", "TagsConf", b1 =>
                        {
                            b1.Property<string>("ConnectionRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ConnectionRequestId", "Id");

                            b1.ToTable("ConnectionRequest_TagsConf");

                            b1.WithOwner()
                                .HasForeignKey("ConnectionRequestId");
                        });

                    b.Navigation("ConnectionRequestStatus");

                    b.Navigation("ConnectionStrengthConf");

                    b.Navigation("CreationDate");

                    b.Navigation("TagsConf");

                    b.Navigation("Text");
                });

            modelBuilder.Entity("SocialNetwork.core.model.missions.domain.Mission", b =>
                {
                    b.OwnsOne("SocialNetwork.core.model.missions.domain.MissionDifficulty", "Difficulty", b1 =>
                        {
                            b1.Property<string>("MissionId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Difficulty")
                                .HasColumnType("int");

                            b1.HasKey("MissionId");

                            b1.ToTable("Mission");

                            b1.WithOwner()
                                .HasForeignKey("MissionId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.missions.domain.MissionPoints", "Points", b1 =>
                        {
                            b1.Property<string>("MissionId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Points")
                                .HasColumnType("int");

                            b1.HasKey("MissionId");

                            b1.ToTable("Mission");

                            b1.WithOwner()
                                .HasForeignKey("MissionId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.missions.domain.MissionStatus", "Status", b1 =>
                        {
                            b1.Property<string>("MissionId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("CurrentStatus")
                                .HasColumnType("int");

                            b1.HasKey("MissionId");

                            b1.ToTable("Mission");

                            b1.WithOwner()
                                .HasForeignKey("MissionId");
                        });

                    b.Navigation("Difficulty");

                    b.Navigation("Points");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("SocialNetwork.core.model.players.domain.Player", b =>
                {
                    b.OwnsOne("SocialNetwork.core.model.players.domain.DateOfBirth", "DateOfBirth", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.players.domain.Email", "Email", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("PlayerId");

                            b1.HasIndex("Address")
                                .IsUnique();

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.players.domain.EmotionalStatus", "EmotionalStatus", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("CurrentEmotionalStatus")
                                .HasColumnType("int");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.players.domain.FacebookProfile", "FacebookProfile", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("FacebookProfileLink")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.players.domain.LinkedinProfile", "LinkedinProfile", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("LinkedinProfileLink")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.players.domain.Name", "Name", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("FullName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ShortName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.players.domain.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Player");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsMany("SocialNetwork.core.model.tags.domain.TagId", "TagsList", b1 =>
                        {
                            b1.Property<string>("PlayerId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PlayerId", "Id");

                            b1.ToTable("Player_TagsList");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.Navigation("DateOfBirth");

                    b.Navigation("Email");

                    b.Navigation("EmotionalStatus");

                    b.Navigation("FacebookProfile");

                    b.Navigation("LinkedinProfile");

                    b.Navigation("Name");

                    b.Navigation("PhoneNumber");

                    b.Navigation("TagsList");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.comment.Comment", b =>
                {
                    b.HasOne("SocialNetwork.core.model.posts.domain.post.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.OwnsOne("SocialNetwork.core.model.shared.CreationDate", "CreationDate", b1 =>
                        {
                            b1.Property<string>("CommentId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("CommentId");

                            b1.ToTable("Comment");

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.shared.TextBox", "CommentText", b1 =>
                        {
                            b1.Property<string>("CommentId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Content")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CommentId");

                            b1.ToTable("Comment");

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });

                    b.Navigation("CommentText");

                    b.Navigation("CreationDate");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.post.Post", b =>
                {
                    b.OwnsOne("SocialNetwork.core.model.shared.CreationDate", "CreationDate", b1 =>
                        {
                            b1.Property<string>("PostId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("PostId");

                            b1.ToTable("Post");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.shared.TextBox", "PostText", b1 =>
                        {
                            b1.Property<string>("PostId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Content")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PostId");

                            b1.ToTable("Post");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("SocialNetwork.core.model.tags.domain.TagId", "Tags", b1 =>
                        {
                            b1.Property<string>("PostId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PostId", "Id");

                            b1.ToTable("Post_Tags");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.Navigation("CreationDate");

                    b.Navigation("PostText");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.reaction.Reaction", b =>
                {
                    b.HasOne("SocialNetwork.core.model.posts.domain.comment.Comment", null)
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId");

                    b.HasOne("SocialNetwork.core.model.posts.domain.post.Post", null)
                        .WithMany("Reactions")
                        .HasForeignKey("PostId");

                    b.OwnsOne("SocialNetwork.core.model.posts.domain.reaction.ReactionValue", "ReactionValue", b1 =>
                        {
                            b1.Property<string>("ReactionId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Reaction")
                                .HasColumnType("int");

                            b1.HasKey("ReactionId");

                            b1.ToTable("Reaction");

                            b1.WithOwner()
                                .HasForeignKey("ReactionId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.shared.CreationDate", "CreationDate", b1 =>
                        {
                            b1.Property<string>("ReactionId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("ReactionId");

                            b1.ToTable("Reaction");

                            b1.WithOwner()
                                .HasForeignKey("ReactionId");
                        });

                    b.Navigation("CreationDate");

                    b.Navigation("ReactionValue");
                });

            modelBuilder.Entity("SocialNetwork.core.model.relationships.domain.Relationship", b =>
                {
                    b.OwnsOne("SocialNetwork.core.model.players.domain.PlayerId", "PlayerDest", b1 =>
                        {
                            b1.Property<string>("RelationshipId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RelationshipId");

                            b1.ToTable("Relationship");

                            b1.WithOwner()
                                .HasForeignKey("RelationshipId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.players.domain.PlayerId", "PlayerOrig", b1 =>
                        {
                            b1.Property<string>("RelationshipId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RelationshipId");

                            b1.ToTable("Relationship");

                            b1.WithOwner()
                                .HasForeignKey("RelationshipId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.relationships.domain.ConnectionStrength", "ConnectionStrength", b1 =>
                        {
                            b1.Property<string>("RelationshipId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Strength")
                                .HasColumnType("int");

                            b1.HasKey("RelationshipId");

                            b1.ToTable("Relationship");

                            b1.WithOwner()
                                .HasForeignKey("RelationshipId");
                        });

                    b.OwnsMany("SocialNetwork.core.model.tags.domain.TagId", "TagsList", b1 =>
                        {
                            b1.Property<string>("RelationshipId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RelationshipId", "Id");

                            b1.ToTable("Relationship_TagsList");

                            b1.WithOwner()
                                .HasForeignKey("RelationshipId");
                        });

                    b.Navigation("ConnectionStrength");

                    b.Navigation("PlayerDest");

                    b.Navigation("PlayerOrig");

                    b.Navigation("TagsList");
                });

            modelBuilder.Entity("SocialNetwork.core.model.systemUsers.domain.SystemUser", b =>
                {
                    b.OwnsOne("SocialNetwork.core.model.systemUsers.domain.Password", "Password", b1 =>
                        {
                            b1.Property<string>("SystemUserId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SystemUserId");

                            b1.ToTable("SystemUser");

                            b1.WithOwner()
                                .HasForeignKey("SystemUserId");
                        });

                    b.Navigation("Password");
                });

            modelBuilder.Entity("SocialNetwork.core.model.tags.domain.Tag", b =>
                {
                    b.OwnsOne("SocialNetwork.core.model.shared.CreationDate", "CreationDate", b1 =>
                        {
                            b1.Property<string>("TagId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("TagId");

                            b1.ToTable("Tag");

                            b1.WithOwner()
                                .HasForeignKey("TagId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.tags.domain.TagName", "TagName", b1 =>
                        {
                            b1.Property<string>("TagId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("TagId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Tag");

                            b1.WithOwner()
                                .HasForeignKey("TagId");
                        });

                    b.Navigation("CreationDate");

                    b.Navigation("TagName");
                });

            modelBuilder.Entity("SocialNetwork.core.model.connectionRequests.domain.DirectRequest", b =>
                {
                    b.HasOne("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequest", null)
                        .WithOne()
                        .HasForeignKey("SocialNetwork.core.model.connectionRequests.domain.DirectRequest", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.core.model.connectionRequests.domain.IntroductionRequest", b =>
                {
                    b.HasOne("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequest", null)
                        .WithOne()
                        .HasForeignKey("SocialNetwork.core.model.connectionRequests.domain.IntroductionRequest", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("SocialNetwork.core.model.connectionRequests.domain.ConnectionRequestStatus", "IntroductionStatus", b1 =>
                        {
                            b1.Property<string>("IntroductionRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("CurrentStatus")
                                .HasColumnType("int");

                            b1.HasKey("IntroductionRequestId");

                            b1.ToTable("IntroductionRequest");

                            b1.WithOwner()
                                .HasForeignKey("IntroductionRequestId");
                        });

                    b.OwnsOne("SocialNetwork.core.model.shared.TextBox", "TextIntroduction", b1 =>
                        {
                            b1.Property<string>("IntroductionRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Content")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("IntroductionRequestId");

                            b1.ToTable("IntroductionRequest");

                            b1.WithOwner()
                                .HasForeignKey("IntroductionRequestId");
                        });

                    b.Navigation("IntroductionStatus");

                    b.Navigation("TextIntroduction");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.comment.Comment", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.core.model.posts.domain.post.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}

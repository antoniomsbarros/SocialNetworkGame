using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConnectionRequest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConnectionRequestStatus_CurrentStatus = table.Column<int>(type: "int", nullable: true),
                    PlayerSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerReceiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConnectionStrengthConf_Strength = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Player = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_CurrentStatus = table.Column<int>(type: "int", nullable: true),
                    Difficulty_Difficulty = table.Column<int>(type: "int", nullable: true),
                    Points_Points = table.Column<int>(type: "int", nullable: true),
                    ObjectivePlayer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email_Address = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookProfile_FacebookProfileLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinProfile_LinkedinProfileLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name_ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmotionalStatus_CurrentEmotionalStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostText_Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerDest_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerOrig_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionStrength_Strength = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password_Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagName_Value = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionRequest_TagsConf",
                columns: table => new
                {
                    ConnectionRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionRequest_TagsConf", x => new { x.ConnectionRequestId, x.Id });
                    table.ForeignKey(
                        name: "FK_ConnectionRequest_TagsConf_ConnectionRequest_ConnectionRequestId",
                        column: x => x.ConnectionRequestId,
                        principalTable: "ConnectionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectRequest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectRequest_ConnectionRequest_Id",
                        column: x => x.Id,
                        principalTable: "ConnectionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntroductionRequest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TextIntroduction_Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerIntroduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroductionStatus_CurrentStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroductionRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntroductionRequest_ConnectionRequest_Id",
                        column: x => x.Id,
                        principalTable: "ConnectionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player_TagsList",
                columns: table => new
                {
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_TagsList", x => new { x.PlayerId, x.Id });
                    table.ForeignKey(
                        name: "FK_Player_TagsList_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentText_Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post_Tags",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Tags", x => new { x.PostId, x.Id });
                    table.ForeignKey(
                        name: "FK_Post_Tags_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationship_TagsList",
                columns: table => new
                {
                    RelationshipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship_TagsList", x => new { x.RelationshipId, x.Id });
                    table.ForeignKey(
                        name: "FK_Relationship_TagsList_Relationship_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReactionValue_Reaction = table.Column<int>(type: "int", nullable: true),
                    Player = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reaction_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reaction_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Email_Address",
                table: "Player",
                column: "Email_Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_CommentId",
                table: "Reaction",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_PostId",
                table: "Reaction",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagName_Value",
                table: "Tag",
                column: "TagName_Value",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionRequest_TagsConf");

            migrationBuilder.DropTable(
                name: "DirectRequest");

            migrationBuilder.DropTable(
                name: "IntroductionRequest");

            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "Player_TagsList");

            migrationBuilder.DropTable(
                name: "Post_Tags");

            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropTable(
                name: "Relationship_TagsList");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "ConnectionRequest");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}

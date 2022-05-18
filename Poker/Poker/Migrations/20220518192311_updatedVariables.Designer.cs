﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokerClassLibrary;

namespace Poker.Migrations
{
    [DbContext(typeof(PokerContext))]
    [Migration("20220518192311_updatedVariables")]
    partial class updatedVariables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Hebrew_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poker.DataModel.Pot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("RoomId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId1");

                    b.ToTable("Pots");
                });

            modelBuilder.Entity("PokerClassLibrary.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("RoomId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Suit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId1");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PokerClassLibrary.Room", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DealerPosition")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Pot")
                        .HasColumnType("int");

                    b.Property<short>("Round")
                        .HasColumnType("smallint");

                    b.Property<short>("TalkingPosition")
                        .HasColumnType("smallint");

                    b.Property<int>("TurnStake")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PokerClassLibrary.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Money")
                        .HasColumnType("int")
                        .HasColumnName("userMoney");

                    b.Property<int>("MoneyInTable")
                        .HasColumnType("int");

                    b.Property<int>("MoneyInTurn")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("PlayedThisTurn")
                        .HasColumnType("bit");

                    b.Property<short>("Position")
                        .HasColumnType("smallint");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Username");

                    b.HasIndex("RoomId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Poker.DataModel.Pot", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("Pots")
                        .HasForeignKey("RoomId1");
                });

            modelBuilder.Entity("PokerClassLibrary.Card", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("Deck")
                        .HasForeignKey("RoomId1");
                });

            modelBuilder.Entity("PokerClassLibrary.User", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("Users")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("PokerClassLibrary.Room", b =>
                {
                    b.Navigation("Deck");

                    b.Navigation("Pots");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

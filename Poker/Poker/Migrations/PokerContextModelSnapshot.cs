﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokerClassLibrary;

namespace Poker.Migrations
{
    [DbContext(typeof(PokerContext))]
    partial class PokerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Hebrew_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PokerClassLibrary.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PokerClassLibrary.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("Pot")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoomId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("PokerClassLibrary.UserInRoom", b =>
                {
                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int?>("MoneyInTable")
                        .HasColumnType("int");

                    b.Property<short?>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserName");

                    b.ToTable("UserInRoom");
                });

            modelBuilder.Entity("PokerClassLibrary.Users", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserMoney")
                        .HasColumnType("int")
                        .HasColumnName("userMoney");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PokerClassLibrary.UserInRoom", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK__UserInRoo__RoomI__412EB0B6")
                        .IsRequired();

                    b.HasOne("PokerClassLibrary.Users", "UserNameNavigation")
                        .WithMany()
                        .HasForeignKey("UserName")
                        .HasConstraintName("FK__UserInRoo__userN__403A8C7D")
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("UserNameNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}

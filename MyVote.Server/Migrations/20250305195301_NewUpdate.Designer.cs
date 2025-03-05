﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyVote.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250305195301_NewUpdate")]
    partial class NewUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyVote.Server.Models.Choice", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChoiceId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumVotes")
                        .HasColumnType("integer");

                    b.Property<int>("PollId")
                        .HasColumnType("integer");

                    b.HasKey("ChoiceId");

                    b.HasIndex("PollId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("MyVote.Server.Models.Poll", b =>
                {
                    b.Property<int>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PollId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateEnded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("MultiSelect")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PollId");

                    b.HasIndex("UserId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("MyVote.Server.Models.Suggestion", b =>
                {
                    b.Property<int>("SuggestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SuggestionId"));

                    b.Property<int>("PollId")
                        .HasColumnType("integer");

                    b.Property<string>("PollName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SuggestionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("SuggestionId");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("MyVote.Server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserChoice", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "ChoiceId");

                    b.HasIndex("ChoiceId");

                    b.ToTable("UserChoices");
                });

            modelBuilder.Entity("UserPoll", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("PollId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "PollId");

                    b.HasIndex("PollId");

                    b.ToTable("UserPoll");
                });

            modelBuilder.Entity("MyVote.Server.Models.Choice", b =>
                {
                    b.HasOne("MyVote.Server.Models.Poll", "Poll")
                        .WithMany("Choices")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("MyVote.Server.Models.Poll", b =>
                {
                    b.HasOne("MyVote.Server.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserChoice", b =>
                {
                    b.HasOne("MyVote.Server.Models.Choice", "Choice")
                        .WithMany("UserChoices")
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyVote.Server.Models.User", "User")
                        .WithMany("UserChoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Choice");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserPoll", b =>
                {
                    b.HasOne("MyVote.Server.Models.Poll", "Poll")
                        .WithMany()
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyVote.Server.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Poll");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyVote.Server.Models.Choice", b =>
                {
                    b.Navigation("UserChoices");
                });

            modelBuilder.Entity("MyVote.Server.Models.Poll", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("MyVote.Server.Models.User", b =>
                {
                    b.Navigation("UserChoices");
                });
#pragma warning restore 612, 618
        }
    }
}

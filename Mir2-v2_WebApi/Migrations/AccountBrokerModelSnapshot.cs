﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mir2_v2_WebApi.Broker;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mir2_v2_WebApi.Migrations
{
    [DbContext(typeof(AccountBroker))]
    partial class AccountBrokerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Mir2_v2_WebApi.Model.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("EntryTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Mir2_v2_WebApi.Model.Character", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<int>("CharacterClass")
                        .HasColumnType("integer");

                    b.Property<int>("EntryTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Mir2_v2_WebApi.Model.Character", b =>
                {
                    b.HasOne("Mir2_v2_WebApi.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}

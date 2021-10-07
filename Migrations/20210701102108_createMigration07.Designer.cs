﻿// <auto-generated />
using System;
using AuthenticationApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthenticationApi.Migrations
{
    [DbContext(typeof(TempaAuthContext))]
    [Migration("20210701102108_createMigration07")]
    partial class createMigration07
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthenticationApi.Models.AuditTrail", b =>
                {
                    b.Property<long>("ItbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailOrUserid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Eventdateutc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Eventtype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Newvalue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Originalvalue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recordid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tablename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItbId");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("AuthenticationApi.Models.EmailServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerPort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailServer");
                });

            modelBuilder.Entity("AuthenticationApi.Models.LogTbl", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ErrMsg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogTbl");
                });

            modelBuilder.Entity("AuthenticationApi.Models.OnboardActivationDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activated")
                        .HasColumnType("bit");

                    b.Property<string>("ActivationCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OnboardActivationDetails");
                });

            modelBuilder.Entity("AuthenticationApi.Models.TempaUsers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAcctCreationResponse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAcctName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessCACDocImageCloudPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessTINNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CACRegNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailRegisSent")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ReferralCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TempaTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TempaUsers");
                });

            modelBuilder.Entity("AuthenticationApi.Models.Token", b =>
                {
                    b.Property<long>("value1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("value2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("value1");

                    b.ToTable("Token");

                    b.HasData(
                        new
                        {
                            value1 = 6743853663L,
                            value2 = "ZfhTyeyhshsh"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

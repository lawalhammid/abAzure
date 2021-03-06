// <auto-generated />
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
    [Migration("20211003132623_CreateMigration39")]
    partial class CreateMigration39
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthenticationApi.Entities.ErrorUpdateWalletBalance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CrAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLaterTaken")
                        .HasColumnType("datetime2");

                    b.Property<string>("DrAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ErrorUpdateWalletBalance");
                });

            modelBuilder.Entity("AuthenticationApi.Models.AirTimeSetUp", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountToDisplay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountToSendToServiceProvider")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceProvider")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirTimeSetUp");
                });

            modelBuilder.Entity("AuthenticationApi.Models.AuditTrail", b =>
                {
                    b.Property<long>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("AuthenticationApi.Models.CorporateUsers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessCACDocImageCloudPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessTINNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CorporateUsers");
                });

            modelBuilder.Entity("AuthenticationApi.Models.DataSetUp", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountToDisplay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountToSendToServiceProvider")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimSlot")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DataSetUp");
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

            modelBuilder.Entity("AuthenticationApi.Models.GroupUsers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InitiatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("AuthenticationApi.Models.LogSendFailedEmail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MailBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogSendFailedEmail");
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

                    b.Property<DateTime?>("DateActivated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OnboardActivationDetails");
                });

            modelBuilder.Entity("AuthenticationApi.Models.TempaWalletDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("CollectBankCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionAcctType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool?>("ReceiveLatestNews")
                        .HasColumnType("bit");

                    b.Property<string>("ReferralCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationStatus")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletAcct")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TempaWalletDetails");
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

            modelBuilder.Entity("AuthenticationApi.Models.TransactionLog", b =>
                {
                    b.Property<long>("TId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ApproveBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ApproveDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("BalanceAfterPosting")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BalanceBeforePosting")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankTransRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatchId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChargeAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChargeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClosedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrAcctBBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrAcctEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrAcctName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrAcctPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrAcctStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrBankBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrBankCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateAuthorised")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRejected")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateVerified")
                        .HasColumnType("datetime2");

                    b.Property<string>("DrAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrAcctBBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrAcctEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrAcctName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrAcctPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrAcctStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrBankBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrBankCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullTransResponseText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsBulkTransfer")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsGroupTrans")
                        .HasColumnType("bit");

                    b.Property<string>("NIPTransRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectedById")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectionReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reversal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReversalResponseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReversalResponseText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SequenceNo")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TaxRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempaTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempaTransRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransCompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransResponseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransResponsecode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TId");

                    b.ToTable("TransactionLog");
                });

            modelBuilder.Entity("AuthenticationApi.Models.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool?>("ReceiveLatestNews")
                        .HasColumnType("bit");

                    b.Property<string>("ReferralCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationStatus")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TempaTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletAcctName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthenticationApi.Models.UsersPin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("TempaTag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersPin");
                });

            modelBuilder.Entity("AuthenticationApi.Models.WEMAVirtualAcctControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<DateTime>("TodaysDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WEMAVirtualAcctControl");
                });

            modelBuilder.Entity("AuthenticationApi.Models.WemaUsersAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AmountPerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AmountPerTransaction")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAcctName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("RegistrationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempaTag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WemaUsersAccount");
                });
#pragma warning restore 612, 618
        }
    }
}

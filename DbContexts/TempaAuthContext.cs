using AuthenticationApi.Entities;
using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.DbContexts
{
    public class TempaAuthContext : DbContext
    {
        public TempaAuthContext(DbContextOptions<TempaAuthContext> options) : base(options)
        {

        }
        public DbSet<Token> Token { get; set; }
        public DbSet<LogTbl> LogTbl { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<EmailServer> EmailServer { get; set; }
        public DbSet<OnboardActivationDetails> OnboardActivationDetails { get; set; }
        public DbSet<AuditTrail> AuditTrail { get; set; }
        public DbSet<LogSendFailedEmail> LogSendFailedEmail { get; set; }
        public DbSet<WEMAVirtualAcctControl> WEMAVirtualAcctControl { get; set; }
        public DbSet<WemaUsersAccount> WemaUsersAccount { get; set; }
        public DbSet<CorporateUsers> CorporateUsers { get; set; }
        public DbSet<GroupUsers> GroupUsers { get; set; }
        public DbSet<TempaWalletDetails> TempaWalletDetails { get; set; }
        public DbSet<AirTimeSetUp> AirTimeSetUp { get; set; }
        public DbSet<DataSetUp> DataSetUp { get; set; }
        public DbSet<TransactionLog> TransactionLog { get; set; }
        public DbSet<UsersPin> UsersPin { get; set; }

        public DbSet<ErrorUpdateWalletBalance> ErrorUpdateWalletBalance { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>().HasData(
                new Token
                {
                    value1 = 6743853663,
                    value2 = "ZfhTyeyhshsh",
                   
                }
            );

        
        }

      
    }


}

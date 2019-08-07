using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {

        public CareerCloudContext() : base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(c => c.ApplicantEducations)
                .WithRequired(b => b.ApplicantProfiles)
                .HasForeignKey(c => c.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(c => c.ApplicantResumes)
                .WithRequired(b => b.ApplicantProflies)
                .HasForeignKey(c => c.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(c => c.ApplicantWorkHistory)
                .WithRequired(b => b.ApplicantProfiles)
                .HasForeignKey(c => c.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(c => c.ApplicantSkills)
                .WithRequired(b => b.ApplicantProfiles)
                .HasForeignKey(c => c.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.ApplicantJobApplications)
                .WithRequired(b => b.CompanyJobs)
                .HasForeignKey(c => c.Job)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobEducations)
                .WithRequired(b => b.CompanyJobs)
                .HasForeignKey(c => c.Job)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobSkills)
                .WithRequired(b => b.CompanyJobs)
                .HasForeignKey(c => c.Job)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobDescriptions)
                .WithRequired(b => b.CompanyJobs)
                .HasForeignKey(c => c.Job)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(b => b.CompanyProfiles)
                .HasForeignKey(c => c.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyJobs)
                .WithRequired(b => b.CompanyProfiles)
                .HasForeignKey(c => c.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyLocations)
                .WithRequired(b => b.CompanyProfiles)
                .HasForeignKey(c => c.Company)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(c => c.ApplicantProfiles)
                .WithRequired(b => b.SecurityLogins)
                .HasForeignKey(c => c.Login)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(c => c.SecurityLoginsLogs)
                .WithRequired(b => b.SecurityLogins)
                .HasForeignKey(c => c.Login)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(c => c.SecurityLoginsRoles)
                .WithRequired(b => b.SecurityLogins)
                .HasForeignKey(c => c.Login)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(c => c.SecurityLoginsRoles)
                .WithRequired(b => b.SecurityRoles)
                .HasForeignKey(c => c.Role)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(c => c.ApplicantProfiles)
                .WithOptional(b => b.SystemCountryCodes)
                .HasForeignKey(c => c.Country);


            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(c => c.ApplicantWorkHistory)
                .WithRequired(b => b.SystemCountryCodes)
                .HasForeignKey(c => c.CountryCode)
                .WillCascadeOnDelete(true);



            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(b => b.SystemLanguageCodes)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
              .HasMany(c => c.ApplicantJobApplications)
              .WithRequired(b => b.ApplicantProfiles)
              .HasForeignKey(c => c.Applicant)
              .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }



        DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }

        DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }


    }

}

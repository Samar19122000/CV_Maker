using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SamarApp.Models
{
    public partial class PersonalAppdbContext : IdentityDbContext<ApplicationUser>
    {
        public PersonalAppdbContext()
        {
        }

        public PersonalAppdbContext(DbContextOptions<PersonalAppdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAbouteme> TbAboutemes { get; set; }
        public virtual DbSet<TbEducation> TbEducations { get; set; }
        public virtual DbSet<TbLanguage> TbLanguages { get; set; }
        public virtual DbSet<TbProject> TbProjects { get; set; }
        public virtual DbSet<TbSlider> TbSliders { get; set; }
        public virtual DbSet<TbWork> TbWorks { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAbouteme>(entity =>
            {

                entity.ToTable("TbAbouteme");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Freelancer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbEducation>(entity =>
            {
                entity.ToTable("TbEducation");

                entity.Property(e => e.AcademyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QualiDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbLanguage>(entity =>
            {
                entity.ToTable("TbLanguage");

                entity.Property(e => e.LangaugeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbProject>(entity =>
            {
                entity.Property(e => e.Pdate)
                    .HasColumnType("date")
                    .HasColumnName("PDate");

                entity.Property(e => e.PImage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PImage");

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PName");
            });

            modelBuilder.Entity<TbSlider>(entity =>
            {
                entity.ToTable("TbSlider");

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GetHubLink)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedInLink)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TwitterLink)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbWork>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.JobName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

           

            OnModelCreatingPartial(modelBuilder);

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<IdentityUserLogin<string>>();
            //modelBuilder.Ignore<IdentityUserRole<string>>();
            //modelBuilder.Ignore<IdentityUserClaim<string>>();
            //modelBuilder.Ignore<IdentityUserToken<string>>();
            //modelBuilder.Ignore<IdentityUser<string>>();

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

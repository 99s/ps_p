using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PS_Portal_Api.Models
{
    public partial class psportal_dbContext : DbContext
    {
        public psportal_dbContext()
        {
        }

        public psportal_dbContext(DbContextOptions<psportal_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionTbl> ActionTbls { get; set; } = null!;
        public virtual DbSet<AdditionalDataTbl> AdditionalDataTbls { get; set; } = null!;
        public virtual DbSet<ComplainTable> ComplainTables { get; set; } = null!;
        public virtual DbSet<ContactsTbl> ContactsTbls { get; set; } = null!;
        public virtual DbSet<DocsTbl> DocsTbls { get; set; } = null!;
        public virtual DbSet<ReplyTbl> ReplyTbls { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;
        public virtual DbSet<UserTypeTbl> UserTypeTbls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=H0ME_IG;Database=psportal_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionTbl>(entity =>
            {
                entity.ToTable("Action_tbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionTakenBy).HasColumnName("Action_Taken_by");

                entity.Property(e => e.AutharityName).HasColumnName("Autharity_Name");

                entity.Property(e => e.ComplaintIdFk).HasColumnName("Complaint_ID_fk");

                entity.Property(e => e.DrNo).HasColumnName("DR_No");

                entity.Property(e => e.EvidenceDocFk).HasColumnName("Evidence_Doc_fk");

                entity.Property(e => e.IpcCrpcSection).HasColumnName("IPC_CRPC_section");

                entity.Property(e => e.TimeOfAction)
                    .HasColumnType("datetime")
                    .HasColumnName("Time_of_Action");

                entity.Property(e => e.WhichActionTaken).HasColumnName("Which_Action_Taken");
            });

            modelBuilder.Entity<AdditionalDataTbl>(entity =>
            {
                entity.ToTable("AdditionalData_tbl");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ComplainTable>(entity =>
            {
                entity.ToTable("Complain_Table");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccusedDetails).HasColumnName("Accused_details");

                entity.Property(e => e.ComplainDateTime)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Complain_Date_Time");

                entity.Property(e => e.ComplainNature).HasColumnName("Complain_Nature");

                entity.Property(e => e.ComplainNo).HasColumnName("Complain_no");

                entity.Property(e => e.ComplainTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Complain_Time");

                entity.Property(e => e.ComplainUpdateTimes).HasColumnName("Complain_Update_Times");

                entity.Property(e => e.ComplainantAddress).HasColumnName("Complainant_Address");

                entity.Property(e => e.ComplainantName).HasColumnName("Complainant_Name");

                entity.Property(e => e.DateTimeOfIncident).HasColumnName("Date_Time_of_Incident");

                entity.Property(e => e.EmailId).HasColumnName("Email_Id");

                entity.Property(e => e.EvidenceDocFk).HasColumnName("Evidence_Doc_fk");

                entity.Property(e => e.EvidenceDocPath).HasColumnName("Evidence_Doc_path");

                entity.Property(e => e.GdNo).HasColumnName("GD_no");

                entity.Property(e => e.GistOfTheComplain).HasColumnName("Gist_of_the_Complain");

                entity.Property(e => e.IsGd).HasColumnName("isGD");

                entity.Property(e => e.MobileNo).HasColumnName("Mobile_No");

                entity.Property(e => e.VictimName).HasColumnName("Victim_Name");
            });

            modelBuilder.Entity<ContactsTbl>(entity =>
            {
                entity.ToTable("ContactsTbl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Psname).HasColumnName("PSName");
            });

            modelBuilder.Entity<DocsTbl>(entity =>
            {
                entity.ToTable("Docs_tbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Doc_Date");

                entity.Property(e => e.DocName).HasColumnName("Doc_Name");

                entity.Property(e => e.DocPath).HasColumnName("Doc_Path");

                entity.Property(e => e.DocUploadTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Doc_Upload_Time");
            });

            modelBuilder.Entity<ReplyTbl>(entity =>
            {
                entity.ToTable("Reply_tbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorityAddress).HasColumnName("Authority_Address");

                entity.Property(e => e.AuthorityName).HasColumnName("Authority_Name");

                entity.Property(e => e.CaseReferenceNo).HasColumnName("Case_Reference_No");

                entity.Property(e => e.ComplaintIdFk).HasColumnName("Complaint_ID_fk");

                entity.Property(e => e.CourtNameAddress).HasColumnName("Court_Name_Address");

                entity.Property(e => e.CourtOrder).HasColumnName("Court_Order");

                entity.Property(e => e.DrNo).HasColumnName("DR_No");

                entity.Property(e => e.EvidenceDocIdFk).HasColumnName("Evidence_Doc_id_fk");

                entity.Property(e => e.OrderCopyDocFk).HasColumnName("Order_Copy_doc_fk");

                entity.Property(e => e.OrderDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date_Time");

                entity.Property(e => e.OrderGistCourt).HasColumnName("Order_Gist_Court");

                entity.Property(e => e.OrderNo).HasColumnName("Order_No");

                entity.Property(e => e.ReplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reply_Date");

                entity.Property(e => e.ReplyGist).HasColumnName("Reply_Gist");

                entity.Property(e => e.SuspectStatus).HasColumnName("Suspect_Status");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("userTable");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.LoginName).HasColumnName("loginName");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UserTypeFk).HasColumnName("userType_fk");
            });

            modelBuilder.Entity<UserTypeTbl>(entity =>
            {
                entity.ToTable("userType_tbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

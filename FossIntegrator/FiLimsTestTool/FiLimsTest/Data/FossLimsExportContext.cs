using System;
using System.Collections.Generic;
using FiLimsTest.Models;
using Microsoft.EntityFrameworkCore;

namespace FiLimsTest.Data;

public partial class FossLimsExportContext : DbContext
{
    public FossLimsExportContext(DbContextOptions<FossLimsExportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalInformation> AdditionalInformations { get; set; }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<RawDataHeader> RawDataHeaders { get; set; }

    public virtual DbSet<RawDataValue> RawDataValues { get; set; }

    public virtual DbSet<SampleDatum> SampleData { get; set; }

    public virtual DbSet<SampleHeader> SampleHeaders { get; set; }

    public virtual DbSet<StatusDatum> StatusData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalInformation>(entity =>
        {
            entity.HasKey(e => new { e.ExportId, e.FieldNo });

            entity.ToTable("AdditionalInformation");

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.FieldName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FieldValue)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Export).WithMany(p => p.AdditionalInformations)
                .HasForeignKey(d => d.ExportId)
                .HasConstraintName("FK_AdditionalInformation_SampleHeader");
        });

        modelBuilder.Entity<Info>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Info");

            entity.Property(e => e.Key)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("key");
            entity.Property(e => e.Value)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        modelBuilder.Entity<RawDataHeader>(entity =>
        {
            entity.HasKey(e => new { e.ExportId, e.RawDataId });

            entity.ToTable("RawDataHeader");

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.RawDataId).HasColumnName("RawDataID");

            entity.HasOne(d => d.Export).WithMany(p => p.RawDataHeaders)
                .HasForeignKey(d => d.ExportId)
                .HasConstraintName("FK_RawDataHeader_SampleHeader");
        });

        modelBuilder.Entity<RawDataValue>(entity =>
        {
            entity.HasKey(e => new { e.ExportId, e.RawDataId, e.IndexNo }).HasName("PK_RawDateValues");

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.RawDataId).HasColumnName("RawDataID");

            entity.HasOne(d => d.RawDataHeader).WithMany(p => p.RawDataValues)
                .HasForeignKey(d => new { d.ExportId, d.RawDataId })
                .HasConstraintName("FK_RawDataValues_RawDataHeader");
        });

        modelBuilder.Entity<SampleDatum>(entity =>
        {
            entity.HasKey(e => new { e.ExportId, e.ComponentClassId, e.ComponentSubClassId, e.ComponentType, e.ComponentCustomId });

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.ComponentClassId).HasColumnName("ComponentClassID");
            entity.Property(e => e.ComponentSubClassId).HasColumnName("ComponentSubClassID");
            entity.Property(e => e.ComponentCustomId).HasColumnName("ComponentCustomID");
            entity.Property(e => e.ComponentError)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ComponentLimit)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ComponentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ComponentUnit)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ComponentValueText)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.Export).WithMany(p => p.SampleData)
                .HasForeignKey(d => d.ExportId)
                .HasConstraintName("FK_SampleData_SampleHeader");
        });

        modelBuilder.Entity<SampleHeader>(entity =>
        {
            entity.HasKey(e => e.ExportId);

            entity.ToTable("SampleHeader");

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.ExportDateTime)
                .HasDefaultValueSql("(getutcdate())", "DF_SampleHeader_ExportDateTime")
                .HasColumnType("datetime");
            entity.Property(e => e.JobName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.JobType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MeasureProgram)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SampleComments)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SampleId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SampleID");
            entity.Property(e => e.SampleIntakeNo).HasDefaultValue(1, "DF_SampleHeader_SampleIntakeNo");
            entity.Property(e => e.SampleStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SampleSubType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SampleTestDateTime).HasColumnType("datetime");
            entity.Property(e => e.SampleType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WorkstationName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusDatum>(entity =>
        {
            entity.HasKey(e => new { e.ExportId, e.SourceId, e.StatusName });

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.SourceId).HasColumnName("SourceID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Export).WithMany(p => p.StatusData)
                .HasForeignKey(d => d.ExportId)
                .HasConstraintName("FK_StatusData_SampleHeader");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

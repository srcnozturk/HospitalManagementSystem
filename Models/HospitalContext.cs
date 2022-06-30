using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospitalManagementSystem.Models
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("appointmentDate");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("doctorName");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("patientName");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointments_Doctors");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointments_Patients");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.DoctorAddress)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("doctorAddress");

                entity.Property(e => e.DoctorFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("doctorFirstName");

                entity.Property(e => e.DoctorLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("doctorLastName");

                entity.Property(e => e.DoctorPhone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("doctorPhone");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.PatientAddress)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("patientAddress");

                entity.Property(e => e.PatientFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("patientFirstName");

                entity.Property(e => e.PatientInsurance)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("patientInsurance");

                entity.Property(e => e.PatientLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("patientLastName");

                entity.Property(e => e.PatientPhone)
                     .IsRequired()
                     .HasMaxLength(11)
                     .HasColumnName("patientPhone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

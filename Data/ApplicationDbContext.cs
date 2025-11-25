// ==============================================================================
// File: ApplicationDbContext.cs
// Description: This class defines the Entity Framework Core database context for 
//              the Medical Journey Log application. It manages the connection to 
//              the MySQL database and provides DbSet properties for each model.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

using Microsoft.EntityFrameworkCore;
using MedicalJourneyLog.Models;

namespace MedicalJourneyLog.Data
{
    /// <summary>
    /// ApplicationDbContext is the primary EF Core context for the application.
    /// It configures the database connection and exposes DbSets for all domain models.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor that passes DbContextOptions to the base class.
        /// </summary>
        /// <param name="options">Database context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Table for child profiles.
        /// </summary>
        public DbSet<Child> Children { get; set; }

        /// <summary>
        /// Table for caregiver user accounts.
        /// </summary>
        public DbSet<Caregiver> Caregivers { get; set; }

        /// <summary>
        /// Join table for many-to-many relationship between caregivers and children.
        /// </summary>
        public DbSet<CaregiverChild> CaregiverChildren { get; set; }

        /// <summary>
        /// Table for notes added by caregivers.
        /// </summary>
        public DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Table for tracking child symptoms.
        /// </summary>
        public DbSet<Symptom> Symptoms { get; set; }

        /// <summary>
        /// Table for medical appointments.
        /// </summary>
        public DbSet<Appointment> Appointments { get; set; }

        /// <summary>
        /// Table for development or treatment milestones.
        /// </summary>
        public DbSet<Milestone> Milestones { get; set; }
    }
}

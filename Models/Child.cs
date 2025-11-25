// ==============================================================================
// File: Child.cs
// Description: Represents a child in the Medical Journey Log application. A child 
//              can have symptoms, notes, milestones, appointments, and multiple 
//              associated caregivers.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

using System.ComponentModel.DataAnnotations;

namespace MedicalJourneyLog.Models
{
    /// <summary>
    /// Represents a child whose medical history is being tracked in the system.
    /// Includes relationships to symptoms, notes, milestones, appointments, and caregivers.
    /// </summary>
    public class Child
    {
        /// <summary>
        /// Primary key identifier for the child.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Full name of the child (required).
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(80, ErrorMessage = "Name cannot be longer than 80 characters.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Optional date of birth for the child.
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        // Navigation properties
        public ICollection<Note>? Notes { get; set; }
        public ICollection<Symptom>? Symptoms { get; set; }
        public ICollection<Milestone>? Milestones { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<CaregiverChild>? CaregiverChildren { get; set; }
    }
}

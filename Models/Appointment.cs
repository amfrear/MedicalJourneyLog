// ==============================================================================
// File: Appointment.cs
// Description: Represents a medical appointment for a specific child, including 
//              location, doctor, and appointment date.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

namespace MedicalJourneyLog.Models
{
    /// <summary>
    /// Represents a scheduled medical appointment for a child.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Primary key identifier for the appointment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Optional location where the appointment takes place (e.g., clinic name).
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Optional name of the doctor or specialist for the appointment.
        /// </summary>
        public string? Doctor { get; set; }

        /// <summary>
        /// The date and time of the appointment.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Foreign key referencing the child associated with this appointment.
        /// </summary>
        public int ChildId { get; set; }

        /// <summary>
        /// Navigation property for the related child.
        /// </summary>
        public Child? Child { get; set; }
    }
}

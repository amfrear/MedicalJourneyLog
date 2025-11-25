// ==============================================================================
// File: Note.cs
// Description: Represents a caregiver's note about a child. Notes can be used 
//              for journaling daily observations or recording important details.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

namespace MedicalJourneyLog.Models
{
    /// <summary>
    /// Represents a note recorded by a caregiver for a specific child.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Primary key identifier for the note.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text content of the caregiver's note.
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Foreign key referencing the associated child.
        /// </summary>
        public int ChildId { get; set; }

        /// <summary>
        /// Navigation property for the related child.
        /// </summary>
        public Child? Child { get; set; }
    }
}

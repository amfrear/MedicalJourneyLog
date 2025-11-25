// ==============================================================================
// File: Caregiver.cs
// Description: Represents a caregiver who may be responsible for one or more children.
//              Supports many-to-many relationships via CaregiverChild join entity.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

namespace MedicalJourneyLog.Models
{
    /// <summary>
    /// Represents a caregiver in the system, such as a parent or guardian.
    /// A caregiver can be linked to multiple children through a join table.
    /// </summary>
    public class Caregiver
    {
        /// <summary>
        /// Primary key identifier for the caregiver.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Full name of the caregiver.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Navigation property for the join relationship to multiple children.
        /// </summary>
        public ICollection<CaregiverChild>? CaregiverChildren { get; set; }
    }
}

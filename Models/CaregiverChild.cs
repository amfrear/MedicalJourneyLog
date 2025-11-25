// ==============================================================================
// File: CaregiverChild.cs
// Description: Join entity for the many-to-many relationship between Caregivers 
//              and Children in the Medical Journey Log application.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

namespace MedicalJourneyLog.Models
{
    /// <summary>
    /// Join entity to associate caregivers with multiple children, and vice versa.
    /// Supports a many-to-many relationship between Caregiver and Child.
    /// </summary>
    public class CaregiverChild
    {
        /// <summary>
        /// Primary key identifier for the join record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key referencing the associated caregiver.
        /// </summary>
        public int CaregiverId { get; set; }

        /// <summary>
        /// Navigation property for the caregiver.
        /// </summary>
        public Caregiver? Caregiver { get; set; }

        /// <summary>
        /// Foreign key referencing the associated child.
        /// </summary>
        public int ChildId { get; set; }

        /// <summary>
        /// Navigation property for the child.
        /// </summary>
        public Child? Child { get; set; }
    }
}

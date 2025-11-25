// ==============================================================================
// File: Milestone.cs
// Description: Represents a milestone related to a child’s development or 
//              medical journey, including a title and description.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

namespace MedicalJourneyLog.Models
{
    /// <summary>
    /// Represents a milestone for a child, such as developmental progress
    /// or key events in a medical treatment plan.
    /// </summary>
    public class Milestone
    {
        /// <summary>
        /// Primary key identifier for the milestone.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Short title or name of the milestone.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Optional detailed description of the milestone.
        /// </summary>
        public string? Description { get; set; }

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

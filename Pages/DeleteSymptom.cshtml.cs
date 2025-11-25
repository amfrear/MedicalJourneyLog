using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedicalJourneyLog.Pages
{
    // This PageModel handles deleting a symptom record that belongs to a specific child.
    // It ensures the caregiver can review the symptom before confirming deletion.
    public class DeleteSymptomModel : PageModel
    {
        // Bring in the database context so we can read and modify symptom data.
        private readonly ApplicationDbContext _context;
        public DeleteSymptomModel(ApplicationDbContext context) => _context = context;

        // This property represents the symptom being displayed or deleted.
        // It’s bound to the Razor page, which allows us to show the details of the symptom
        // before actually removing it.
        [BindProperty]
        public Symptom Symptom { get; set; } = new();

        // The OnGetAsync method runs when the delete page first loads.
        // It looks up the symptom record by its ID in the database.
        // If the record doesn’t exist, we return a 404 Not Found response.
        // Otherwise, we store it in the Symptom property so the Razor page can display
        // its details for confirmation before deletion.
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var symptom = await _context.Symptoms.FirstOrDefaultAsync(s => s.Id == id);
            if (symptom is null) return NotFound();
            Symptom = symptom;
            return Page();
        }

        // The OnPostAsync method runs when the user confirms the deletion.
        // It finds the same symptom record again, removes it from the database,
        // and then redirects back to the Child Details page with a success message.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var symptom = await _context.Symptoms.FirstOrDefaultAsync(s => s.Id == id);
            if (symptom is null) return NotFound();

            // Save the child’s ID so we can redirect back to their details page after deletion.
            var childId = symptom.ChildId;

            // Remove the symptom from the database.
            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();

            // Set a success alert so the caregiver knows the deletion worked.
            TempData["SuccessMessage"] = "Symptom deleted successfully.";

            // Redirect back to the child’s details page to show the updated list of symptoms.
            return RedirectToPage("/ChildDetails", new { id = childId });
        }
    }
}

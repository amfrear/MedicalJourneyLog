using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedicalJourneyLog.Pages
{
    // This PageModel controls the logic for deleting a child record.
    // It prevents accidental deletions if the child still has related symptoms.
    public class DeleteChildModel : PageModel
    {
        // Bring in the database context so we can query and modify the data.
        private readonly ApplicationDbContext _context;
        public DeleteChildModel(ApplicationDbContext context) => _context = context;

        // This property holds the child record being displayed or deleted.
        [BindProperty]
        public Child Child { get; set; } = new();

        // This optional property stores the reason why a delete might be blocked.
        public string? BlockReason { get; set; }

        // The OnGetAsync method runs when the page first loads.
        // It loads the child by ID and includes their related symptoms in the query.
        // If the child doesn’t exist, we return a 404 Not Found.
        // If the child does exist but has symptoms, we set a message explaining
        // why deletion is currently blocked.
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var child = await _context.Children
                .Include(c => c.Symptoms)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (child is null) return NotFound();

            Child = child;

            if (child.Symptoms != null && child.Symptoms.Any())
            {
                BlockReason = "This child has one or more symptoms. Please delete the symptoms first before deleting the child.";
            }

            return Page();
        }

        // The OnPostAsync method runs when the user confirms the deletion.
        // It retrieves the same child record from the database, again including symptoms.
        // If the child doesn’t exist, we return a 404.
        // If the child still has symptoms, we stop the process,
        // set a red error message in TempData, and redirect back to the Child Details page.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var child = await _context.Children
                .Include(c => c.Symptoms)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (child is null) return NotFound();

            if (child.Symptoms != null && child.Symptoms.Any())
            {
                TempData["ErrorMessage"] = "Delete blocked: this child has symptoms. Delete those first.";
                return RedirectToPage("/ChildDetails", new { id });
            }

            // If no symptoms exist, we safely remove the child from the database.
            _context.Children.Remove(child);
            await _context.SaveChangesAsync();

            // Use TempData to show a green success alert once the deletion completes.
            TempData["SuccessMessage"] = "Child deleted successfully.";

            // Redirect back to the Index page so the caregiver sees the updated list.
            return RedirectToPage("/Index");
        }
    }
}

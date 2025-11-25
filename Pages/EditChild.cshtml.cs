using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedicalJourneyLog.Pages
{
    // This PageModel handles editing an existing child's information in the system.
    // It uses Entity Framework Core to fetch the record, display it, and save changes back to the database.
    public class EditChildModel : PageModel
    {
        // Inject the database context so this page can interact with the database.
        private readonly ApplicationDbContext _context;
        public EditChildModel(ApplicationDbContext context) => _context = context;

        // The Child property is bound to the Razor form on the page.
        // When the user edits the form and submits it, those values are automatically mapped here.
        [BindProperty]
        public Child Child { get; set; } = new();

        // The OnGetAsync method runs when the page is first loaded.
        // It receives the child's ID from the URL and looks up that record in the database.
        // If the child doesn’t exist, it returns a 404 Not Found.
        // Otherwise, it populates the Child property so the form fields show the existing values.
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var child = await _context.Children.FirstOrDefaultAsync(c => c.Id == id);
            if (child is null) return NotFound();
            Child = child;
            return Page();
        }

        // The OnPostAsync method runs when the user submits the form.
        // First, it checks if the model is valid (all required fields filled).
        // Then it looks up the same record in the database using the provided ID.
        // If the record exists, it updates the Name and Date of Birth with the new values from the form.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid) return Page();

            var childToUpdate = await _context.Children.FirstOrDefaultAsync(c => c.Id == id);
            if (childToUpdate is null) return NotFound();

            childToUpdate.Name = Child.Name;
            childToUpdate.DateOfBirth = Child.DateOfBirth;

            // SaveChangesAsync commits the updates to the database.
            await _context.SaveChangesAsync();

            // TempData stores a short success message to display once the page reloads.
            TempData["SuccessMessage"] = "Child updated successfully.";

            // Finally, redirect back to the Child Details page so the caregiver can see the updated info.
            return RedirectToPage("/ChildDetails", new { id });
        }
    }
}

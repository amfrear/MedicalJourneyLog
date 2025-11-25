using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedicalJourneyLog.Pages
{
    // This PageModel handles editing an existing symptom that belongs to a child.
    // It allows caregivers to correct details like name, description, or the date it was logged.
    public class EditSymptomModel : PageModel
    {
        // Inject the database context so we can access and modify symptom data.
        private readonly ApplicationDbContext _context;
        public EditSymptomModel(ApplicationDbContext context) => _context = context;

        // This property represents the symptom record that’s being edited.
        // It’s automatically bound to the form fields on the Razor page.
        [BindProperty]
        public Symptom Symptom { get; set; } = new();

        // The OnGetAsync method runs when the Edit page is first opened.
        // It looks up the symptom by its ID in the database.
        // If no record is found, we return a 404 Not Found response.
        // Otherwise, we load the data into the Symptom property so the form shows current values.
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var symptom = await _context.Symptoms.FirstOrDefaultAsync(s => s.Id == id);
            if (symptom is null) return NotFound();
            Symptom = symptom;
            return Page();
        }

        // The OnPostAsync method runs when the caregiver submits the edited form.
        // First, we check if the model is valid — meaning all required fields are filled.
        // Then, we retrieve the same record from the database using the ID.
        // If it exists, we update its properties with the new values from the form.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid) return Page();

            var symptomToUpdate = await _context.Symptoms.FirstOrDefaultAsync(s => s.Id == id);
            if (symptomToUpdate is null) return NotFound();

            // Update the editable fields with the new values provided by the user.
            symptomToUpdate.Name = Symptom.Name;
            symptomToUpdate.Description = Symptom.Description;
            symptomToUpdate.DateLogged = Symptom.DateLogged;

            // Save the updated data to the database.
            await _context.SaveChangesAsync();

            // Display a green success alert on the next page.
            TempData["SuccessMessage"] = "Symptom updated successfully.";

            // Redirect the user back to the Child Details page to see the updated symptom list.
            return RedirectToPage("/ChildDetails", new { id = symptomToUpdate.ChildId });
        }
    }
}

// ==============================================================================
// File: LogChild.cshtml.cs
// Description: Handles the creation of new child records via a form. Accepts 
//              user input, validates it, and saves to the database.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalJourneyLog.Pages
{
    // This PageModel handles the logic for logging a new child in the system.
    // It's tied to the LogChild Razor Page where users can input a child's name and date of birth.
    public class LogChildModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // The constructor brings in our EF Core database context
        // so we can save new children to the database.
        public LogChildModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // This property is bound to the form on the page.
        // It holds the data the user submits when adding a new child.
        [BindProperty]
        public Child Child { get; set; } = new Child();

        // This method handles GET requests for the page.
        // In this case, we don't need to do anything when the page first loads.
        public void OnGet()
        {
        }

        // This method handles POST requests — basically when the form is submitted.
        // First, we check if the submitted data is valid using ModelState.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the form has validation errors, we stay on the page and show them.
                return Page();
            }

            // If the data is valid, we add the new child to the database
            // and save the changes using EF Core.
            _context.Children.Add(Child);
            _context.SaveChanges();

            // We also store a success message in TempData
            // and then redirect the user back to the homepage.
            TempData["SuccessMessage"] = "Child added successfully!";
            return RedirectToPage("Index");
        }
    }
}

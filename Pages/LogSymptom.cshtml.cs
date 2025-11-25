// ==============================================================================
// File: LogSymptom.cshtml.cs
// Description: Handles the logic for logging a symptom for a selected child.
//              Supports optional pre-selection of child via query string.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalJourneyLog.Pages
{
    // This PageModel handles the Log Symptom page.
    // It lets users fill out a form to log a new symptom and optionally pre-selects a child if one was passed in.
    public class LogSymptomModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // This constructor injects the database context so we can access the children and symptoms tables.
        public LogSymptomModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // This property stores the ID of a child if it was passed through the URL query string.
        // For example, if the user clicked “Log Symptom” from a child’s detail page, we’d receive that child’s ID here.
        [BindProperty(SupportsGet = true)]
        public int? ChildId { get; set; }

        // This is the actual Symptom object that gets bound to the form fields when the user fills them out.
        [BindProperty]
        public Symptom Symptom { get; set; } = new Symptom();

        // This list holds all the children for the dropdown menu in the form.
        public List<SelectListItem> ChildrenOptions { get; set; } = new();

        // This method runs when the page loads (GET request).
        // It builds the dropdown list of children and optionally pre-selects one based on the ChildId.
        public void OnGet()
        {
            ChildrenOptions = _context.Children
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = (ChildId.HasValue && c.Id == ChildId.Value)
                })
                .ToList();

            // If a child ID was passed in, we pre-fill that in the form and also set the symptom date to today.
            if (ChildId.HasValue)
            {
                Symptom.ChildId = ChildId.Value;
                Symptom.DateLogged = DateTime.Today;
            }
        }

        // This method handles the form submission (POST request).
        // It validates the form and either saves the symptom or redisplays the form with errors.
        public IActionResult OnPost()
        {
            // We always rebuild the dropdown so the form keeps the selected value even if validation fails.
            ChildrenOptions = _context.Children
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = (Symptom.ChildId == c.Id)
                })
                .ToList();

            // If the user input fails validation, we return the same page so errors can be shown.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // If the input is valid, we add the new symptom to the database and save it.
            _context.Symptoms.Add(Symptom);
            _context.SaveChanges();

            // Show a success message and redirect back to the homepage.
            TempData["SuccessMessage"] = "Symptom logged successfully!";
            return RedirectToPage("Index");
        }
    }
}

// ==============================================================================
// File: Index.cshtml.cs
// Description: PageModel for the homepage of the Medical Journey Log app.
//              Displays a list of children with links to their detail pages.
// Author: Alex Frear
// Created: July 21, 2025
// ==============================================================================

using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalJourneyLog.Pages;

/// <summary>
/// PageModel for the Index (Home) page.
/// Loads and displays a list of children from the database.
/// </summary>
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor that injects the EF Core DB context.
    /// </summary>
    /// <param name="context">ApplicationDbContext</param>
    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The list of children to display on the home page.
    /// </summary>
    public List<Child> Children { get; set; } = new();

    /// <summary>
    /// Handles GET requests to the home page. Retrieves all children.
    /// </summary>
    public void OnGet()
    {
        Children = _context.Children.ToList();
    }
}

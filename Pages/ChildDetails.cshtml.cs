// ==============================================================================
// File: ChildDetails.cshtml.cs
// ==============================================================================

using MedicalJourneyLog.Data;
using MedicalJourneyLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedicalJourneyLog.Pages
{
    public class ChildDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ChildDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Keep non-nullable; initialize, and only overwrite after a null-check
        public Child Child { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var child = await _context.Children
                .Include(c => c.Symptoms)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (child is null)
                return NotFound();

            Child = child;
            return Page();
        }
    }
}

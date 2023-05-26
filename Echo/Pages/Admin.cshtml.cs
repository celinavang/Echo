using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using Echo.Interfaces;
using Echo.Models;

namespace Echo.Pages
{
    public class AdminModel : PageModel
    {
        private IExhibitRepository catalogue;
        private IArticleRepository articleCatalogue;
        [BindProperty]
        public string? SearchCriteria { get; set; }
        public AdminModel(IExhibitRepository repository, IArticleRepository articleRepository)
        {
            catalogue = repository;
            articleCatalogue = articleRepository;
        }

        public Dictionary<int, Exhibit> Exhibits { get; private set; }

       

        public IActionResult OnPostSearch()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else if (!string.IsNullOrEmpty(SearchCriteria) && SearchCriteria != "0")
            {
                if (catalogue.ExhibitExists(SearchCriteria))
                {
                    Response.Redirect("Edit/" + (SearchCriteria));
                }
                else
                {
                    ModelState.AddModelError("SearchCriteria", "Udstillingen fandtes ikke..");
                    return Page();
                }

            }
            ModelState.AddModelError("SearchCriteria", "Indtast venligst et udstillings nr...");
            return Page();

        }

        public IActionResult OnGet()
        {
            Exhibits = catalogue.AllExhibits();
            if (!string.IsNullOrEmpty(SearchCriteria))
            {
                Exhibits = catalogue.FilterExhibits(SearchCriteria);
            }
            return Page();
        }
    }
}

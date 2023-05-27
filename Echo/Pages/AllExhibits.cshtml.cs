using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using Echo.Interfaces;
using Echo.Models;


namespace Echo.Pages
{
    public class AllExhibitsModel : PageModel
    {
        private IExhibitRepository catalogue;
        private IArticleRepository articleCatalogue;

        [BindProperty]
        public string? SearchCriteria { get; set; }
        public AllExhibitsModel(IExhibitRepository repository, IArticleRepository articleRepository)
        {
            catalogue = repository;
            articleCatalogue = articleRepository;
            Exhibits = catalogue.AllExhibits();
        }

        public Dictionary<int, Exhibit> Exhibits { get; private set; }

        public IActionResult OnGet()
        {
            Exhibits = catalogue.AllExhibits();
            return Page();
        }

        public IActionResult OnPostSort() {
            catalogue.SortBy();
            Exhibits = catalogue.AllExhibits();
            return Page();
        }
        public IActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchCriteria) && SearchCriteria != "0")
            {
                if (catalogue.ExhibitExists(SearchCriteria))
                    {
                        Response.Redirect("ExhibitInfo/" + (SearchCriteria));
                    }else {
                    ModelState.AddModelError("SearchCriteria", "Udstillingen fandtes ikke..");
                    return Page();
                }

            }
            ModelState.AddModelError("SearchCriteria", "Indtast venligst et udstillings nr...");
            return Page();
        }
    }
}


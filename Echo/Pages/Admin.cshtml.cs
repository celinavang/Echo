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
            Exhibits = catalogue.AllExhibits();
        }

        public Dictionary<int, Exhibit> Exhibits { get; private set; }
        public Dictionary<int, Article> Articles { get; private set; }



        public IActionResult OnPostSearch()
        {
            
            if (!string.IsNullOrEmpty(SearchCriteria) && SearchCriteria != "0")
            {
                if (catalogue.ExhibitExists(SearchCriteria))
                {
                    Response.Redirect("ExhibitInfo/" + (SearchCriteria));
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
            Articles = articleCatalogue.AllArticles();

            return Page();
        }
    }
}

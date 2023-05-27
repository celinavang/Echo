using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using Echo.Interfaces;
using Echo.Models;

namespace Echo.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Exhibit Exhibit { get; set; }
        [BindProperty]
        public Article ArticleDa { get; set; }
        [BindProperty]
        public Article ArticleEn { get; set; }

        [BindProperty]
        public string? SearchCriteria { get; set; }
        private IExhibitRepository catalogue;
        private IArticleRepository articleCatalogue;
        public CreateModel(IExhibitRepository repository, IArticleRepository articleRepository)
        {
            catalogue = repository;
            articleCatalogue = articleRepository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
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

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if (catalogue.ExhibitExists(Exhibit.ID))
            {
                ModelState.AddModelError("Exhibit.ID", "En udstilling med dette ID findes allerede ...");
                return Page();
                
            }else if (articleCatalogue.ArticleExists(ArticleDa.Id)){
                ModelState.AddModelError("ArticleDa.Id", "En artikel med dette ID findes allerede ...");
                return Page();
            }else if (articleCatalogue.ArticleExists(ArticleEn.Id))
            {
                ModelState.AddModelError("ArticleEn.Id", "En artikel med dette ID findes allerede ...");
                return Page();
            }

            Exhibit.ArticledaID = ArticleDa.Id;
            Exhibit.ArticleenID = ArticleEn.Id;

            catalogue.AddExhibit(Exhibit);
            articleCatalogue.AddArticle(ArticleDa);
            articleCatalogue.AddArticle(ArticleEn);
            return RedirectToPage("Admin");
        }
    }
}

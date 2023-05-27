using Echo.Interfaces;
using Echo.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Echo.Pages
{
    public class ExhibitInfoModel : PageModel
    {

        [BindProperty]
        public Exhibit Exhibit { get; set; }
        [BindProperty]
        public Article ArticleDa { get; set; }
        [BindProperty]
        public Article ArticleEn { get; set; }
        [BindProperty]
        public string? SearchCriteria { get; set; }

        public string exhibitName;
        public int articleID;
        public string videourl;
        private IExhibitRepository catalogue;
        private IArticleRepository articlecatalogue;
        public ExhibitInfoModel(IExhibitRepository repository, IArticleRepository articleRepository)
        {
            catalogue = repository;
            articlecatalogue = articleRepository;
        }

        public IActionResult Return()
        {
            return RedirectToAction("Index");
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

        public IActionResult OnGet(string id)
        {
            Exhibit = catalogue.GetExhibit(id);
            ArticleDa = articlecatalogue.GetArticle(Exhibit.ArticledaID);
            ArticleEn = articlecatalogue.GetArticle(Exhibit.ArticleenID);
          
            return Page();
        }
    }
}

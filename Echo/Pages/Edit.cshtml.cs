using Echo.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Echo.Interfaces;

namespace Echo.Pages
{
    public class EditModel : PageModel
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
        public EditModel(IExhibitRepository repository, IArticleRepository articleRepository)
        {
            catalogue = repository;
            articleCatalogue = articleRepository;
        }
        public IActionResult OnGet(string id)
        {
             
            Exhibit=catalogue.GetExhibit(id);
            ArticleDa = articleCatalogue.GetArticle(catalogue.GetExhibit(id).ArticledaID);
            ArticleEn =articleCatalogue.GetArticle(catalogue.GetExhibit(id).ArticleenID);
            return Page();

        }
        public IActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchCriteria) && SearchCriteria != "0")
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
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Exhibit.ArticledaID = ArticleDa.Id;
            Exhibit.ArticleenID = ArticleEn.Id;
            catalogue.UpdateExhibit(Exhibit);
            articleCatalogue.UpdateArticle(ArticleDa);
            articleCatalogue.UpdateArticle(ArticleEn);
            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using Echo.Interfaces;
using Echo.Models;


namespace Echo.Pages
{
    public class DeleteModel : PageModel
    {
        private IExhibitRepository catalogue;
        private IArticleRepository articleCatalogue;

        [BindProperty]
        public Exhibit Exhibit { get; set; }
        [BindProperty]
        public Article ArticleDa { get; set; }
        [BindProperty]
        public Article ArticleEn { get; set; }
        [BindProperty]
        public string? SearchCriteria { get; set; }
        public DeleteModel(IExhibitRepository repository, IArticleRepository articleRepository)
        {
            catalogue = repository;
            articleCatalogue = articleRepository;

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
        public IActionResult OnPostDelete(string id)
        {
            articleCatalogue.DeleteArticle(catalogue.GetExhibit(id).ArticledaID);
           
            articleCatalogue.DeleteArticle(catalogue.GetExhibit(id).ArticleenID);

            catalogue.DeleteExhibit(Int32.Parse(id));
           
            return RedirectToPage("AllExhibits");

        }
        public IActionResult OnPostReturn()
        {
            return RedirectToPage("AllExhibits");
        }
        public IActionResult OnGet(string id)
        {
            Exhibit=catalogue.GetExhibit(id);
            ArticleDa=articleCatalogue.GetArticle(Exhibit.ArticledaID);
            ArticleEn=articleCatalogue.GetArticle(Exhibit.ArticleenID);
            return Page();
        }
    }
}

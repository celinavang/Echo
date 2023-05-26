using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using Echo.Models;
using Echo.Interfaces;

namespace Echo.Pages
{
    public class ExhibitModel : PageModel
    {
        [BindProperty]
        public Exhibit Exhibit { get; set; }
        [BindProperty]
        public Article Article { get; set; }

        public string exhibitName;
        public int articleID;
        public string videourl;
        private IExhibitRepository catalogue;
        private IArticleRepository articlecatalogue;
        public ExhibitModel(IExhibitRepository repository, IArticleRepository articleRepository) 
        {
            catalogue = repository;
            articlecatalogue = articleRepository;
        }

        public IActionResult Return()
        {
            return RedirectToAction("Index");
        }
     

        public IActionResult OnGet(string id)
        {
            Exhibit=catalogue.GetExhibit(id);
            if (HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture.ToString() == "da") { exhibitName = Exhibit.Name; articleID = Exhibit.ArticledaID; videourl = Exhibit.Videourl; }
            else
            {
                exhibitName = Exhibit.Nameen;
                articleID = Exhibit.ArticleenID;
                videourl = Exhibit.Videourlen;
            }
            Article=articlecatalogue.GetArticle(articleID);
            return Page();
        }
    }
}

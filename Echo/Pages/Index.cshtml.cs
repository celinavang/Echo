using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Echo.Interfaces;


namespace Echo.Pages
{
    
    public class IndexModel : PageModel
    {

        public IStringLocalizer<IndexModel> localizer;
        private IExhibitRepository catalogue;

         public IndexModel(IExhibitRepository repository, IStringLocalizer<IndexModel> istringlocalizer)
        {
            catalogue= repository;
            localizer = istringlocalizer;
        }

       [BindProperty]
        public string? SearchCriteria { get; set; }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                
                return Page(); }
            else if (!string.IsNullOrEmpty(SearchCriteria) && SearchCriteria != "0")
            {
                if (catalogue.ExhibitExists(SearchCriteria))
                {
                    Response.Redirect("Exhibit/" + (SearchCriteria) + "?culture=" + HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture);
                }
                else
                {
                    ModelState.AddModelError("SearchCriteria", localizer["dangermissing"]);

                    
                    return Page();
                }
                
            }
            ModelState.AddModelError("SearchCriteria", localizer["dangerempty"]);
            return Page();
        }
    }
}
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

# region Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion

namespace WebApp.Pages.SamplePages
{
    public class AlbumsByGenreQueryModel : PageModel
    {
        #region Private variable and DI constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly AlbumServices _albumServices;
        private readonly GenreServices _genreServices;

        public AlbumsByGenreQueryModel(ILogger<IndexModel> logger, 
            AlbumServices albumservices, GenreServices genreServices)
        {
            _logger = logger;
            _albumServices = albumservices;
            _genreServices = genreServices;
        }
        #endregion

        #region FeedBack and ErrorHandling
        [TempData]
        public string FeedBack { get; set; }
        public bool HasFeedBack => !string.IsNullOrEmpty(FeedBack);

        [TempData]
        public string ErrorMsg { get; set; }
        public bool HasErrorMsg => !string.IsNullOrEmpty(ErrorMsg);
        #endregion

        [BindProperty]
        public List<SelectionList> GenreList { get; set; }

        [BindProperty]
        public int GenreId { get; set; }

        public void OnGet()
        {
            GenreList = _genreServices.GetAllGenres();

            // Sort the List<T> using the method .Sort
            GenreList.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));
        }

        public IActionResult OnPost()
        {
            if(GenreId == 0)
            {
                // Prompt line test
                FeedBack = "You did not select a genre";
            }
            else
            {
                FeedBack = $"You selected genre id of {GenreId}";
            }
            return RedirectToPage(); // Causes a GET request which forces OnGet execution
        }
    }
}

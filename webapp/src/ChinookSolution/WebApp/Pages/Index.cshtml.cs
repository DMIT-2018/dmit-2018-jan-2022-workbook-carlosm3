using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

# region Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private variable and DI constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly AboutServices _aboutServices;

        public IndexModel(ILogger<IndexModel> logger, AboutServices aboutservices)
        {
            _logger = logger;
            _aboutServices = aboutservices;
        }
        #endregion

        #region FeedBack and ErrorHandling
        [TempData]
        public string FeedBack { get; set; }
        public bool HasFeedBack => !string.IsNullOrEmpty(FeedBack);
        #endregion

        public void OnGet()
        {
            // Consume a service
            DbVersionInfo info = _aboutServices.GetDbVersion();

            if (info == null)
            {
                FeedBack = "Version unknown";
            }
            else
            {
                FeedBack = $"Version: {info.Major}.{info.Minor}.{info.Build}" + $" Release date of {info.ReleaseDate.ToShortDateString()}";
            }
        }
    }
}
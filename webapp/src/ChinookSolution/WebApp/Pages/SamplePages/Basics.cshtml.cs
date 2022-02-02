using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        // Basically this is an object, treat it as such

        // Data fields
        public string? MyName;

        public void OnGet()
        {
            // Executes in response to a GET request from the browser
            // When the page is first accessed, the browser isssues a GET request
            // When the page is refreshed, WITHOUT a POST reuqest, the broser issues a GET request
            // When the page is retrieved in response to a form;s POST using a RedirectToPage()
            // IF NOT RedirectToPage() is used on the POST, there is NO GET request issued

            // Server-side processing
            // Containes no HTML

            Random rnd = new Random();
            int oddeven = rnd.Next(0,25);
            if(oddeven % 2 == 0)
            {
                MyName = $"Carlos is even {oddeven}";
            }
            else
            {
                MyName = null;
            }
        }
    }
}

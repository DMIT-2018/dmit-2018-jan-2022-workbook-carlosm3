using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        // Basically this is an object, treat it as such

        // Data fields
        public string? MyName;

        // Properties

        // The annotation [TempData] stores data until it's read in another immediate request
        // This annotation attribute has two methods called Keep(string) and Peek(string) (used on content page)
        // Kept in a dictionary (name/value pair)
        // Usuful to redirect when data is required for more than a single request
        // Implemented by TempData providers using either cookies or session state
        // TempData is NOT bound to any particular control like BindProperty
        [TempData]
        public string FeedBack { get; set; }

        // The annotation BindProperty ties a property in the PageModel class directly to a
        // control on the Content Page.
        // Data is transferred between the two automatically
        // On the Content Page, the control to use this property will have a helper-tag called asp

        // To retain a value in the control tied to this property AND retained via the @page
        //      use the SupportsGet attribute = true
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

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

        // Processing in response to a request from a form on a web page
        // This request is referred to as a Post (method="post")

        // General Post
        // A general post occurs when a asp-page-handler is NOT used
        // The return datatype can be void, however, you will normally encounter the datatype by IActionResutl
        // The IActionResult requires some type of request action on the return statement of the method OnPost()
        // Typical actions:
        //      Page()
        //          - Does NOT issue an OnGet request
        //          - Remains on the current page
        //          - A good action for form processing involving validation and with the catch of a try/catch
        //      RedirectToPage()
        //          - DOES issue an OnGet request
        //          - Is also used to retain input values via the @page and your BindProperty
        //                  from controls on your form on the Content Page

        public IActionResult OnPost()
        {
            // This line of code is used to cause a delay in processing so we can see on the Network Activity some type
            //      of emulated processing
            Thread.Sleep(2000);

            // Retrieve data via the Request Object
            // Request: web page -> server
            // Response: server -> web page
            string buttonvalue = Request.Form["theButton"];
            FeedBack = $"Button press is {buttonvalue} with numberic input of {id}";

            // return Page(); // does not issue and OnGet()
            return RedirectToPage(new {id = id}); // request for OnGet()
        }
    }
}

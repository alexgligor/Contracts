using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Contracts.Pages
{
    public class ContactModel : PageModel
    {
        IMessagesService messagesService;

        public ContactModel(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var message = Request.Form["message"];

            messagesService.Add(new Messages() { Name = name, Email = email, Message = message, Created = DateTime.Now });
            
            return Redirect("/Index");
        }
    }
}

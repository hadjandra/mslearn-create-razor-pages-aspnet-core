using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Pages
{
    public class PizzaListModel: PageModel
    {
        [BindProperty]
        public Pizza Newpizza { get; set; } = default!;
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList= _service.GetPizzas();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid || Newpizza==null)
            {
                return Page();
            }

            _service.AddPizza(Newpizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id) 
        {
            _service.DeletePizza(id);

            return RedirectToAction("Get");
        }
    }
}

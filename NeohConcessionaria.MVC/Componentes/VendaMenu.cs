
using Microsoft.AspNetCore.Mvc;

namespace NeohConcessionaria.MVC.Componentes
{
    public class VendaMenu:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        } 
    }
}


using Microsoft.AspNetCore.Mvc;

namespace NeohConcessionaria.MVC.Componentes
{
    public class FabricanteMenu:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        } 
    }
}

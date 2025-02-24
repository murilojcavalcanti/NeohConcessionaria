
using Microsoft.AspNetCore.Mvc;

namespace NeohConcessionaria.MVC.Componentes
{
    public class VeiculoMenu:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        } 
    }
}

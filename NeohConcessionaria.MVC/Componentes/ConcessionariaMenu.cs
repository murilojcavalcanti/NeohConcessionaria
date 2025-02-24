
using Microsoft.AspNetCore.Mvc;

namespace NeohConcessionaria.MVC.Componentes
{
    public class ConcessionariaMenu:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        } 
    }
}

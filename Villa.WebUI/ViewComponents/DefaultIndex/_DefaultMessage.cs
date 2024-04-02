using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultMessage : ViewComponent
    {
        public IViewComponentResult Invoke()
            { return View(); }
    }
}

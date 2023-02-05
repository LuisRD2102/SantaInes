using Microsoft.AspNetCore.Mvc;

namespace SantaInesWEB.Controllers
{
    public class ItinerariosController : Controller
    {
        public async Task<IActionResult> GestionItinerarios()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
}

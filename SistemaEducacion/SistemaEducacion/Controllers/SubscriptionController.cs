using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.Models;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Controllers
{
    public class SubscriptionController(ISubscription _suscriptionModel, IHostEnvironment _environment) : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var resp = _suscriptionModel.ListSubscriptions();

            if (resp?.Code != "00")
            {
                return View(resp!.Data);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Message;
                return View(new List<SubscriptionController>());
            }
        }
    }
}

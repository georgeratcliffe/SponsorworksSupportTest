using System.Web.Mvc;
using System.Threading.Tasks;

namespace SupportEngineerTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<ActionResult> Helpdesk()
        {
			await Task.CompletedTask;
			return View();
        }
    }
}

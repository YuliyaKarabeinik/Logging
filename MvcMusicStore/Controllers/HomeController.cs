using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.PerformanceCounters;
using NLog;
using PerformanceCounterHelper;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        static CounterHelper<Counters> counterHelper;

        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();
        
        public HomeController(ILogger logger)
        {
            this.logger = logger;
            counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Test project");
        }

        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            logger.Info("Home page is opened.");

            counterHelper.Increment(Counters.GoToHome);

            return View(await _storeContext.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
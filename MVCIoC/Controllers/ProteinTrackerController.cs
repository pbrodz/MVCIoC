using System.Web.Mvc;
using MVCIoC.Models;

namespace MVCIoC.Controllers
{
    public class ProteinTrackerController : Controller
    {

        //This controller depends on the concrete instance of the ProteinTrackingService
        //This is a problem because then this inherits all of the dependencies that the ProteinTrackingService has (e.g. if it has
        //a reference to a Repository within it, then oops this Controller now has a dependency on that too!
        //So, we need to break this dependency, enter IoC!
        //Easiest way to do this is to make thie concrete ProteinTrackingService an Interface
        //Once we use Resharper to Extract the Interface to a new file, we just hve this Controller use the IProteinTrackingService
        //instead of the actual ProteinTrackingService.

        //Lets change the origianl concrete to use an Interface and create a constructor
        //private ProteinTrackingService _proteinModel = new ProteinTrackingService(); //ORIGINAL
        private readonly IProteinTrackingService _proteinModel;

        public ProteinTrackerController(IProteinTrackingService proteinModel)
        {
            //we're saying that this class depends on a ProteinTrackingService - I mean, something has to pass that in to this constructor
            //otherwise it won't get initialized and used, right?
            _proteinModel = proteinModel;
        }

        // GET: ProteinTracker
        public ActionResult Index()
        {
            ViewBag.Total = _proteinModel.Total;
            return View();
        }

        public ActionResult AddProtein(int proteinGrams)
        {
            _proteinModel.AddProtein(proteinGrams);
            return View("Index");
        }
    }
}
using System.IO;
using System.Web.Mvc;

using FileEncryption.WebApp;

namespace PgpTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var pathInput = Server.MapPath("~/App_Data/Image.png");
            var pathOutput = Server.MapPath("~/App_Data/data.png");
            var pathDecrypted = Server.MapPath("~/App_Data/after.png");
            var key = "123456789098765432125432124654567";
            FileEncryptionHelper.Encrypt(pathInput, pathOutput, key);
            FileEncryptionHelper.Decrypt(pathOutput, pathDecrypted, key);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
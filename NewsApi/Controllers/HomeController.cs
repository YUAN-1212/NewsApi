using Application.Home;
using System.Web.Mvc;

namespace NewsApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 取得下拉式選單資料
        /// </summary>
        /// <param name="currency">以哪國貨幣為基準，初始或是空值時以台灣TWD為準</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getDDLCurrencyData()
        {
            var data = EFHomeRepository.getCurrencyDto();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="currency">以哪國貨幣為基準，初始或是空值時以台灣TWD為準</param>
        /// <returns></returns>
        [HttpPost]        
        public JsonResult getData(string currency)
        {          
            var data = EFHomeRepository.getData(currency);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
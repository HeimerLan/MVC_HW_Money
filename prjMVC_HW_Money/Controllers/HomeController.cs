using prjMVC_HW_Money.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace prjMVC_HW_Money.Controllers
{
    public class HomeController : Controller
    {
        //建立KeepingAccountService的物件並調用方法，取得List
        public ActionResult Index(int Page = 1)
        {
            KeepingAccountService KeepingAccount = new KeepingAccountService();

            var ShowList = KeepingAccount.GetAllData();

            //使用PagedList
            int PageSize = 100;
            int PageCurrent = Page < 1 ? 1 : Page;
            var PagedList = ShowList.ToPagedList(PageCurrent,PageSize);

            return View(PagedList);
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

        [HttpPost]
        public ActionResult Create(String category, String date, int money, String description)
        {
            KeepingAccountService KeepingAccount = new KeepingAccountService();
            KeepingAccount.Create(category, date, money, description);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String Page)
        {
            int Order = Convert.ToInt32(Page)-1;
            //System.Diagnostics.Debug.WriteLine("order================="+Page);
            KeepingAccountService KeepingAccount = new KeepingAccountService();
            KeepingAccount.Delete(Order);
            return RedirectToAction("Index");
        }

    }
}
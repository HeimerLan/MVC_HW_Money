using prjMVC_HW_Money.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjMVC_HW_Money.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Random Random = new Random();
            KeepingAccountViewModel KeepingAccount = null;
            var KeepingAccountResult = new List<KeepingAccountViewModel>();

            for (int i = 1; i <= 100; i++)
            {
                //隨機產生數值1或2
                int RandomType = Random.Next(1, 3);
                String TempType = "";

                //1為收入，2為支出
                if (RandomType == 1)
                    TempType = "收入";
                else
                    TempType = "支出";

                //隨機產生金額，50~5000之間
                int RandomAmount = Random.Next(50, 5001);

                //從2019/01/01開始100天
                DateTime _Date = new DateTime(2018, 12, 31);

                //產生的資料暫存於Model中，在Index裡依序提取出來列表
                KeepingAccount = new KeepingAccountViewModel
                {
                    No = i,
                    Type = TempType,
                    Date = _Date.AddDays(i).ToString("yyyy-MM-dd"),
                    Amount = RandomAmount.ToString("N0")
                };

                KeepingAccountResult.Add(KeepingAccount);

            }

            return View(KeepingAccountResult);
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
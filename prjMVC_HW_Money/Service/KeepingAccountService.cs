using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjMVC_HW_Money.Repository;
using prjMVC_HW_Money.Models.ViewModel;

namespace prjMVC_HW_Money.Service
{
    //暫時未做Interface
    public class KeepingAccountService
    {
        AccountBookRepository _GetAllData = new AccountBookRepository();

        KeepingAccountViewModel KeepingAccount = null;

        public List<KeepingAccountViewModel> GetAllData()
        {
            var KeepingAccountResult = new List<KeepingAccountViewModel>();

            var result = _GetAllData.GetAllData();
            int len = result.Count();

            for (int i = 0; i < len; i++)
            {
                //因ViewModel的No原始設計為int，因此Guid類型的Id不與其他資料一起存在ViewModel，之後會再處理
                Guid Id = result[i].Id;
                String _Id = result[i].Id.ToString();

                //0為收入，1為支出
                int TypeNum = result[i].Categoryyy;
                String TypeStr = "";
                if (TypeNum == 0)
                    TypeStr = "收入";
                else
                    TypeStr = "支出";

                //轉換為文字
                DateTime date = result[i].Dateee;
                String _date = date.ToString("yyyy-MM-dd");

                //轉換為文字，並且千分位處理
                int amount = result[i].Amounttt;
                String _amount = amount.ToString("N0");

                //資料暫存於Model中，在Index裡依序提取出來列表
                KeepingAccount = new KeepingAccountViewModel
                {
                    No = i+1,
                    Type = TypeStr,
                    Date = _date,
                    Amount = _amount
                };

                KeepingAccountResult.Add(KeepingAccount);

            }

            return KeepingAccountResult;
        }
    }
}
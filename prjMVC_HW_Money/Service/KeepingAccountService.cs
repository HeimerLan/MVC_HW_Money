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

        //List<Guid> GuidList = new List<Guid>();

        public List<KeepingAccountViewModel> GetAllData()
        {
            var KeepingAccountResult = new List<KeepingAccountViewModel>();

            var result = _GetAllData.GetAllData();
            int len = result.Count();

            int TypeNum;
            String TypeStr;
            DateTime date;
            String _date;
            int amount;
            String _amount;

            for (int i = 0; i < len; i++)
            {
                //0為收入，1為支出
                TypeNum = result[i].Categoryyy;
                TypeStr = "";
                if (TypeNum == 0)
                    TypeStr = "收入";
                else
                    TypeStr = "支出";

                //轉換為文字
                date = result[i].Dateee;
                _date = date.ToString("yyyy-MM-dd");

                //轉換為文字，並且千分位處理
                amount = result[i].Amounttt;
                _amount = amount.ToString("N0");

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

        public void Create(String Category, String Date, int Amount, String Remark)
        {
            Guid Id = Guid.NewGuid();
            int Categoryyy;
            DateTime Dateee;
            String Remarkkk;

            if (Remark == "" || Remark == null)
                Remarkkk = "test";
            else
                Remarkkk = Remark;

            if (Category == "收入")
                Categoryyy = 0;
            else
                Categoryyy = 1;

            Dateee = DateTime.ParseExact(Date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);

            AccountBookRepository _CreateData = new AccountBookRepository();
            _CreateData.Create(Id, Categoryyy, Dateee, Amount, Remarkkk);
        }

        public void Delete(int order)
        {
            AccountBookRepository _DeleteData = new AccountBookRepository();

            //因ViewModel的No原始設計為int，因此Guid類型的Id不與其他資料一起存在ViewModel
            List<Guid> GuidList = new List<Guid>();

            var result = _DeleteData.GetAllGuid();
            int len = result.Count();
            Guid Id;

            for (int i = 0; i < len; i++)
            {
                Id = result[i].Id;
                GuidList.Add(Id);
            }

            Guid _Id = GuidList[order];
            _DeleteData.Delete(_Id);
        }
    }
}
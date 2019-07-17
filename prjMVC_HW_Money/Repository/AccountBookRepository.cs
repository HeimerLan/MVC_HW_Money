using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjMVC_HW_Money.Models.DataModel;

namespace prjMVC_HW_Money.Repository
{
    public class AccountBookRepository
    {
        //AccountBook db = new AccountBook();
        SkillTreeHomeworkEntities1 db = new SkillTreeHomeworkEntities1();
        
        public List<AccountBook> GetAllData()
        {
            var Data = db.AccountBook.OrderBy(m => m.Dateee).ToList();
            return Data;
        }

        //public Guid GetDataId()
        //{
        //    Guid result = db.Id;
        //    return result;
        //}

        //public int GetDataCategoryyy()
        //{
        //    int result = db.Categoryyy;
        //    return result;
        //}

        //public DateTime GetDataDateee()
        //{
        //    DateTime result = db.Dateee;
        //    return result;
        //}

        //public int GetDataAmounttt()
        //{
        //    int result = db.Amounttt;
        //    return result;
        //}

    }
}
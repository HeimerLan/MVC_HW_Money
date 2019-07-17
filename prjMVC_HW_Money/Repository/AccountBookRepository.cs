using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjMVC_HW_Money.Models.DataModel;

namespace prjMVC_HW_Money.Repository
{
    //暫時未做Interface
    public class AccountBookRepository
    {
        SkillTreeHomeworkEntities1 db = new SkillTreeHomeworkEntities1();
        
        public List<AccountBook> GetAllData()
        {
            var Data = db.AccountBook.OrderBy(m => m.Dateee).ToList();
            return Data;
        }

    }
}
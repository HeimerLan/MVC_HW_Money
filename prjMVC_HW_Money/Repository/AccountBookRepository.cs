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

        public List<AccountBook> GetAllGuid()
        {
            var Data = db.AccountBook.Select(Id => Id).OrderBy(m => m.Dateee).ToList();
            return Data;
        }

        public void Create(Guid Id, int Category, DateTime Date, int Amount, String Remark)
        {
            AccountBook Data = new AccountBook
            {
                Id = Id,
                Categoryyy = Category,
                Dateee = Date,
                Amounttt = Amount,
                Remarkkk = Remark
            };
            db.AccountBook.Add(Data);
            db.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var Data = db.AccountBook.Where(m => m.Id == Id).FirstOrDefault();
            db.AccountBook.Remove(Data);
            db.SaveChanges();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMVC_HW_Money.Models
{
    public class KeepingAccountViewModel
    {
        public int No { get; set; }
        public int TypeNum { get; set; }

        //1表示為收入，2表示為支出
        public string Type
        {
            get
            {
                if(this.TypeNum == 1)
                    return "收入";
                else
                    return "支出";
            }
        }
        public String Date { get; set; }
        public String Amount { get; set; }
    }


}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quan.UI.Models
{
    
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string WID { get; set; } //对应微信ID
        public int Jifen { get; set; }//积分


    }
}
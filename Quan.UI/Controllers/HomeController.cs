using Quan.UI.EF;
using Quan.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Quan.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            QuanDbContext db = new QuanDbContext();

            User a = new User();
            a.Jifen = 100;
            a.UserName = "admin";
            a.WID = "wid";

            db.Users.Add(a);

            db.SaveChanges();

           

            if (!string.IsNullOrEmpty(Request["echoStr"]))
            {
                var echostr = Request["echoStr"];
                if (CheckSignature() && !string.IsNullOrEmpty(echostr))
                {
                    Response.Write(echostr);//推送  

                    Response.End();
                }
            }
            return View();
        }

        public bool CheckSignature()
        {
            var signature = Request["signature"];
            var timestamp = Request["timestamp"];
            var nonce = Request["nonce"];
            var token = "Quan2018";
            string[] ArrTmp = { token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序  
            string tmpStr = string.Join("", ArrTmp);
           // tmpStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");

            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(tmpStr));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            tmpStr = sh1;
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
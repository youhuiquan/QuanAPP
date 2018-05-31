using Quan.UI.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quan.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoTaskAttribute.RegisterTask();//注册全局定时服务
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        // 添加Application_End 方法,解决IIS应用程序池自动回收的问题
        protected void Application_End(object sender, EventArgs e)
        {
            //下面的代码是关键，可解决IIS应用程序池自动回收的问题
            Thread.Sleep(1000);
            //这里设置你的web地址，可以随便指向你的任意一个aspx页面甚至不存在的页面，目的是要激发Application_Start <br>　　　　　　　//我这里是一个验证token的地址。
            string url = System.Configuration.ConfigurationManager.AppSettings["tokenurl"];
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流
        }
    }
}

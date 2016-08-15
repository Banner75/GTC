using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSXML2;

namespace ZGZY.Common
{
   public class PhoneCode
    {
       public static string name = "cy1234";
       public static string PWD = "woaini1314";

       /// <summary>
       /// 查询短信接口余额
       /// </summary>
       /// <returns></returns>
       public static string CheckedMoney()
       {
           string uid = name;
           string pwd = PWD;

           string Send_URL = "http://service.winic.org/webservice/public/remoney.asp?uid=" + uid + "&pwd=" + pwd + "";

           //____________________________

           XMLHTTP xmlhttp = new XMLHTTP();
           xmlhttp.open("GET", Send_URL, false, null, null);
           xmlhttp.send("");
           XMLDocument dom = new XMLDocument();
           Byte[] b = (Byte[])xmlhttp.responseBody;
           //string Flag = System.Text.ASCIIEncoding.UTF8.GetString(b, 0, b.Length);
           string andy = System.Text.Encoding.GetEncoding("GB2312").GetString(b).Trim();
           return andy;
       }

       /// <summary>
       /// 发送手机验证码信息
       /// </summary>
       /// <param name="mobile"></param>
       /// <param name="Message"></param>
       /// <param name="code"></param>
       /// <returns></returns>
       public static string SendMessage(string mobile,out string code)
       {
           string uid = name;
           string pwd = PWD;
           string mob = mobile;
           code = Utils.Number(4, true);
           string msg = "您的短信随机码是：" + code;
           string Send_URL = "http://service.winic.org/sys_port/gateway/?id=" + uid + "&pwd=" + pwd + "&to=" + mob + "&content=" + msg + "&time=";
           XMLHTTP xmlhttp = new XMLHTTP();
           xmlhttp.open("GET", Send_URL, false, null, null);
           xmlhttp.send("");
           XMLDocument dom = new XMLDocument();
           Byte[] b = (Byte[])xmlhttp.responseBody;
           string andy = System.Text.Encoding.GetEncoding("GB2312").GetString(b).Trim();
           return andy;
       }

       /// <summary>
       /// 发送手机验证码信息
       /// </summary>
       /// <param name="mobile"></param>
       /// <param name="Message"></param>
       /// <param name="code"></param>
       /// <returns></returns>
       public static string SendMessage(string mobile,string Messager)
       {
           string uid = name;
           string pwd = PWD;
           string mob = mobile;           
           string msg = Messager;
           string Send_URL = "http://service.winic.org/sys_port/gateway/?id=" + uid + "&pwd=" + pwd + "&to=" + mob + "&content=" + msg + "&time=";
           XMLHTTP xmlhttp = new XMLHTTP();
           xmlhttp.open("GET", Send_URL, false, null, null);
           xmlhttp.send("");
           XMLDocument dom = new XMLDocument();
           Byte[] b = (Byte[])xmlhttp.responseBody;
           string andy = System.Text.Encoding.GetEncoding("GB2312").GetString(b).Trim();
           return andy;
       }
    }
  
}

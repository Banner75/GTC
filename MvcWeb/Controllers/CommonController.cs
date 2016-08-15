using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
     /// 重制版人员：DeanWinchester
    public class CommonController : Controller
    {
        #region 生成验证码

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            string code = string.Empty;
            int codeLeng = 4;

            // 颜色列表，用于验证码、噪线、噪点
            Color[] color = {  Color.Red, Color.Blue, Color.Green };

            // 字体列表，用于验证码
            string[] font = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };

            // 验证码的字符集，去掉了一些容易混淆的字符
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            
            Random rnd = new Random();
            
            // 生成验证码字符串
            for (int i = 0; i < codeLeng; i++)
            {
                code += character[rnd.Next(character.Length)];
            }

            // 保存校验码数字到Session中
            Session["ValidateCode"] = code;

            Bitmap bmp = new Bitmap(100, 40);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(253, 240, 242));

            // 画噪线
            for (int i = 0; i < 6; i++)
            {
                int x1 = rnd.Next(100);
                int y1 = rnd.Next(40);
                int x2 = rnd.Next(100);
                int y2 = rnd.Next(40);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }

            // 画验证码字符串
            for (int i = 0; i < code.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, 16);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawString(code[i].ToString(), ft, new SolidBrush(clr), (float)i * 20 + 8, (float)8);
            }

            // 画噪点
            for (int i = 0; i < 50; i++)
            {
                int x = rnd.Next(bmp.Width);
                int y = rnd.Next(bmp.Height);
                Color clr = color[rnd.Next(color.Length)];
                bmp.SetPixel(x, y, clr);
            }

            // 清除该页输出缓存，设置该页无缓存

            // 将验证码图片写入内存流，并将其以 "image/Png" 格式输出
            MemoryStream ms = new MemoryStream();

            try
            {
                bmp.Save(ms, ImageFormat.Png);
                return File(ms.ToArray(), "image/gif");

            }
            finally
            {
                // 显式释放资源
                bmp.Dispose();
                g.Dispose();
            }
        }

        #endregion
    }
}

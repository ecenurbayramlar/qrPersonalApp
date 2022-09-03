using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using deneme.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deneme.Controllers
{
    public class CreateController : Controller
    {

        // GET: /<controller>/
        DbService dbService = new DbService();
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Index(string nameText, string lastNameText, string tcText, string telNoText)
        {
            byte[] byteQr;
            bool control = true;
            List<Personal> list = dbService.GetPersonals();

            foreach (var a in list)
            {
                if (a.tc == tcText)
                {
                    control = false;
                }
            }

            if (control == true)
            {
                dbService.AddPersonal(new Personal
                {
                    name = nameText,
                    lastName = lastNameText,
                    tc = tcText,
                    tel = telNoText
                });


                List<Personal> list2 = dbService.GetPersonals();

                foreach (var x in list2)
                {
                    if (x.tc==tcText)
                    {
                        string idQRData = x.id.ToString();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(idQRData, QRCodeGenerator.ECCLevel.Q);
                            QRCode oQRCode = new QRCode(qRCodeData);
                            using (Bitmap oBitmap = oQRCode.GetGraphic(20))
                            {
                                oBitmap.Save(ms, ImageFormat.Png);
                                ViewBag.QRCode = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                                byteQr = ImageToByteArray(oBitmap);
                            }
                        }


                        dbService.AddQr(new Qr
                        {
                            perId = x.id,
                            qrByte = byteQr
                        });
                    }
                }

                ViewBag.control = true;
            }
            else
            {
                ViewBag.control = false;
            }

            
            ViewBag.nameTxt = nameText;
            ViewBag.lastNameTxt = lastNameText;
            ViewBag.tcTxt = tcText;
            ViewBag.telNoTxt = telNoText;

            

            return View();
        }



        public static byte[] ImageToByteArray(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

    }
}







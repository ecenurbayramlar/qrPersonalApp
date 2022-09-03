using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using deneme.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deneme.Controllers
{
    public class PersonelController : Controller
    {
        
        DbService dbservice = new DbService();
        Context context = new Context();
        // GET: /<controller>/
        public IActionResult List_Personel()
        {
            PersonelModel modelList = new PersonelModel();
            List<Personal> listPersonal = dbservice.GetPersonals();
            List<Qr> listQr = dbservice.GetQrs();
            modelList.personel = listPersonal;
            modelList.qr = listQr;
            return View(modelList);
        }


        
        public IActionResult Delete_Personal(int id)
        {
            var per = context.personals.Find(id);
            List<Qr> listQrDelete = context.qrs.ToList();
            foreach (var i in listQrDelete)
            {
                if (i.id==per.id)
                {
                    context.qrs.Remove(i);
                }
            }
            context.personals.Remove(per);
            context.SaveChanges();
            return RedirectToAction("List_Personel");
        }
    }
}




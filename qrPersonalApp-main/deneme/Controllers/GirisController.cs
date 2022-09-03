using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deneme.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deneme.Controllers
{
    public class GirisController : Controller
    {
        DbService db = new DbService();


        public IActionResult Home()
        {
            return View();
        }



        public IActionResult SaveTime(int id)
        {
            
            List<Personal> listPer = db.GetPersonals();
            foreach (var a in listPer)
            {
                if (a.id==id)
                {
                    if (a.state==false)
                    {
                        db.AddInTime(new Intime
                        {
                            perId = a.id,
                            time = DateTime.Now
                        });
                        db.UpdateState(a);
                    }
                    else
                    {
                        db.AddOutTime(new Outtime
                        {
                            perId=a.id,
                            time=DateTime.Now
                        });
                        db.UpdateState(a);
                    }
                }
            }
            return RedirectToAction("Home");
        }
    }
}

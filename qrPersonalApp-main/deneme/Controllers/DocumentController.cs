using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace deneme.Controllers
{
    public class DocumentController : Controller
    {
        DbService db = new DbService();

        public IActionResult Documents()
        {
            List<Personal> perList = db.GetPersonals();
            return View(new PersonelModel()
            {
                personel = perList,
            });
        }


        [HttpPost]
        public IActionResult Documents(string selectedDate,  int selectedPersonal, string selectedDate2)
        {
            if (selectedDate != null && selectedDate2 != null && selectedPersonal != 0)
            {
                int selectedPerId = Convert.ToInt32(selectedPersonal);
                ViewBag.date = "Selected Date: " + selectedDate;

                List<Personal> perList = db.GetPersonals();
                List<DocumentModelView> choosenPer = db.FilterPersonal(selectedPerId, selectedDate, selectedDate2);
                return View(new PersonelModel()
                {
                    personel = perList,
                    ali=choosenPer
                });
            }
            else
            {
                return View();
            }
        }
    }
}

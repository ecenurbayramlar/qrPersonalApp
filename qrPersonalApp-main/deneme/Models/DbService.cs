using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace deneme.Models
{
    public class DbService
    {
        Context c = new Context();

        public List<Personal> GetPersonals()
        {
            List<Personal> list = c.personals.ToList();
            return list;
        }

        public void AddPersonal(Personal personal)
        {
            c.personals.Add(personal);
            c.SaveChanges();
        }

        public void AddQr(Qr qr)
        {
            c.qrs.Add(qr);
            c.SaveChanges();
        }

        public List<Qr> GetQrs()
        {
            List<Qr> lisQr = c.qrs.ToList();
            return lisQr;
        }

        public void AddInTime(Intime intime)
        {
            c.intimes.Add(intime);
            c.SaveChanges();
        }

        public void AddOutTime(Outtime outtime)
        {
            c.outtimes.Add(outtime);
            c.SaveChanges();
        }

        public void UpdateState(Personal per)
        {
            if (per.state==true)
            {
                per.state = false;
            }
            else
            {
                per.state = true;
            }
            c.Entry(per).Property("state").IsModified = true;
            c.SaveChanges();
        }

        public List<DocumentModelView> FilterPersonal(int id, string date, string date2)
        {

            date2 += " 23:59:59.474473";
            date += " 00:00:00.474473";


            DateTime myDate = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss.ffffff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            DateTime myDate2 = DateTime.ParseExact(date2, "yyyy-MM-dd HH:mm:ss.ffffff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            var girisTarihleri = c.intimes.Where(p => p.perId == id && (p.time <= myDate2) && (p.time >= myDate))
                                    .Select(p => p.time).ToList();

            
            girisTarihleri.Sort();
            girisTarihleri.Reverse();

           

            var cikisTarihleri = c.outtimes.Where(p => p.perId == id && (p.time <= myDate2) && (p.time >= myDate))
                                    .Select(p => p.time).ToList();

            cikisTarihleri.Sort();
            cikisTarihleri.Reverse();

            Personal choosenPer = c.personals.Where(p => p.id == id).FirstOrDefault();

           
            List<DocumentModelView> listem2 = new List<DocumentModelView>();
            for (int i = 0; i < girisTarihleri.Count; i++)
            {
                //string sal = ((cikisTarihleri[i] - girisTarihleri[i]).TotalMinutes * 0.39351852).ToString();
                //float salary = float.Parse(sal, CultureInfo.InvariantCulture.NumberFormat);

                listem2.Add(new DocumentModelView
                {
                    name=choosenPer.name,
                    lastName=choosenPer.lastName,
                    giris=girisTarihleri[i],
                    cikis=cikisTarihleri[i],
                    sure=(cikisTarihleri[i]-girisTarihleri[i]).ToString(),
                    maas="165.2324 TL"
                });
            }
            return listem2;
        }
    }
}

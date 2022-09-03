using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace deneme.Models
{
    public class PersonelModel
    {
        public List<Personal> personel { get; set; }
        public List<Qr> qr { get; set; }
        public DocumentModelView perDoc { get; set; }
        public List<DocumentModelView> ali { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace deneme.Models
{
    public class Qr
    {
        [Key]
        public int id { get; set; }
        public int perId { get; set; }
        public byte[] qrByte { get; set; }
    }
}

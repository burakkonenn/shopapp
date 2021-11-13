using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.webui.Models
{
    public class RegisterModel
    {
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string SifreTekrarı { get; set; }
        public string CepTelefonu { get; set; }
        public string KullanıcıAdı { get; set; }
        
        
    }
}
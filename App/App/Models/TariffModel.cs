using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class TariffModel
    {
        public int TariffId { get; set; }
        public int ProviderId { get; set; }
        public string Speed { get; set; }
        public string Cost { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiModels.Models
{
    public class Tariff
    {
        public string TariffId { get; set; }
        public string Provider { get; set; }
        public string Speed { get; set; }
        public string Cost { get; set; }
    }
}

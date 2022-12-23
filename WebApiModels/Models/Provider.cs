using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiModels.Models
{
    public class Provider
    {
        public string ProviderId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}

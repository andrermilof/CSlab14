using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiModels.Models
{
    public class Region
    {
        public string RegionId { get; set; }
        public string Provider { get; set; }
        public string Name { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolaczenieZbaza.Models
{
    [Keyless]
    public partial class LodówkaDTO
    {
        public string nazwa { get; set; }

        public decimal? ilosc_skladnika { get; set; }

        public string przelicznik { get; set; }


    }
}

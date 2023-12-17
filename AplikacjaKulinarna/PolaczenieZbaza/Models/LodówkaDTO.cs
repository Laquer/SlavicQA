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
        public string NazwaSkladnika { get; set; }

        public decimal? IloscSkladnika { get; set; }

        public string PrzelicznikSkladnika { get; set; }


    }
}

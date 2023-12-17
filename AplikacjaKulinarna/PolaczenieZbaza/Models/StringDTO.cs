using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PolaczenieZbaza.Models
{
    [Keyless]
    public partial class StringDTO
    {
        public string nazwa { get; set; }
   
    }
}

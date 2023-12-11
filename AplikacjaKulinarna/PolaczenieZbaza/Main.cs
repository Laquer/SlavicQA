using Microsoft.EntityFrameworkCore;
using PolaczenieZbaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolaczenieZbaza
{
    internal class Main
    {
        LodówkaAppContext context = new LodówkaAppContext();

        List<String> ListaSkladnikow()
        {

            var result = context.StringDTOs.FromSqlRaw("SELECT nazwa from Skladnik");
            var wynikiString = result.Select(dto => dto.StringProperty).ToList();

            return wynikiString;
        }
    }
}

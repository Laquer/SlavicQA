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

            var result = context.StringDTOs.FromSqlRaw("SELECT s.nazwa, l.ilosc_skladnika, s.przelicznik FROM Lodowki l JOIN Skladnik s ON l.id_skladnika = s.id_skladnika;");
            var wynikiString = result.Select(dto => dto.StringProperty).ToList();

            return wynikiString;
        }
        
    }
}

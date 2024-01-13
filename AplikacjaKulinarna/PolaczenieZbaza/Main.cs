using Microsoft.EntityFrameworkCore;
using PolaczenieZbaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolaczenieZbaza
{
    public class Main
    {
        
        static LodówkaAppContext context = new LodówkaAppContext();

        public static List<String> ListaSkladnikow()
        {
            var result = context.StringDTOs.FromSqlRaw("SELECT nazwa FROM Skladnik");
            var wynikiString = result.Select(dto => dto.nazwa).ToList();
            return wynikiString;
        }

public static List<LodówkaDTO> SkladLodowki()
        { 
            var skladlodówki = context.LodówkaDTOs.FromSqlRaw("SELECT s.nazwa, l.ilosc_skladnika, s.przelicznik FROM Lodowki l JOIN Skladnik s ON l.id_skladnika = s.id_skladnika;").ToList();          
            return skladlodówki;
        }

    }
}

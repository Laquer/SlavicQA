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

            //throw new Exception("chuj");
        }


        //public static List<String> SkladLodowki()
        public static (List<String>,List<decimal?>,List<String>) SkladLodowki()
        {

            var result = context.LodówkaDTOs.FromSqlRaw("SELECT s.nazwa, l.ilosc_skladnika, s.przelicznik FROM Lodowki l JOIN Skladnik s ON l.id_skladnika = s.id_skladnika");
            var NazwaSkladnika = result.Select(dto => dto.nazwa).ToList();
            var IloscSkladnika = result.Select(dto => dto.ilosc_skladnika).ToList();
             var PrzelicznikSkladnika = result.Select(dto => dto.przelicznik).ToList();

            //return (NazwaSkladnika);

            return (NazwaSkladnika,IloscSkladnika,PrzelicznikSkladnika);
        }

    }
}

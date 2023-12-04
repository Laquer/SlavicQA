using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolaczenieZbaza;

namespace LogikaProgramu
{
    internal class BasicInterfejsConnection : IInterfejs
    {
        public static ILogika Logika;

        public List<string> DejMiPrzepisy()
        {
            return Logika.DejMiPrzepisy();
        }

        public void PobierzDane()
        {
            throw new NotImplementedException();
        }
    }
}

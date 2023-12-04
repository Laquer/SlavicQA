using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolaczenieZbaza
{
    public interface ILogika
    {
        void PobierzDane();

        List<String> DejMiPrzepisy();
    }
}

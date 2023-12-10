using System;
using System.Collections.Generic;

namespace PolaczenieZbaza.Models;

public partial class Przepi
{
    public int IdPrzepisu { get; set; }

    public string Nazwa { get; set; }

    public string OpisPrzygotowania { get; set; }

    public string WartosciOdzywcze { get; set; }
}

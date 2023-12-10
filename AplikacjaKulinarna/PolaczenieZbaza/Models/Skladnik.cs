using System;
using System.Collections.Generic;

namespace PolaczenieZbaza.Models;

public partial class Skladnik
{
    public int IdSkladnika { get; set; }

    public string Nazwa { get; set; }

    public string Przelicznik { get; set; }
}

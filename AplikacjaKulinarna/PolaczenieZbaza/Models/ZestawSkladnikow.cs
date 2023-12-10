using System;
using System.Collections.Generic;

namespace PolaczenieZbaza.Models;

public partial class ZestawSkladnikow
{
    public int? IdPrzepisu { get; set; }

    public int? IdSkladnika { get; set; }

    public decimal? IloscSkladnika { get; set; }

    public virtual Przepi IdPrzepisuNavigation { get; set; }

    public virtual Skladnik IdSkladnikaNavigation { get; set; }
}

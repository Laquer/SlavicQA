﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PolaczenieZbaza.Models;


[Keyless]
public partial class Lodowki
{
    public int IdLodowka { get; set; }

    public int? IdSkladnika { get; set; }

    public decimal? IloscSkladnika { get; set; }

    public virtual Skladnik IdSkladnikaNavigation { get; set; }
}

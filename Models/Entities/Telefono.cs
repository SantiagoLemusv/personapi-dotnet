using System;
using System.Collections.Generic;

namespace personapi_dotnet.Models.Entities;

public partial class Telefono
{
    public int IdTelefono { get; set; }

    public string Num { get; set; } = null!;

    public string? Oper { get; set; }

    public long DuenioCc { get; set; }

    public virtual Persona DuenioCcNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace personapi_dotnet.Models.Entities;

public partial class Estudio
{
    public int IdEstudio { get; set; }

    public long CcPer { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Univer { get; set; }

    public virtual Persona CcPerNavigation { get; set; } = null!;
}

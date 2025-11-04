using System;
using System.Collections.Generic;

namespace personapi_dotnet.Models.Entities;

public partial class Profesion
{
    public int IdProf { get; set; }

    public string Nom { get; set; } = null!;

    public string? Des { get; set; }
}

using System;
using System.Collections.Generic;

namespace ClaseNosePeroClase.Models;

public partial class Contacto
{
    public string Rut { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string Mail { get; set; } = null!;
}

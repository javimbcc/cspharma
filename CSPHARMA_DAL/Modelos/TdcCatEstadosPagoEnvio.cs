using System;
using System.Collections.Generic;

namespace CSPHARMA_DAL.Modelos;

public partial class TdcCatEstadosPagoEnvio
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string CodEstadoPago { get; set; } = null!;

    public string? DesEstadoPago { get; set; }

    public virtual TdcTchEstadoPedido? TdcTchEstadoPedido { get; set; }
}

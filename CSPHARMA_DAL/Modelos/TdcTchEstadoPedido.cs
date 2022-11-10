using System;
using System.Collections.Generic;

namespace CSPHARMA_DAL.Modelos;

public partial class TdcTchEstadoPedido
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string? CodEstadoEnvio { get; set; }

    public string? CodEstadoPago { get; set; }

    public string? CodEstadoDevolucion { get; set; }

    public string CodPedido { get; set; } = null!;

    public string CodLinea { get; set; } = null!;

    public virtual TdcCatEstadosDevolucionPedido MdUu { get; set; } = null!;

    public virtual TdcCatEstadosPagoEnvio MdUu1 { get; set; } = null!;

    public virtual TdcCatLineasDistribucion MdUu2 { get; set; } = null!;

    public virtual TdcCatEstadosEnvioPedido MdUuNavigation { get; set; } = null!;
}

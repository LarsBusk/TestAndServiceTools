using System;
using System.Collections.Generic;

namespace FiLimsTest.Models;

public partial class RawDataValue
{
    public int ExportId { get; set; }

    public int RawDataId { get; set; }

    public int IndexNo { get; set; }

    public double IndexValue { get; set; }

    public virtual RawDataHeader RawDataHeader { get; set; } = null!;
}

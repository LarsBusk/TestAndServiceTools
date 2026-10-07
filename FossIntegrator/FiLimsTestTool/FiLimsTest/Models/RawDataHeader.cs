using System;
using System.Collections.Generic;

namespace FiLimsTest.Models;

public partial class RawDataHeader
{
    public int ExportId { get; set; }

    public int RawDataId { get; set; }

    public int NoOfDataPoints { get; set; }

    public int Increment { get; set; }

    public int IndexStart { get; set; }

    public int IndexEnd { get; set; }

    public virtual SampleHeader Export { get; set; } = null!;

    public virtual ICollection<RawDataValue> RawDataValues { get; set; } = new List<RawDataValue>();
}

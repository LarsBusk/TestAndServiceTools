using System;
using System.Collections.Generic;

namespace FiLimsTest.Models;

public partial class StatusDatum
{
    public int ExportId { get; set; }

    public int SourceId { get; set; }

    public string StatusName { get; set; } = null!;

    public double? StatusValue { get; set; }

    public virtual SampleHeader Export { get; set; } = null!;
}

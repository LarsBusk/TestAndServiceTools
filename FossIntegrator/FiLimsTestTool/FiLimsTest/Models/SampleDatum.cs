using System;
using System.Collections.Generic;

namespace FiLimsTest.Models;

public partial class SampleDatum
{
    public int ExportId { get; set; }

    public int ComponentClassId { get; set; }

    public int ComponentSubClassId { get; set; }

    public int ComponentType { get; set; }

    public int ComponentCustomId { get; set; }

    public string ComponentName { get; set; } = null!;

    public string ComponentUnit { get; set; } = null!;

    public double? ComponentValueNumeric { get; set; }

    public string? ComponentValueText { get; set; }

    public string? ComponentError { get; set; }

    public string? ComponentLimit { get; set; }

    public virtual SampleHeader Export { get; set; } = null!;
}

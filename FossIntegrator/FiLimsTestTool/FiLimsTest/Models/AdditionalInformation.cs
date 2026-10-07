using System;
using System.Collections.Generic;

namespace FiLimsTest.Models;

public partial class AdditionalInformation
{
    public int ExportId { get; set; }

    public int FieldNo { get; set; }

    public string FieldName { get; set; } = null!;

    public string? FieldValue { get; set; }

    public virtual SampleHeader Export { get; set; } = null!;
}

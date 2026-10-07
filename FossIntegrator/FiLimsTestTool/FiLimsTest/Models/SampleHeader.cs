using System;
using System.Collections.Generic;

namespace FiLimsTest.Models;

public partial class SampleHeader
{
    public int ExportId { get; set; }

    public DateTime? ExportDateTime { get; set; }

    public string WorkstationName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string JobName { get; set; } = null!;

    public string JobType { get; set; } = null!;

    public string MeasureProgram { get; set; } = null!;

    public int? SampleNoInJob { get; set; }

    public int SampleIntakeNo { get; set; }

    public string? SampleId { get; set; }

    public DateTime SampleTestDateTime { get; set; }

    public string SampleType { get; set; } = null!;

    public string SampleSubType { get; set; } = null!;

    public string? SampleStatus { get; set; }

    public string? SampleComments { get; set; }

    public bool RawDataIncluded { get; set; }

    public bool StatusDataIncluded { get; set; }

    public bool Processed { get; set; }

    public virtual ICollection<AdditionalInformation> AdditionalInformations { get; set; } = new List<AdditionalInformation>();

    public virtual ICollection<RawDataHeader> RawDataHeaders { get; set; } = new List<RawDataHeader>();

    public virtual ICollection<SampleDatum> SampleData { get; set; } = new List<SampleDatum>();

    public virtual ICollection<StatusDatum> StatusData { get; set; } = new List<StatusDatum>();
}

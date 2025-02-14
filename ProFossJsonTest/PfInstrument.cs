namespace ProFossJsonTest
{
    public class PfInstrument
  {
    public string Name;

    public string SerialNumber;

    public PfInstrument(string name, string serialNumber)
    {
      this.Name = name;
      this.SerialNumber = serialNumber;
    }

    public override string ToString()
    {
      return $"{Name}, ({SerialNumber})";
    }
  }
}

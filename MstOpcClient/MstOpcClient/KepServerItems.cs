namespace MstOpcClient
{
  public class KepServerItems
  {
    public string KepServerNiceName;

    public string KepServerName;

    public KepServerItems(string kepServerNiceName, string kepServerName)
    {
      this.KepServerNiceName = kepServerNiceName;
      this.KepServerName = kepServerName;
    }

    public override string ToString()
    {
      return this.KepServerNiceName;
    }
  }
}
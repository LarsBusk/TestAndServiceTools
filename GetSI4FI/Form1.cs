using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GetSI4FI
{

  public partial class Form1 : Form
  {
    private XDocument sysXml;

    private XDocument comXml;

    private NumberFormatInfo nfi = new CultureInfo("en-UK").NumberFormat;

    public Form1()
    {
      InitializeComponent();
    }

    private void loadSysXmlButton_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();

      if (dialog.ShowDialog() != DialogResult.Cancel)
      {
        sysXml = XDocument.Load(dialog.FileName);
      }
    }

    private void loadCompXmlButton_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();

      if (dialog.ShowDialog() != DialogResult.Cancel)
      {
        comXml = XDocument.Load(dialog.FileName);
      }
    }

    private List<XElement> PmsWithSorI()
    {
      var pms = sysXml.Element("tSettings").Element("tComponentList").Elements("tComponent").
        Where(e => double.Parse(e.Element("tSlopeIntercept").Element("dSlope").Value, nfi) != 1 
                   || double.Parse(e.Element("tSlopeIntercept").Element("dIntercept").Value, nfi) != 0);

      return pms.ToList();
    }

    private List<Tuple<string, double, double>> PmSiValues(List<XElement> pms)
    {
      var idsFromSys = pms.Select(e => e.Attribute("ID").Value);

      var pmsFromCompXml = comXml.Element("tComponents").Element("tComponentList").Elements("tComponent")
        .Where(e => idsFromSys.Contains(e.Attribute("ID").Value));

      List<Tuple<string, double, double>> sivals = new List<Tuple<string, double, double>>();

      foreach (var pm in pms)
      {
        Tuple<string, double, double> siTuple = new Tuple<string, double, double>(
          pmsFromCompXml.First(e => e.Attribute("ID").Value.Equals(pm.Attribute("ID").Value)).Element("sName").Value,
          double.Parse(pm.Element("tSlopeIntercept").Element("dSlope").Value, nfi),
          double.Parse(pm.Element("tSlopeIntercept").Element("dIntercept").Value, nfi));

        sivals.Add(siTuple);
      }

      return sivals;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
      List<string> lines = new List<string>();

      lines.Add("Name;Slope;Intercept");
      foreach (var pmSiValue in PmSiValues(PmsWithSorI()))
      {
        lines.Add($"{pmSiValue.Item1};{pmSiValue.Item2};{pmSiValue.Item3}");
      }

      File.AppendAllLines("SiValues.csv", lines);
    }
  }
}

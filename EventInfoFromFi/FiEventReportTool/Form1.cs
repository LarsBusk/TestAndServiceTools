using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiEventReportTool
{
  public partial class MainForm : Form
  {
    private ReportContents reportContents;
    private int reportId;
    private string reportFileName = String.Empty;
    private DatabaseHelper databaseHelper = new DatabaseHelper();

    public MainForm()
    {
      InitializeComponent();
    }

    private void readReportButton_Click(object sender, EventArgs e)
    {
      EventReportXmlHelper helper = new EventReportXmlHelper(reportFileName);
      reportContents = helper.ReadReport();
      WriteReportHeaders();
    }

    private void addToDbButton_Click(object sender, EventArgs e)
    {
      if (reportContents == null) return;

      reportContents.StartDateTime = DateTime.Parse(startTimeTextBox.Text);
      reportContents.EndDateTime = DateTime.Parse(endtimeTextBox.Text);
      reportContents.CountryId = GetCountryId(countryComboBox.Text);
      reportContents.CompanyId = GetCompanyId(companyComboBox.Text);

      databaseHelper.AddEventReport(reportContents);
    }

    private void BrowseButton_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();

      if (!dialog.ShowDialog().Equals(DialogResult.Cancel))
      {
        this.reportFileName = dialog.FileName;
      }

      ReadReport();
    }

    private void WriteReportHeaders()
    {
      string isoFormat = "yyyy-MM-dd hh:mm:ss";
      this.detailsLabel.Text = reportContents.ToString();
      this.startTimeTextBox.Text = reportContents.StartDateTime.ToString(isoFormat);
      this.endtimeTextBox.Text = reportContents.EndDateTime.ToString(isoFormat);
    }

    private void ReadReport()
    {
      EventReportXmlHelper helper = new EventReportXmlHelper(reportFileName);
      reportContents = helper.ReadReport();
      WriteReportHeaders();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.companyComboBox.Items.AddRange(databaseHelper.GetCompanies().ToArray());
      this.countryComboBox.Items.AddRange(databaseHelper.GetCountries().ToArray());
    }

    private int GetCountryId(string countryName)
    {
      if (!string.IsNullOrEmpty(countryName))
      {
        var countries = databaseHelper.GetCountries();

      if (!countries.Any(c => c.CountryName.Equals(countryName)))
      {
        countries = databaseHelper.AddCountry(countryName);
      }

      return countries.Find(c => c.CountryName.Equals(countryName)).CountryId;
      }

      return -1;
    }

    private int GetCompanyId(string companyName)
    {
      if (!string.IsNullOrEmpty(companyName))
      {
        var companies = databaseHelper.GetCompanies();

        if (!companies.Any(c => c.CompanyName.Equals(companyName)))
        {
          companies = databaseHelper.AddCompany(companyName);
        }

        return companies.Find(c => c.CompanyName.Equals(companyName)).CompanyId;
      }

      return -1;
    }
  }
}

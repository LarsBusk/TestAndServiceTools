using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiEventReportTool
{
  public class DatabaseHelper
  {
    private string connectionString = "Server=bl-JitterData;Database=FiEvents;User id=FiEventUser; Password=Foss1234;";

    public bool AddEventReport(ReportContents reportContents)
    {
      try
      {
        int reportId = -1;

        reportId = AddEventReportHeader(reportContents);

        if (reportId != -1)
        {
          foreach (var eventContentse in reportContents.EventList)
          {
            AddEvent(eventContentse, reportId);
          }

          return true;
        }

        return false;
      }
      catch (Exception e)
      {
        throw;
      }
    }

    public List<CompanyInfo> GetCompanies()
    {
      List<CompanyInfo> info = new List<CompanyInfo>();

      string query = "Select CompanyId, CompanyName From Companies";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
          while (reader.Read())
          {
            info.Add(new CompanyInfo((int) reader["CompanyId"], (string) reader["CompanyName"]));
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }
        finally
        {
          reader.Close();
        }
      }

      info.Sort();

      return info;
    }

    public List<CountryInfo> GetCountries()
    {
      List<CountryInfo> info = new List<CountryInfo>();

      string query = "Select CountryId, CountryName From Countries";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
          while (reader.Read())
          {
            info.Add(new CountryInfo((int)reader["CountryId"], (string)reader["CountryName"]));
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }
        finally
        {
          reader.Close();
        }
      }

      info.Sort();

      return info;
    }

    public List<CountryInfo> AddCountry(string countryName)
    {
      string query = $"Insert Into Countries (CountryName) values ('{countryName}')";

      ExecuteQueryNoReturn(query);

      return GetCountries();
    }

    public List<CompanyInfo> AddCompany(string companyName)
    {
      string query = $"Insert Into Companies (CompanyName) values ('{companyName}')";

      ExecuteQueryNoReturn(query);

      return GetCompanies();
    }

    private int AddEventReportHeader(ReportContents reportContents)
    {
      int reportId = -1;
      string isoFormat = "yyyy-MM-dd hh:mm:ss";
      string startTid = reportContents.StartDateTime.ToString(isoFormat);
      string endTid = reportContents.EndDateTime.ToString(isoFormat);

      string query = 
          "Declare @ReportId int " +
          "Select @ReportId = 0 " +
          "Exec [dbo].[AddEventReport] " +
          $"@WorkstationName = '{reportContents.WorkStationName}', " +
          $"@Configuration = '{reportContents.Configuration}', " +
          $"@SamplesInPeriod = {reportContents.MeasureInPeriod}, " +
          $"@SamplesTotal = {reportContents.TotalMeasure}, " +
          $"@ChassisId = '{reportContents.ChassisId}', " +
          $"@SwVersion = '{reportContents.SoftWareVersion}', " +
          $"@StartDateTime = '{startTid}', " +
          $"@EndDateTime = '{endTid}', " +
          $"@CompanyId = {reportContents.CompanyId}, " +
          $"@CountryId = {reportContents.CountryId}, " +
          "@ReportId = @ReportId OUTPUT " + 
          "SELECT @ReportId as N'ReportId' ";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
          while (reader.Read())
          {
            reportId = (int) reader["ReportId"];
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }
        finally
        {
          reader.Close();
        }
      }

      return reportId;
    }

    private void AddEvent(EventContents eventContents, int reportId)
    {
      string query = "Exec dbo.AddEvent " +
                     $"@EventType = '{eventContents.EventType}', " +
                     $"@EventText = '{eventContents.EventText}', " +
                     $"@EventCode = '{eventContents.EventCode}', " +
                     $"@ReportId = {reportId}, " +
                     $"@Count = {eventContents.Count}";

      ExecuteQueryNoReturn(query);
    }

    private void ExecuteQueryNoReturn(string query)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
      }
    }
  }
}

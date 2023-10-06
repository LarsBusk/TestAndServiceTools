using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx;

namespace OpcUaTestClient
{
    public partial class Form1 : Form
    {
        public OpcClient Client { get; set; }

        private Timer watchdogTimer;
        private uint watchdog = 0;
        private string certString = "MIIDezCCAmOgAwIBAgIITPD3M9Wkj00wDQYJKoZIhvcNAQELBQAwDzENMAsGA1UEAwwETm9yYTAgFw0yMzEwMDQwOTUxMzNaGA8yMDczMTAwNDA5NTEzM1owDzENMAsGA1UEAwwETm9yYTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALZSXjKkyWRjfJ9pHN2eSTKrx5h2AVqOP/7lk5nIY6bjiW45WvOFgayvSgpe5FAUbVouXXsWlMZ9usQjaGTkxXld9Bb1msy5w1drSODoX7eHhyvwb2veKC1BNIcqkq6DVtlbVlvcvgIRRpcDsit8efij+QBg+NaSlapxRS4REf4sAxHDg0XIVJnJpn7EZumjBHGdnt/3xTaIDPLTNMoMuyUEoqPDYXTWwr66rpdiycOgvixd6T07jalGaH2yjGl/Z1xUmkOnueZxMkO61tGSrNBlTjCODtqJGgtGO1z7PHpux8LHQDMsfXLZatvoKRuXxdSVLLZ5rKvGVJuJAgAFLT0CAwEAAaOB2DCB1TAdBgNVHQ4EFgQUo2B7gGeXFjj78NP+3/uYj+4xaNgwEgYDVR0TAQH/BAgwBgEB/wIBADA+BgNVHSMENzA1gBSjYHuAZ5cWOPvw0/7f+5iP7jFo2KETpBEwDzENMAsGA1UEAwwETm9yYYIITPD3M9Wkj00wDgYDVR0PAQH/BAQDAgL0MCAGA1UdJQEB/wQWMBQGCCsGAQUFBwMBBggrBgEFBQcDAjAuBgNVHREEJzAlhhV1cm46TGFiLVcxMC1Ob3JhOk5vcmGCDExhYi1XMTAtTm9yYTANBgkqhkiG9w0BAQsFAAOCAQEAP8/e1bSnTNjR948sDnhOnN4PW8MvswHtsxxJobISWjPUiGGY+R3D8QUH2VrBFtDIuv6yGN7rc19PK7k6iNQS3kXMy9mKbPM8ObJ45gPgl20UcpYLoqdfts62SDe+ID3baVtShTmhqRgplO9zxPLDT6pow+k+IcLlfHJoHKWJKOft58dGBRyHd0A6PnmlvZQg8+Fjg8BCcnlCSZKslAoaW7GKwdyJ5u6pUe/ofpazLEMyVSSphCLwKqmkHfMzRkFp/iL5XTQIEsg2pW4i/zdkXkn2xWuUgl5uSm80+h81BJ0zM+f8tIQnuOR6J7KI4bZFu4qPxs+8/bJitqr47ynZRA==";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initialise();
            Client.Connect();
            watchdogTimer.Enabled = true;
            watchdogTimer.Start();
        }

        private void Initialise()
        {
            Client = new OpcClient("opc.tcp://localhost:4840/NoraTestServer");
            var importedCert = new X509Certificate2("FOSStestLicense.cer", "SLU1234");
            var certArray = importedCert.GetRawCertData();
            //var cert = new X509Certificate2(certArray);
            var cert = new X509Certificate2(Convert.FromBase64String(textBox1.Text));
            Client.CertificateStores.ApplicationStore.Add(cert);
            
            Client.Security.UseOnlySecureEndpoints = true;
            Client.Security.UserIdentity = new OpcCertificateIdentity(Client.CertificateStores.ApplicationStore.GetCertificate(cert.Thumbprint).Certificate);
            Client.Security.AutoAcceptUntrustedCertificates = true;
            watchdogTimer = new Timer
            {
                Interval = 1000,
                Enabled = false
            };
            watchdogTimer.Tick += WatchdogTimer_Tick;
        }

        private void WatchdogTimer_Tick(object sender, EventArgs e)
        {
            var res = Client.WriteNode("ns=2;s=Foss.Nora.Instrument.WatchdogCounter", watchdog);
            label1.Text = $"Writing {watchdog} result: {res.IsGood}";
            watchdog++;
        }

        private byte[] ConvertHex(string hexString)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < hexString.Length; i += 2)
            {
                var hs = hexString.Substring(i, 2);
                uint decval = System.Convert.ToUInt32(hs, 16);
                char character = System.Convert.ToChar(decval);
                sb.Append(character);
            }
            var ascii = sb.ToString();
            var bytes = Encoding.ASCII.GetBytes(ascii);
            return bytes;
        }
    }
}

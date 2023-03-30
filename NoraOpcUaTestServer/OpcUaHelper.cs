﻿using NoraOpcUaTestServer.OpcNodes;
using Opc.UaFx;
using Opc.UaFx.Server;
using System;
using System.Threading;

namespace NoraOpcUaTestServer
{
    public class OpcUaHelper
    {
        public NoraNodes Nodes => noraNodes;
        public OpcServer Server;

        private readonly NoraNodes noraNodes;
        private static uint serverWatchdog = 1;


        public OpcUaHelper(string serverName, string homeFolderName = "Foss.Nora")
        {
            noraNodes = new NoraNodes(homeFolderName);

            Opc.UaFx.Licenser.LicenseKey =
                "AALSA4IRQPJKOGVQOZP32DTKRRNAIWS3CQLTG7RJEPUAZGVQG6NPQK2OL4DOJNVLSSUDQOEUY5KDHHJWYQSTXUITOEOGOOFL2R5TEIIMCGFE5JV6CQM7TDVFY35SPAB" +
                "5T4YNCIPWM2Y7YCY2ZLFSWL5ZU64WK3J4M7AL7CCMS7SPGXUJ22YFGCJUV6F5OZALRVWJ5W73O6CQUGPEFZQJVHYZS3ORBJ75O3BS6N2JM75CCQTK5V6NIQOUB2PIHK" +
                "C6XIA7OU6PYI6NX5XAABZ7QGSNRZICR44DL5OGS2DXUQV4JBDAXDLXYK3VDBPDEFEUR7E2CBVAU4BI6I2EYJ3MRUNYTQK5UQXDKCOEMKZW52XMK3X27YNRPMNPNSSJF" +
                "LT737QGAJILKL2KCQFSW4PSN7BXXGT3GUQO4BBL7MUKZ5EUTQRE3DTAQATVRPL427ZPZJOLBNDGUOGH6L4SH34PFHHANIG2IKNLPVN3OFNKHFHA4ZFFKOV5W2SBLCMM" +
                "7JFAGAA7VH6AW56COVRCXJ5OWACCUVQ7OBRZV5TG3QODO67J444B7MALRM2OV7KZ5RG7FJLXZXQNWKTG7ZRHSNNRMVOMLI37IEOSO4E5FN5YRZKGZMAJHWYIKNZ7TPR" +
                "IRHTTZ2ZJCAVWIIYP3O2WI5RQQ3QZT5YIN477RSEML6AX226MIGNWMLYAHJNC6IDLQQF2E5VAQCTQYCJI7CH3NOWYJDANMP5RA74LVYMRAX326BZ4S3MPU6SC6RRV7C" +
                "HKBAPKEU6YE464ZFRQ7IPACBBUMKZ22P6ZEP4D3AJOQU4P4EGRTNDNJ7QVIS4OFBKYWNLN4FE6L6ASYF2QMDRXD3AM2OJMW4ZVQ7LNFVRMEVKAQX7HYYBWXGCDKML57" +
                "64TEQITT3TGRWNJB7HDBEZYK3UCBVDXQ7BTWZT6PGS2COL2ZHKMK6O3LGKUB5KXRYSQYM76SAWOANBS7FAPNYE2O6SYOIAZRQQAAHK5EDDYR3XVMGDQHGTESGEDTVQZ" +
                "VSBANGDJBTYCHKC7TILXWXJP64DDSDVSNAAWE2AF4KXDJFUYJNVIMEEDMLCJXVVSH27QB4NT3U6YPEEAD62NKXCU2H3MY5T2DHHC2NHCR2AOZJFHNASEBB7OLZ32GLJ" +
                "APLH3XEINORMCAUJJL6H3X2ODOPPLDBPL5T6HPS7EENJJAKWSZV622J65FXMI2QZCWEGAAOEV6A56FSAHNWUS3MFPBMBB";

            Server = new OpcServer(
                serverName,
                noraNodes.Nodes);
        }


        public void StartServer()
        {
            Server.Start();
        }

        public void StopServer()
        {
            Server.Stop();
        }

        public void StartMeasuring(string product)
        {
            SetNodeValue(noraNodes.ControllerNodes.ProductCode, product);
            SetNodeValue(noraNodes.ControllerNodes.ModeN, 1);
        }

        public void StartMeasuring()
        {
            SetNodeValue(noraNodes.ControllerNodes.ModeN, 1);
        }

        public void StopMeasuring()
        {
            SetNodeValue(noraNodes.ControllerNodes.ModeN, 0);
        }

        public void SetCip()
        {
            SetNodeValue(noraNodes.ControllerNodes.ModeN, 2);
        }

        public void ChangeProduct(string newProduct)
        {
            SetNodeValue<string>(noraNodes.ControllerNodes.ProductCode, newProduct);
        }

        public void EnqueueZero()
        {
            ToggleNode(noraNodes.ControllerNodes.ZeroToQueue, TimeSpan.FromMilliseconds(500));
        }

        public void EnqueueClean()
        {
            ToggleNode(noraNodes.ControllerNodes.CleanToQueue, TimeSpan.FromMilliseconds(500));
        }

        public void SetSampleRegistration(string registration)
        {
            SetNodeValue<string>(noraNodes.ControllerNodes.SampleRegistration, registration);
        }

        public void SetNoDelayedResults(bool state)
        {
            SetNodeValue(noraNodes.ControllerNodes.NoDelayedResults, state);
        }

        public void UpdateServerWatchdog()
        {
            SetNodeValue(noraNodes.ControllerNodes.WatchdogCounter, serverWatchdog);
            serverWatchdog++;
        }

        private void SetNodeValue<T>(OpcDataVariableNode<T> node, object value)
        {
            node.Value = (T)value;
            node.ApplyChanges(Server.SystemContext);
        }

        private void ToggleNode(OpcDataVariableNode<bool> node, TimeSpan onTime)
        {
            SetNodeValue(node, true);
            Thread.Sleep(onTime);
            SetNodeValue(node, false);
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using log4net;
using System.Threading;
using OPCClient.OPCTags;
using OPCClient.Properties;

namespace OPCClient.Communicators
{
    /// <summary>
    /// Communicate with Opc Server of given type
    /// </summary>
    public class MeatMasterKepserverCommunicatior : KepServerCommunicator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MeatMasterKepserverCommunicatior));

        public static KepServerMeatMasterIIOPCTags KepServerOpcTags;


        public static void KepServerSetRegistrationValue2(int value)
        {
            SetValueOfOpcTag(KepServerOpcTags.ControllerGroup.PreregistrationValue2, value);
        }

        public static void KepServerSetRegistrationValue1(int value)
        {
            SetValueOfOpcTag(KepServerOpcTags.ControllerGroup.PreregistrationValue1, value);
        }


        private static bool SetValueOfOpcTag(IOPCTag tag, object value)
        {
            log.Debug($"Setting value of {tag.ShortName} to {value}");
            tag.ObjectValue = value;
            bool res = OpcHelp.OPCSetData.SetOneOPCTag(tag);
            log.Debug($"Value of tag {tag.ShortName} set: {res}");
            return res;
        }
    }
}
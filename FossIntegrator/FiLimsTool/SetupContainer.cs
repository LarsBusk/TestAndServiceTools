using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiLimsTool
{
    public class SetupContainer
    {
        public readonly string SetupType;
        public readonly int SetupIndex;
        public readonly string SetupFileName;

        public SetupContainer(string setupType, int setupIndex, string setupFileName)           
        {
            SetupFileName = setupFileName;
            SetupType = setupType;
            SetupIndex = setupIndex;
        }

        public string[] ToArray()
        {
            return new [] { this.SetupType, this.SetupIndex.ToString(), this.SetupFileName };
        }
    }
}

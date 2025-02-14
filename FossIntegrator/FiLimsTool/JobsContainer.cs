using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiLimsTool
{
    public class JobsContainer
    {
        public int ID;
        public int JobIndex;

        public JobsContainer(int id, int jobIndex)
        {
            ID = id;
            JobIndex = jobIndex;
        }
    }
}

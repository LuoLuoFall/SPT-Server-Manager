using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovServerControl
{
    public class Config
    {
        public string ServerPath { get; set; }

        public string HeadlessPath { get; set; }

        public bool EnableCpuAffinity { get; set; }

        public bool MinimizeToTray { get; set; }
    }
}
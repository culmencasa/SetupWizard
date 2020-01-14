using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetupWizard.Models
{
    [Serializable]
    public class UninstallInfo 
    {
        public string DestDir { get; set; }

        public List<InstalledFiles> Manifest { get; set; }
    }
}

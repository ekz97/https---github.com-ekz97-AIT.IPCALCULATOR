using Ait.IPCalculator.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ait.IPCalculator.Lib
{
    public class SubnetmaskerService
    {
        public List<Sunbnetmasker> Sunbnetmaskers { get; set; }

        public SubnetmaskerService()
        {
            GenerateSubnetMaskers();
        }

        private void GenerateSubnetMaskers()
        {
            Sunbnetmaskers = new List<Sunbnetmasker>();

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "0.0.0.0", CdirPrefix = "0" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "128.0.0.0", CdirPrefix = "1" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "192.0.0.0", CdirPrefix = "2" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "224.0.0.0", CdirPrefix = "3" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "240.0.0.0", CdirPrefix = "4" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "248.0.0.0", CdirPrefix = "5" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "252.0.0.0", CdirPrefix = "6" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "254.0.0.0", CdirPrefix = "7" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.0.0.0", CdirPrefix = "8" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.128.0.0", CdirPrefix = "9" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.192.0.0", CdirPrefix = "10" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.224.0.0", CdirPrefix = "11" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.240.0.0", CdirPrefix = "12" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.248.0.0", CdirPrefix = "13" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.252.0.0", CdirPrefix = "14" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.254.0.0", CdirPrefix = "15" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.0.0", CdirPrefix = "16" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.128.0", CdirPrefix = "17" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.192.0", CdirPrefix = "18" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.224.0", CdirPrefix = "19" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.240.0", CdirPrefix = "20" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.248.0", CdirPrefix = "21" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.252.0", CdirPrefix = "22" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.254.0", CdirPrefix = "23" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.255.0", CdirPrefix = "24" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.255.128", CdirPrefix = "25" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.255.192", CdirPrefix = "26" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.255.224", CdirPrefix = "27" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.255.240", CdirPrefix = "28" });
            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.255.248", CdirPrefix = "29" });

            Sunbnetmaskers.Add(new Sunbnetmasker { Subnetmasker = "255.255.255.252", CdirPrefix = "30" });
            








        }

      
    }
}

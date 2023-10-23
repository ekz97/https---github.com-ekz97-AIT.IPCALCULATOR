using System;
using System.Collections.Generic;
using System.Text;

namespace Ait.IPCalculator.Lib.Entities
{
    public class Sunbnetmasker
    {
        public string Subnetmasker { get; set; }
        public string CdirPrefix { get; set; }



        public override string ToString()
        {
            return $"{Subnetmasker} /{CdirPrefix}";
        }

    }
}

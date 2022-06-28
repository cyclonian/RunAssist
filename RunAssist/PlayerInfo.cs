using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositiveChaos.RunAssist
{
    public class PlayerInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Zones { get; set; } = string.Empty;

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Zones);
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Zones);
        }
    }
}

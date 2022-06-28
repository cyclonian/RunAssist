using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PositiveChaos.RunAssist
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("RunAssistState")]
    public class RunAssistState
    {
        [XmlIgnore]
        protected const int LIMIT = 8;
        [XmlIgnore]
        public int Limit { get; } = LIMIT;

        [XmlIgnore] 
        public string RootPath { get; set; } = string.Empty;
        [XmlIgnore]
        public string StateFileName { get; set; } = "RunAssist.xml";


        [XmlArray("Players")]
        [XmlArrayItem("PlayerInfo", typeof(PlayerInfo))]
        public PlayerInfo[] Players = new PlayerInfo[LIMIT];

        [XmlElement("GameName")]
        public string GameName { get; set; } = string.Empty;
        [XmlIgnore]
        public string GameNumber { get; set; } = string.Empty;
        [XmlElement("NumPadding")]
        public string NumPadding { get; set; } = "2";
        [XmlElement("Password")]
        public string Password { get; set; } = string.Empty;

        [XmlElement("Region")]
        public string Region { get; set; } = string.Empty;
        [XmlElement("Note")]
        public string Note { get; set; } = "{0} minute timed runs";

        [XmlElement("RunTime")]
        public string RunTime { get; set; } = "6:00";
        [XmlElement("WarningTime")]
        public string WarningTime { get; set; } = "2:00";
        [XmlElement("WarningMessage")]
        public string WarningMessage { get; set; } = "{0} remaining";
        [XmlElement("WarningTime2")]
        public string WarningTime2 { get; set; } = "0:30";
        [XmlElement("WarningMessage2")]
        public string WarningMessage2{ get; set; } = "{0} remaining";

        [XmlElement("WarningAutoClipboard")]
        public bool WarningAutoClipboard { get; set; } = true;
        [XmlElement("TimeZone")]
        public string TimeZone { get; set; } = "EST";

        [XmlArray("GameNames")]
        [XmlArrayItem("GameNames", typeof(string))]
        public List<string> GameNames = new List<string>();

        [XmlArray("PlayerNames")]
        [XmlArrayItem("PlayerName", typeof(string))]
        public List<string> PlayerNames = new List<string>();

        [XmlArray("Zones")]
        [XmlArrayItem("Zone", typeof(string))]
        public List<string> Zones = new List<string>();

        [XmlArray("Notes")]
        [XmlArrayItem("Notes", typeof(string))]
        public List<string> Notes = new List<string>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int nGameNumber = 1;
            if (!int.TryParse(GameNumber, out nGameNumber))
                nGameNumber = 1;
            sb.AppendFormat("{0}{1} /// {2}{3}", GameName, nGameNumber.ToString("00"), Password, Environment.NewLine);
            if (!string.IsNullOrWhiteSpace(Region))
                sb.AppendLine(Region);
            if (!string.IsNullOrWhiteSpace(Note))
            {
                string szMinute = "6";
                string[] split = RunTime.Split(":");
                szMinute = split[0];
                sb.AppendFormat(Note, szMinute);
                sb.AppendLine();
            }

            sb.AppendLine();
            for (int i = 0; i <= LIMIT; i++)
            {
                if (Players.Length > i)
                {
                    if(Players[i] != null && !Players[i].IsEmpty())
                        sb.AppendFormat("[{0} - {1}]{2}", Players[i].Name, Players[i].Zones, Environment.NewLine);
                    else
                        sb.AppendFormat("[Player - Location]{0}", Environment.NewLine);
                }
            }

            sb.AppendLine();
            sb.AppendFormat("Timestamp: {0} {1}", DateTime.Now.ToString("hh:mm:ss tt"), TimeZone);

            return sb.ToString();
        }

        public string ToStringRoles(string szTimeleft = "")
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(szTimeleft))
                sb.AppendFormat("Time remaining in run: {0} >>> ", szTimeleft);
            for (int i = 0; i <= LIMIT; i++)
            {
                if (Players.Length > i)
                    if (Players[i] != null && !Players[i].IsEmpty())
                        sb.AppendFormat("[{0} - {1}]{2}", Players[i].Name, Players[i].Zones, Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}

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
        [XmlIgnore]
        public int NumPaddingVal
        {
            get
            {
                int nVal = 10;
                int.TryParse(NumPadding, out nVal);
                return nVal;
            }
        }
        [XmlElement("Password")]
        public string Password { get; set; } = string.Empty;
        [XmlElement("Region")]
        public string Region { get; set; } = string.Empty;
        [XmlElement("IncludeRegion")]
        public string IncludeRegion { get; set; } = "True";
        [XmlIgnore]
        public bool IncludeRegionVal
        {
            get
            {
                bool bVal = false;
                bool.TryParse(IncludeRegion, out bVal);
                return bVal;
            }
        }
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
        [XmlElement("Advert")]
        public string Advert { get; set; } = string.Empty;
        [XmlElement("WarningAutoClipboard")]
        public bool WarningAutoClipboard { get; set; } = true;
        [XmlElement("TimeZone")]
        public string TimeZone { get; set; } = "EST";
        [XmlElement("AutoTimer")]
        public string AutoTimer { get; set; } = "True";
        [XmlIgnore]
        public bool AutoTimerVal
        {
            get
            {
                bool bVal = false;
                bool.TryParse(AutoTimer, out bVal);
                return bVal;
            }
        }
        [XmlElement("AutoTimerDelay")]
        public string AutoTimerDelay { get; set; } = "10";
        [XmlIgnore]
        public int AutoTimerDelayVal
        {
            get
            {
                int nVal = 10;
                int.TryParse(AutoTimerDelay, out nVal);
                return nVal;
            }
        }
        [XmlElement("OverlayLocationX")]
        public string OverlayLocationX { get; set; } = string.Empty;
        [XmlElement("OverlayLocationY")]
        public string OverlayLocationY { get; set; } = string.Empty;
        [XmlElement("OverlayWidth")]
        public string OverlayWidth { get; set; } = "300";
        [XmlElement("OverlayHeight")]
        public string OverlayHeight { get; set; } = "450";
        [XmlElement("OverlayForeColor")]
        public string OverlayForeColor { get; set; } = "#FF808080";
        [XmlElement("OverlayBackColor")]
        public string OverlayBackColor { get; set; } = "#222222";

        [XmlElement("OverlayShowPlayersZones")]
        public string OverlayShowPlayersZones { get; set; } = "True";
        [XmlIgnore]
        public bool OverlayShowPlayersZonesVal
        {
            get
            {
                bool bVal = false;
                bool.TryParse(OverlayShowPlayersZones, out bVal);
                return bVal;
            }
        }
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

        [XmlElement("KeybindToggle")]
        public KeyCombo KeybindToggle { get; set; } = new KeyCombo(ModifierKeys.Control, Keys.D0);
        [XmlElement("KeybindNextGame")]
        public KeyCombo KeybindNextGame { get; set; } = new KeyCombo(ModifierKeys.Control, Keys.Oemplus);
        [XmlElement("KeybindCopyRoles")]
        public KeyCombo KeybindCopyRoles { get; set; } = new KeyCombo(ModifierKeys.Control, Keys.Oem6);
        [XmlElement("KeybindOverlay")]
        public KeyCombo KeybindOverlay { get; set; } = new KeyCombo(ModifierKeys.Control, Keys.OemQuestion);
        [XmlElement("KeybindAdvert")]
        public KeyCombo KeybindAdvert { get; set; } = new KeyCombo(ModifierKeys.Control, Keys.Oem4);

        [XmlElement("IncludeTimestamp")]
        public string IncludeTimestamp { get; set; } = "True";
        [XmlIgnore]
        public bool IncludeTimestampVal
        {
            get
            {
                bool bVal = false;
                bool.TryParse(IncludeTimestamp, out bVal);
                return bVal;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int nGameNumber = 1;
            if (!int.TryParse(GameNumber, out nGameNumber))
                nGameNumber = 1;
            int nNumPadding = int.Parse(NumPadding);
            string szPadding = string.Empty;
            for (int i = 0; i < nNumPadding; i++)
                szPadding += "0";
            sb.AppendFormat("{0}{1} /// {2}{3}", GameName, nGameNumber.ToString(szPadding), string.IsNullOrWhiteSpace(Password) ? "[no password]" : Password, Environment.NewLine);
            if (IncludeRegionVal && !string.IsNullOrWhiteSpace(Region))
                sb.AppendLine(Region);
            if (!string.IsNullOrWhiteSpace(Note))
            {
                string szMinute = "6";
                string[] split = RunTime.Split(":");
                szMinute = split[0];
                string szTime = szMinute;
                if (split.Length > 1 && split[1] != "00")
                    szTime = RunTime;
                string szNote = string.Empty;
                Helpers.TryFormat(Note, out szNote, szTime);
                sb.AppendLine(szNote);
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

            if (IncludeTimestampVal)
            {
                sb.AppendLine();
                sb.AppendFormat("Timestamp: {0} {1}", DateTime.Now.ToString("hh:mm:ss tt"), TimeZone);
            }

            return sb.ToString();
        }

        public string ToStringOverlayAssignments()
        {
            StringBuilder sb = new StringBuilder();

            int nGameNumber = 1;
            if (!int.TryParse(GameNumber, out nGameNumber))
                nGameNumber = 1;
            int nNumPadding = int.Parse(NumPadding);
            string szPadding = string.Empty;
            for (int i = 0; i < nNumPadding; i++)
                szPadding += "0";
            sb.AppendFormat("{0}{1}{2}", GameName, nGameNumber.ToString(szPadding), Environment.NewLine);
            sb.Append(ToStringRoles());

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

    [Serializable]
    public class KeyCombo
    {
        [XmlElement("Modifiers")]
        public ModifierKeys Modifiers { get; set; }
        [XmlElement("Key")]
        public Keys Key { get; set; }

        public KeyCombo()
        {
            Modifiers = ModifierKeys.None;
            Key = Keys.None;
        }

        public KeyCombo(ModifierKeys modifiers, Keys key)
        {
            Modifiers = modifiers;
            Key = key;
        }
    }
}

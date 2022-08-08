using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PositiveChaos.RunAssist
{
    public static class Helpers
    {
        public static bool TryFormat(string szFormat, out string szResult, params string[] args)
        {
            szResult = string.Empty;
            try
            {
                szResult = string.Format(szFormat, args);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GetSafeVal(ValType valType, string szVal)
        {
            string szRet = szVal.Trim();
            if (!string.IsNullOrWhiteSpace(szVal))
            {
                switch (valType)
                {
                    case ValType.GameName: break;
                    case ValType.NumPadding: break;
                    case ValType.Password: break;
                    case ValType.Region:
                        if (string.IsNullOrWhiteSpace(szVal))
                            szRet = "Americas";
                        break;
                    case ValType.Note:
                        szRet = CorrectFormatZero(szVal);
                        break;
                    case ValType.RunTime: break;
                    case ValType.WarningTime: break;
                    case ValType.WarningMessage:
                        szRet = CorrectFormatZero(szVal);
                        break;
                    case ValType.WarningTime2: break;
                    case ValType.Advert: break;
                    case ValType.WarningAutoClipboard: break;
                    case ValType.TimeZone:
                        if (string.IsNullOrWhiteSpace(szVal))
                            szRet = "EST";
                        break;
                    default: break;
                }
            }

            return szRet;
        }

        public static string CorrectFormatZero(string szVal)
        {
            string szRet = szVal;

            szRet = Regex.Replace(szVal, @"\{[1,2,3,4,5,6,7,8,9]\}", @"{0}");

            return szRet;
        }
    }

    [Flags]
    public enum ModifierKeys : uint
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

    public enum RunAssistKey
    {
        None = 0,
        Toggle = 1,
        NextGame = 2,
        CopyRoles = 3,
        Overlay = 4,
        Advert = 5
    }

    public enum WorkerKey
    {
        AutoStart
    }

    public enum ValType
    {
        GameName,
        NumPadding,
        Password,
        Region,
        Note,
        RunTime,
        WarningTime,
        WarningMessage,
        WarningTime2,
        Advert,
        WarningAutoClipboard,
        TimeZone,
        AutoTimer,
        AutoTimerDelay,
        OverlayLocationX,
        OverlayLocationY,
        OverlayWidth,
        OverlayHeight,
        OverlayForeColor,
        OverlayBackColor,
        KeybindToggle,
        KeybindNextGame,
        KeybindCopyRoles,
        KeybindOverlay,
        KeybindAdvert
    }
}

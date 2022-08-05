using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositiveChaos.RunAssist
{
    public static class Helpers
    {
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
}

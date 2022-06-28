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
        Start = 1,
        Stop = 2,
        NextGame = 3
    }
}

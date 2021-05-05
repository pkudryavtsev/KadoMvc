using System;

namespace Globals
{
    public class Global
    {
        public static String GetConnectionStringName()
        {
#if DEBUG
            return "PresentBox_Local";
#else
            return "PresentBox_Production";
#endif
        }
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}

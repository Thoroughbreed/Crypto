using System;

namespace Crypto.UTIL
{
    public class BadUser : Exception
    {
        public override string Message
        {
            get { return "It looks like you tried to cheat the system ...\nBad user!"; }
        }
    }

    public class DOOM : Exception
    {
        public override string Message
        {
            get { return "You have unlocked godlike-mode ..."; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM3_Proto
{
    class AppMessage
    {
        public enum MsgType { ActivateChannelModelTab };

        public MsgType Type { get; set; }
        public object Param0 { get; set; }
    }
}

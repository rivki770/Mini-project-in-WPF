using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RelatedHosting
    {
        int _stSerialKey;
        string _HostingUnitName;
        int _OrderId;

        public int stSerialKey { get => _stSerialKey; set => _stSerialKey = value; }
        public string HostingUnitName { get => _HostingUnitName; set => _HostingUnitName = value; }
        public int OrderId { get => _OrderId; set => _OrderId = value; }
    }
}

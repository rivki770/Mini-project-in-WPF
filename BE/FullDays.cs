using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class FullDays
    {
        int _Id;
        int _HostingUnitId;
        DateTime _Date;
        int _OrderId;

        public int Id { get => _Id; set => _Id = value; }
        public int HostingUnitId { get => _HostingUnitId; set => _HostingUnitId = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int OrderId { get => _OrderId; set => _OrderId = value; }
    }
}

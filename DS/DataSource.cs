using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        public static List<BE.HostingUnit> hostingUnits = new List<BE.HostingUnit>();
        public static List<Order> orders = new List<Order>();
        public static List<GuestRequest> guestRequests = new List<GuestRequest>();
    }
}

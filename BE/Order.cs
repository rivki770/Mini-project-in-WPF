using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class Order
    {
        int _HostingUnitKey;
        int _GuestRequestKey;
        int _OrderKey;
        DateTime _CreateDate;
        DateTime _OrderDate;

        public int HostingUnitKey { get => _HostingUnitKey; set => _HostingUnitKey = value; }
        public int GuestRequestKey { get => _GuestRequestKey; set => _GuestRequestKey = value; }
        public int OrderKey { get => _OrderKey; set => _OrderKey = value; }
        public DateTime CreateDate { get => _CreateDate; set => _CreateDate = value; }
        public DateTime OrderDate { get => _OrderDate; set => _OrderDate = value; }

        public override string ToString()
        {
            return (HostingUnitKey + "\n" + GuestRequestKey + "\n" + OrderKey
                + "\n" + Status + "\nCreateDate: " + CreateDate + "\nOrderKey: " + OrderKey);
        }
        
        [XmlIgnore]
        public Enums.OrderStatus Status { get; set; }
        public int StatusId
        {
            get
            {
                return (int)Status;
            }
            set
            {
                Status = (Enums.OrderStatus)value;
            }
        }
        [XmlIgnore]
        public string StrStatus
        {
            get
            {
                string t = "";
                switch (Status)
                {
                    case Enums.OrderStatus.Closed:
                        t = "נסגר ללא הזמנה";
                        break;
                    case Enums.OrderStatus.Mailed:
                        t = "בתהליך";
                        break;
                    case Enums.OrderStatus.Not_treated:
                        t = "";
                        break;
                    case Enums.OrderStatus.Success:
                        t = "נסגר בהצלחה";
                        break;
                    default:
                        break;
                }
                return t;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class GuestRequest
    {
        public GuestRequest()
        {
            EntryDate = DateTime.Now.AddDays(1);
            ReleaseDate = DateTime.Now.AddDays(7);
        }

        int _GuestRequestsKey;
        string _FirstName;
        string _LastName;
        string _MailAddress;
        string _PhonePre;
        string _PhoneExt;
        DateTime _RegistrationDate;
        DateTime _EntryDate;
        DateTime _ReleaseDate;
        string _SubArea;
        int _Adult;
        int _Children;
        int _Rooms;

        public int GuestRequestsKey { get => _GuestRequestsKey; set => _GuestRequestsKey = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }

        [XmlIgnore]
        public string FullName { get => FirstName + " " + LastName; }

        public string MailAddress { get => _MailAddress; set => _MailAddress = value; }
        public string PhonePre { get => _PhonePre; set => _PhonePre = value; }
        public string PhoneExt { get => _PhoneExt; set => _PhoneExt = value; }

        [XmlIgnore]
        public string Phone { get => PhonePre + "-" + PhoneExt; }

        public DateTime RegistrationDate { get => _RegistrationDate; set => _RegistrationDate= value; }
        public DateTime EntryDate { get => _EntryDate; set => _EntryDate = value; }
        public DateTime ReleaseDate { get => _ReleaseDate; set => _ReleaseDate = value; }
        public string SubArea { get => _SubArea; set => _SubArea = value; }
        public int Adult { get => _Adult; set => _Adult = value; }
        public int Children { get => _Children; set => _Children = value; }
        public int Rooms { get => _Rooms; set => _Rooms = value; }

        public override string ToString()
        {
            return ("#" + GuestRequestsKey + ":\n" +
                   "סטטוס: " + StrStatus + "\n" +
                   "שם מלא: " + FirstName + " " + LastName + "\n" +
                    "מייל: " + MailAddress + "\n" +
                    "נוצר בתאריך: " + RegistrationDate.ToString("dd/MM/yyyy") + "\n" +
                    "תאריכים: " + EntryDate.ToString("dd/MM/yyyy") + "-" + ReleaseDate.ToString("dd/MM/yyyy") + "\n" +
                    "סוג: " + StrType + "\n" +
                    "אזור: " + StrArea + "," + SubArea + "\n" +
                    "מבוגרים: " + Adult + "\n" +
                    "ילדים: " + Children + "\n" +
                    "חדרים: " + Rooms + "\n" +
                    "בריכה: " + ConvertExtensionTypeToString(Pool) + "\n" +
                    "ג'קוזי: " + ConvertExtensionTypeToString(Jacuzzi) + "\n" +
                    "גינה: " + ConvertExtensionTypeToString(Garden) + "\n" +
                    "פעילות: " + ConvertExtensionTypeToString(ChildrensAttractions) + "\n"
                  );
        }
        
        [XmlIgnore]
        public Enums.ExtensionType Pool { get; set; }
        public int PoolId
         {
             get
             {
                 return (int)Pool;
             }
             set
             {
                 Pool = (Enums.ExtensionType)value;
             }
         }
        [XmlIgnore]
        public Enums.ExtensionType Jacuzzi { get; set; }
        public int JacuzziId
         {
             get
             {
                 return (int)Jacuzzi;
             }
             set
             {
                 Jacuzzi = (Enums.ExtensionType)value;
             }
         }
        [XmlIgnore]
        public Enums.ExtensionType Garden { get; set; }
        public int GardenId
         {
             get
             {
                 return (int)Garden;
             }
             set
             {
                 Garden = (Enums.ExtensionType)value;
             }
         }
        [XmlIgnore]
        public Enums.ExtensionType ChildrensAttractions { get; set; }
        public int ChildrensAttractionsId
         {
             get
             {
                 return (int)ChildrensAttractions;
             }
             set
             {
                 ChildrensAttractions = (Enums.ExtensionType)value;
             }
         }
        [XmlIgnore]
        public string StrArea
        {
            get
            {
                string t = "";
                switch (Area)
                {
                    case Enums.HostingUnitArea.All:
                        t = "הכל";
                        break;
                    case Enums.HostingUnitArea.North:
                        t = "צפון";
                        break;
                    case Enums.HostingUnitArea.South:
                        t = "דרום";
                        break;
                    case Enums.HostingUnitArea.Center:
                        t = "מרכז";
                        break;
                    case Enums.HostingUnitArea.Jerusalem:
                        t = "ירושלים";
                        break;
                    default:
                        break;
                }
                return t;
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
                    case Enums.GuestRequestStatus.Opened:
                        t = "פתוח";
                        break;
                    case Enums.GuestRequestStatus.InProccess:
                        t = "בתהליך";
                        break;
                    case Enums.GuestRequestStatus.ActiveAndClose:
                        t = "סגור";
                        break;
                    case Enums.GuestRequestStatus.Closed:
                        t = "סגירת מערכת";
                        break;
                    case Enums.GuestRequestStatus.Expired:
                        t = "פג תוקף";
                        break;
                    default:
                        break;
                }
                return t;
            }
        }
        [XmlIgnore]
        public string StrType
        {
            get
            {
                string t = "";
                switch (Type)
                {
                    case Enums.HostingUnitType.All:
                        t = "הכל";
                        break;
                    case Enums.HostingUnitType.Zimmer:
                        t = " צימר";
                        break;
                    case Enums.HostingUnitType.Hotel:
                        t = "מלון";
                        break;
                    case Enums.HostingUnitType.Camping:
                        t = "קמפינג";
                        break;
                    default:
                        break;
                }
                return t;
            }
        }
        [XmlIgnore]
        public string Description
        {
            get
            {

                return ("#" + GuestRequestsKey + "\n" +
                   //"סטטוס: " + StrStatus + "\n" +
                   "שם מלא: " + FirstName + " " + LastName + "\n" +
                    "מייל: " + MailAddress + "\n" +
                    "טלפון: " + Phone + "\n" +
                    "נוצר בתאריך: " + RegistrationDate.ToString("dd/MM/yyyy") + "\n" +
                    "תאריכים: " + EntryDate.ToString("dd/MM/yyyy") + "-" + ReleaseDate.ToString("dd/MM/yyyy") + "\n" +
                    "סוג: " + StrType + "\n" +
                    "אזור: " + StrArea + "," + SubArea + "\n" 
                  
                  );
            }
        }
        [XmlIgnore]
        public string Extantion
        {
            get
            {

                return (  "מבוגרים: " + Adult + "\n" +
                    "ילדים: " + Children + "\n" +
                    "חדרים: " + Rooms + "\n" +
                    "בריכה: " + ConvertExtensionTypeToString(Pool) + "\n" +
                    "ג'קוזי: " + ConvertExtensionTypeToString(Jacuzzi) + "\n" +
                    "גינה: " + ConvertExtensionTypeToString(Garden) + "\n" +
                    "פעילות: " + ConvertExtensionTypeToString(ChildrensAttractions) + "\n"
                  );
            }
        }
        [XmlIgnore]
        public Enums.HostingUnitArea Area { get; set; }
        public int AreaId
        {
            get
            {
                return (int)Area;
            }
            set
            {
                Area = (Enums.HostingUnitArea)value;
            }
        }
        [XmlIgnore]
        public Enums.GuestRequestStatus Status { get; set; }
        public int StatusId
        {
            get
            {
                return (int)Status;
            }
            set
            {
                Status = (Enums.GuestRequestStatus)value;
            }
        }
        [XmlIgnore]
        public Enums.HostingUnitType Type { get; set; }
        public int TypeId
        {
            get
            {
                return (int)Type;
            }
            set
            {
                Type = (Enums.HostingUnitType)value;
            }
        }
        [XmlIgnore]
        public string StrDates
        {
            get
            {
                return EntryDate.ToString("dd/MM/yy") + "-" + ReleaseDate.ToString("dd/MM/yy");


            }
        }
        private string ConvertExtensionTypeToString(Enums.ExtensionType type)
        {
            string t = "";
            switch (type)
            {
                case Enums.ExtensionType.All:
                    t = "הכל";
                    break;
                case Enums.ExtensionType.Necessary:
                    t = "נדרש";
                    break;
                case Enums.ExtensionType.Not_interested:
                    t = "לא מעוניין";
                    break;
                default:
                    break;
            }
            return t;
        }
    }
}

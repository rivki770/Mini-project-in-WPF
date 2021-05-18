using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    [Serializable()]
    public class HostingUnit
    {
        public HostingUnit()
        {
            //DiaryState = new Diary();
            Images = new List<GalleryImageItem>();
            Days = new List<FullDays>();
        }

        int _stSerialKey;
        int _OwnerId;
        bool _Pool;
        bool _Jacuzzi;
        bool _Garden;
        bool _ChildrensAttractions;
        string _SubArea;
        int _Adult;
        int _Children;
        int _Rooms;
        string _HostingUnitName;
        int _Totaldays;

        public int stSerialKey { get => _stSerialKey; set => _stSerialKey = value; }
        public int OwnerId { get => _OwnerId; set => _OwnerId = value; }
        public bool Pool { get => _Pool; set => _Pool = value; }
        public bool Jacuzzi { get => _Jacuzzi; set => _Jacuzzi = value; }
        public bool Garden { get => _Garden; set => _Garden = value; }
        public bool ChildrensAttractions { get => _ChildrensAttractions; set => _ChildrensAttractions = value; }
        public string SubArea { get => _SubArea; set => _SubArea = value; }
        public int Adult { get => _Adult; set => _Adult = value; }
        public int Children { get => _Children; set => _Children = value; }
        public int Rooms { get => _Rooms; set => _Rooms = value; }
        public string HostingUnitName { get => _HostingUnitName; set => _HostingUnitName = value; }
        public int Totaldays { get => _Totaldays; set => _Totaldays = value; }

        public override string ToString()
        {
            return HostingUnitName + ", " + stSerialKey + "\n";
        }

        [XmlIgnore]
        public Host Owner
        {
            get
            {
                return null;
            }
        }
        [XmlIgnore]
        public Enums.HosignUnitStatus Status { get; set; }
        [XmlIgnore]
        public Enums.HostingUnitType Type { get; set; }
        [XmlIgnore]
        public Enums.HostingUnitArea Area { get; set; }
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
        public int TypeId
        {
            get
            {
                return (int)Type;
            }
            set
            {
                Type = ( Enums.HostingUnitType)value;
            }
        }
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
        public int StatusId
        {
            get
            {
                return (int)Status;
            }
            set
            {
                Status = (Enums.HosignUnitStatus)value;
            }
        }

        
       // [XmlIgnore]
       // public Diary DiaryState { get; set; }
        [XmlIgnore]
        public List<GalleryImageItem> Images { get; set; }
        [XmlIgnore]
        private List<GalleryImageItem> _TempImages;
        [XmlIgnore]
        public List<GalleryImageItem> TempImages
        {
            get
            {
                if (_TempImages == null)
                {
                    _TempImages = Images.ToList();
                }
                return _TempImages;

            }
            set
            {
                _TempImages = value;
            }
        }
        [XmlIgnore]
        public List<FullDays> Days { get; set; }
    }




}

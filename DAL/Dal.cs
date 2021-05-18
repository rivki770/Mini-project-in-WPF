using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public class Dal : DAL.IDal
    {


        #region XML
        public List<T> FromXML<T>() //הבאה מXML
        {

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                var path = typeof(T).ToString() + ".xml";
                using (StreamReader reader = new StreamReader(path))
                {
                    return (List<T>)serializer.Deserialize(reader);
                }

            }
            catch
            {
                return null;
            }

        }


        private void ToXML<T>(List<T> data) //שמירה לXML
        {
            try
            {

                //create the serialiser to create the xml
                XmlSerializer serialiser = new XmlSerializer(typeof(List<T>));

                // Create the TextWriter for the serialiser to use
                var path = typeof(T).ToString() + ".xml";
                using (TextWriter filestream = new StreamWriter(path))
                {
                    //write to the file
                    serialiser.Serialize(filestream, data);
                }

            }
            catch
            {

            }
        }


        private void UpdateXml<T>(List<T> list)
        {
            ToXML<T>(list);
        }
        #endregion



        #region lists
        private List<Host> _HostsList;
        private List<Host> HostsList
        {
            get
            {
                if (_HostsList == null)
                {

                    _HostsList = FromXML<Host>();
                    if (_HostsList == null)
                    {
                        _HostsList = Hosts.getHosts();
                    }
                    if (_HostsList.Count > 0)
                    {
                        //עדכון המספר שממנו נעדכן את הנתונים החדשים
                        var max = _HostsList.OrderByDescending(c => c.Id).FirstOrDefault();
                        if (max != null)
                        {
                            Configuration.HostIdentity = max.Id + 1;
                        }
                    }

                }
                return _HostsList;
            }
        }


        private List<HostingUnit> _HostingUnitsList;
        private List<HostingUnit> HostingUnitsList
        {
            get
            {
                if (_HostingUnitsList == null)
                {
                   
                    _HostingUnitsList = FromXML<HostingUnit>();
                    if (_HostingUnitsList == null)
                    {
                        _HostingUnitsList = TempData.getHostingUnits();
                    }
                    if (_HostingUnitsList.Count > 0)
                    {
                        //עדכון המספר שממנו נעדכן את הנתונים החדשים
                        var max = _HostingUnitsList.OrderByDescending(c => c.stSerialKey).FirstOrDefault();
                        if (max != null)
                        {
                            Configuration.HostingUnitKey = max.stSerialKey + 1;
                        }
                    }
                }
                return _HostingUnitsList;
            }
        }


        private List<GalleryImageItem> _GalleryList;
        private List<GalleryImageItem> GalleryList
        {
            get
            {
                if (_GalleryList == null)
                {
                   
                    _GalleryList = FromXML<GalleryImageItem>();
                    if (_GalleryList == null)
                    {
                        _GalleryList = TempData.GetImages(HostingUnitsList);
                    }
                    if (_GalleryList.Count > 0)
                    {
                        //עדכון המספר שממנו נעדכן את הנתונים החדשים
                        var max = _GalleryList.OrderByDescending(c => c.Id).FirstOrDefault();
                        if (max != null)
                        {
                            Configuration.ImageIdentity = max.Id + 1;
                        }
                    }
                }
                return _GalleryList;
            }
        }


        private List<FullDays> _DaysList;
        private List<FullDays> DaysList
        {
            get
            {
                if (_DaysList == null)
                {

                    _DaysList = FromXML<FullDays>();
                    if (_DaysList == null)
                    {
                        _DaysList = new List<FullDays>();
                    }
                    if (_DaysList.Count > 0)
                    {
                        //עדכון המספר שממנו נעדכן את הנתונים החדשים
                        var max = _DaysList.OrderByDescending(c => c.Id).FirstOrDefault();
                        if (max != null)
                        {
                            Configuration.DaysIdentity = max.Id + 1;
                        }
                    }
                }
                return _DaysList;
            }
        }


        private List<Order> _OrderList;
        private List<Order> OrderList
        {
            get
            {
                if (_OrderList == null)
                {
                   
                    _OrderList = FromXML<Order>();
                    if (_OrderList == null)
                    {
                        _OrderList = new List<Order>();
                    }
                    if (_OrderList.Count > 0)
                    {
                        //עדכון המספר שממנו נעדכן את הנתונים החדשים
                        var max = _OrderList.OrderByDescending(c => c.OrderKey).FirstOrDefault();
                        if (max != null)
                        {
                            Configuration.OrderKey = max.OrderKey + 1;
                        }
                    }
                }
                return _OrderList;
            }
        }


        private List<GuestRequest> _GuestRequestList;
        private List<GuestRequest> GuestRequestList
        {
            get
            {
                if (_GuestRequestList == null)
                {
                    
                    _GuestRequestList = FromXML<GuestRequest>();
                    if (_GuestRequestList == null)
                    {
                        _GuestRequestList = TempData.getRequests();
                    }
                    if (_GuestRequestList.Count > 0)
                    {
                        //עדכון המספר שממנו נעדכן את הנתונים החדשים
                        var max = _GuestRequestList.OrderByDescending(c => c.GuestRequestsKey).FirstOrDefault();
                        if (max != null)
                        {
                            Configuration.GuestRequestKey = max.GuestRequestsKey + 1;
                        }
                    }
                }
                return _GuestRequestList;
            }
        }



        private GlobalSettings _GlobalSettingsObj;
        private GlobalSettings GlobalSettingsObj
        {
            get
            {
                if (_GlobalSettingsObj == null)
                {
                   
                    List <GlobalSettings> list = FromXML<GlobalSettings>();
                    if (list == null || list.Count() == 0)
                    {
                        _GlobalSettingsObj = new GlobalSettings()
                        {
                            ContactMail = Configuration.ContactMail,
                            OrderMailSubject = Configuration.OrderMailSubject,
                            OrderMailText = Configuration.OrderMailText,
                            PayForDay = Configuration.PayForDay
                        };
                    }
                    else
                    {
                        _GlobalSettingsObj = list[0];
                    }
                   
                }
                return _GlobalSettingsObj;
            }
        }

        //static lists

        private List<string> _PhonePreList;
        private List<string> PhonePreList
        {
            get
            {
                if (_PhonePreList == null)
                {
                    _PhonePreList = TempData.getPrePhones();
                }
                return _PhonePreList;
            }
        }


        private List<Bank> _BanksList;
        private List<Bank> BanksList
        {
            get
            {
                if (_BanksList == null)
                {
                    _BanksList = TempData.getBanks();
                }
                return _BanksList;
            }
        }

        private List<BankBranch> _BranchList;
        private List<BankBranch> BranchList
        {
            get
            {
                if (_BranchList == null)
                {
                    _BranchList = TempData.getBranches();
                }
                return _BranchList;
            }
        }


        #endregion



        #region Hosts


        public List<Host> GetAllHosts(Func<Host, bool> predicate = null)
        {
            if (predicate != null)
            {
                return HostsList.Where(predicate).ToList();
            }
            else
            {
                return HostsList;
            }

        }
        public void DeleteHost(int Id)
        {
            int index = HostsList.FindIndex(c => c.Id == Id);
            if (index > -1)
            {
                HostsList.RemoveAt(index);
            }
            UpdateXml<Host>(HostsList);
        }

        public Host GetHostById(int Id)
        {
            var host = HostsList.FirstOrDefault(c => c.Id == Id);
            host.RelatedHostingUnit = GetHostingUnits(c => c.OwnerId == Id).ToList();
            return host;
        }

        public void UpdateHost(Host host)
        {
            var h = GetHostById(host.Id);
            if (h != null)
            {
                h.FirstName = host.FirstName;
                h.LastName = host.LastName;
                h.MailAddress = host.MailAddress;
                h.PhoneExt = host.PhoneExt;
                h.PhonePre = host.PhonePre;
                h.HostKey = host.HostKey;
            }
            UpdateXml<Host>(HostsList);
        }

        public void AddHost(Host host)
        {
            host.Id = Configuration.HostIdentity;
            Configuration.HostIdentity++;
            HostsList.Add(host);
            UpdateXml<Host>(HostsList);
        }
        #endregion

        #region HostingUnits


        public List<BE.HostingUnit> GetHostingUnits(Func<BE.HostingUnit, bool> predicate = null)
        {
            List<BE.HostingUnit> list = null;
            if (predicate != null)
            {
                list = HostingUnitsList.Where(predicate).ToList();
            }
            else
            {
                list = HostingUnitsList;
            }

            for (int i = 0; i < list.Count(); i++)
            {
                list[i].Images = GalleryList.Where(c => c.HostingUnitId == list[i].stSerialKey).ToList();
            }

            for (int i = 0; i < list.Count(); i++)
            {
                list[i].Days = DaysList.Where(c => c.HostingUnitId == list[i].stSerialKey).ToList();
            }

            return list;

        }

        public HostingUnit GetHostingUnitById(int stSerialKey)
        {
            var hosting = HostingUnitsList.FirstOrDefault(c => c.stSerialKey == stSerialKey);
            if (hosting != null)
            {
                hosting.Images = GalleryList.Where(c => c.HostingUnitId == hosting.stSerialKey).ToList();

            }
            return hosting;
        }

        public void AddHostingUnit(BE.HostingUnit hostingUnit)
        {

            hostingUnit.stSerialKey = Configuration.HostingUnitKey;
            Configuration.HostingUnitKey++;
            HostingUnitsList.Add(hostingUnit);
            //save images
            for (int i = 0; i < hostingUnit.TempImages.Count(); i++)
            {

                int key = Configuration.ImageIdentity;
                Configuration.ImageIdentity++;
                GalleryImageItem ii = new GalleryImageItem()
                {
                    HostingUnitId = hostingUnit.stSerialKey,
                    Id = key,
                    Url = hostingUnit.TempImages[i].Url
                };
                GalleryList.Add(ii);

            }
            UpdateXml<HostingUnit>(HostingUnitsList);
            UpdateXml<GalleryImageItem>(GalleryList);

        }

        public void DeleteHostingUnit(int hostingUnitId)
        {
            int index = HostingUnitsList.FindIndex(c => c.stSerialKey == hostingUnitId);
            if (index > -1)
            {
                HostingUnitsList.RemoveAt(index);
                //delete Prev items
                GalleryList.RemoveAll(c => c.HostingUnitId == hostingUnitId);

            }
            UpdateXml<HostingUnit>(HostingUnitsList);
            UpdateXml<GalleryImageItem>(GalleryList);
        }

        public void UpdatingHostingUnit(BE.HostingUnit hostingUnit)
        {
            var h = GetHostingUnitById(hostingUnit.stSerialKey);
            if (h != null)
            {
                h.HostingUnitName = hostingUnit.HostingUnitName;
                h.Rooms = hostingUnit.Rooms;
                h.SubArea = hostingUnit.SubArea;
                h.OwnerId = hostingUnit.OwnerId;
                h.Pool = hostingUnit.Pool;
                h.Adult = hostingUnit.Adult;
                h.Area = hostingUnit.Area;
                h.Children = hostingUnit.Children;
                h.ChildrensAttractions = hostingUnit.ChildrensAttractions;
                h.Garden = hostingUnit.Garden;
                //h.
                h.Status = hostingUnit.Status;
                //h.DiaryState = hostingUnit.DiaryState;

                //delete Prev items
                GalleryList.RemoveAll(c => c.HostingUnitId == hostingUnit.stSerialKey);
                for (int i = 0; i < hostingUnit.TempImages.Count(); i++)
                {

                    int key = Configuration.ImageIdentity;
                    Configuration.ImageIdentity++;
                    GalleryImageItem ii = new GalleryImageItem()
                    {
                        HostingUnitId = hostingUnit.stSerialKey,
                        Id = key,
                        Url = hostingUnit.TempImages[i].Url
                    };
                    GalleryList.Add(ii);

                }
                UpdateXml<HostingUnit>(HostingUnitsList);
                UpdateXml<GalleryImageItem>(GalleryList);
            }
        }



        #endregion

        #region Banks
        public List<Bank> GetBanksList()
        {
            return BanksList;
        }
        #endregion

        #region Branch

        public List<BankBranch> GetBankAccounts(Func<BankBranch, bool> predicate)
        {
            throw new NotImplementedException();
        }


        public List<BankBranch> GetBankBranches(Func<BankBranch, bool> predicate)
        {
            return BranchList;
        }

        public List<BankBranch> GetBankBranchesByBank(int BankNumber)
        {
            return BranchList.Where(c => c.BankNumber == BankNumber).ToList();
        }
        #endregion

        #region PrePhones
        public List<string> GetPrePhones()
        {
            return PhonePreList;
        }
        #endregion


        #region Guest Request
        public void AddGusetRequest(GuestRequest guestRequest)
        {
            guestRequest.GuestRequestsKey = Configuration.GuestRequestKey;
            Configuration.GuestRequestKey++;
            guestRequest.Status = Enums.GuestRequestStatus.Opened;
            guestRequest.RegistrationDate = DateTime.Now;
            GuestRequestList.Add(guestRequest);
            UpdateXml<GuestRequest>(GuestRequestList);
        }

        public void UpdatingGusetRequest(GuestRequest guestRequest, Enums.GuestRequestStatus status)
        {
            int index = GuestRequestList.FindIndex(c => c.GuestRequestsKey == guestRequest.GuestRequestsKey);
            if (index > -1)
            {
                GuestRequestList[index].Status = status;



            }
            UpdateXml<GuestRequest>(GuestRequestList);
        }

        public List<GuestRequest> GetGuestRequests(Func<GuestRequest, bool> predicate = null)
        {
            //update unrelevant request to expired
            var expired_requests = GuestRequestList.Where(c => c.EntryDate < DateTime.Now && (c.StatusId == 0 /*open*/ || c.StatusId == 1 /*inproccess*/)).ToList();
            if (expired_requests.Count > 0)
            {
                foreach (var expired_request in expired_requests)
                {
                    UpdatingGusetRequest(expired_request, Enums.GuestRequestStatus.Expired);
                }
            }
            if (predicate != null)
            {
                return GuestRequestList.Where(predicate).ToList();
            }
            else
            {
                return GuestRequestList;
            }

        }
        #endregion


        #region order



        public void AddOrder(Order order)
        {
            order.OrderKey = Configuration.OrderKey;
            Configuration.OrderKey++;
            order.CreateDate = DateTime.Now;
            OrderList.Add(order);
            UpdateXml<Order>(OrderList);
            UpdateXml<FullDays>(DaysList);
        }

        public void UpdatingOrder(Order order, Enums.OrderStatus status)
        {
            int index = OrderList.FindIndex(c => c.OrderKey == order.OrderKey);
            if (index > -1)
            {
                OrderList[index].Status = status;

                if (status == Enums.OrderStatus.Success)
                {
                    //עדכון של שאר ההזמנות
                    var orders = OrderList.FindAll(c => c.GuestRequestKey == order.GuestRequestKey);
                    foreach (var orderi in orders)
                    {
                        orderi.Status = Enums.OrderStatus.Closed;
                    }

                    //עדכון הימים באכסניה

                    int hostingid = HostingUnitsList.FindIndex(c => c.stSerialKey == order.HostingUnitKey);
                    var request = GuestRequestList.Where(c => c.GuestRequestsKey == order.GuestRequestKey).FirstOrDefault();
                    HostingUnit relatedHostings =GetHostingUnits(c => c.stSerialKey == order.HostingUnitKey).FirstOrDefault();
                    Host relatedHost = GetHostById(relatedHostings.OwnerId);
                    var settings = GetGlobalSettings();
                    if (hostingid > -1 && request != null && relatedHost != null && settings != null)
                    {
                        // Diary diary = HostingUnitsList[hostingid].DiaryState;
                        for (DateTime time = request.EntryDate.AddDays(1); time < request.ReleaseDate; time = time.AddDays(1))
                        {
                            DaysList.Add(new FullDays(){
                                Date  = time.Date,
                                 HostingUnitId = order.HostingUnitKey,
                                 OrderId = order.OrderKey,
                                  Id = Configuration.DaysIdentity +1

                            });
                            Configuration.DaysIdentity++;
                            relatedHost.Discount += settings.PayForDay;
                            relatedHostings.Totaldays++;
                    

                            //diary.Calender[time.Month - 1, time.Day - 1] = true;
                        }
                        // HostingUnitsList[key].DiaryState = diary;
                    }
                    OrderList[index].Status = Enums.OrderStatus.Success; //אני לא יודעת אם סטטוס ההזמנה המקורית השנה אף הוא
                   
                }
                UpdateXml<Order>(OrderList);
                UpdateXml<FullDays>(DaysList);
                UpdateXml<Host>(HostsList);
            }
        }

        public List<Order> GetOrders(Func<Order, bool> predicate = null)
        {
            return OrderList.Where(predicate).ToList();
        }

        #endregion


        #region Global Settings


        public GlobalSettings GetGlobalSettings()
        {
            return GlobalSettingsObj;
        }

        public void UpdateGlobalSettings(GlobalSettings setting)
        {
            List<GlobalSettings> list = new List<GlobalSettings>();
            list.Add(setting);
            UpdateXml<GlobalSettings>(list);
        }

       

        #endregion
    }
}

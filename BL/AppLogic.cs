using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class AppLogic : BL.IAppLogic
    {
        //small test
        private IDal dal { get; set; }
        public AppLogic(IDal _dal)
        {
            dal = _dal;
        }


        #region Global App 

        public void SendMail ( string from, string to, string subject, string body, bool isHtml){
             MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("kymsite@gmail.com");
                mail.To.Add(to);

                mail.Subject = subject;
                 mail.Body = body;
                 mail.IsBodyHtml = isHtml;
                //mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("kymsite@gmail.com", "g9095398");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
        }
        #endregion

        #region Hosts

        public List<Host> GetAllHosts()
        {
            return dal.GetAllHosts();
        }
        public List<Host> GetAllHosts(Func<BE.Host, bool> predicate)
        {
            return dal.GetAllHosts(predicate);
        }
        public void DeleteHost(int Id, out Enums.HostValidationStatus status)
        {
            status = Enums.HostValidationStatus.Deleted;
            var hosts = dal.GetHostingUnits(c => c.OwnerId == Id).ToList();
            if (hosts.Count > 0)
            {
                status = Enums.HostValidationStatus.HasActiveHostingUnits;
                return;
            }
            dal.DeleteHost(Id);
        }

        public Host GetHostById(int Id)
        {
            return dal.GetHostById(Id);
        }

        public void UpdateHost(Host host, out Enums.HostValidationStatus status)
        {
            status = Enums.HostValidationStatus.Success;
            if (string.IsNullOrEmpty(host.FirstName) || (string.IsNullOrEmpty(host.LastName)) || string.IsNullOrEmpty(host.PhonePre) || string.IsNullOrEmpty(host.PhoneExt) || string.IsNullOrEmpty(host.MailAddress))
            {
                status = Enums.HostValidationStatus.MissingFields;
                return;
            }
            //בדיקה האם תעודת הזהות והטלפון זה ספרות
            long id = 0;

            long.TryParse(host.PhoneExt, out id);
            if (id == 0)
            {
                status = Enums.HostValidationStatus.WrongFields;
                return;
            }
            if (!string.IsNullOrEmpty(host.MailAddress))
            {
                //ואלידציה לכתובת המייל
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (!regex.IsMatch(host.MailAddress))
                {
                    status = Enums.HostValidationStatus.WrongFields;
                    return;
                }
            }
            if (host.PhoneExt.Length < 7)
            {
                status = Enums.HostValidationStatus.WrongFields;
                return;
            }
            if (host.BankNumber == 0 || host.BranchNumber == 0 || host.BankAccount == 0)
            {
                status = Enums.HostValidationStatus.MissingBankAccount;
                return;
            }
            dal.UpdateHost(host);
        }

        public void AddHost(Host host, out Enums.HostValidationStatus status)
        {
            status = Enums.HostValidationStatus.Success;
            var list = dal.GetAllHosts(c => c.HostKey == host.HostKey).ToList();
            if (list.Count > 0)
            {
                status = Enums.HostValidationStatus.DuplicateId;
                return;
            }
            list = dal.GetAllHosts(c => c.MailAddress == host.MailAddress).ToList();
            if (list.Count > 0)
            {
                status = Enums.HostValidationStatus.EmailExist;
                return;
            }
            if (string.IsNullOrEmpty(host.FirstName) || string.IsNullOrEmpty(host.LastName) || string.IsNullOrEmpty(host.HostKey) || string.IsNullOrEmpty(host.PhonePre) || string.IsNullOrEmpty(host.PhoneExt) || string.IsNullOrEmpty(host.MailAddress))
            {
                status = Enums.HostValidationStatus.MissingFields;
                return;
            }
            if (host.HostKey.Length < 9)
            {
                status = Enums.HostValidationStatus.WrongId;
                return;
            }

            var HostsWithSameIds = dal.GetAllHosts(c => c.HostKey == host.HostKey);
            if (HostsWithSameIds.Count > 0)
            {
                status = Enums.HostValidationStatus.DuplicateId;
                return;
            }
            //בדיקה האם תעודת הזהות והטלפון זה ספרות
            long id = 0;
            long.TryParse(host.HostKey, out id);
            if (id == 0)
            {
                status = Enums.HostValidationStatus.WrongFields;
                return;
            }
            long.TryParse(host.PhoneExt, out id);
            if (id == 0)
            {
                status = Enums.HostValidationStatus.WrongFields;
                return;
            }
            if (!string.IsNullOrEmpty(host.MailAddress))
            {
                //ואלידציה לכתובת המייל
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (!regex.IsMatch(host.MailAddress))
                {
                    status = Enums.HostValidationStatus.WrongFields;
                    return;
                }
            }
            if (host.PhoneExt.Length < 7)
            {
                status = Enums.HostValidationStatus.WrongFields;
                return;
            }

            if (host.BankNumber == 0 || host.BranchNumber == 0 || host.BankAccount == 0)
            {
                status = Enums.HostValidationStatus.MissingBankAccount;
                return;
            }

            dal.AddHost(host);
        }

        public void SetCollectionClearance(int OwnerId, bool CollectionClearance)
        {
            Host host = dal.GetHostById(OwnerId);
            host.CollectionClearance = CollectionClearance;
            dal.UpdateHost(host);
        }
        #endregion


        #region HostingUnits


        public List<BE.HostingUnit> GetHostingUnits(Func<BE.HostingUnit, bool> predicate = null)
        {
            return dal.GetHostingUnits(predicate);
        }

        public HostingUnit GetHostingUnitById(int stSerialKey)
        {
            return dal.GetHostingUnitById(stSerialKey);
        }

        public void AddHostingUnit(BE.HostingUnit hostingUnit, out Enums.HostingUnitSaveStatus status)
        {
            status = Enums.HostingUnitSaveStatus.Success;
            if (string.IsNullOrEmpty(hostingUnit.HostingUnitName) ||
                 hostingUnit.Area == Enums.HostingUnitArea.All ||
                 hostingUnit.Type == Enums.HostingUnitType.All ||
                string.IsNullOrEmpty(hostingUnit.SubArea) ||
                hostingUnit.Rooms == 0 ||
                hostingUnit.OwnerId == 0 ||
                hostingUnit.Children == 0 ||
                hostingUnit.Adult == 0
                )
                status = Enums.HostingUnitSaveStatus.MissingFields;
            if (status == Enums.HostingUnitSaveStatus.Success)
                dal.AddHostingUnit(hostingUnit);
        }

        public bool DeleteHostingUnit(int hostingUnitId)
        {
            var hostingUnits = dal.GetOrders(c => c.HostingUnitKey == hostingUnitId).ToList();
            if (hostingUnits.Count > 0)
            {
                
                //אי אפשר למחוק את הבקשה
                return false;
            }
            dal.DeleteHostingUnit(hostingUnitId);
            return true;
        }

        public void UpdatingHostingUnit(BE.HostingUnit hostingUnit, out Enums.HostingUnitSaveStatus status)
        {
            status = Enums.HostingUnitSaveStatus.Success;
            if (string.IsNullOrEmpty(hostingUnit.HostingUnitName) ||
                hostingUnit.Area == Enums.HostingUnitArea.All ||
                hostingUnit.Type == Enums.HostingUnitType.All ||
               string.IsNullOrEmpty(hostingUnit.SubArea) ||
               hostingUnit.Rooms == 0 ||
               hostingUnit.OwnerId == 0 ||
               hostingUnit.Children == 0 ||
               hostingUnit.Adult == 0
               )
                status = Enums.HostingUnitSaveStatus.MissingFields;
            if (status == Enums.HostingUnitSaveStatus.Success)
                dal.UpdatingHostingUnit(hostingUnit);
        }


        public IEnumerable<Object> GetHostingUnitGrouingByOwner(Func<BE.HostingUnit, bool> predicate = null)
        {

            var hostings_units = from p in  dal.GetHostingUnits(predicate)
                          group p by p.OwnerId into g
                                 select new { OwnerId = g.Key, OwnerName=dal.GetHostById(g.Key).FullName, Units = g.ToList() };

           
            return hostings_units;
        }



        #endregion


        #region Banks

        public List<Bank> GetBanksList()
        {
            return dal.GetBanksList();
        }

        #endregion


        #region Branch



        public List<BankBranch> GetBankBranches(Func<BankBranch, bool> predicate)
        {
            return dal.GetBankBranches(predicate);
        }

        public List<BankBranch> GetBankBranchesByBank(int BankNumber)
        {
            return dal.GetBankBranchesByBank(BankNumber);
        }
        #endregion


        #region PrePhones
        public List<string> GetPrePhones()
        {
            return dal.GetPrePhones();
        }
        #endregion


        #region GuestRequest

        //פונקציה להוספת בקשה
        public void AddGusetRequest(GuestRequest guestRequest, out Enums.GuestRequesteCreateStatus status)
        {
            status = Enums.GuestRequesteCreateStatus.Success;
            if (string.IsNullOrEmpty(guestRequest.FirstName) || (string.IsNullOrEmpty(guestRequest.LastName)) || string.IsNullOrEmpty(guestRequest.MailAddress))
            {
                status = Enums.GuestRequesteCreateStatus.MissingFields;
                return;
            }
            //if (guestRequest.GuestRequestsKey < 10000000)
            //{
            //    status = Enums.GuestRequesteCreateStatus.WrongFields;
            //    return;
            //}

            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!regex.IsMatch(guestRequest.MailAddress))
            {
                status = Enums.GuestRequesteCreateStatus.WrongFields;
                return;
            }

            long id = 0;
            long.TryParse(guestRequest.PhoneExt, out id);
            if (id == 0)
            {
                status = Enums.GuestRequesteCreateStatus.WrongFields;
                return;
            }

            if (guestRequest.PhoneExt.Length < 7)
            {
                status = Enums.GuestRequesteCreateStatus.WrongFields;
                return;
            }
            if (guestRequest.ReleaseDate < guestRequest.EntryDate || guestRequest.EntryDate < DateTime.Now)
            {
                status = Enums.GuestRequesteCreateStatus.ErrorDates;
                return;
            }

            var hostings = dal.GetHostingUnits();
            int avilableHostings = 0;
            foreach (var hosting in hostings)
            {
                if (CheckForFreeDays(guestRequest, hosting))
                {
                    avilableHostings++;
                }
            }
            if (avilableHostings == 0)
            {
                status = Enums.GuestRequesteCreateStatus.NoHosting;
                return;
            }
            dal.AddGusetRequest(guestRequest);
        }

        //פונקציה שמעדכנת סטטוס בקשה
        public void UpdatingGusetRequest(GuestRequest guestRequest, Enums.GuestRequestStatus status)
        {
            if (guestRequest.Status == Enums.GuestRequestStatus.Closed || guestRequest.Status == Enums.GuestRequestStatus.ActiveAndClose)
            {
                return;
            }
            guestRequest.Status = status;
            dal.UpdatingGusetRequest(guestRequest, status);
        }

        //פונקציה שמקבלת בקשות עם אופציות של סינון
        public List<GuestRequest> GetGuestRequests(Func<GuestRequest, bool> predicate)
        {
            return dal.GetGuestRequests(predicate);
        }

        //פונקציה שמחזירה יחידות אירוח מתאימות לבקשה, עם אופציה לראות יחידות אירוח רק השייכים למארח
        public List<RelatedHosting> GetRelevantHostingByRequest(GuestRequest guestRequest, int OwnerId = 0)
        {
            //יש לסנן גם לפי הOWNERID
            List<HostingUnit> hostings = dal.GetHostingUnits(c=>c.OwnerId == OwnerId || OwnerId==0);
            List<RelatedHosting> hostingsNew = new List<RelatedHosting>();

            foreach (HostingUnit hosting in hostings)
            {
                if (CheckForFreeDays(guestRequest, hosting))
                {

                    ///check for other fields
                    ///
                    if (guestRequest.Area != Enums.HostingUnitArea.All)
                    {
                        if (hosting.Area != guestRequest.Area) continue;
                    }

                    if (!string.IsNullOrEmpty(guestRequest.SubArea))
                    {
                        if (hosting.SubArea != guestRequest.SubArea) continue;
                    }

                    if (guestRequest.Type != Enums.HostingUnitType.All)
                    {
                        if (hosting.Type != guestRequest.Type) continue;
                    }


                    if (guestRequest.Adult != 0)
                    {
                        if (hosting.Adult < guestRequest.Adult) continue;
                    }


                    if (guestRequest.Children != 0)
                    {
                        if (hosting.Children < guestRequest.Children) continue;
                    }

                    if (guestRequest.Rooms != 0)
                    {
                        if (hosting.Rooms < guestRequest.Rooms) continue;
                    }

                    if (guestRequest.Pool != Enums.ExtensionType.All)
                    {
                        if (guestRequest.Pool == Enums.ExtensionType.Necessary && !hosting.Pool) continue;
                        if (guestRequest.Pool == Enums.ExtensionType.Not_interested && hosting.Pool) continue;
                    }

                    if (guestRequest.Jacuzzi != Enums.ExtensionType.All)
                    {
                        if (guestRequest.Jacuzzi == Enums.ExtensionType.Necessary && !hosting.Jacuzzi) continue;
                        if (guestRequest.Jacuzzi == Enums.ExtensionType.Not_interested && hosting.Jacuzzi) continue;
                    }

                    if (guestRequest.Garden != Enums.ExtensionType.All)
                    {
                        if (guestRequest.Garden == Enums.ExtensionType.Necessary && !hosting.Garden) continue;
                        if (guestRequest.Garden == Enums.ExtensionType.Not_interested && hosting.Garden) continue;
                    }
                    if (guestRequest.ChildrensAttractions != Enums.ExtensionType.All)
                    {
                        if (guestRequest.ChildrensAttractions == Enums.ExtensionType.Necessary && !hosting.ChildrensAttractions) continue;
                        if (guestRequest.ChildrensAttractions == Enums.ExtensionType.Not_interested && hosting.ChildrensAttractions) continue;
                    }

                    int orderid = 0;
                    Order o = GetOrders(c => c.GuestRequestKey == guestRequest.GuestRequestsKey && c.HostingUnitKey == hosting.stSerialKey).FirstOrDefault();
                    if (o != null) orderid = o.OrderKey;
                    hostingsNew.Add(new RelatedHosting() { HostingUnitName = hosting.HostingUnitName, OrderId = orderid, stSerialKey = hosting.stSerialKey });
                }
            }
            return hostingsNew;
        }

        public List<GuestRequest> GetRequestsThatRelevantForOwner(Func<GuestRequest, bool> predicate, int OwnerId = 0)
        {
            //update expired request
           
            List<GuestRequest> list = new List<GuestRequest>();
            var requests =  dal.GetGuestRequests(predicate);
            foreach (var req in requests)
            {
                var relevant = GetRelevantHostingByRequest(req, OwnerId);
                if (relevant != null && relevant.Count() > 0)
                {
                    list.Add(req);
                }
            }

            return list;

        }


        #endregion


        #region Order
        public void AddOrder(Order order, out Enums.OrderCreateStatus status)
        {
            status = Enums.OrderCreateStatus.Success;
            //מבצע בדיקה שמספר יחידת האירוח קיים  - סיום

            HostingUnit relatedHostings = dal.GetHostingUnits(c => c.stSerialKey == order.HostingUnitKey).FirstOrDefault();

            if (relatedHostings == null)
            {
                status = Enums.OrderCreateStatus.ErrorInDetails;
                return;
            }
            //find the related host
            Host host = dal.GetHostById(relatedHostings.OwnerId);
            if (!host.CollectionClearance)
            {
                status = Enums.OrderCreateStatus.MissingCollectionClearance;
                return;
            }
            //מבצע בדיקה שמספר הבקשה קיימת והסטטוס או פתוח או בתהליך - סיום
            GuestRequest guest = dal.GetGuestRequests(c => c.GuestRequestsKey == order.GuestRequestKey).FirstOrDefault();

            if (guest == null || guest.Status == Enums.GuestRequestStatus.Closed || guest.Status == Enums.GuestRequestStatus.ActiveAndClose || guest.Status == Enums.GuestRequestStatus.Expired)
            {
                status = Enums.OrderCreateStatus.ErrorInDetails;
                return;
            }

            order.GuestRequestKey = guest.GuestRequestsKey;
            order.HostingUnitKey = relatedHostings.stSerialKey;

            //שליחת מייל ללקוח - סיום
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                var settings = dal.GetGlobalSettings();
                // {NAME} {REQUESTID} {HOSTINGNAME} {IMAGE} {OWNERNAME} {OWNERMAIL}
                var subject = settings.OrderMailSubject
                        .Replace("{NAME}", guest.FullName)
                        .Replace("{REQUESTID}", guest.GuestRequestsKey.ToString())
                        .Replace("{HOSTINGNAME}", relatedHostings.HostingUnitName)
                        .Replace("{OWNERNAME}", host.FullName)
                        .Replace("{OWNERMAIL}", host.MailAddress)
                        .Replace("{IMAGE}", "");
              

                var body = "<div style='width:600px; border:solid 5px #ccc; margin:0 auto; padding:15px; direction:rtl; font-size:20px; text-align:center' >" + settings.OrderMailText
                       .Replace("{NAME}", "<strong>" +  guest.FullName + "</strong>")
                       .Replace("{REQUESTID}", guest.GuestRequestsKey.ToString())
                        .Replace("{HOSTINGNAME}", "<h1>" +  relatedHostings.HostingUnitName + "</h1>")
                        .Replace("{OWNERNAME}", host.FullName)
                        .Replace("{OWNERMAIL}", "<span style='direction:ltr'>" + host.MailAddress + "</span>")
                        .Replace(System.Environment.NewLine, "<br />")
                        .Replace("\n", "<br />");
                if (relatedHostings.Images.Count > 0)
                {
                    body = body.Replace("{IMAGE}", "<img style='width:250px; border:solid 1px #fff' src='" + relatedHostings.Images[0].Url + "' />");
                }
                else
                {
                    body = body.Replace("{IMAGE}", "");
                }

                body = body + "</div>";

                mail.From = new MailAddress("kymsite@gmail.com");
                mail.To.Add(guest.MailAddress);

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("kymsite@gmail.com", "g9095398");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                status = Enums.OrderCreateStatus.MailFailed;
                return;
            }
            order.Status = Enums.OrderStatus.Mailed;
            dal.AddOrder(order);
            dal.UpdatingGusetRequest(guest, Enums.GuestRequestStatus.InProccess);

        }

        public bool UpdatingOrder(int OrderId, Enums.OrderStatus status)
        {
            //if (order.Status == Enums.OrderStatus.Closes_in_response)
            //    return;

            Order order = dal.GetOrders(c => c.OrderKey == OrderId).FirstOrDefault();
            if (order == null) return false;
            order.Status = status;
            GuestRequest guest = dal.GetGuestRequests(c => c.GuestRequestsKey == order.GuestRequestKey).FirstOrDefault();
            HostingUnit relatedHostings = dal.GetHostingUnits(c => c.stSerialKey == order.HostingUnitKey).FirstOrDefault();

            if (relatedHostings == null)
            {

                return false;
            }
            if (guest == null || guest.Status == Enums.GuestRequestStatus.Closed || guest.Status == Enums.GuestRequestStatus.ActiveAndClose || guest.Status == Enums.GuestRequestStatus.Expired)
            {

                return false;
            }

            if (status == Enums.OrderStatus.Success)
            {

                dal.UpdatingGusetRequest(guest, Enums.GuestRequestStatus.ActiveAndClose);

            }

            dal.UpdatingOrder(order, status);

            return true;


        }

        public List<Order> GetOrders(Func<Order, bool> predicate, int OwnerId = 0)
        {

            return dal.GetOrders(predicate);
        }

        public IEnumerable<object> GetFullOrder(Func<Order, bool> predicate, int OwnerId = 0)
        {
            var orderList = (from order in dal.GetOrders(predicate)
                             select new
                             {
                                 OrderKey = order.OrderKey,
                                 OrderDate = order.OrderDate,
                                 HostingName = dal.GetHostingUnitById(order.HostingUnitKey).HostingUnitName,
                                 RequestUserName = dal.GetGuestRequests(c => c.GuestRequestsKey == order.GuestRequestKey).FirstOrDefault().FullName,
                                 HostingNum = dal.GetHostingUnitById(order.HostingUnitKey).stSerialKey,
                                 Status = order.StrStatus,
                                 Gmail = dal.GetGuestRequests(c => c.GuestRequestsKey == order.GuestRequestKey).FirstOrDefault().MailAddress,
                                 Time = dal.GetGuestRequests(c => c.GuestRequestsKey == order.GuestRequestKey).FirstOrDefault().StrDates,
                                 Phone = dal.GetGuestRequests(c => c.GuestRequestsKey == order.GuestRequestKey).FirstOrDefault().Phone
                             });

            return orderList;
        }

        #endregion





        #region Global Settings
        public GlobalSettings GetGlobalSettings()
        {
            return dal.GetGlobalSettings();
        }

        public bool UpdateGlobalSettings(GlobalSettings setting)
        {
            if (string.IsNullOrEmpty(setting.ContactMail)
               || string.IsNullOrEmpty(setting.OrderMailSubject)
                 || string.IsNullOrEmpty(setting.OrderMailText)
                ) return false;

            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!regex.IsMatch(setting.ContactMail))
            {
                return false;
            }
            if (setting.PayForDay < 0)
                return false;

            dal.UpdateGlobalSettings(setting);
            return true;
        }
        #endregion


        public bool CheckForFreeDays(GuestRequest guestReq, HostingUnit unit)
        {
            DateTime first = guestReq.EntryDate;
            first = first.AddDays(1);
            DateTime last = guestReq.ReleaseDate;
            last = last.AddDays(-1);
            for (DateTime date = first; date < last; date = date.AddDays(1))
            {
                var exist = unit.Days.Where(c => c.Date.Date == date.Date).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                //if (unit.DiaryState.Calender[date.Month - 1, date.Day - 1] == true)
                //    return false;
            }
            return true;
        }

        public bool CheckForFreeDays(HostingUnit hosting, DateTime first, DateTime last)
        {
            for (DateTime date = first; date < last; date = date.AddDays(1))
            {
                var exist = hosting.Days.Where(c => c.Date.Date == date.Date).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                //if (hosting.DiaryState.Calender[date.Month - 1, date.Day - 1] == true)
                //    return false;
            }
            return true;
        }

        public List<List<GuestRequest>> GetGuestRequestsGrouingByArea()
        {
            var guestList = dal.GetGuestRequests()
                .GroupBy(c => c.Area)
                .Select(grp => grp.ToList())
                .ToList();

            return guestList;
        }

        public List<HostingUnit> HostingUnitList(DateTime time, int numDay)
        {
            List<HostingUnit> hostingUnits = dal.GetHostingUnits();
            List<HostingUnit> hostingUnitsNew = null;
            foreach (HostingUnit hostingUnit in hostingUnits)
            {
                if (CheckForFreeDays(hostingUnit, time.AddDays(1), time.AddDays(-1)))
                {
                    hostingUnitsNew.Add(hostingUnit);
                }
            }
            return hostingUnitsNew;
        }

        public int NumDays(DateTime start, DateTime end)
        {
            return (end - start).Days;
        }

        public int NumDays(DateTime start)
        {
            DateTime end = DateTime.Now;
            return (end - start).Days;
        }

        public List<Order> OrderFromTime(int numDay)
        {
            List<Order> orders = dal.GetOrders();
            List<Order> ordersNew = null;
            foreach (Order order in orders)
            {
                int create = (DateTime.Now - order.CreateDate).Days;
                int sent = (DateTime.Now - order.OrderDate).Days;
                if (!(numDay > create) || !(numDay > sent))
                    ordersNew.Add(order);
            }
            return ordersNew;
        }

        public List<GuestRequest> RequestMatchToStipulation(Predicate<GuestRequest> predic)
        {

            List<GuestRequest> guestRequestsNew = null;
            List<GuestRequest> guestRequests = dal.GetGuestRequests();
            bool temp = true;
            foreach (GuestRequest guestRequest in guestRequests)
            {
                if (guestRequest.Status == Enums.GuestRequestStatus.ActiveAndClose)
                {
                    foreach (Predicate<GuestRequest> item in predic.GetInvocationList())
                    {
                        if (!item(guestRequest))
                            temp = false;
                    }
                    if (temp)
                        guestRequestsNew.Add(guestRequest);
                    temp = true;
                }
            }
            return guestRequestsNew;
        }

        public int Orders(GuestRequest guestRequest) //מספר יחידות אירוח שמתאימות להזמנה
        {
            List<Order> temp = null;
            List<Order> orders = dal.GetOrders();
            foreach (Order order in orders)
            {
                if (order.GuestRequestKey == guestRequest.GuestRequestsKey)
                    temp.Add(order);
            }
            return temp.Count;
        }

        public int Orders(HostingUnit hostingUnit)
        {
            int count = 0;
            List<Order> orders = dal.GetOrders();
            foreach (Order order in orders)
            {
                if (order.HostingUnitKey == hostingUnit.stSerialKey)
                    count++;
            }
            return count;
        }

        #region grouping

        public IEnumerable<IGrouping<Enums.HostingUnitArea, GuestRequest>> GroupGRByArea()
        {
            IEnumerable<GuestRequest> guestRequests = dal.GetGuestRequests();
            var group = from guestRequest in guestRequests
                        group guestRequest by guestRequest.Area;
            return group;
        }

        public IEnumerable<IGrouping<int, GuestRequest>> GroupGRByVacationers()
        {
            IEnumerable<GuestRequest> guestRequests = dal.GetGuestRequests();
            var group = from guestRequest in guestRequests
                        group guestRequest by (guestRequest.Children + guestRequest.Adult);
            return group;
        }

        public IEnumerable<IGrouping<Host, HostingUnit>> GroupHostByHostingUnit()
        {
            IEnumerable<HostingUnit> hostingUnits = dal.GetHostingUnits();
            IEnumerable<IGrouping<Host, HostingUnit>> group = from hostingUnit in hostingUnits
                                                              group hostingUnit by hostingUnit.Owner;
            return group;
        }

        public IEnumerable<IGrouping<Enums.HostingUnitArea, HostingUnit>> GroupHostingUnitByArea()
        {
            IEnumerable<HostingUnit> hostingUnits = dal.GetHostingUnits();
            var group = from unit in hostingUnits
                        group unit by unit.Area;
            return group;
        }
        #endregion

        //public List<GuestRequest> GetGuestRequests()
        //{
        //    List<GuestRequest> guestRequests = dal.GetGuestRequests();
        //    return guestRequests;
        //}

        public List<Order> GetOrders()
        {
            List<Order> guestRequests = dal.GetOrders();
            return guestRequests;
        }
    }

}

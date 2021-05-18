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
    public interface IAppLogic
    {
        void AddGusetRequest(BE.GuestRequest guestRequest, out BE.Enums.GuestRequesteCreateStatus status);
        void AddHost(BE.Host host, out BE.Enums.HostValidationStatus status);
        void AddHostingUnit(BE.HostingUnit hostingUnit, out Enums.HostingUnitSaveStatus status);
        void AddOrder(BE.Order order, out BE.Enums.OrderCreateStatus status);
        bool CheckForFreeDays(BE.GuestRequest guestReq, BE.HostingUnit unit);
        void DeleteHost(int Id, out Enums.HostValidationStatus status);
        bool DeleteHostingUnit(int hostingUnitId);
        System.Collections.Generic.List<BE.Host> GetAllHosts();
        System.Collections.Generic.List<BE.Host> GetAllHosts(Func<BE.Host, bool> predicate);
        System.Collections.Generic.List<BE.BankBranch> GetBankBranches(Func<BE.BankBranch, bool> predicate);
        System.Collections.Generic.List<BE.BankBranch> GetBankBranchesByBank(int BankNumber);
        System.Collections.Generic.List<BE.Bank> GetBanksList();
        System.Collections.Generic.List<BE.GuestRequest> GetGuestRequests(Func<BE.GuestRequest, bool> predicate);
        System.Collections.Generic.List<System.Collections.Generic.List<BE.GuestRequest>> GetGuestRequestsGrouingByArea();
        BE.Host GetHostById(int Id);
        BE.HostingUnit GetHostingUnitById(int stSerialKey);
        System.Collections.Generic.List<BE.HostingUnit> GetHostingUnits(Func<BE.HostingUnit, bool> predicate = null);
        System.Collections.Generic.List<BE.Order> GetOrders(Func<BE.Order, bool> predicate, int OwnerId = 0);
        System.Collections.Generic.List<string> GetPrePhones();
        System.Collections.Generic.List<BE.RelatedHosting> GetRelevantHostingByRequest(BE.GuestRequest guestRequest, int OwnerId = 0);
        List<GuestRequest> GetRequestsThatRelevantForOwner(Func<GuestRequest, bool> predicate, int OwnerId = 0);
        System.Collections.Generic.List<BE.HostingUnit> HostingUnitList(DateTime time, int numDay);
        int NumDays(DateTime start, DateTime end);
        System.Collections.Generic.List<BE.Order> OrderFromTime(int numDay);
        int Orders(BE.GuestRequest guestRequest);
        int Orders(BE.HostingUnit hostingUnit);
        void UpdateHost(BE.Host host, out BE.Enums.HostValidationStatus status);
        void UpdatingGusetRequest(BE.GuestRequest guestRequest, BE.Enums.GuestRequestStatus status);
        void UpdatingHostingUnit(BE.HostingUnit hostingUnit, out Enums.HostingUnitSaveStatus status);
        bool UpdatingOrder(int OrderId, BE.Enums.OrderStatus status);
        IEnumerable<IGrouping<Enums.HostingUnitArea, GuestRequest>> GroupGRByArea();
        IEnumerable<IGrouping<Enums.HostingUnitArea, HostingUnit>> GroupHostingUnitByArea();
        void SetCollectionClearance(int OwnerId, bool CollectionClearance);
        //System.Collections.Generic.List<BE.GuestRequest> GetGuestRequests();
        System.Collections.Generic.List<BE.Order> GetOrders();
        void SendMail(string from, string to, string subject, string body, bool isHtml);
        GlobalSettings GetGlobalSettings();
        bool UpdateGlobalSettings(GlobalSettings setting);
        IEnumerable<Object> GetHostingUnitGrouingByOwner(Func<BE.HostingUnit, bool> predicate = null);
        IEnumerable<object> GetFullOrder(Func<Order, bool> predicate, int OwnerId = 0);
    }
}

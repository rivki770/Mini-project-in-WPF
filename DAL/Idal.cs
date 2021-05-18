using BE;
using System;
namespace DAL
{
   public interface IDal
    {
        void AddGusetRequest(BE.GuestRequest guestRequest);
        void AddHost(BE.Host host);
        void AddHostingUnit(BE.HostingUnit hostingUnit);
        void AddOrder(BE.Order order);
        void DeleteHost(int Id);
        void DeleteHostingUnit(int hostingUnitId);
        System.Collections.Generic.List<BE.Host> GetAllHosts(Func<BE.Host, bool> predicate = null);
        System.Collections.Generic.List<BE.BankBranch> GetBankAccounts(Func<BE.BankBranch, bool> predicate);
        System.Collections.Generic.List<BE.BankBranch> GetBankBranches(Func<BE.BankBranch, bool> predicate);
        System.Collections.Generic.List<BE.BankBranch> GetBankBranchesByBank(int BankNumber);
        System.Collections.Generic.List<BE.Bank> GetBanksList();
        System.Collections.Generic.List<BE.GuestRequest> GetGuestRequests(Func<BE.GuestRequest, bool> predicate = null);
        BE.Host GetHostById(int Id);
        BE.HostingUnit GetHostingUnitById(int stSerialKey);
        System.Collections.Generic.List<BE.HostingUnit> GetHostingUnits(Func<BE.HostingUnit, bool> predicate = null);
        System.Collections.Generic.List<BE.Order> GetOrders(Func<BE.Order, bool> predicate = null);
        System.Collections.Generic.List<string> GetPrePhones();
        void UpdateHost(BE.Host host);
        void UpdatingGusetRequest(BE.GuestRequest guestRequest, BE.Enums.GuestRequestStatus status);
        void UpdatingHostingUnit(BE.HostingUnit hostingUnit);
        void UpdatingOrder(BE.Order order, BE.Enums.OrderStatus status);
        GlobalSettings GetGlobalSettings();
        void UpdateGlobalSettings(GlobalSettings setting);
    }
}

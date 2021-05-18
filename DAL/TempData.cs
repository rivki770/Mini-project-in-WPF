using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class TempData
    {
        public static List<BankBranch> getBranches()
        {
            return DS.Branches.getAllBrancehs();
        }

        public static List<Bank> getBanks()
        {
            return DS.Banks.getAllBanks();
        }

        public static List<string> getPrePhones()
        {
            return DS.PrePhones.getPrePhones();
        }
        public static List<HostingUnit> getHostingUnits()
        {
            return DS.HostingUnits.getHostingUnits();
        }

        public static List<Host> getHosts()
        {
            return DS.Hosts.getHosts();
        }
        public static List<GalleryImageItem> GetImages(List<HostingUnit> hu)
        {
            return DS.GalleryImageItems.GetImages(hu);
        }
        public static List<GuestRequest> getRequests()
        {
            return DS.GuestRequests.getAllRequests();
        }

       
    }
}

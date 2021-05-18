using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DS
{
    public class GuestRequests
    {

        public static List<GuestRequest> getAllRequests()
        {

            List<GuestRequest> list = new List<GuestRequest>();
            string[] Names = new string[] { "אהרון", "שירה", "חדווה", "משה חיים", "דוד", "שרה", "גאולה", "רבקי"};
            string[] lastNames = new string[] { "שרביט", "כהן", "לוי", "יוסף", "רבלין" };
            string[] mails = new string[] { "geula.shoshan@gmail.com", "rivkistudies@gmail.com", "g@geshtop.com" };

            for (int i = 0; i < 3; i++)
            {
                GuestRequest req = new GuestRequest();
                string g = String.Concat(Guid.NewGuid().ToString("N").Select(c => (char)(c + 17)));

                Random random = new Random();
                int randomNumber = random.Next(1,10);

                req.GuestRequestsKey = Configuration.GuestRequestKey;
                Configuration.GuestRequestKey++;
                req.FirstName = Names[i % 8];
                req.LastName = lastNames[i % 5];
                req.Status = Enums.GuestRequestStatus.Opened;
                req.RegistrationDate = DateTime.Now;
                req.MailAddress = mails[i % 3];
                req.EntryDate = DateTime.Now.AddDays(1 + i);
                req.ReleaseDate = DateTime.Now.AddDays(7 + i);
                req.Area = (Enums.HostingUnitArea)(i % 4);
                // req.Garden = (Enums.ExtensionType)   (i%2 ) ;
                req.Pool = (Enums.ExtensionType)(i  +1 % 2);
                // req.Jacuzzi = (Enums.ExtensionType)(i + 2 % 2);
               // req.ChildrensAttractions = (Enums.ExtensionType)(i % 2);
                // req.Adult = (randomNumber +i) % 10;
                //req.Children = (randomNumber * i+1 * 52) % 10;
                //req.Rooms = (randomNumber * i+1 * 34) % 10;
                list.Add(req);
            }
            // Add all missing banks
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        public static int GuestRequestKey = 10000000;
        public static int HostingUnitKey = 10000000;
        public static int OrderKey = 10000000;

        public static int HostIdentity = 5;
        public static int ImageIdentity = 100;
        public static int DaysIdentity = 100;

        public static string ContactMail = "geula.shoshan@gmail.com";
        public static string OrderMailText = "שלום רב {NAME}, \n \n אנו רוצים להציע לך יחידת נופש אטרקטיבית במיוחד בהתאם, לדרישות אותן ציינת במערכת. \n {HOSTINGNAME} \n {IMAGE} \n\n נשמח לעמוד לשירותך תמיד,\n {OWNERNAME}\n {OWNERMAIL} \n\n\n [הופק במערכת GR - עושים נופש לנופש] ";
        public static string OrderMailSubject = "התאמת יחידת אירוח #{REQUESTID}";

        public static int PayForDay = 15;

    }
}

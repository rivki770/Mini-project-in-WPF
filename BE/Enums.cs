using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Enums
    {
        public enum HostingUnitType
        {
            All = 0,
            Zimmer =1,
            Hotel =2,
            Camping =3,
        }
        public enum HostingUnitArea
        {
            All =0,
            North =1,
            South =2,
            Center =3,
            Jerusalem =4,
        }
        public enum DataSourseType
        {
            List,
            XML
        }
        public enum ExtensionType
        {
            All =0,
            Necessary =1,
            Not_interested =2
        }
       
        public enum OrderStatus
        {
            Not_treated =0,
            Mailed =1,
            Closed =2, //נסגרה בגלל שהזמנה אחרת שוייכה לבקשה בהצלחה 
            Success =3, //ההזמנה אושרה על ידי הלקוח 
        }
        public enum GuestRequestStatus
        {
            Opened = 0, // הבקשה נקלטה במערכת
            InProccess = 1, // נשלחה הצעה ללקוח  במייל
            ActiveAndClose = 2,  // נסגרה יחידת אירוח למשתמש
            Closed=3, // נסגר באמצעות המערכת
            Expired = 4, // לא מומשה ועבר הזמן
        }

        public enum HosignUnitStatus  {
            Active = 0,
            DeActive = 1,
            Paused = 2
        }


        public enum HostValidationStatus
        {
            Success = 0, //נמצא תקין
            MissingFields = 1, //חסרים שדות
            DuplicateId=2, //תעודת הזהות קיימת כבר במערכת
            WrongFields =3, // שדות לא תקינים דוגמא תעודת זהות עם מעט תווים
            HasActiveHostingUnits =4, //לא ניתן למחוק בגלל שיש יחידות אירוח שעדיין פעילות
            Faild=5, //שגיאת מסד
            WrongId=6,
            MissingBankAccount =7,
            EmailExist =8,
            Deleted =9
        }

        public enum GuestRequesteCreateStatus
        {
            MissingFields = 0, //חסרים שדות
            WrongFields = 1, // שדות לא תקינים דוגמא תעודת זהות עם מעט תווים
            ErrorDates = 2, // מידע שגוי
            NoHosting = 3, // לא קיים יחידה
            Success = 4 //נמצא תקין
        }

        public enum HostingUnitSaveStatus
        {
            Success = 0 ,//נמצא תקין
            MissingFields = 1 ,//חסרים שדות
            ImageMissing = 2, // חסרה תמונה
           
        }


        public enum OrderCreateStatus
        {
            Success = 0,
            ErrorInDetails = 1,
            MailFailed = 2,
            MissingCollectionClearance = 3

        }

        public enum AuthPermission
        {
            Guest = 0,
            Host = 1,
            Admin =2
        }
        public enum LoginStatus
        {
            Success = 0,
            Faild = 1,
            Missing = 2
        }
    }
}

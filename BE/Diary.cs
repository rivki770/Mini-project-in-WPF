// rivki kanterovich 212030761
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class XDiary
    {
        //לוח השנה
        public bool[,] Calender { get; set; }
        //מספר הימים המלאים
        public int BusyDays { get; set; }
        //התקופות המלאות
        public List<GuestRequest> ApprovedTimes { get; set; }

        public XDiary() //constructor
        {
            Calender = new bool[12, 31];
            ApprovedTimes = new List<GuestRequest>();
            BusyDays = 0;
        }


        public bool ApproveRequest(GuestRequest guestReq)
        {
           return SetCalendarDatesAsBusy(guestReq);
        }

        //קבלת הימים המלאים בלוח השנה
        //public int sdsBusyDays()
        //{
        //    int counter = 0;
        //    for (int i = 0; i < 12; i++)
        //    {
        //        for (int j = 0; j < 31; j++)
        //        {
        //            if (Calender[i, j] == true)
        //            {
        //                counter++;
        //            }
        //        }
        //    }
        //    return counter;
        //}

        //פונקציה הבודקת האם הימים הם ימים חופשיים
        public bool CheckForFreeDays(GuestRequest guestReq)
        {

            bool flag = true;
            //בדיקה אם המדובר על חציית שנה
            if (guestReq.EntryDate.Year != guestReq.ReleaseDate.Year)
            {
                //מעדכנים את התאריך לסוף השנה 
                guestReq.ReleaseDate = new DateTime(guestReq.EntryDate.Year, 12, 31);
            }
            //אם המדובר על אותו החודש באותה השנה
            if (guestReq.EntryDate.Month == guestReq.ReleaseDate.Month)
            {
                for (int i = guestReq.EntryDate.Day; i < guestReq.ReleaseDate.Day - 1; i++)
                {
                    if (Calender[guestReq.EntryDate.Month - 1, i] == true)
                    {
                        flag = false;
                        continue;
                    };
                }
            }
            //אותה שנה חודשים שונים
            else
            {
                //בדיקת החודש החודש הראשון
                for (int i = guestReq.EntryDate.Day; i < 31; i++)
                {
                    if (Calender[guestReq.EntryDate.Month - 1, i] == true)
                    {
                        flag = false;
                        continue;
                    }
                }
                //בדיקת החודש האחרון
                if (flag)
                {
                    for (int i = 0; i < guestReq.ReleaseDate.Day - 1; i++)
                    {
                        if (Calender[guestReq.ReleaseDate.Month - 1, i] == true)
                        {
                            flag = false;
                            continue;
                        }
                    }
                }
                //בדיקת החודשים בין הראשון לאחרון
                if (flag)
                {
                    for (int i = guestReq.EntryDate.Month; i < guestReq.ReleaseDate.Month - 1; i++)
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            if (Calender[i, j] == true)
                            {
                                flag = false;
                                continue;
                            }
                        }
                    }
                }
               
            }
            return flag;
        }

        //פונקציה שמסמנת את הימים כתפוסים
        private bool SetCalendarDatesAsBusy(GuestRequest guestReq)
        {
            bool flag = CheckForFreeDays(guestReq);
            if (flag)
            {
                guestReq.Status =  Enums.GuestRequestStatus.Opened;
                ApprovedTimes.Add(guestReq);

                //אם המדובר על אותו החודש באותה השנה
                if (guestReq.EntryDate.Month == guestReq.ReleaseDate.Month)
                {
                    for (int i = guestReq.EntryDate.Day - 1; i < guestReq.ReleaseDate.Day - 1; i++)
                    {
                        BusyDays++;
                        Calender[guestReq.EntryDate.Month - 1, i] = true;
                    }
                }
                //אותה שנה חודשים שונים
                else
                {
                    //מילוי החודש החודש הראשון
                    for (int i = guestReq.EntryDate.Day - 1; i < 31; i++)
                    {
                        BusyDays++;
                        Calender[guestReq.EntryDate.Month - 1, i] = true;
                    }

                    //מילוי החודש האחרון
                    for (int i = 0; i < guestReq.ReleaseDate.Day - 1; i++)
                    {
                        BusyDays++;
                        Calender[guestReq.ReleaseDate.Month - 1, i] = true;
                    }
                    //מילוי החודשים בין הראשון לאחרון
                    for (int i = guestReq.EntryDate.Month; i < guestReq.ReleaseDate.Month - 1; i++)
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            BusyDays++;
                            Calender[i, j] = true;
                        }
                    }
                }
            }
            return flag;
        }
        
        public override string ToString() //Printing busy days a year
        {
            string s = "";
            //for (int i = 0; i < ApprovedTimes.Count(); i++)
            //{
            //    s += ApprovedTimes[i].EntryDate.ToString("dd/MM/yyyy") + " - " + ApprovedTimes[i].ReleaseDate.ToString("dd/MM/yyyy") + "\n";
            //}
            DateTime first;
            DateTime last;
            int num = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (this.Calender[i, j] == true)
                    {
                        num = 2;
                        first = new DateTime(2019, (i + 1), (j + 1));
                        s += first.ToString("dd/MM/yyyy") + " - "; //Starting busy days
                        for (int k = i; k < 12; k++) //Internal loop that continues from the day received until there is a non-invitation day
                        {
                            for (int l = 0; l < 31; l++)
                            {
                                if (num == 2)
                                {
                                    num = 1;
                                    l = j;
                                }
                                if (this.Calender[k, l] == false || (k == 11 && l == 30)) //Find a free day or end this year
                                {
                                    last = new DateTime(2019, (k + 1), (l + 1));
                                    s += last.ToString("dd/MM/yyyy") + "\n"; //Ending busy days
                                    i = k;
                                    j = l;
                                    l = 31;
                                    k = 12;
                                    num = 1;
                                }
                            }
                        }
                    }
                }
            }
            return s;
        }

        //public override string ToString(string format)
        //{
        //    string s = "";
        //    switch (format)
        //    {
        //        case "T":
        //            for (int i = 0; i < ApprovedTimes.Count(); i++)
        //            {
        //                s += ApprovedTimes[i].EntryDate.ToString("dd/MM/yyyy") + " - " + ApprovedTimes[i].EntryDate.ToString("dd/MM/yyyy") + "\n";
        //            }
        //            break;

        //        default:
        //            break;
        //    }
        //    return s;
        //}
    }
}

using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class GalleryImageItems
    {
        public static List<GalleryImageItem> GetImages(List<HostingUnit> currentHostings )
        {
            List<GalleryImageItem> Images = new List<GalleryImageItem>();
            Images.Add(new GalleryImageItem() { Id = 1, Url = "https://pic.rrr.co.il/images/oazis/2.jpg" });
            Images.Add(new GalleryImageItem() { Id = 2, Url = "https://pic.rrr.co.il/images/oazis/1.jpg" });
            Images.Add(new GalleryImageItem() { Id = 3, Url = "https://pic.rrr.co.il/images/oazis/3.jpg" });
            Images.Add(new GalleryImageItem() { Id = 4, Url = "https://pic.rrr.co.il/images/oazis/5.jpg" });

            Images.Add(new GalleryImageItem() { Id = 5, Url = "https://pic.rrr.co.il/images/oazis/4.jpg" });
            Images.Add(new GalleryImageItem() { Id = 6, Url = "https://pic.rrr.co.il/images/oazis/6.jpg" });
            Images.Add(new GalleryImageItem() { Id = 7, Url = "https://pic.rrr.co.il/images/oazis/7.jpg" });
            Images.Add(new GalleryImageItem() { Id = 8, Url = "https://pic.rrr.co.il/images/oazis/8.jpg" });
            Images.Add(new GalleryImageItem() { Id = 9, Url = "https://pic.rrr.co.il/images/oazis/9.jpg" });
            Images.Add(new GalleryImageItem() { Id = 10, Url = "https://pic.rrr.co.il/images/oazis/10.jpg" });
            Images.Add(new GalleryImageItem() { Id = 11, Url = "https://pic.rrr.co.il/images/oazis/11.jpg" });
            Images.Add(new GalleryImageItem() { Id = 12, Url = "https://pic.rrr.co.il/images/oazis/12.jpg" });
            Images.Add(new GalleryImageItem() { Id = 13, Url = "https://pic.rrr.co.il/images/oazis/13.jpg" });
            Images.Add(new GalleryImageItem() { Id = 14, Url = "https://pic.rrr.co.il/images/oazis/14.jpg" });
            Images.Add(new GalleryImageItem() { Id = 15, Url = "https://pic.rrr.co.il/images/oazis/15.jpg" });
            Images.Add(new GalleryImageItem() { Id = 16, Url = "https://pic.rrr.co.il/images/oazis/16.jpg" });

            try
            {
               var countHostings = currentHostings.Count;
                for (int i = 0; i < Images.Count(); i++)
                {
                    var index = i%countHostings;
                    Images[i].HostingUnitId = currentHostings[index].stSerialKey;
                    
                }
            }
            catch (Exception)
            {
                
                throw;
            }


           

           return Images;
        }
    }
}

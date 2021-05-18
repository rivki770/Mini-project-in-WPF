using BE;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.Controls
{
    /// <summary>
    /// Interaction logic for ImageGalleryCtrl.xaml
    /// </summary>
    public partial class ImageGalleryCtrl : UserControlBase
    {
        public List<GalleryImageItem> images { get; set; }

        public Visibility DeleteVisible
        {
            get
            {
                if (OwnerId > 0) return System.Windows.Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
     

        public ImageGalleryCtrl(HostingUnit _hostingUnit)
        {
            images = _hostingUnit.TempImages;
            InitializeComponent();
            FillGrid();
            GenerateTempUrl();
            if (OwnerId == 0)
            {
                AddImagePanel.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void FillGrid()
        {
            ImagesGrid.DataContext = images;
            ImagesListView.ItemsSource = images;

        }
        public string TempUrl { get; set; }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(ImageUrl.Text))
            {
                Random random = new Random();
                int tempid = random.Next(10000, 1000000);
                images.Add(new GalleryImageItem() { Url = ImageUrl.Text, Id = tempid });
            }
            ImagesListView.Items.Refresh();
            GenerateTempUrl();

       

        }
        public void GenerateTempUrl(){ 
             Random random = new Random();
                int tempid = random.Next(1, 22);
                string tempurl = "https://pic.rrr.co.il/images/oazis/" + tempid + ".jpg";
                ImageUrl.Text = tempurl;
        }
        private void DeleteImage_Click(object sender, RoutedEventArgs e)
        {
            if (OwnerId == 0)
            {
                MessageBox.Show("רק מנהל יחידות אירוח יכול למחוק את התמונות שלו");
                return;
            }
            var b = (Button)sender;
            if (b != null)
            {
                int id = Int32.Parse(b.Tag.ToString());
                if (id > 0)
                {
                    var index = images.FindIndex(c=>c.Id == id);
                    if (index > -1)
                    {
                        images.RemoveAt(index);
                        ImagesListView.Items.Refresh();
                    }
                  
                }
            }

        }


    }
}

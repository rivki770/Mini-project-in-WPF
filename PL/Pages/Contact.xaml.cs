using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PL.Pages
{
    /// <summary>
    /// Interaction logic for Contact.xaml
    /// </summary>
    public partial class ContactPage : PageBase
    {
        //bool flag = false;
        public ContactPage()
        {
            InitializeComponent();
           
            //flag = true;
        }
     

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || telephon.Text == "" || TxtBody.Text == "")
            {
                MessageBox.Show("יש למלא את כל השדות");
                return;
            }
               try
               {

                   string text = "שם: " + name.Text + "\nמייל: " + telephon.Text
              + "\nגוף ההודעה: " + TxtBody.Text;
                   var contact_mail = app.GetGlobalSettings().ContactMail;
                   text = text.Replace(System.Environment.NewLine, "<br />").Replace("\n", "<br />");
                   Contact c = new Contact();
                   c.Body = text;
                   c.Subject = TxtSubject.Text;
                   c.ReciverMail = contact_mail;


                   CurrentWindow.SendBackgroundMail(c);


                   BackToMain();// חזרה לדף ראשי
                 
                                 
                 
               }
               catch
               {
                   MessageBox.Show("אירעה בעיה במשלוח המייל");
               }
              
         
            
        }

      
    }
}

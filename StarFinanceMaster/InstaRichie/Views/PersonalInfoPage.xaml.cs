using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using StartFinance.Models;
using SQLite.Net;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonalInfoPage : Page
    {

        SQLiteConnection con; // adding an SQLite connection
        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Findata.sqlite");

        public PersonalInfoPage()
        {
            this.InitializeComponent();
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            
            Results();
        }

        public void Results()
        {
                        
                // Creating table
                con.CreateTable<PersonalInfo>();
                var query = con.Table<PersonalInfo>();
                PersonalInfoList.ItemsSource = query.ToList();
            
        }





        private async void SearchByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var idSource = UserIdTextBox.Text;
            try
            {


                if (idSource.ToString() == "")
                {
                    MessageDialog dialog = new MessageDialog("ID not Entered", "Oops..!");
                    await dialog.ShowAsync();
                }
                else
                {
                    int id = Int32.Parse(idSource);
                    object idSearchResult = con.Query<PersonalInfo>("SELECT * FROM PersonalInfo WHERE User_ID ='" + id + "'");

                    if (idSearchResult == null)
                    {
                        MessageDialog dialog = new MessageDialog("The profile is not existed");
                        await dialog.ShowAsync();

                    }



                    PersonalInfoList.ItemsSource = idSearchResult;
                }



            }

            catch (FormatException)
            {
                MessageDialog dialog = new MessageDialog("Your input is wrong", "Oops..!");
                await dialog.ShowAsync();
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            int newId = Int32.Parse(UserIdTextBox.Text);
            string newName = FullNameTextBox.Text;
            string newContact = ContactTextBox.Text;
            string newEmail = EmailTextBox.Text;
            con.Insert(new PersonalInfo()
            {
                User_ID = newId,
                Full_Name = newName,
                Contact = newContact,
                Email = newEmail,
            });
            Results();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            string existingId= UserIdTextBox.Text;
            string newName = FullNameTextBox.Text;
            string newContact = ContactTextBox.Text;
            string newEmail = EmailTextBox.Text;

            
            con.Query<PersonalInfo>("update PersonalInfo set Full_Name ='" + newName + "' where User_ID = '" + existingId + "'");
            con.Query<PersonalInfo>("update PersonalInfo set Email ='" + newEmail + "' where User_ID = '" + existingId + "'");
            con.Query<PersonalInfo>("update PersonalInfo set Contact ='" + newContact + "' where User_ID = '" + existingId + "'");

            Results();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string deleteQry = "DELETE FROM PersonalInfo WHERE User_ID = " + UserIdTextBox.Text;
            con.Query<PersonalInfo>(deleteQry);

            Results();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Results();
            
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
        }
        }
}


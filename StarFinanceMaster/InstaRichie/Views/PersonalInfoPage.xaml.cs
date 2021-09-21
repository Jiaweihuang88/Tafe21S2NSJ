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
                    
                    object idSearchResult = con.Query<PersonalInfo>("SELECT * FROM PersonalInfo WHERE User_ID ='" + idSource + "'");

                    if (idSearchResult == null)
                    {
                        MessageDialog dialog = new MessageDialog("The profile is not existed");
                        await dialog.ShowAsync();

                    }
                    else
                    {


                        PersonalInfoList.ItemsSource = idSearchResult;
                    }
                }



            }

            catch (FormatException)
            {
                MessageDialog dialog = new MessageDialog("Your input is wrong", "Oops..!");
                await dialog.ShowAsync();
            }
        }
        private async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string newName;
            string newContact;
            string newEmail;
            int newId;



            try
            {
                newName = FullNameTextBox.Text;
                newContact = ContactTextBox.Text;
                newEmail = EmailTextBox.Text;
                
                if (newName != "" && newContact != "" && newEmail != "")
                {
                    try
                    {
                        con.Insert(new PersonalInfo()
                        {

                            Full_Name = newName,
                            Contact = newContact,
                            Email = newEmail,
                        
                             }
                        );
                        MessageDialog dialog = new MessageDialog("User " + newName + " is saved");
                        await dialog.ShowAsync();
                        Results();
                    }
                    catch (SQLiteException)
                    {
                        MessageDialog dialog = new MessageDialog(newName + " is not saved, Your record is duplicated in our system");
                        await dialog.ShowAsync();
                        Results();
                    }
                }
                else {
                    MessageDialog dialog = new MessageDialog("Please enter all field");
                    await dialog.ShowAsync();
                }
                
              
            }
            catch (FormatException)
            {
                MessageDialog dialog = new MessageDialog("Your input is wrong", "Oops..!");
                await dialog.ShowAsync();
            }
           

            
        }

        private async void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            string existingId = UserIdTextBox.Text;
            string newName = FullNameTextBox.Text;
            string newContact = ContactTextBox.Text;
            string newEmail = EmailTextBox.Text;

            if (existingId != "" && newName != "" && newContact != "" && newEmail != "")
            {
                object idSearchResult = con.Query<PersonalInfo>("SELECT * FROM PersonalInfo WHERE User_ID ='" + existingId + "'");

                if (idSearchResult == null)
                {
                    MessageDialog dialog = new MessageDialog("The profile is not existed");
                    await dialog.ShowAsync();

                }

                else
                {

                    con.Query<PersonalInfo>("update PersonalInfo set Full_Name ='" + newName + "' where User_ID = '" + existingId + "'");
                    con.Query<PersonalInfo>("update PersonalInfo set Email ='" + newEmail + "' where User_ID = '" + existingId + "'");
                    con.Query<PersonalInfo>("update PersonalInfo set Contact ='" + newContact + "' where User_ID = '" + existingId + "'");

                    MessageDialog dialog = new MessageDialog(newName + " is updated");
                    await dialog.ShowAsync();


                    Results();
                }
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Please enter all field");
                await dialog.ShowAsync();
            }
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string existingId = UserIdTextBox.Text;

            try
            {
                string deleteQry = "DELETE FROM PersonalInfo WHERE User_ID = " + UserIdTextBox.Text;
                con.Query<PersonalInfo>(deleteQry);

                MessageDialog dialog = new MessageDialog("ID: "+existingId + " is deleted");
                await dialog.ShowAsync();

                Results();
            }
            catch (SQLiteException)
            {
                MessageDialog dialog = new MessageDialog("Your input is not correct");
                await dialog.ShowAsync();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Results();
            
        }

        private bool VerifyExistingId(int id)
        {
            bool isIdExist = false;



            return isIdExist;
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
        }
        }
}


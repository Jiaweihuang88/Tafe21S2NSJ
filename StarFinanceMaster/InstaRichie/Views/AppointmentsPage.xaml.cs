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
    public sealed partial class AppointmentsPage : Page
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Findata.sqlite");

        public AppointmentsPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            /// Initializing a database
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            // Creating table
            Results();
        }
        public void Results()
        {
            // Creating table
            conn.CreateTable<Appointments>();
            var query = conn.Table<Appointments>();
            AppointmentList.ItemsSource = query.ToList();
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // checks if appointment name is null
                if (EventNameBox.Text.ToString() == "")
                {
                    MessageDialog dialog = new MessageDialog("Event name not Entered", "Oops..!");
                    await dialog.ShowAsync();
                }
                //else if (EventNameBox.Text.ToString() == "AppointmentName" || EventNameBox.Text.ToString() == "InitialAmount")
                //{
                //    MessageDialog variableerror = new MessageDialog("You cannot use this name", "Oops..!");
                //}
                else
                {
                    // issue with conversion - registering as a format exception

                    //conversions to datetime
                    //DateTime eventDateTime;
                    //DateTime startDateTime;
                    //DateTime endDateTime;

                    //eventDateTime = Convert.ToDateTime(appointmentDatePicker.ToString());
                    //startDateTime = Convert.ToDateTime(appStartTimePicker.ToString());
                    //endDateTime = Convert.ToDateTime(appEndTimePicker.ToString());

                    //eventDateTime = appointmentDatePicker.Date.ToString();
                    //startDateTime = Convert.ToDateTime(appStartTimePicker.ToString());
                    //endDateTime = Convert.ToDateTime(appEndTimePicker.ToString());

                    // Should work
                    DateTime startDateTime = appointmentDatePicker.Date.Add(appStartTimePicker.Time).UtcDateTime;
                    DateTime endDateTime = appointmentDatePicker.Date.Add(appEndTimePicker.Time).UtcDateTime;

                    // Inserts the data
                    conn.Insert(new Appointments()
                    {
                        EventName = EventNameBox.Text,
                        Location = LocationBox.Text,
                        //EventDate = eventDateTime,
                        StartTime = startDateTime, //.TimeSpan,
                        EndTime = endDateTime //.Time,
                    });
                    Results();

                    //testTextBlock.Text = "cats" + appointmentDatePicker.Date.ToString();

                }

            }
            catch (Exception ex)
            {   // Exception to display when amount is invalid or not numbers
                if (ex is FormatException)
                {
                    MessageDialog dialog = new MessageDialog("You forgot to enter the event name or entered invalid data", "Oops..!");
                    await dialog.ShowAsync();
                }   // Exception handling when SQLite contraints are violated
                else if (ex is SQLiteException)
                {
                    MessageDialog dialog = new MessageDialog("Event Name already exists, Try a Different Name", "Oops..!");
                    await dialog.ShowAsync();
                }
                else
                {
                    /// no idea
                }

            }
        }

        // Clears the fields
        private async void ClearFileds_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog ClearDialog = new MessageDialog("Cleared", "information");
            await ClearDialog.ShowAsync();
        }

        // Displays the data when navigation between pages
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Results();
        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog ShowConf = new MessageDialog("Would you like to delete this appointment?", "Important");
            ShowConf.Commands.Add(new UICommand("Yes, Delete")
            {
                Id = 0
            });
            ShowConf.Commands.Add(new UICommand("Cancel")
            {
                Id = 1
            });
            ShowConf.DefaultCommandIndex = 0;
            ShowConf.CancelCommandIndex = 1;

            var result = await ShowConf.ShowAsync();
            if ((int)result.Id == 0)
            {
                // checks if data is null else inserts
                try
                {
                    string AppointmentsLabel = ((Appointments)AppointmentList.SelectedItem).EventName;
                    //var querydel = conn.Query<Appointments>("DELETE FROM Appointments WHERE EventName='" + AppointmentsLabel + "'");
                    //Results();
                    //conn.CreateTable<Appointments>();
                    //var querytable = conn.Query<Appointments>("DELETE FROM Appointments WHERE Appointments='" + AppointmentsLabel + "'");
                    
                    //AppointmentList.ItemsSource = querydel.ToList();

                    conn.CreateTable<Appointments>();
                    var query1 = conn.Table<Appointments>();
                    var query3 = conn.Query<Appointments>("DELETE FROM Appointments WHERE EventName ='" + AppointmentsLabel + "'");
                    AppointmentList.ItemsSource = query1.ToList();
                }
                catch (NullReferenceException)
                {
                    MessageDialog ClearDialog = new MessageDialog("Please select the item to Delete", "Oops..!");
                    await ClearDialog.ShowAsync();
                }
            }
            else
            {
                //
            }
        }


    }
}

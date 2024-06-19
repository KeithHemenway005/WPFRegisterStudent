using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Course choice;
        private const int max_credit_hours = 9;
        private int registeredCreditHours = 0;
        private string courseNames = "IT 145,IT 200,IT 201,IT 270,IT 315,IT 328,IT 330";
        private Dictionary<string, Course> availableCourses = new Dictionary<string, Course>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] arrCourseNames = courseNames.Split(',');
            foreach(string courseName in arrCourseNames)
            {
                availableCourses.Add(courseName, new Course(courseName));
                this.comboBox.Items.Add(courseName);
            }
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Get course from dictionary
            choice = availableCourses[this.comboBox.SelectedItem.ToString()];

            if (choice.IsRegisteredAlready)  // Checking if (this.lstRegisteredCourses.Contains(choice.Name) would also work
            {
                // This course already regitered
                this.lblRegistrationStatus.Foreground = Brushes.Red;
                this.lblRegistrationStatus.Content = string.Format("You have already registered for course: {0}.", choice.Name);
            }

            else
            {
                if (this.registeredCreditHours >= max_credit_hours)
                {
                    // Cannot register for a fourth courses
                    this.lblRegistrationStatus.Foreground = Brushes.Red;
                    this.lblRegistrationStatus.Content = string.Format("You cannot register for more than {0} credit hours.", max_credit_hours);
                }

                else
                {
                    this.registeredCreditHours += choice.Credit_hours;
                    this.lstRegisteredCourses.Items.Add(choice.Name);
                    choice.SetToRegistered();
                    this.txtTotalHoursRegistered.Text = Convert.ToString(this.registeredCreditHours);
                    this.lblRegistrationStatus.Foreground = Brushes.DarkBlue;
                    this.lblRegistrationStatus.Content = string.Format("Registeration confirm for course: {0}.", choice.Name);

                }
            }
        }

    }
}

using KMS2_02_LE_01_03.ViewModels;
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

namespace KMS2_02_LE_01_03
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtbPublicationDate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.ShowCalendar();
                if (viewModel.PublicationDate.HasValue)
                {
                    PublicationDateCalendar.SelectedDate = viewModel.PublicationDate.Value;
                    PublicationDateCalendar.DisplayDate = viewModel.PublicationDate.Value;
                }
                e.Handled = true; // Prevent further handling of the event
            }
        }

        private void PublicationDateCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null && PublicationDateCalendar.SelectedDate.HasValue)
            {
                viewModel.PublicationDate = PublicationDateCalendar.SelectedDate.Value;
                viewModel.HideCalendar();
            }
        }

        private void PublicationDateCalendar_LostFocus(object sender, RoutedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar != null && !calendar.IsKeyboardFocusWithin)
            {
                var viewModel = DataContext as MainViewModel;
                if (viewModel != null)
                {
                    viewModel.HideCalendar();
                }
            }
        }

        private void PublicationDateCalendar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null && PublicationDateCalendar.SelectedDate.HasValue)
            {
                viewModel.PublicationDate = PublicationDateCalendar.SelectedDate.Value;
                viewModel.HideCalendar();
            }
        }

        private void cbFilterOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFilter = (cbFilterOptions.SelectedItem as ComboBoxItem)?.Content as string;
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.SelectedFilterOption = selectedFilter;
                if (selectedFilter == "By Date")
                {
                    viewModel.ShowCalendar();
                }
                else
                {
                    viewModel.HideCalendar();
                }
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.FilterText = txtFilter.Text;
    
            }
        }



    }
}

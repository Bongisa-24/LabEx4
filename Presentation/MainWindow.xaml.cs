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
using BusinessLayer;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic business = new Logic();
        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            business.name = nameTxt.Text;
            business.surname = surnameTxt.Text;
            business.gender = genderTxt.Text;
            business.email = emailTxt.Text;
            //business.id = int.Parse(idTxt.Text);
            business.writeData();
            dataGrid.ItemsSource = business.Read().DefaultView;
            string error = business.writeData();
            if (error!= "")
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Data inserted");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            business.name = nameTxt.Text;
            business.surname = surnameTxt.Text;
            business.gender = genderTxt.Text;
            business.email = emailTxt.Text;
            business.id = int.Parse(idTxt.Text);
            business.UpdateData();
            dataGrid.ItemsSource = business.Read().DefaultView;
            string error = business.UpdateData();
            if (error != "")
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Data Updated");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            business.name = nameTxt.Text;
            business.surname = surnameTxt.Text;
            business.gender = genderTxt.Text;
            business.email = emailTxt.Text;
            business.id = int.Parse(idTxt.Text);
            business.DeleteData();
            dataGrid.ItemsSource = business.Read().DefaultView;
            string error = business.DeleteData();
            if (error != "")
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Data Deleted");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            nameTxt.Clear();
            surnameTxt.Clear();
            genderTxt.Clear();
            emailTxt.Clear();
            idTxt.Clear();

        }
    }
}

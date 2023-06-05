using System.Windows;

namespace Tekst
{
    using System.Windows;

    public partial class ct : Window
    {
        public ct(string t)
        {
            InitializeComponent();
            this.DataContext = t;
            TxtViewModel tx = new TxtViewModel();
            tb2.Text = tx.LoadText();

        }
        public ct()
        {
            InitializeComponent();
            this.DataContext = new TxtViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}

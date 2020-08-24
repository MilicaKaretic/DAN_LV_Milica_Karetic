using DAN_LV_Milica_Karetic.ViewModel;
using System.Windows;


namespace DAN_LV_Milica_Karetic.View
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
            this.DataContext = new OrderViewModel(this);
        }
    }
}

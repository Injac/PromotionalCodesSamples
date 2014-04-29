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
using ExGrip.PromotionalCodesDotNet451;

namespace PromotionalCodesTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnRedeemCode_Click(object sender, RoutedEventArgs e)
        {
            var apiKey = "[YOURAPIKEY]";
            var apiSecret = "[YOURAPISECRET]";

            var promocodeManager = new PromotionCodeManager(apiKey, apiSecret);

            var isValid = await promocodeManager.ValidatePromoCode(this.tbPromoCode.Text);

            if(isValid)
            {
                lbResult.Text = "CODE IS VALID";

            }
            else
            {
                lbResult.Text = "CODE INVALID";
            }
            

        }

        private async void btnRedeemCode_Copy_Click(object sender, RoutedEventArgs e)
        {

            var apiKey = "[YOURAPIKEY]";
            var apiSecret = "[YOURAPISECRET]";

            var promocodeManager = new PromotionCodeManager(apiKey, apiSecret);

            var isValid = await promocodeManager.RedeemPromoCode(this.tbPromoCode.Text);

            if (isValid)
            {
                lbResult.Text = "CODE REDEEMED";

            }
            else
            {
                lbResult.Text = "CODE NOT REDEEMED";
            }

        }
    }
}

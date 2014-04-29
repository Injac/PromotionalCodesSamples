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
using ExGrip.ExGripPromotionalCodesWin81;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionalCodesTests
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            PromotionCodeManager man = new PromotionCodeManager("[YOURAPIKEY]",
                                                                "[YOURAPISECRET]");
            var valid = await man.ValidatePromoCode(this.txtPromoCode.Text);
            tbStatus.Text = "";
            if (valid)
            {
                tbStatus.Text = "Promocode successfully validated :)";
                
            }
            else
            {
                tbStatus.Text = "Promocode is invalid";
            }
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PromotionCodeManager man = new PromotionCodeManager("[YOURAPIKEY]",
                                                              "[YOURAPISECRET]");
            var valid = await man.RedeemPromoCode(this.txtPromoCode.Text);
            tbStatus.Text = "";
            if (valid)
            {
                tbStatus.Text = "Promocode successfully redeemed :)";
            }
            else
            {
                tbStatus.Text = "Sorry promocode is not available anymore :(";
            }
        } 
    }
}

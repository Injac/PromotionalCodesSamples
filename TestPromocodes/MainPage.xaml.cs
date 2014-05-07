using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestPromocodes.Resources;
using ExGrip.PromotionalCodes;

namespace TestPromocodes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private async void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            PromotionCodeManager man = new PromotionCodeManager("[YOURAPIKEY]",
                                                                 "[YOURAPISECRET]");
            var valid = await man.ValidatePromoCode(this.txtPromocode.Text);
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

        private async void btnRedeem_Click(object sender, RoutedEventArgs e)
        {
            PromotionCodeManager man = new PromotionCodeManager("[YOURAPIKEY]",
                                                              "[YOURAPISECRET]");
            var valid = await man.RedeemPromoCode(this.txtPromocode.Text);
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


        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PromotionCodeManager man = new PromotionCodeManager("[YOURAPIKEY]",
                                                             "[YOURAPISECRET]");
            var stats = await man.GetMultiCodeStats(this.txtPromocode.Text);
            tbStatus.Text = "";

            if (stats != null)
            {
                tbStatus.Text = string.Format("STATUS: {0}, REDEEM-COUNT: {1}, AVAILABLE-REDEEMS: {2}",
                    stats.status, stats.redeemCount, stats.availableRedeems);
            }
            else
            {
                tbStatus.Text = "Sorry promocode is not available anymore, or could not be found, or it is no multi-code. :(";
            }
        } 
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}
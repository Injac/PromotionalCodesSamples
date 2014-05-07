﻿using ExGrip.PromotionalCodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TestPromocodesWindowsStore
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PromotionCodeManager man = new PromotionCodeManager("[YOURAPIKEY]",
                                                             "[YOURAPISECRET]");
            var stats = await man.GetMultiCodeStats(this.txtPromoCode.Text);
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
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace iPower.Phone.Views
{
    public partial class Channel : PhoneApplicationPage
    {
        public Channel()
        {
            InitializeComponent();
        }
        //test
        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ViewModel.ChannelViewModel Channel = this.DataContext as ViewModel.ChannelViewModel;
            Channel.Play();
        }

        private void TextBlock_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FinalProject.Models
{
    class Constants
    {
        public static bool IsDev = true;

        public static Color BackgroundColor = Color.FromRgb(128,139,150);
        public static Color MainTextColor = Color.White;


        public static int LoginIconHeight = 120;


        //----------Login-------------------

        public static string LoginUrl = "https://test.com/api/Auth/Login";

        public static string NoInternetText = "No Internet, please reconnect.";
    }
}

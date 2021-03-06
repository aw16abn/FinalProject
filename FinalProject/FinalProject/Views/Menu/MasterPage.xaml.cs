﻿using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Views.DetailViews;
using FinalProject.Views.DetailViews.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;

namespace FinalProject.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage

	{

        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;

		public MasterPage ()
		{
			InitializeComponent ();
            SetItems();
            
          
        }

     

        void SetItems()
        {
            items = new List<MasterMenuItem> ();
            items.Add(new MasterMenuItem("Timeline", "LoginIcon.png",Color.White, typeof(InfoScreen1)));
            items.Add(new MasterMenuItem("Create", "LoginIcon.png", Color.White, typeof(Create)));
            items.Add(new MasterMenuItem("Update", "LoginIcon.png", Color.White, typeof(Update)));
            items.Add(new MasterMenuItem("Delete", "LoginIcon.png", Color.White, typeof(Delete)));
            items.Add(new MasterMenuItem("Users", "LoginIcon.png", Color.White, typeof(Users)));
            items.Add(new MasterMenuItem("Memory Items", "LoginIcon.png", Color.White, typeof(MemoryItems)));
            items.Add(new MasterMenuItem("Settings", "LoginIcon.png", Color.White, typeof(SettingsScreen)));

            ListView.ItemsSource = items;

        }


    }
}
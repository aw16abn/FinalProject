﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject.Models
{
   public  class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color Backgroundcolor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string Title, string IconSource, Color color, Type target)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.Backgroundcolor = color;
            this.TargetType = target;
        }
    }
}

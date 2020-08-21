﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoneyManagement.CustomControls
{
    public class NumbericInput : Entry
    {
        public static BindableProperty AllowNegativeProperty = BindableProperty.Create("AllowNegative", typeof(bool), typeof(NumbericInput), false, BindingMode.TwoWay);
        public static BindableProperty AllowFractionProperty = BindableProperty.Create("AllowFraction", typeof(bool), typeof(NumbericInput), false, BindingMode.TwoWay);

        public NumbericInput()
        {
            this.Keyboard = Keyboard.Numeric;
        }

        public bool AllowNegative
        {
            get { return (bool)GetValue(AllowNegativeProperty); }
            set { SetValue(AllowNegativeProperty, value); }
        }

        public bool AllowFraction
        {
            get { return (bool)GetValue(AllowFractionProperty); }
            set { SetValue(AllowFractionProperty, value); }
        }
    }
}

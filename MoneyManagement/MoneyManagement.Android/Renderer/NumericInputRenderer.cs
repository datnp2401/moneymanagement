using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using MoneyManagement.CustomControls;
using MoneyManagement.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NumbericInput), typeof(NumericInputRenderer))]
namespace MoneyManagement.Droid.Renderer
{
    public class NumericInputRenderer : EntryRenderer
    {
        public NumericInputRenderer(Context context) : base(context)
        {

        }
        private EditText _native = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            _native = Control as EditText;
            _native.InputType = Android.Text.InputTypes.ClassNumber;
            if ((e.NewElement as NumbericInput).AllowNegative == true)
                _native.InputType |= InputTypes.NumberFlagSigned;
            if ((e.NewElement as NumbericInput).AllowFraction == true)
            {
                _native.InputType |= InputTypes.NumberFlagDecimal;
                _native.KeyListener = DigitsKeyListener.GetInstance(string.Format("1234567890{0}", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            }
            if (e.NewElement.FontFamily != null)
            {
                var font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, e.NewElement.FontFamily);
                _native.Typeface = font;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (_native == null)
                return;

            if (e.PropertyName == NumbericInput.AllowNegativeProperty.PropertyName)
            {
                if ((sender as NumbericInput).AllowNegative == true)
                {
                    // Add Signed flag
                    _native.InputType |= InputTypes.NumberFlagSigned;
                }
                else
                {
                    // Remove Signed flag
                    _native.InputType &= ~InputTypes.NumberFlagSigned;
                }
            }
            if (e.PropertyName == NumbericInput.AllowFractionProperty.PropertyName)
            {
                if ((sender as NumbericInput).AllowFraction == true)
                {
                    // Add Decimal flag
                    _native.InputType |= InputTypes.NumberFlagDecimal;
                    _native.KeyListener = DigitsKeyListener.GetInstance(string.Format("1234567890{0}", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                }
                else
                {
                    // Remove Decimal flag
                    _native.InputType &= ~InputTypes.NumberFlagDecimal;
                    _native.KeyListener = DigitsKeyListener.GetInstance(string.Format("1234567890"));
                }
            }
        }
    }
}
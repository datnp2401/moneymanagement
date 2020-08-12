using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoneyManagement.CustomControls
{
    public class CustomListView : ListView
    {
        //public static readonly BindableProperty LazyLoadCommandProperty = BindableProperty.Create(nameof(LazyLoadCommand), typeof(Command), typeof(CustomListView), null, BindingMode.TwoWay);

        //public ICommand LazyLoadCommand
        //{
        //    get { return (ICommand)GetValue(LazyLoadCommandProperty); }
        //    set { SetValue(LazyLoadCommandProperty, value); }
        //}
        public CustomListView()
        {
            //ItemAppearing += CustomListView_ItemAppearing;
        }

        //void CustomListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        //{
        //    var items = ItemsSource as IList;

        //    if (items != null && e.Item == items[items.Count - 1])
        //    {
        //        if (LazyLoadCommand != null && LazyLoadCommand.CanExecute(null))
        //            LazyLoadCommand.Execute(null);
        //    }
        //}

        protected override void SetupContent(Cell content, int index)
        {
            base.SetupContent(content, index);

            var viewCell = content as ViewCell;

            viewCell.View.BackgroundColor = index % 2 == 0 ? Color.FromHex("#d6e9e9") : Color.FromHex("#FFFFFF");
            //Color.FromHex("#F3F8F9")
        }
    }
}

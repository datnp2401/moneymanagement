using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoneyManagement
{
    public class CustomListView : ListView
    {
        public CustomListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
        }

        protected override void SetupContent(Cell content, int index)
        {
            base.SetupContent(content, index);

            var viewCell = content as ViewCell;
            viewCell.View.BackgroundColor = index % 2 == 0 ? Color.WhiteSmoke : Color.White;
        }
    }
}

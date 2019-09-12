using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace PhotoStore.BusinessLogic.Paging
{
    public class PageArgs:EventArgs
    {
        bool _isEnableBackward, _isEnableForward;
        int _totalCount;
        public bool EnableBackward
        {

            get { return _isEnableBackward; }
            set { _isEnableBackward = value; }
        }
        public bool EnableForward
        {

            get { return _isEnableForward; }
            set { _isEnableForward = value; }
        }
        BindingSource _bs=new BindingSource();
        public BindingSource BindingSourceObject
        {
            get { return _bs; }
            set { _bs = value; }
        }
       


    }
}

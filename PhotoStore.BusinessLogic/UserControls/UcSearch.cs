using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore.BusinessLogic.UserControls
{
    public partial class UcSearch : UserControl
    {
        public event EventHandler<EventArgs> _Search;
        public UcSearch()
        {
            InitializeComponent();
        }
        public string SearchCode
        {
            get { return txtSearchCode.Text.Trim(); }
        }

        public string TagLabel
        {
            set { label1.Text = value; }
        }
        private void UcSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnSeaarch_Click(object sender, EventArgs e)
        {
            if (_Search != null)
            {
                _Search(sender, e);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore.BusinessLogic.Forms
{
    public partial class DateSelector : Form
    {
        public DateSelector()
        {
            InitializeComponent();
        }
        public DateTime DateFrom
        {
            get { return dtFrom.Value; }
        }
        public DateTime DateTo
        {
            get { return dtpTo.Value; }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
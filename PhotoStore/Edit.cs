using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhotoStore.Entity;
using PhotoStore.BusinessLogic;
namespace PhotoStore
{
    public partial class Edit : Form
    {
        string _type;
        object _entity = null;
        public Edit()
        {
            InitializeComponent();
        }
        public Edit(string type)
        {
            InitializeComponent();
            _type = type;
        }
        public Edit(string type, object entity)
        {
            InitializeComponent();
            _entity = entity;
            _type = type;

        }
        private void Edit_Load(object sender, EventArgs e)
        {
            ucAddEdit1._doneSaving += new PhotoStore.BusinessLogic.UserControls.DoneSaving(ucAddEdit1__doneSaving);
            ucAddEdit1.LoadStartUpVariables();
            ucAddEdit1.LoadDatas(_type, _entity);
            

        }

        void ucAddEdit1__doneSaving()
        {
            this.Close();
        }

        

    }
}
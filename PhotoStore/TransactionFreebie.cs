using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore
{
    public partial class TransactionFreebie : Form
    {
        #region Declarations
        //declare an entity
        List<Entity.Freebie> _FreebieList = new List<PhotoStore.Entity.Freebie>();

        #endregion
        List<Entity.Freebie> _SelectedFreebieList = new List<PhotoStore.Entity.Freebie>();
        public List<Entity.Freebie> SelectedFreebieList
        {
            get { return _SelectedFreebieList; }
        }
        
        #region Properties

        #endregion

        public TransactionFreebie()
        {
            InitializeComponent();
        }

        private void TransactionFreebie_Load(object sender, EventArgs e)
        {
            LoadFreebies();
        }

        private void LoadFreebies()
        {

            _FreebieList = BusinessLogic.blFreebie.retrieve();

            gvSelection.DataSource = null;
            gvSelection.AutoGenerateColumns = false;

            //this will prevent the "Index -1 does not have a value" message
            BindingSource bs = new BindingSource();
            bs.DataSource = _FreebieList;
            bs.ResetBindings(false);


            gvSelection.DataSource = bs;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvSelection.SelectedRows)
            {
                _SelectedFreebieList.Add((Entity.Freebie)row.DataBoundItem);
            }
            this.Close();

        }



    }
}
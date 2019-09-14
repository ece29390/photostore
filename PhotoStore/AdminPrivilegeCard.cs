using PhotoStore.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotoStore
{
    public partial class AdminPrivilegeCard : Form
    {
        public AdminPrivilegeCard()
        {
            InitializeComponent();
        }

        private void AdminPrivilegeCard_Load(object sender, EventArgs e)
        {
            ucSearchPrivilegeCard._Search += UcSearchPrivilegeCard__Search;
            ucSearchPrivilegeCard.TagLabel = "Card Number"; 
        }

        private void UcSearchPrivilegeCard__Search(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ucSearchPrivilegeCard.SearchCode))
            {
                MessageBox.Show("Invalid Search Key");
                return;
            }

            RetrievePrivilegeCardsBySearchKey();
        }

        private void RetrievePrivilegeCardsBySearchKey()
        {
            List<Entity.PrivilegeCard> privilegeCards = blPrivilegeCard.retrieveByCardNumber(ucSearchPrivilegeCard.SearchCode);
            bindingSourcePrivilegeCard.DataSource = privilegeCards;
        }

        private void DataGridViewPrivilegeCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1 && e.ColumnIndex!=-1)
            {
                var isExpired = (bool)dataGridViewPrivilegeCard.Rows[e.RowIndex].Cells["colIsExpired"].Value;
                if(!isExpired)
                {
                    var userSelection = MessageBox.Show($"The selected card is not yet expired, deleting the card number will disassociate it to the customer,{Environment.NewLine}Do you still want to proceed?"
                                                        , "Caution"
                                                        , MessageBoxButtons.YesNo
                                                        , MessageBoxIcon.Warning);
                    if(userSelection==DialogResult.No)
                    {
                        return;
                    }
                }

                var id = (long)dataGridViewPrivilegeCard.Rows[e.RowIndex].Cells["colId"].Value;
                var customerId = (long)dataGridViewPrivilegeCard.Rows[e.RowIndex].Cells["colCustomerId"].Value;
                var cardNumber = dataGridViewPrivilegeCard.Rows[e.RowIndex].Cells["colCode"].Value.ToString();
                blPrivilegeCard.deactiveCardNumber(id, customerId,cardNumber);
                RetrievePrivilegeCardsBySearchKey();
            }
        }
    }
}

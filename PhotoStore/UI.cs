using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using PhotoStore.Entity;
namespace PhotoStore
{
    public  class UI
    {
        public static BindingSource BindSource(object datasource, bool resetbindings)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = datasource;
            bs.ResetBindings(resetbindings);
            return bs;
        }
        public static BindingSource BindSource(object datasource, bool resetbindings,string sortQuery)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = datasource;
            bs.ResetBindings(resetbindings);
            bs.Sort = sortQuery;
            return bs;
        }
        public static string NoRecordsFound()
        {
            return ConfigurationManager.AppSettings["searchnotfound"].ToString();
        }
        public static void InitializeGrid(DataGridView gv, bool autogencolumns)
        {
            gv.DataSource = null;
            gv.AutoGenerateColumns = autogencolumns;
        }

        public static void BindComboValue(ComboBox combo, object value, Type type)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (type == typeof(ParticularType))
                {
                    ParticularType particularType = (ParticularType)combo.Items[i];
                    if (particularType.Id.Equals(value))
                    {
                        combo.SelectedIndex = i;
                        break;
                    }
                    particularType = null;
                }
                else if(type==typeof(ProductList))
                {
                    ProductList productList = (ProductList)combo.Items[i];
                    if (productList.Id.Equals(value))
                    {
                        combo.SelectedIndex = i;
                        break;
                    }
                    productList = null;
                }
            }
        }
    }
}

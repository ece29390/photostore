using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
namespace PhotoStore.BusinessLogic
{
    public enum NonProductType:int
    {
        GiftCertificate =1,
        Coupon,
        GiftCertificateAndCoupon
    }
    public class blUtility
    {
        List<long> _redemptionGCIds = new List<long>();
        List<long> _redemptionCouponIds = new List<long>();

        public blUtility()
        {
            string[] arrGCIds = ConfigurationManager.AppSettings["redemptiongcids"].ToString().Split(
                new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string arrGCId in arrGCIds)
            {
                _redemptionGCIds.Add(Convert.ToInt32(arrGCId));
            }
            string[] arrCouponIds = ConfigurationManager.AppSettings["redemptioncouponids"].ToString().Split(
                new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string arrCouponId in arrCouponIds)
            {
                _redemptionCouponIds.Add(Convert.ToInt32(arrCouponId));
            }
        }
        public static string FormatCode(string code)
        {
            int maxLength = Convert.ToInt32(ConfigurationManager.AppSettings["MaxChars"]);
            if (code.Length < maxLength)
            {
                int numberOfZeroes = maxLength - code.Length;
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= numberOfZeroes; i++)
                {
                    sb.Append("0");
                }
                return string.Concat(sb.ToString(), code);
            }
            return code;
        }
        public  bool EnableParentGCCoupon(long particulartypeid)
        {
            bool retValue = false;
                       
            if (_redemptionGCIds.Contains(particulartypeid))
            {
                retValue = true;
            }
            if (!retValue)
            {
                if (_redemptionCouponIds.Contains(particulartypeid))
                {
                    retValue = true;
                }
            }
            return retValue;
        }
        private static void CreateDictionary(Dictionary<int, bool> dic, int pointer,DataGridView gv,string columnid
            )
        {
            if (pointer < gv.RowCount)
            {
                bool isSelected = Convert.ToBoolean(gv.Rows[pointer].Cells[columnid].Value);
                if (isSelected)
                {
                    dic.Add(pointer, true);
                }
                CreateDictionary(dic, ++pointer, gv,columnid);
            }
        }

        public static Dictionary<int,bool> SelectedItems(DataGridView gv,string checkcolumnid)
        {
            Dictionary<int, bool> retValue = new Dictionary<int, bool>();
            CreateDictionary(retValue, 0, gv,checkcolumnid);
            return retValue;
        }

        public static List<T> PreviousSelectedIds<T>(Dictionary<int,bool> dic,DataGridView gv,string columnid)
        {
            List<T> retValue=new List<T>();
            foreach(int key in dic.Keys)
            {
                if(dic[key])
                {
                    
                    retValue.Add(
                        (T)gv.Rows[key].Cells[columnid].Value);
                }
            }
            return retValue;
        }

        public static void ManipulateDictionary<T, V>(Dictionary<T, V> dic, T key,V value)
        {
            if (dic == null)
                return;
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        public static bool ValidatePreviousRows(DataGridView gv, string columnnametovalidate)
        {
            bool retValue = false;
            if (gv.RowCount == 0)
            {
                return true;
            }
            foreach (DataGridViewRow row in gv.Rows)
            {
                if (row.Cells[columnnametovalidate].Value != null)
                {
                    if(!string.IsNullOrEmpty(row.Cells[columnnametovalidate].Value.ToString()))
                            retValue = true;
                }
            }
            return retValue;
        }

        public static void OpenWindow(Form form)
        {
            form.ShowDialog();
        }
        private static void AdjustGCOrCouponStatus(SqlParameter param)
        {
            SqlCommand cmd=null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spAdjustGCCouponStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(param);
                DataAccess.daHelper.executeNonQuery(cmd);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (cmd != null)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                    }
                }
            }
        }
       
        public static void AdjustGcOrCouponStatus(NonProductType nonProdType)
        {
            SqlParameter sqlParam;
            switch (nonProdType)
            {
                case NonProductType.Coupon:
                    sqlParam = new SqlParameter("@TableName", SqlDbType.VarChar, 20);
                    sqlParam.Direction = ParameterDirection.Input;
                    sqlParam.Value = "Coupon";
                    AdjustGCOrCouponStatus(sqlParam);
                    break;
                case NonProductType.GiftCertificate:
                    sqlParam = new SqlParameter("@TableName", SqlDbType.VarChar, 20);
                    sqlParam.Direction = ParameterDirection.Input;
                    sqlParam.Value = "GiftCertificate";
                    AdjustGCOrCouponStatus(sqlParam);                
                    break;
                case NonProductType.GiftCertificateAndCoupon:
                    //Executing GC
                    sqlParam = new SqlParameter("@TableName", SqlDbType.VarChar, 20);
                    sqlParam.Direction = ParameterDirection.Input;
                    sqlParam.Value = "GiftCertificate";
                    AdjustGCOrCouponStatus(sqlParam);
                    //Executing Coupon
                    sqlParam.Value = "Coupon";
                    AdjustGCOrCouponStatus(sqlParam);                    
                    break;
            }
           
         }
        private static void ExecuteSQLScript(string scriptFile,SqlCommand cmd)
        {
            using (StreamReader reader = new StreamReader(scriptFile))
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = reader.ReadToEnd();
                DataAccess.daHelper.executeNonQuery(cmd);
                reader.Close();
                if (File.Exists(scriptFile))
                    File.Delete(scriptFile);
            }
        }
        private static void ExecuteSQLScripts(ref string returnMessage,string scriptPath)
        {
            string[] scriptFiles = Directory.GetFiles(scriptPath, "*.sql");
            if (scriptFiles.Length > 0)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    foreach (string scriptFile in scriptFiles)
                    {
                        ExecuteSQLScript(scriptFile,cmd);
                    }
                    returnMessage = "Script file(s) had been successfully executed!";
                }
            }
        }
        public static string  ExecuteScripts(string scriptPath)
        {
            string retValue = "No Script file(s) found!";
            if (!File.Exists(string.Concat(scriptPath,"\\Sequence.txt")))
            {
                ExecuteSQLScripts(ref retValue,scriptPath);
            }
            else
            {
                string sequenceFullPath=string.Concat(scriptPath, "\\Sequence.txt");
                using (StreamReader readerText = new StreamReader(sequenceFullPath))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string lineString = readerText.ReadLine();
                        while (lineString!=null)
                        {
                            ExecuteSQLScript(string.Concat(scriptPath, "\\", lineString),cmd);
                            lineString=readerText.ReadLine();
                        }

                       
                      
                    }
                    readerText.Close();
                    retValue = "Script file(s) had been successfully executed!";
                  
                }
                if (File.Exists(sequenceFullPath))
                    File.Delete(sequenceFullPath);

                ExecuteSQLScripts(ref retValue,scriptPath);
            }

           
            return retValue;
        }
        public static string GetSettingValue(string code)
        {
            string retValue = "";
            using (DataSet ds = DataAccess.daHelper.executeSelect(
                string.Format("SELECT [Value] FROM Setting WHERE [Code]='{0}'",
                code)))
            {
                if (ds != null)
                    retValue = ds.Tables[0].Rows[0]["Value"].ToString();
            }
            return retValue;
        }
     
    }
}

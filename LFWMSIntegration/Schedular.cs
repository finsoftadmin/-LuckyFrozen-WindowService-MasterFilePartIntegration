using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LFWMSIntegration
{
    class Schedular
    {
        System.Timers.Timer oTimer = null;
        double interval = Convert.ToDouble(ConfigurationManager.AppSettings["Interval"]);
        StringBuilder sbLog;
        bool isExecutionCompleted = true;
        string CSVfilePath = string.Empty; //ConfigurationManager.AppSettings["CSVfilePath"];
        string companies = ConfigurationManager.AppSettings["Company"]; //Amin

        public void Start()
        {
            //sbLog.AppendLine(iterationCount.ToString());
            //sbLog.AppendLine("Start Method--Start");
            oTimer = new System.Timers.Timer(interval);
            oTimer.AutoReset = true;
            oTimer.Enabled = true;
            oTimer.Start();

            oTimer.Elapsed += oTimer_Elapsed;
            //sbLog.AppendLine("Start Method--End");

            //TransferFiles();
        }

        void oTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!isExecutionCompleted)
                return;


            string[] lstCompanies = companies.Split(','); //Amin
            int totalCompanies = lstCompanies.Length;
            int curCompany = 0;
            foreach (string comp in lstCompanies)
            {
                curCompany++;
                try
                {

                    CSVfilePath = ConfigurationManager.AppSettings[comp + "CSVfilePath"];

                    isExecutionCompleted = false;
                    string LuckyConStr = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
                    //string Lucky10QualityConStr = ConfigurationManager.ConnectionStrings["Lucky10Quality"].ConnectionString;
                    //Part is separated in another program - Start

                    string P101fileName = "ITEM_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");//"P(101) Material Master";
                    string P101procName = "dbo.P101_MaterialMaster";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    string PartNumcolumn = "Calculated_PartNum";
                    int P101rows = oDAL.GetRows(LuckyConStr, P101procName, comp);
                    if (P101rows > 0)
                    {
                        if (!CSVFileExist(P101fileName))
                            SendDataToCSVFile(LuckyConStr, P101fileName, P101procName, PartNumcolumn, comp);
                    }

                    //string Lucky10QualityConStr = ConfigurationManager.ConnectionStrings["Lucky10Quality"].ConnectionString;
                    string P103fileName = "UOM_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss"); //"P(103) UOM Master";
                    string P103procName = "dbo.P103_UOMMaster"; //ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    string uomColumn = "Part_PartNum";
                    int P103rows = oDAL.GetRows(LuckyConStr, P103procName, comp);
                    if (P103rows > 0)
                    {
                        if (!CSVFileExist(P103fileName))
                            SendDataToCSVFile(LuckyConStr, P103fileName, P103procName, uomColumn, comp);
                    }

                    //Part is separated in another program - End
                    /*
                    string P105fileName = "CUST_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");// "P(105) Customer Master";
                    string P105procName = "dbo.P105_CustomerMaster";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    string customerColumn = "Calculated_customer_code";
                    int P105rows = oDAL.GetRows(LuckyConStr, P105procName);
                    if (P105rows > 0)
                    {
                        if (!CSVFileExist(P105fileName))
                            SendDataToCSVFile(LuckyConStr, P105fileName, P105procName, customerColumn);
                    }

                    string P107fileName = "SUPP_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");// "P(107) Supplier Master";
                    string P107procName = "dbo.P107_SupplierMaster";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    string supplierColumn = "Calculated_supplier_code";
                    int P107rows = oDAL.GetRows(LuckyConStr, P107procName);
                    if (P107rows > 0)
                    {
                        if (!CSVFileExist(P107fileName))
                            SendDataToCSVFile(LuckyConStr, P107fileName, P107procName, supplierColumn);
                    }
                    */

                    //string P201fileName = "P(201) Purchase Order";
                    //PO Done in POWMSIntegration service seperately. 
                    //string P201fileName = "PO_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("hhmmss");
                    //string P201procName = "dbo.P201_PurchaseOrder";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    //if (!CSVFileExist(P201fileName))
                    //    SendDataToCSVFile(LuckyConStr, P201fileName, P201procName);

                    /*
                    string P109fileName = "REASON_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");// "P(109) Reason Code";
                    string P109procName = "dbo.P109_ReasonCode";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    string reasonCodeColumn = "Calculated_reason_code";
                    int P109rows = oDAL.GetRows(LuckyConStr, P109procName);
                    if (P109rows > 0)
                    {
                        if (!CSVFileExist(P109fileName))
                            SendDataToCSVFile(LuckyConStr, P109fileName, P109procName, reasonCodeColumn);
                    }
                    */

                    //ready to process
                    //string P301fileName = "SO_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");// "P(301) Sales Order";
                    //string P301procName = "dbo.P301_SalesOrder";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    //string orderNumColumn = "OrderHed_OrderNum";
                    //int P301rows = oDAL.GetRows(LuckyConStr, P301procName);
                    //if (P301rows > 0)
                    //{
                    //    if (!CSVFileExist(P301fileName))
                    //        SendDataToCSVFile(LuckyConStr, P301fileName, P301procName, orderNumColumn);
                    //}

                    //Auto print ready
                    /*
                    string P401fileName = "RMA_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");// "P(401) RMA Market Return";
                    string P401procName = "dbo.P401_RMAMarketReturn";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    string rmaNumColumn = "RMAHead_RMANum";
                    int P401rows = oDAL.GetRows(LuckyConStr, P401procName);
                    if (P401rows > 0)
                    {
                        if (!CSVFileExist(P401fileName))
                            SendDataToCSVFile(LuckyConStr, P401fileName, P401procName, rmaNumColumn);
                    }
                    */

                    //Auto print ready old one -- Export_c = true then exports
                    //string P601fileName = "TR_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");// "P(601) Transfer Order";
                    //string P601procName = "dbo.P601_TransferOrder";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    //string tfOrdNumColumn = "TFOrdHed_TFOrdNum";
                    //int P601rows = oDAL.GetRows(LuckyConStr, P601procName);
                    //if (P601rows > 0)
                    //{
                    //    if (!CSVFileExist(P601fileName))
                    //        SendDataToCSVFile(LuckyConStr, P601fileName, P601procName,  tfOrdNumColumn);
                    //}

                    //Tick Shipped
                    //string P604fileName = "TO_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");//"P(604) Transfer Shipment";
                    //string P604procName = "dbo.P604_TransferShipment";//ConfigurationManager.AppSettings["P101_StoredProceudreName"];
                    //string tfShHdPackNumColumn = "TFShipHead_PackNum";
                    //int P604rows = oDAL.GetRows(LuckyConStr, P604procName);
                    //if (P604rows > 0)
                    //{
                    //    if (!CSVFileExist(P604fileName))
                    //        SendDataToCSVFile(LuckyConStr, P604fileName, P604procName, tfShHdPackNumColumn);
                    //}
                }
                catch (Exception ex)
                {
                    sbLog = new StringBuilder();
                    sbLog.AppendLine(ex.Message.ToString());
                    WriteLogToFile(DateTime.Now.ToString());
                }
                finally
                {
                    //WriteLogToFile(DateTime.Now.ToString());
                    if (curCompany == totalCompanies)
                        isExecutionCompleted = true;
                }
            }
        }

        public void WriteLogToFile(string time)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt"))
                System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt").Dispose();
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt", true))
            {
                file.WriteLine(time);
                if (sbLog != null)
                {
                    file.WriteLine(sbLog.ToString());
                    sbLog.Clear();
                }
            }
        }
        public void CreateCSVFile(string fileName)
        {
            if (!File.Exists(CSVfilePath + fileName + ".csv"))
                System.IO.File.Create(CSVfilePath + fileName + ".csv").Dispose();           

        }
        public bool CSVFileExist(string fileName)
        {
            bool i = true;
            if (!File.Exists(CSVfilePath + fileName + ".csv"))
                i=false;
            return i;

        }


        private void SendDataToCSVFile(string dbConStr,string fileName,string storeProcName,string colName, string company)
        {
 
            Stopwatch swra = new Stopwatch();
            swra.Start();
            string NewconnectionString = dbConStr;
            
            CreateCSVFile(fileName);

            string file = CSVfilePath + fileName + ".csv";
            if (!IsFileLocked(file))
            {
                StreamWriter CsvfileWriter = new StreamWriter(file);
                string sqlselectQuery = storeProcName;
                SqlCommand sqlcmd = new SqlCommand();

                SqlConnection spContentConn = new SqlConnection(NewconnectionString);
                sqlcmd.Connection = spContentConn;
                sqlcmd.CommandTimeout = 0;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Company", company);//2019-09-26
                sqlcmd.CommandText = sqlselectQuery;
                spContentConn.Open();
                using (spContentConn)
                {
                    using (SqlDataReader sdr = sqlcmd.ExecuteReader())
                    using (CsvfileWriter)
                    {
                        //This Block of code for getting the Table Headers
                        DataTable Tablecolumns = new DataTable();

                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            Tablecolumns.Columns.Add(sdr.GetName(i));
                        }
                        CsvfileWriter.WriteLine(string.Join("|", Tablecolumns.Columns.Cast<DataColumn>().Select(csvfile => csvfile.ColumnName)));
                        //This block of code for getting the Table Headers

                        while (sdr.Read())
                        {
                            //based on your Table columns you can increase and decrese columns
                            //CsvfileWriter.WriteLine(sdr[0].ToString() + "," + sdr[1].ToString() + "," + sdr[2].ToString() + "," + sdr[3].ToString() + "," + sdr[4].ToString() + "," + sdr[5].ToString() + "," + sdr[6].ToString() + "," + sdr[7].ToString() + "," + sdr[8].ToString() + "," + sdr[9].ToString() + "," + sdr[10].ToString() + "," + sdr[11].ToString() + ",");
                            string[] columnValues = Enumerable.Range(0, sdr.FieldCount)
                                  .Select(i => sdr.GetValue(i).ToString())
                                  //.Select(field => string.Concat("\"", field.Replace("\"", "\"\""), "\""))
                                  .ToArray();
                            CsvfileWriter.WriteLine(string.Join("|", columnValues));

                            string keyColToUpd = sdr[colName].ToString();
                            if (keyColToUpd != string.Empty)
                            {
                               
                                    switch (colName)
                                    {
                                        //Part is separated in another program - Start

                                        case "Calculated_PartNum":
                                            //Part.CheckBox14 needs to update
                                            oDAL.UpdatePartCheckBox14(keyColToUpd, dbConStr, company);
                                            break;
                                        case "Part_PartNum":
                                            //Part_UD.CheckBox15 needs to update
                                            oDAL.UpdatePartCheckBox15(keyColToUpd, dbConStr, company);
                                            break;

                                        //Part is separated in another program - End
                                        /*
                                        case "Calculated_customer_code":
                                            //Customer_UD.CheckBox02 needs to update
                                            oDAL.UpdateCustomerCheckBox02(keyColToUpd, dbConStr);
                                            break;
                                        case "Calculated_supplier_code":
                                            //Vendor_UD.CheckBox01 needs to update
                                            oDAL.UpdateVendorCheckBox01(keyColToUpd, dbConStr);
                                            break;
                                        case "Calculated_reason_code":
                                            //Reason_UD.CheckBox01 needs to update
                                            string ReasonType = sdr["Reason_ReasonType"].ToString();
                                            oDAL.UpdateReasonCheckBox01(ReasonType, keyColToUpd, dbConStr);
                                            break;
                                        */
                                        //case "OrderHed_OrderNum":
                                        //    //OrderHed.CheckBox18 needs to update
                                        //    oDAL.UpdateOrderHedCheckBox18(keyColToUpd, dbConStr);
                                        //    break;
                                        /*
                                        case "RMAHead_RMANum":
                                            //RMAHead_UD.CheckBox04 needs to update
                                            oDAL.UpdateRMAHeadCheckBox04(keyColToUpd, dbConStr);                                            
                                            break;
                                        case "TFOrdHed_TFOrdNum":
                                            //TFOrdHed_UD.CheckBox01 needs to update
                                            oDAL.UpdateTFOrdHedCheckBox01(keyColToUpd, dbConStr);                                            
                                            break;
                                        case "TFShipHead_PackNum":
                                            //TFShipHead_UD.CheckBox01 needs to update                                            
                                            oDAL.UpdateTFShipHeadCheckBox01(keyColToUpd, dbConStr);
                                            break;
                                        */
                                        default:
                                            //Console.WriteLine("Default case");
                                            break;
                                    }
                            }
                        }
                    }
                }
                swra.Stop();
                Console.WriteLine(swra.ElapsedMilliseconds);
            }
        }

       
      
        #region FileLock
        public bool IsFileLocked(string file)
        {
            bool Locked = false;
            try
            {
                FileStream fs =
                    File.Open(file, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                Locked = true;
            }
            return Locked;
        }

        #endregion FIleLock

    }
}

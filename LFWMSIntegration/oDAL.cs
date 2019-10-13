using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LFWMSIntegration
{
    public class oDAL
    {
        public static DataTable GetOrderHed()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd= new SqlCommand("SELECT * from erp.OrderHed", con))
                {
                    DataTable dt=new DataTable();
                    con.Open();
                    //SqlCommand sqlCmd = new SqlCommand(sqlselectQuery, spContentConn);
                    sqlCmd.CommandTimeout = 0;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.ExecuteNonQuery();
                    SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                    adptr.Fill(dt);
                    con.Close();

                    return dt;
                }
            }
        }
        /*
        public static void UpdateReasonCheckBox01(string ReasonType,string ReasonCode,string ConnectionString)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("Update Reason Set CheckBox01=1 Where CheckBox01=0 and ReasonType=@ReasonType and ReasonCode=@ReasonCode", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@ReasonType", ReasonType);
                    sqlCmd.Parameters.AddWithValue("@ReasonCode", ReasonCode);
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();
                    
                }
            }
        }
        */
        /*
        public static void UpdateVendorCheckBox01(string VendorID, string ConnectionString)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("Update Vendor Set CheckBox01=1 Where CheckBox01=0 and VendorID=@VendorID", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@VendorID", VendorID);                    
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }
        */
        /*
        public static void UpdateCustomerCheckBox02(string CustID, string ConnectionString)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("Update Customer Set CheckBox02=1 Where CheckBox02=0 and CustID=@CustID", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@CustID", CustID);
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }
        */
        //Part is separated in another program

        public static void UpdatePartCheckBox15(string PartNum, string ConnectionString, string company)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("Update Part Set CheckBox15=1 Where CheckBox15=0 and PartNum=@PartNum and Company=@company", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@PartNum", PartNum);
                    sqlCmd.Parameters.AddWithValue("@company", company);//2019-09-26
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }



        public static void UpdatePartCheckBox14(string PartNum, string ConnectionString, string company)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("Update Part Set CheckBox14=1 Where CheckBox14=0 and PartNum=@PartNum and Company=@company", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@PartNum", PartNum);
                    sqlCmd.Parameters.AddWithValue("@company", company);//2019-09-26
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }

        /*
        public static void UpdateOrderHedCheckBox18(string OrderNum, string ConnectionString)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("update OrderHed set CheckBox18=1 where CheckBox18=0 and OrderNum=@OrderNum", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@OrderNum", OrderNum);
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }
        /*
        public static void UpdateRMAHeadCheckBox04(string RMANum, string ConnectionString)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("update RMAHead set CheckBox04=1 where CheckBox04=0 and RMANum=@RMANum", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@RMANum", RMANum);
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }
        */
        /*
        public static void UpdateTFOrdHedCheckBox01(string TFOrdNum, string ConnectionString)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("update TFOrdHed set CheckBox01=1 where CheckBox01=0 and TFOrdNum=@TFOrdNum", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@TFOrdNum", TFOrdNum);
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }
        */
        /*
        public static void UpdateTFShipHeadCheckBox01(string PackNum, string ConnectionString)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("update TFShipHead set CheckBox01=1 where CheckBox01=0 and PackNum=@PackNum", con))
                {
                    con.Open();
                    //SqlCommand cmd = new SqlCommand(sqlCmd, con);                    
                    sqlCmd.Parameters.AddWithValue("@PackNum", PackNum);
                    int i = (int)sqlCmd.ExecuteNonQuery();
                    //return i;
                    con.Close();

                }
            }
        }
        */
        public static int GetRows(string ConnectionString, string storeProcName, string company)
        {
            int rowCount = 0;
            //string ConnectionString = ConfigurationManager.ConnectionStrings["Lucky10Prod"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = con;
                sqlcmd.CommandTimeout = 0;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Company", company);//2019-09-26
                sqlcmd.CommandText = storeProcName;
                con.Open();
                SqlDataReader sdr = sqlcmd.ExecuteReader();
                //rowCount = sdr.Cast<object>().Count();
                using (DataTable dt = new DataTable())
                {
                    dt.Load(sdr);
                    rowCount = dt.Rows.Count;
                }
                con.Close();
            }
            return rowCount;
        }
    }
}

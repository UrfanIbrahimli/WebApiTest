using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ERP.StockService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StockService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StockService.svc or StockService.svc.cs at the Solution Explorer and start debugging.
    public class StockService : IStockService
    {
        //string connectionString = "Server=DESKTOP-D40F8MT\\MSSQLSERVER2;Database=TutunZavodu;Trusted_Connection=True;";
        string connectionString = "Server=DESKTOP-6MMIBQE;Database=TutunZavodu;Trusted_Connection=True;";

        public List<DS_IncomePrice> GetIncomePriceList(int Id)
        {
            List<DS_IncomePrice> models = new List<DS_IncomePrice>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = @"SELECT 
                    DS_IP.ID as DS_IP_ID, DS_IP.StatusID as DS_IP_StatusID, DS_IP.OwnerID as DS_IP_OwnerID, DS_IP.BranchID as DS_IP_BranchID,
                    DS_IP.CurrencyID as DS_IP_CurrencyID, DS_IP.CustomerID as DS_IP_CustomerID, DS_IP.PhysicalPersonID,DS_IP.ExternalDocNumber,
                    DS_IP.ExternalDocDate,DS_IP.CreateDate,DS_IP.IncomeDate,DS_IP.DS_StockID,DS_IP.RefIncomeTypeID,DS_IP.Description as DS_IP_Description,
                    DS_IP.Contract, DS_IP.ContractDate,DS_IP.LastPaymentDate,DS_IP.DocDueDate as DS_IP_DocDueDate,
                    DS_IP.PJProjectID,DS_IP.OperationalDay as DS_IP_OperationalDay,DS_IP.DsPaymentTypeID
                    FROM CASPELERP.DS_IncomePrice DS_IP
                    WHERE DS_IP.DS_StockID = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DS_IncomePrice model = new DS_IncomePrice
                    {
                        ID = ReplaceNullDecimal(dataReader["DS_IP_ID"]),
                        StatusID = ReplaceNullDecimal(dataReader["DS_IP_StatusID"]),
                        OwnerID = ReplaceNullDecimal(dataReader["DS_IP_OwnerID"]),
                        BranchID = ReplaceNullDecimal(dataReader["DS_IP_BranchID"]),
                        CurrencyID = ReplaceNullDecimal(dataReader["DS_IP_CurrencyID"]),
                        CustomerID = ReplaceNullDecimal(dataReader["DS_IP_CustomerID"]),
                        PhysicalPersonID = ReplaceNullDecimal(dataReader["PhysicalPersonID"]),
                        ExternalDocNumber = ReplaceNullString(dataReader["ExternalDocNumber"]),
                        ExternalDocDate = ReplaceNullDateTime(dataReader["ExternalDocDate"]),
                        CreateDate = ReplaceNullDateTime(dataReader["CreateDate"]),
                        IncomeDate = ReplaceNullDateTime(dataReader["IncomeDate"]),
                        DS_StockID = ReplaceNullDecimal(dataReader["DS_StockID"]),
                        RefIncomeTypeID = ReplaceNullDecimal(dataReader["RefIncomeTypeID"]),
                        Description = ReplaceNullString(dataReader["DS_IP_Description"]),
                        Contract = ReplaceNullString(dataReader["Contract"]),
                        ContractDate = ReplaceNullDateTime(dataReader["ContractDate"]),
                        DocDueDate = ReplaceNullDateTime(dataReader["DS_IP_DocDueDate"]),
                        PJProjectID = ReplaceNullDecimal(dataReader["PJProjectID"]),
                        OperationalDay = ReplaceNullDateTime(dataReader["DS_IP_OperationalDay"]),
                        DsPaymentTypeID = ReplaceNullDecimal(dataReader["DsPaymentTypeID"]),
                    };
                    model.DS_IncomePriceItems = GetIncomePriceItems(model.ID);
                    models.Add(model);
                }
                return models;
            }
        }


        public List<DS_IncomePriceItems> GetIncomePriceItems(decimal IncomePriceID)
        {
            List<DS_IncomePriceItems> models = new List<DS_IncomePriceItems>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = @"SELECT 
                    DS_IPI.ID as DS_IPI_ID, DS_IPI.ProductUnitID,DS_IPI.Quantity,DS_IPI.Price,DS_IPI.SerialNumber as DS_IPI_SerialNumber,
                    DS_IPI.QualityID,DS_IPI.Description as DS_IPI_Description,DS_IPI.Picture,DS_IPI.VatID,
                    DS_IPI.VatPrice,DS_IPI.DocDueDate as DS_IPI_DocDueDate,DS_IPI.OperationalDay as DS_IPI_OperationalDay, DS_IPI.AddressID,DS_IPI.OwnerID as DS_IPI_OwnerID,
                    DS_IPI.StatusID as DS_IPI_StatusID, DS_IPI.BranchID as DS_IPI_BranchID, DS_IPI.CustomerID as DS_IPI_CustomerID, 
                    DS_IPI.CurrencyID as DS_IPI_CurrencyID, DS_IPI.ContractID, DS_IPI.VHFNum,DS_IPI.VHFDate,DS_IPI.HasWarranty,DS_IPI.WarrantyType,
                    DS_IPI.WarrantyMonth,DS_IPI.WarrantyDescription,DS_IPI.Code
                    FROM CASPELERP.DS_IncomePriceItems DS_IPI 
                    WHERE DS_IPI.DS_IncomePriceID = @IncomePriceID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@IncomePriceID", IncomePriceID);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DS_IncomePriceItems model = new DS_IncomePriceItems
                    {
                        ID = ReplaceNullDecimal(dataReader["DS_IPI_ID"]),
                        StatusID = ReplaceNullDecimal(dataReader["DS_IPI_StatusID"]),
                        SerialNumber = ReplaceNullString(dataReader["DS_IPI_SerialNumber"]),
                        OwnerID = ReplaceNullDecimal(dataReader["DS_IPI_OwnerID"]),
                        BranchID = ReplaceNullDecimal(dataReader["DS_IPI_BranchID"]),
                        CurrencyID = ReplaceNullDecimal(dataReader["DS_IPI_CurrencyID"]),
                        CustomerID = ReplaceNullDecimal(dataReader["DS_IPI_CustomerID"]),
                        Description = ReplaceNullString(dataReader["DS_IPI_Description"]),
                        DocDueDate = ReplaceNullDateTime(dataReader["DS_IPI_DocDueDate"]),
                        OperationalDay = ReplaceNullDateTime(dataReader["DS_IPI_OperationalDay"]),
                    };
                    model.DS_IncomePriseSimpleItem = GetIncomePriseSimpleItemItems(model.ID);
                    models.Add(model);
                }
                return models;
            }
        }

        public DS_IncomePriseSimpleItemItems GetIncomePriseSimpleItemItems(decimal IdParent)
        {
            DS_IncomePriseSimpleItemItems model = new DS_IncomePriseSimpleItemItems();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = @" SELECT 
                        DS_IPSII.ID as DS_IPSII_ID , DS_IPSII.SerialNumber as DS_IPSII_SerialNumber,DS_IPSII.EnterDate,
                        DS_IPSII.Weight,DS_IPSII.Moisture,DS_IPSII.IsFirst,DS_IPSII.Ds_refBotanicTypeIDs
                        FROM CASPELERP.DS_IncomePriseSimpleItemItems DS_IPSII
                        Where DS_IPSII.IdParent = @IdParent";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@IdParent", IdParent);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                model.ID = ReplaceNullDecimal(dataReader["DS_IPSII_ID"]);
                model.SerialNumber = ReplaceNullString(dataReader["DS_IPSII_SerialNumber"]);
                model.EnterDate = ReplaceNullDateTime(dataReader["EnterDate"]);
                model.Weight = ReplaceNullDecimal(dataReader["Weight"]);
                model.Moisture = ReplaceNullDecimal(dataReader["Moisture"]);
                model.IsFirst = ReplaceNullBool(dataReader["IsFirst"]);
                model.Ds_refBotanicTypeIDs = ReplaceNullString(dataReader["Ds_refBotanicTypeIDs"]);
                return model;
            }
        }
        public string ReplaceNullString(object value)
        {
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }

        public bool ReplaceNullBool(object value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }
        public int ReplaceNullInt(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt16(value);

        }

        public decimal ReplaceNullDecimal(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(value);
        }

        public DateTime ReplaceNullDateTime(object value)
        {
            if (value == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            return DateTime.Parse(value.ToString());
        }
    }
}

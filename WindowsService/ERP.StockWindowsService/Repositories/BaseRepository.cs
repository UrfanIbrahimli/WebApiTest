using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using ERP.StockWindowsService.Models;

namespace ERP.StockWindowsService.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ErpStockConString"].ConnectionString;
        int Id = Convert.ToInt32(ConfigurationManager.AppSettings["stockId"]);
        int IncomeStatusId = Convert.ToInt32(ConfigurationManager.AppSettings["IncomeStatusId"]);
        int OutcomeStatusId = Convert.ToInt32(ConfigurationManager.AppSettings["OutcomeStatusId"]);
        private readonly ILog _logger;
        public BaseRepository()
        {
            _logger = LogManager.GetLogger<BaseRepository>();
        }
        #region GetIncomePriceList
        public List<DS_IncomePrice> GetIncomePriceList()
        {
            List<DS_IncomePrice> models = new List<DS_IncomePrice>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    /* AND SendingStatus = 0*/
                    connection.Open();
                    string sqlQuery = @"SELECT TOP(100) * FROM CASPELERP.DS_IncomePrice WHERE DS_StockID = @Id AND StatusID = @StatusId AND SendingStatus = 0";

                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@StatusId", IncomeStatusId);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DS_IncomePrice model = new DS_IncomePrice
                        {
                            ID = ReplaceNullDecimal(dataReader["ID"]),
                            StatusID = ReplaceNullDecimal(dataReader["StatusID"]),
                            OwnerID = ReplaceNullDecimal(dataReader["OwnerID"]),
                            BranchID = ReplaceNullDecimal(dataReader["BranchID"]),
                            CurrencyID = ReplaceNullDecimal(dataReader["CurrencyID"]),
                            CustomerID = ReplaceNullDecimal(dataReader["CustomerID"]),
                            PhysicalPersonID = ReplaceNullDecimal(dataReader["PhysicalPersonID"]),
                            ExternalDocNumber = ReplaceNullString(dataReader["ExternalDocNumber"]),
                            ExternalDocDate = ReplaceNullDateTime(dataReader["ExternalDocDate"]),
                            CreateDate = ReplaceNullDateTime(dataReader["CreateDate"]),
                            IncomeDate = ReplaceNullDateTime(dataReader["IncomeDate"]),
                            DS_StockID = ReplaceNullDecimal(dataReader["DS_StockID"]),
                            RefIncomeTypeID = ReplaceNullDecimal(dataReader["RefIncomeTypeID"]),
                            Description = ReplaceNullString(dataReader["Description"]),
                            Contract = ReplaceNullString(dataReader["Contract"]),
                            ContractDate = ReplaceNullDateTime(dataReader["ContractDate"]),
                            LastPaymentDate = ReplaceNullDateTime(dataReader["LastPaymentDate"]),
                            DocDueDate = ReplaceNullDateTime(dataReader["DocDueDate"]),
                            PJProjectID = ReplaceNullDecimal(dataReader["PJProjectID"]),
                            OperationalDay = ReplaceNullDateTime(dataReader["OperationalDay"]),
                            DsPaymentTypeID = ReplaceNullDecimal(dataReader["DsPaymentTypeID"]),
                        };
                        int incomePriceId = Convert.ToInt32(model.ID);
                        IncomePriceUpdateStatus(incomePriceId);
                        model.DS_IncomePriceItems = GetIncomePriceItems(model.ID);
                        models.Add(model);
                    }
                    _logger.Info($"GetIncomePriceList({string.Join(",", Id)})");
                    return models;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"GetIncomePriceList({string.Join(",", Id)}), Exception: {ex.Message}");
                return models;
            }

        }


        public List<DS_IncomePriceItems> GetIncomePriceItems(decimal IncomePriceID)
        {
            List<DS_IncomePriceItems> models = new List<DS_IncomePriceItems>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = @"SELECT * FROM CASPELERP.DS_IncomePriceItems WHERE DS_IncomePriceID = @IncomePriceID";

                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@IncomePriceID", IncomePriceID);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DS_IncomePriceItems model = new DS_IncomePriceItems
                        {
                            ID = ReplaceNullDecimal(dataReader["ID"]),
                            DS_IncomePriceID = ReplaceNullDecimal(dataReader["DS_IncomePriceID"]),
                            ProductUnitID = ReplaceNullDecimal(dataReader["ProductUnitID"]),
                            Quantity = ReplaceNullDecimal(dataReader["Quantity"]),
                            Price = ReplaceNullDecimal(dataReader["Price"]),
                            StatusID = ReplaceNullDecimal(dataReader["StatusID"]),
                            SerialNumber = ReplaceNullString(dataReader["SerialNumber"]),
                            QualityID = ReplaceNullDecimal(dataReader["QualityID"]),
                            AddressID = ReplaceNullDecimal(dataReader["AddressID"]),
                            OwnerID = ReplaceNullDecimal(dataReader["OwnerID"]),
                            BranchID = ReplaceNullDecimal(dataReader["BranchID"]),
                            CurrencyID = ReplaceNullDecimal(dataReader["CurrencyID"]),
                            CustomerID = ReplaceNullDecimal(dataReader["CustomerID"]),
                            ContractID = ReplaceNullDecimal(dataReader["ContractID"]),
                            Description = ReplaceNullString(dataReader["Description"]),
                            VHFNum = ReplaceNullString(dataReader["VHFNum"]),
                            DocDueDate = ReplaceNullDateTime(dataReader["DocDueDate"]),
                            OperationalDay = ReplaceNullDateTime(dataReader["OperationalDay"]),
                            Picture = ReplaceNullByte(dataReader["Picture"]),
                            VatID = ReplaceNullDecimal(dataReader["VatID"]),
                            VatPrice = ReplaceNullDecimal(dataReader["VatPrice"]),
                            VHFDate = ReplaceNullDateTime(dataReader["VHFDate"]),
                            HasWarranty = ReplaceNullBool(dataReader["HasWarranty"]),
                            WarrantyType = ReplaceNullString(dataReader["WarrantyType"]),
                            WarrantyMonth = ReplaceNullDecimal(dataReader["WarrantyMonth"]),
                            WarrantyDescription = ReplaceNullString(dataReader["WarrantyDescription"]),
                            Code = ReplaceNullString(dataReader["Code"]),

                        };
                        model.DS_IncomePriseSimpleItem = GetIncomePriseSimpleItemItems(model.ID);
                        models.Add(model);
                    }
                    _logger.Info($"GetIncomePriceItems({string.Join(",", IncomePriceID)})");
                    return models;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"GetIncomePriceItems({string.Join(",", IncomePriceID)}), Exception: {ex.Message}");
                return models;
            }


        }

        public DS_IncomePriseSimpleItemItems GetIncomePriseSimpleItemItems(decimal IdParent)
        {
            DS_IncomePriseSimpleItemItems model = new DS_IncomePriseSimpleItemItems();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = @"SELECT * FROM CASPELERP.DS_IncomePriseSimpleItemItems Where IdParent = @IdParent";

                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@IdParent", IdParent);
                    SqlDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    model.ID = ReplaceNullDecimal(dataReader["ID"]);
                    model.SerialNumber = ReplaceNullString(dataReader["SerialNumber"]);
                    model.EnterDate = ReplaceNullDateTime(dataReader["EnterDate"]);
                    model.Weight = ReplaceNullDecimal(dataReader["Weight"]);
                    model.Moisture = ReplaceNullDecimal(dataReader["Moisture"]);
                    model.IsFirst = ReplaceNullBool(dataReader["IsFirst"]);
                    model.IdParent = ReplaceNullDecimal(dataReader["IdParent"]);
                    model.Ds_refBotanicTypeIDs = ReplaceNullString(dataReader["Ds_refBotanicTypeIDs"]);
                    _logger.Info($"GetIncomePriseSimpleItemItems({string.Join(",", IdParent)})");
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"GetIncomePriseSimpleItemItems({string.Join(",", IdParent)}), Exception: {ex.Message}");
                return model;
            }

        }

        public void IncomePriceUpdateStatus(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = String.Format("UPDATE CASPELERP.DS_IncomePrice SET SendingStatus = 1 WHERE ID IN ({0})", String.Join(",", Id));
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region GetOutcomeList
        public List<DS_Outcome> GetOutcomeList()
        {
            List<DS_Outcome> models = new List<DS_Outcome>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //AND SendingStatus = 0
                    connection.Open();
                    string sqlQuery = @"SELECT TOP(100) * FROM CASPELERP.DS_Outcome WHERE DS_StockID = @Id AND StatusID = @StatusId AND SendingStatus = 0";

                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@StatusId", OutcomeStatusId);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DS_Outcome model = new DS_Outcome
                        {
                            ID = ReplaceNullDecimal(dataReader["ID"]),
                            StatusID = ReplaceNullDecimal(dataReader["StatusID"]),
                            OwnerID = ReplaceNullDecimal(dataReader["OwnerID"]),
                            BranchID = ReplaceNullDecimal(dataReader["BranchID"]),
                            CurrencyID = ReplaceNullDecimal(dataReader["CurrencyID"]),
                            CustomerID = ReplaceNullDecimal(dataReader["CustomerID"]),
                            PhysicalPersonID = ReplaceNullDecimal(dataReader["PhysicalPersonID"]),
                            ExternalDocNumber = ReplaceNullString(dataReader["ExternalDocNumber"]),
                            ExternalDocDate = ReplaceNullDateTime(dataReader["ExternalDocDate"]),
                            CreateDate = ReplaceNullDateTime(dataReader["CreateDate"]),
                            OutcomeDate = ReplaceNullDateTime(dataReader["OutcomeDate"]),
                            DS_StockID = ReplaceNullDecimal(dataReader["DS_StockID"]),
                            RefOutcomeTypeID = ReplaceNullDecimal(dataReader["RefOutcomeTypeID"]),
                            Description = ReplaceNullString(dataReader["Description"]),
                            DocDueDate = ReplaceNullDateTime(dataReader["DocDueDate"]),
                            PJProjectID = ReplaceNullDecimal(dataReader["PJProjectID"]),
                            OperationalDay = ReplaceNullDateTime(dataReader["OperationalDay"]),
                            RefAddressID = ReplaceNullDecimal(dataReader["RefAddressID"]),
                            StructID = ReplaceNullDecimal(dataReader["StructID"]),
                        };
                        int outcomeId = Convert.ToInt32(model.ID);
                        OutcomeUpdateStatus(outcomeId);
                        model.DS_OutcomeItems = GetOutcomeItems(model.ID);
                        models.Add(model);
                    }
                    _logger.Info($"GetOutcomeList({string.Join(",", Id)})");
                    return models;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"GetOutcomeList({string.Join(",", Id)}), Exception: {ex.Message}");
                return models;
            }

        }

        public List<DS_OutcomeItems> GetOutcomeItems(decimal OutcomeID)
        {
            List<DS_OutcomeItems> models = new List<DS_OutcomeItems>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = @"Select * from CASPELERP.DS_OutcomeItems WHERE DS_OutcomeID = @OutcomeID";

                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@OutcomeID", OutcomeID);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DS_OutcomeItems model = new DS_OutcomeItems
                        {
                            ID = ReplaceNullDecimal(dataReader["ID"]),
                            DS_OutcomeID = ReplaceNullDecimal(dataReader["DS_OutcomeID"]),
                            ProductUnitID = ReplaceNullDecimal(dataReader["ProductUnitID"]),
                            Quantity = ReplaceNullDecimal(dataReader["Quantity"]),
                            StatusID = ReplaceNullDecimal(dataReader["StatusID"]),
                            SerialNumber = ReplaceNullString(dataReader["SerialNumber"]),
                            QualityID = ReplaceNullDecimal(dataReader["QualityID"]),
                            OwnerID = ReplaceNullDecimal(dataReader["OwnerID"]),
                            BranchID = ReplaceNullDecimal(dataReader["BranchID"]),
                            CurrencyID = ReplaceNullDecimal(dataReader["CurrencyID"]),
                            CustomerID = ReplaceNullDecimal(dataReader["CustomerID"]),
                            ContractID = ReplaceNullDecimal(dataReader["ContractID"]),
                            Description = ReplaceNullString(dataReader["Description"]),
                            VHFNum = ReplaceNullString(dataReader["VHFNum"]),
                            DocDueDate = ReplaceNullDateTime(dataReader["DocDueDate"]),
                            OperationalDay = ReplaceNullDateTime(dataReader["OperationalDay"]),
                            Picture = ReplaceNullByte(dataReader["Picture"]),
                            VHFDate = ReplaceNullDateTime(dataReader["VHFDate"]),
                            Code = ReplaceNullString(dataReader["Code"]),
                            CurrentWeight = ReplaceNullDecimal(dataReader["CurrentWeight"]),
                            //NewSerialNumber = ReplaceNullString(dataReader["NewSerialNumber"]),
                        };
                        models.Add(model);
                    }
                    _logger.Info($"GetOutcomeItems({string.Join(",", OutcomeID)})");
                    return models;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"GetOutcomeItems({string.Join(",", OutcomeID)}), Exception: {ex.Message}");
                return models;
            }

        }

        public void OutcomeUpdateStatus(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = String.Format("UPDATE CASPELERP.DS_Outcome SET SendingStatus = 1 WHERE ID IN ({0})", String.Join(",", Id));
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        #endregion


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
                return DateTime.Now;
            }
            return DateTime.Parse(value.ToString());
        }



        public byte[] ReplaceNullByte(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            return (byte[])value;
        }
    }
}

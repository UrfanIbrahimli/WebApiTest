using Common.Logging;
using ERP.GetOutcomeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ERP.GetOutcomeWebApi.Repositories
{
    public class BaseRepository : IBaseRepository
    {

        string connectionString = ConfigurationManager.ConnectionStrings["ErpStockConString"].ConnectionString;
        string Id = ConfigurationManager.AppSettings["stockId"];
        private readonly ILog _logger;
        public BaseRepository()
        {
            _logger = LogManager.GetLogger<BaseRepository>();
        }

        #region GetOutcomeList
        public List<DS_Outcome> GetOutcomeList()
        {
            List<string> Ids = Id.Split(',').ToList();

            string[] paramNames = Ids.Select(
                (s, i) => "@Id" + i.ToString()
            ).ToArray();

            string inClause = string.Join(", ", paramNames);

            List<DS_Outcome> models = new List<DS_Outcome>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = @"SELECT * FROM CASPELERP.DS_Outcome WHERE DS_StockID NOT IN ({0}) AND RefOutcomeTypeID = 14 AND SendingStatus = 0";
                    using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, inClause),connection))
                    {
                        for (int i = 0; i < paramNames.Length; i++)
                        {
                            command.Parameters.AddWithValue(paramNames[i], Ids[i]);
                        }
                        SqlDataReader dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            DS_Outcome model = new DS_Outcome
                            {
                                ID = ReplaceNullDecimal(dataReader["ID"]),
                                ExternalDocDate = ReplaceNullDateTime(dataReader["ExternalDocDate"]),
                                CreateDate = ReplaceNullDateTime(dataReader["CreateDate"]),
                            };
                            int outcomeId = Convert.ToInt32(model.ID);
                            OutcomeUpdateStatus(outcomeId);
                            model.DS_OutcomeItems = GetOutcomeItems(model.ID);
                            models.Add(model);
                        }
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
                            SerialNumber = ReplaceNullString(dataReader["SerialNumber"]),
                            OperationalDay = ReplaceNullDateTime(dataReader["OperationalDay"]),
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

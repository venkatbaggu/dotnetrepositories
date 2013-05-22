﻿using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public class SqlBulkCopier
    {
        public static void WriteToServer(string connectionString, DataTable dataTable)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection))
                {
                    sqlBulkCopy.DestinationTableName = dataTable.TableName;
                    sqlBulkCopy.WriteToServer(dataTable);
                }

                connection.Close();
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace ClsAppTypeColumn
{
    public sealed class DaoPeople
    {
        private SqlConnection _connection;
        public DaoPeople(SqlConnection connection)
        {
            _connection = connection;
        }

        public People Add(People model)
        {
            using (SqlCommand _command = _connection.OpenAndCreateCommand())
            {                
                _command.CommandText = "INSERT INTO People(Name, GuidId, DateCreated, TimeCreated, Active, Value) ";
                _command.CommandText += "VALUES(@Name, @GuidId, @DateCreated, @TimeCreated, @Active, @Value); ";
                _command.CommandText += "SELECT @@IDENTITY; ";
                _command.Parameters.Add("@Name", SqlDbType.VarChar).Value = model.Name.GetValueOrDBNull();
                _command.Parameters.Add("@GuidId", SqlDbType.UniqueIdentifier).Value = model.GuidId.GetValueOrDBNull();
                _command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = model.DateCreated.GetValueOrDBNull();
                _command.Parameters.Add("@TimeCreated", SqlDbType.Time).Value = model.TimeCreated.GetValueOrDBNull();
                _command.Parameters.Add("@Active", SqlDbType.Bit).Value = model.Active.GetValueOrDBNull();
                _command.Parameters.Add("@Value", SqlDbType.Decimal).Value = model.Value.GetValueOrDBNull();
                if (int.TryParse($"{_command.ExecuteScalar()}", out int _id))
                {
                    model.Id = _id;
                }
                _connection.Close();
            }
            return model;
        }


        public People Find(params object[] id)
        {
            People p = null;
            using (SqlCommand _command = _connection.OpenAndCreateCommand())
            {
                _command.CommandText = "SELECT Id,Name, GuidId, DateCreated, TimeCreated, Active, Value ";                
                _command.CommandText += "FROM People WHERE Id=@Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = id[0];
                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        p = new People
                        {
                            Id = reader.GetInt32(0), 
                            Name = reader.GetStringOrNull(1), 
                            GuidId  = reader.GetGuidOrNull(2),
                            DateCreated = reader.GetDateTimeOrNull(3),
                            TimeCreated = reader.GetTimeSpanOrNull(4),
                            Active = reader.GetBooleanOrNull(5),
                            Value = reader.GetDecimalOrNull(6) 
                        };
                    }
                    
                }
                _connection.Close();
            }
            return p;
        }

        public IEnumerable<People> All()
        {            
            using (SqlCommand _command = _connection.OpenAndCreateCommand())
            {
                _command.CommandText = "SELECT Id, Name, GuidId, DateCreated, TimeCreated, Active, Value ";
                _command.CommandText += "FROM People ";                
                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            yield return new People
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetStringOrNull(1),
                                GuidId = reader.GetGuidOrNull(2),
                                DateCreated = reader.GetDateTimeOrNull(3),
                                TimeCreated = reader.GetTimeSpanOrNull(4),
                                Active = reader.GetBooleanOrNull(5),
                                Value = reader.GetDecimalOrNull(6)
                            };
                        }
                    }
                }
                _connection.Close();
            }            
        }
    }
}

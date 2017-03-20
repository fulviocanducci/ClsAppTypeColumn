using System;
using System.Data.SqlClient;
using System.Data;


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
                int _id;
                if (int.TryParse($"{_command.ExecuteScalar()}", out _id))
                {
                    model.Id = _id;
                }
                _connection.Close();
            }
            return model;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClsAppTypeColumn
{
    public static class Utils
    {
        public static object GetValueOrDBNull<T>(this T? _o)
            where T: struct
        {
            return _o.HasValue
                ? (object)_o
                : DBNull.Value;
        }

        public static object GetValueOrDBNull(this string _o)            
        {
            return (object)_o ?? DBNull.Value;
        }

        public static void IsOpen(this SqlConnection _c)
        {
            if (_c.State == ConnectionState.Closed)
                _c.Open();
        }

        public async static Task IsOpenAsync(this SqlConnection _c)
        {
            if (_c.State == ConnectionState.Closed)
                await _c.OpenAsync();
        }

        public static SqlCommand OpenAndCreateCommand(this SqlConnection _c)
        {
            _c.IsOpen();
            return _c.CreateCommand();
        }

        public async static Task<SqlCommand> OpenAsyncAndCreateCommand(this SqlConnection _c)
        {
            await _c.IsOpenAsync();
            return _c.CreateCommand();
        }
    }
}

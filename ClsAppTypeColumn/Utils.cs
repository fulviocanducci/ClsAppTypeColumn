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

        #region SqlDataReader_Data_Or_Null
        
        public static T GetValueOrNull<T>(this SqlDataReader _r, int index)            
        {
            return (!_r.IsDBNull(index))
                ? _r.GetFieldValue<T>(index)
                : default(T);
        }

        public static string GetStringOrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<string>(index);
        }

        public static short? GetInt16OrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<short?>(index);
        }
        public static long? GetInt64OrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<long?>(index);
        }
        public static int? GetInt32OrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<int?>(index);
        }

        public static decimal? GetDecimalOrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<decimal?>(index);
        }

        public static double? GetDoubleOrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<double?>(index);
        }

        public static Guid? GetGuidOrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<Guid?>(index);
        }

        public static DateTime? GetDateTimeOrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<DateTime?>(index);
        }

        public static TimeSpan? GetTimeSpanOrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<TimeSpan?>(index);
        }

        public static bool? GetBooleanOrNull(this SqlDataReader _r, int index)
        {
            return _r.GetValueOrNull<bool?>(index);
        }
        #endregion
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using Npgsql;

namespace pgSQLandWinForms
{
    internal class Repository
    {
        NpgsqlConnection oCon = null;

        public NpgsqlConnection Connect()
        {
            string strCon = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["AutoConnectionString"];
            if (settings != null)
                strCon = settings.ConnectionString;

            try
            {
                oCon = new NpgsqlConnection(strCon);
                oCon.Open();
            }
            catch (Exception) { }
            return oCon;
        }


        public void CloseBD()
        {
            if (oCon.FullState == ConnectionState.Open)
                oCon.Close();
        }


        public NpgsqlDataReader LoadData()
        {
            oCon = Connect();
            if (oCon.FullState == ConnectionState.Open)
            {
                string sqlstr = "SELECT * FROM public.\"Human\"";
                using (NpgsqlCommand command = new NpgsqlCommand(sqlstr, oCon))
                {
                    NpgsqlDataReader read = command.ExecuteReader();
                    return read;
                }
            }
            return null;
        }


        private int GetMaxIndex()
        {
            int maxId = 0;
            oCon = Connect();
            if (oCon.FullState == ConnectionState.Open)
            {
                string sqlstr = "SELECT MAX(id) FROM public.\"Human\"";
                using (NpgsqlCommand command = new NpgsqlCommand(sqlstr, oCon))
                {
                    try
                    {
                        maxId = (int)command.ExecuteScalar();
                    }
                    catch (Exception) { }
                    finally
                    {
                        CloseBD();
                    }
                }
            }
            return maxId;
        }


        public void InsertData(Person obj)
        {
            int id = GetMaxIndex();
            oCon = Connect();
            if (oCon.FullState == ConnectionState.Open)
            {
                string sqlstr = $"INSERT INTO public.\"Human\" (id, name, surname, patronymic, age) VALUES({id + 1},'{obj.Имя}','{obj.Фамилия}','{obj.Отчество}',{obj.Возраст})";
                using (NpgsqlCommand command = new NpgsqlCommand(sqlstr, oCon))
                {
                    command.ExecuteNonQuery();
                }
                CloseBD();
            }
        }


        public void DeleteData(int id)
        {
            oCon = Connect();
            if (oCon.FullState == ConnectionState.Open)
            {
                String sqlstr = $"DELETE FROM public.\"Human\" WHERE Id = {id}";
                using (NpgsqlCommand command = new NpgsqlCommand(sqlstr, oCon))
                {
                    int t = command.ExecuteNonQuery();
                }
                CloseBD();
            }
        }


        public NpgsqlDataReader FilterData(string attr, string value)
        {
            oCon = Connect();
            if (oCon.FullState == ConnectionState.Open)
            {
                string[] str = attr.Split('-');
                string sqlstr = $"SELECT * FROM public.\"Human\" WHERE {str[1].Trim()}='{value}'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlstr, oCon))
                {
                    NpgsqlDataReader read = cmd.ExecuteReader();
                    return read;
                }
            }
            return null;
        }
    }
}

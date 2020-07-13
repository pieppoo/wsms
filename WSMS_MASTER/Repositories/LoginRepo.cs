using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;
using WSMS_MASTER.Common;
using WSMS_MASTER.Models;
using WSMS_MASTER.Properties;

namespace WSMS_MASTER.Repositories
{
    public class LoginRepo : IRepository<LoginColumns>
    {
        private IDbConnection dbConnection = null;

        public LoginRepo()
        {
            dbConnection = new MySqlConnection(Settings.Default.connection_string);
            //dbConnection.Open();

        }
        public bool Add(LoginColumns entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LoginColumns> GetAll()
        {
            try
            {
                var queryResult = dbConnection.Query<LoginColumns>("SELECT * FROM users");
                return queryResult.ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public List<LoginColumns> GetAll(string username)
        {
            try
            {
                var sql = "select * from users where username = '" + username + "'";
                var queryResult = dbConnection.Query<LoginColumns>(sql);
                return queryResult.ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
            }
            return null;
        }

        public LoginColumns GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<LoginColumns> Search(params object[] args)
        {
            throw new NotImplementedException();
        }

        public bool Update(LoginColumns userdetail)
        {
            throw new NotImplementedException();
        }

        public bool Updatelastlogin(LoginColumns userdetail)
        {
            var result = false;
            try
            {
                string sql = string.Format("UPDATE users SET last_login = '{1}' WHERE userid = {0}",
                                            userdetail.userid,
                                            userdetail.last_login);

                var count = dbConnection.Execute(sql, userdetail);
                result = count > 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
            }

            return result;
        }

        public bool updatepswd(LoginColumns userdetail)
        {
            var result = false;
            try
            {
                string sql = string.Format("UPDATE users SET password = '{1}' WHERE userid = {0}",
                                            userdetail.userid,
                                            userdetail.password);

                var count = dbConnection.Execute(sql, userdetail);
                result = count > 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
            }

            return result;
        }
    }
}

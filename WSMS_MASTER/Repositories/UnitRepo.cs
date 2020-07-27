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
    public class UnitRepo : IRepository<UnitColumns>
    {
        private IDbConnection dbConnection = null;

        public UnitRepo()
        {
            dbConnection = new MySqlConnection(Settings.Default.connection_string);
            //dbConnection.Open();

        }
        public bool Add(UnitColumns unititem)
        {
            var result = false;
            try
            {
                string sql = string.Format("insert into units (unitcode, name, remark, created_by) values ('{0}', '{1}', '{2}', '{3}')",
                                            unititem.unitcode,
                                            unititem.name, 
                                            unititem.remark,
                                            unititem.created_by
                                            );

                var count = dbConnection.Execute(sql, unititem);
                result = count > 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
            }

            return result;
        }

        public bool Delete(int id)
        {
            var result = false;
            try
            {
                string sql = string.Format("DELETE FROM units WHERE unitid = @id");
                Console.WriteLine(sql);

                var count = dbConnection.Execute(sql, new { Id = id });
                return count > 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
            }
            return result;
        }

        public UnitColumns GetByAny(int anyvar)
        {
            try
            {
                var queryResult = dbConnection.Query<UnitColumns>("select * from units order by unitid desc LIMIT " + anyvar);

                return queryResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public List<UnitColumns> GetAll()
        {
            try
            {
                var queryResult = dbConnection.Query<UnitColumns>("SELECT * FROM units");
                return queryResult.ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public UnitColumns GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UnitColumns> Search(params object[] args)
        {
            throw new NotImplementedException();
        }

        public bool Update(UnitColumns unitdetail)
        {
            var result = false;
            try
            {
                string sql = string.Format("UPDATE units SET name = '{1}', remark = '{2}', updated_by = '{3}', unitcode = '{4}' WHERE unitid = {0}",
                            unitdetail.unitid,
                            unitdetail.name,
                            unitdetail.remark,
                            unitdetail.updated_by,
                            unitdetail.unitcode);

                var count = dbConnection.Execute(sql, unitdetail);
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

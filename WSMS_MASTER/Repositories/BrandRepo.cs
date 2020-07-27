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
    public class BrandRepo : IRepository<BrandColumns>
    {
        private IDbConnection dbConnection = null;

        public BrandRepo()
        {
            dbConnection = new MySqlConnection(Settings.Default.connection_string);
            //dbConnection.Open();

        }
        public bool Add(BrandColumns branditem)
        {
            var result = false;
            try
            {
                string sql = string.Format("insert into brands (name, remark, created_by) values ('{0}', '{1}', '{2}')",
                                            branditem.name,
                                            branditem.remark,
                                            branditem.created_by
                                            );

                var count = dbConnection.Execute(sql, branditem);
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
                string sql = string.Format("DELETE FROM brands WHERE brandid = @id");
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
        public BrandColumns GetByAny(int anyvar)
        {
            try
            {
                var queryResult = dbConnection.Query<BrandColumns>("select * from brands order by brandid desc LIMIT " + anyvar);

                return queryResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public List<BrandColumns> GetAll()
        {
            try
            {
                var queryResult = dbConnection.Query<BrandColumns>("SELECT * FROM brands");
                return queryResult.ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public BrandColumns GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BrandColumns> Search(params object[] args)
        {
            throw new NotImplementedException();
        }

        public bool Update(BrandColumns brandDetail)
        {
            var result = false;
            try
            {
                string sql = string.Format("UPDATE brands SET name = '{1}', remark = '{2}', updated_by = '{3}' WHERE brandid = {0}",
                            brandDetail.brandid,
                            brandDetail.name,
                            brandDetail.remark,
                            brandDetail.updated_by);

            var count = dbConnection.Execute(sql, brandDetail);
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

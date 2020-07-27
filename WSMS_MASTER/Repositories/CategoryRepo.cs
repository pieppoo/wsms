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
    public class CategoryRepo : IRepository<CategoryColumns>
    {
        private IDbConnection dbConnection = null;

        public CategoryRepo()
        {
            dbConnection = new MySqlConnection(Settings.Default.connection_string);
            //dbConnection.Open();

        }
        public bool Add(CategoryColumns catsitem)
        {
            var result = false;
            try
            {
                string sql = string.Format("insert into categories (name, remark, created_by) values ('{0}', '{1}', '{2}')",
                                            catsitem.name,
                                            catsitem.remark,
                                            catsitem.created_by
                                            );

                var count = dbConnection.Execute(sql, catsitem);
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
                string sql = string.Format("DELETE FROM categories WHERE CATID = @id");
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

        public CategoryColumns GetByAny(int anyvar)
        {
            try
            {
                var queryResult = dbConnection.Query<CategoryColumns>("select * from categories order by catid desc LIMIT " + anyvar);

                return queryResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public List<CategoryColumns> GetAll()
        {
            try
            {
                var queryResult = dbConnection.Query<CategoryColumns>("SELECT * FROM categories");
                return queryResult.ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public CategoryColumns GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryColumns> Search(params object[] args)
        {
            throw new NotImplementedException();
        }

        public bool Update(CategoryColumns catdetail)
        {
            var result = false;
            try
            {
                string sql = string.Format("UPDATE categories SET name = '{1}', remark = '{2}', updated_by = '{3}' WHERE catid = {0}",
                            catdetail.catid,
                            catdetail.name,
                            catdetail.remark,
                            catdetail.updated_by);

                var count = dbConnection.Execute(sql, catdetail);
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

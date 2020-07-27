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
    public class ProductRepo : IRepository<ProductColumns>
    {
         private IDbConnection dbConnection = null;

         public ProductRepo()
         {
             dbConnection = new MySqlConnection(Settings.Default.connection_string);
             //dbConnection.Open();

         }
         public bool Add(ProductColumns product)
         {
            var result = false;
            try
            {
                string sql = string.Format("insert into products (prodcode, name, brandid, prodcat, produnit,  purchaseprice, barcodeno, created_by ) values ('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}', '{7}')",
                                            product.prodcode,
                                            product.name,
                                            product.brandid,
                                            product.prodcat,
                                            product.produnit,
                                            product.purchaseprice,
                                            product.barcodeno,
                                            product.created_by
                                            );

                var count = dbConnection.Execute(sql, product);
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
                 string sql = string.Format("DELETE FROM products WHERE prodid = @id");
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

        public bool Delete2table(int id)
        {
            var result = false;
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            using (var tran = dbConnection.BeginTransaction())
            {
                try
                {
                    // multiple operations involving here

                    //step 1: delete data in selling_price table first
                    string sql = string.Format("DELETE FROM selling_price WHERE prodid = @id");
                    Console.WriteLine(sql);

                    var count = dbConnection.Execute(sql, new { Id = id });
                    var firstResult = count > 0;

                    if (firstResult)
                    {
                        //step 2: delete product
                        string sql2 = string.Format("DELETE FROM products WHERE prodid = @id");
                        Console.WriteLine(sql2);

                        var count2 = dbConnection.Execute(sql2, new { Id = id });
                        result = count2 > 0;

                        tran.Commit();
                        return result;
                    }
                    else
                        return firstResult;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.Log(ex, true);
                    return result;
                }
            }
        }

         public List<ProductColumns> GetAll()
         {
             try
             {
                 var queryResult = dbConnection.Query<ProductColumns>("SELECT * FROM products");
                 return queryResult.ToList();
             }
             catch (Exception ex)
             {
                 Logger.Log(ex, true);
                 return null;
             }
         }



         public List<ProductColumns> GetAll(int brandid)
         {
             try
             {
                 var queryResult = dbConnection.Query<ProductColumns>("SELECT * FROM products where brandid = " + brandid);

                 return queryResult.ToList();
             }
             catch (Exception ex)
             {
                 Logger.Log(ex, true);
                 return null;
             }
         }

         public ProductColumns GetById(int id)
         {
            try
            {
                var queryResult = dbConnection.Query<ProductColumns>("SELECT * FROM products where prodid = " + id);

                return queryResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public ProductColumns GetByGUID(string guid)
        {
            try
            {
                return dbConnection.Query<ProductColumns>("SELECT * FROM products WHERE guid = '" + guid + "';").FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public ProductColumns GetByAny(int anyvar)
        {
            try
            {
                var queryResult = dbConnection.Query<ProductColumns>("select * from products order by prodid desc LIMIT " + anyvar);

                return queryResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }


        public List<ProductColumns> Search(params object[] args)
         {
             throw new NotImplementedException();
         }

        public bool Update(ProductColumns product)
        {
            var result = false;
            try
            {
                string sql = string.Format("UPDATE products SET prodcat = {1}, brandid = {2}, prodcode = '{3}', name = '{4}', produnit = {5}, purchaseprice = {6}, barcodeno = '{7}', updated_by = '{8}' WHERE prodid = {0}",
                                            product.prodid,
                                            product.prodcat,
                                            product.brandid,
                                            product.prodcode,
                                            product.name,
                                            product.produnit,
                                            product.purchaseprice,
                                            product.barcodeno,
                                            product.updated_by);

                var count = dbConnection.Execute(sql, product);
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


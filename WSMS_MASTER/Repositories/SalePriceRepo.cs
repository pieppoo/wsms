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
    public class SalePriceRepo
    {
        private IDbConnection dbConnection = null;

        public SalePriceRepo()
        {
            dbConnection = new MySqlConnection(Settings.Default.connection_string);
            //dbConnection.Open();

        }
        public bool Add(SalePriceColumns salepriceitem)
        {
            var result = false;
            try
            {
                string sql = string.Format("insert into selling_price (prodid, created_by ) values ({0}, '{1}')",
                                            salepriceitem.prodid,
                                            salepriceitem.created_by
                                            );

                var count = dbConnection.Execute(sql, salepriceitem);
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
            throw new NotImplementedException();
        }

        public List<SalePriceColumns> GetAll()
        {
            try
            {
                var queryResult = dbConnection.Query<SalePriceColumns>("SELECT * FROM selling_price");
                return queryResult.ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }


        public SalePriceColumns GetById(int prodid)
        {
            try
            {
                var queryResult = dbConnection.Query<SalePriceColumns>("SELECT * FROM selling_price where prodid = " + prodid);

                return queryResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, true);
                return null;
            }
        }

        public SalePriceColumns GetByAny(int anyvar)
        {
            throw new NotImplementedException();
        }


        public List<SalePriceColumns> Search(params object[] args)
        {
            throw new NotImplementedException();
        }

        public bool Update(SalePriceColumns salepriceitem)
        {
            var result = false;
            try
            {
                string sql = string.Format("UPDATE selling_price SET price_1 = {1}, price_2 = {2}, price_3 = {3}, price_4 = {4}, price_5 = {5}, updated_by = '{6}' WHERE prodid = {0}",
                                            salepriceitem.prodid,
                                            salepriceitem.price_1,
                                            salepriceitem.price_2,
                                            salepriceitem.price_3,
                                            salepriceitem.price_4,
                                            salepriceitem.price_5,
                                            salepriceitem.created_by
                                            );

                var count = dbConnection.Execute(sql, salepriceitem);
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


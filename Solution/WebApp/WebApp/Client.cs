using Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Client
    {
        public static DataTable getCities()
        {
            DataTable table = DB.getStaticData("SELECT * FROM City");
            return table;
        }
        public static DataTable getRegions()
        {
            DataTable table = DB.getStaticData("SELECT * FROM Region");
            return table;
        }

        public static DataTable getRegions(string cityId)
        {
            DataTable table = DB.getStaticData("SELECT * FROM Region r WHERE r.CityId = "+DB.Quote(cityId));
            return table;
        }

        public static DataTable getClassifications()
        {
            DataTable table = DB.getStaticData("SELECT * FROM Classification");
            return table;
        }

        public static DataTable getLastPurchases()
        {
            DataTable table = DB.getStaticData("SELECT DISTINCT FORMAT(LastPurchase,'dd/MM/yyyy') as LastPurchase FROM Client");
            return table;
        }
        public static DataTable getLastPurchasesMinus()
        {
            DataTable table = DB.getStaticData("SELECT DISTINCT FORMAT(LastPurchase-1,'dd/MM/yyyy') as LastPurchase FROM Client");
            return table;
        }
        public static DataTable getLastPurchasesPlus()
        {
            DataTable table = DB.getStaticData("SELECT DISTINCT FORMAT(LastPurchase+1,'dd/MM/yyyy') as LastPurchase FROM Client");
            return table;
        }



        public static DataTable getClients(string filters)
        {
            string query = " SELECT C2.ClassificationName,c1.Name,C1.Phone,c1.Gender,c3.CityName,r.RegionName," +
                            " FORMAT(c1.LastPurchase, 'dd/MM/yyyy') as LastPurchase, c1.ClientId, c2.ClassificationId, c3.CityId, r.RegionId" +
                            " FROM Client c1 INNER JOIN" +
                            " Classification c2 ON C1.ClassificationId = C2.ClassificationId" +
                            " INNER JOIN Region r on c1.RegionId = r.RegionId" +
                            " INNER JOIN City c3 on c3.CityId = r.CityId";
            if (!string.IsNullOrEmpty(filters))
            {
                query = query + " WHERE 1 = 1 " + filters;
            }
            DataTable table = DB.getStaticData(query);
            return table;
        }
        public static DataTable getClients(string SellerId, string filters)
        {
            string query = " SELECT C2.ClassificationName,c1.Name,C1.Phone,c1.Gender,c3.CityName,r.RegionName," +
                                                " FORMAT(c1.LastPurchase, 'dd/MM/yyyy') as LastPurchase, c1.ClientId, c2.ClassificationId, c3.CityId, r.RegionId" +
                                                " FROM Client c1 INNER JOIN" +
                                                " Classification c2 ON C1.ClassificationId = C2.ClassificationId" +
                                                " INNER JOIN Region r on c1.RegionId = r.RegionId" +
                                                " INNER JOIN City c3 on c3.CityId = r.CityId" +
                                                " WHERE C1.SellerId = " + DB.Quote(SellerId);
            if (!string.IsNullOrEmpty(filters))
            {
                query = query + filters;
            }
            DataTable table = DB.getStaticData(query);
            return table;
        }
    }
}
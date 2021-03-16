namespace ServerTest.Controllers
{
    using ServerTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MySql;
    using MySql.Data.MySqlClient;

    public class RankInfoController : ApiController
    {
        public RankInfo GetDataFromMysql()
        {
            RankInfo rankInfo = new RankInfo();

            using (MySqlConnection connection = new MySqlConnection("Server=10.80.162.193;Database=2048;Uid=root;Pwd=kmk5632980"))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM rank";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader table = cmd.ExecuteReader();

                    int arrayCnt = 0;

                    while (table.Read() && arrayCnt < 10)
                    {
                        rankInfo.userId[arrayCnt] = table["user_id"].ToString();
                        rankInfo.userScore[arrayCnt] = int.Parse(table["user_score"].ToString());
                        rankInfo.playTime[arrayCnt] = table["user_playtime"].ToString();
                        arrayCnt++;
                    }
                    table.Close();
                }
                catch
                {
                    return null;
                }

                return rankInfo;
            }
        }
    }
}
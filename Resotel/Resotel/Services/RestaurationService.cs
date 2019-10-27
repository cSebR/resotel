using MySql.Data.MySqlClient;
using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Services
{
    public class RestaurationService
    {
        #region Singleton

        private static RestaurationService instance = null;
        public static RestaurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RestaurationService();
                }
                return instance;
            }
        }

        // EMPECHE L'INSTANCIATION DE LA CLASSE
        private RestaurationService()
        {
        }

        #endregion

        private MySqlConnection mySqlConnection = null;

        private bool OpenConnection()
        {
            try
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
                csb.Server = "localhost";
                csb.Database = "resotel";
                csb.UserID = "root";
                csb.Password = "";

                mySqlConnection = new MySqlConnection(csb.ConnectionString);

                mySqlConnection.Open();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                mySqlConnection = null;
                return false;
            }
        }

        private void CloseConnection()
        {
            try
            {
                mySqlConnection.Close();
            }
            catch (Exception)
            {

                mySqlConnection = null;
            }
        }


        public List<LinkMeal> ChargerRestauration()
        {
            List<LinkMeal> list = new List<LinkMeal>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT count(*) FROM link_reservationmeal WHERE id_Meal = 2";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LinkMeal restauration = new LinkMeal
                {
                    Id = reader.GetInt32("id_Meal"),
                    Id_resa = reader.GetInt32("id_Reservation"),
                    Date = reader.GetDateTime("date")


                };

                list.Add(restauration);
            }

            CloseConnection();

            return list;
        }


        public List<LinkMeal> ChargerRestaurationsByDate(string date)
        {
            List<LinkMeal> list = new List<LinkMeal>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT count(*) FROM link_reservationmeal WHERE date = '" + date + "' AND id_Meal = 2";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LinkMeal restauration = new LinkMeal
                {
                    Id = reader.GetInt32("id_Meal"),
                    Id_resa = reader.GetInt32("id_Reservation"),
                    Date = reader.GetDateTime("date")

                };

                list.Add(restauration);
            }

            CloseConnection();

            return list;
        }

        public int SaveRestauration(LinkMeal linkmeal)
        {
            if (OpenConnection() == false) return 0;

            string req;

            if (linkmeal.Id > 0)
            {
                req = "UPDATE link_reservationmeal set id_Meal=@idMeal, id_Reservation = @idReservation, date = '@date' WHERE id_Meal = @idMeal";
            }
            else
            {
                req = "INSERT INTO link_reservationmeal (id_Meal, id_Reservation, date) VALUES (@idMeal, @idReservation, '@date')";
            }

            MySqlCommand cmd = new MySqlCommand(req, mySqlConnection);

            if (linkmeal.Id > 0)
            {

                cmd.Parameters.Add(new MySqlParameter("@id_Meal", linkmeal.Id));
            }

            cmd.Parameters.Add(new MySqlParameter("@idReservation", linkmeal.Id_resa));
            cmd.Parameters.Add(new MySqlParameter("@date", linkmeal.Date));

            int res = cmd.ExecuteNonQuery();

            CloseConnection();

            return linkmeal.Id;
        }

    }
}

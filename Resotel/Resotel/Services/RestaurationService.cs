using MySql.Data.MySqlClient;
using Resotel.Entities;
using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        //public List<LinkMeal> ChargerRestauration()
        //{
        //    List<LinkMeal> list = new List<LinkMeal>();

        //    if (OpenConnection() == false)
        //    {
        //        return list;
        //    }
        //    string req = "SELECT count(*) FROM link_reservationmeal WHERE id_Meal = 2";
        //    MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        LinkMeal restauration = new LinkMeal
        //        {
        //            Id = reader.GetInt32("id_Meal"),
        //            Id_resa = reader.GetInt32("id_Reservation"),
        //            Date = reader.GetDateTime("date")
        //        };

        //        list.Add(restauration);
        //    }

        //    CloseConnection();

        //    return list;
        //}


        public List<Meal> ChargerRestaurationsByDate(string date)
        {
            List<Meal> list = new List<Meal>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT m.id, m.name, m.price, l.date FROM meal m JOIN link_reservationmeal l ON m.id = l.id_Meal WHERE date = '" + date + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Meal meal = new Meal
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetFloat("price"),
                    Date = reader.GetDateTime("date")
                };

                list.Add(meal);
            }

            CloseConnection();

            return list;
        }

        public int SaveRestauration(ObservableCollection<MealViewModel> ListMeals, int id_Reservation)
        {
            if (OpenConnection() == false) return 0;

            string req;

            foreach (MealViewModel m in ListMeals)
            {
                req = "INSERT INTO link_reservationmeal (id_Meal, id_Reservation, date) VALUES (@idMeal, @idReservation, @date)";
                MySqlCommand cmd = new MySqlCommand(req, mySqlConnection);
                cmd.Parameters.Add(new MySqlParameter("@idMeal", m.Meal.Id));
                cmd.Parameters.Add(new MySqlParameter("@idReservation", id_Reservation));
                cmd.Parameters.Add(new MySqlParameter("@date", m.Meal.Date));
                int res = cmd.ExecuteNonQuery();
            }

            CloseConnection();

            return id_Reservation;
        }

    }
}

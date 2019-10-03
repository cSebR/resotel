using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Resotel.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Services
{
    public class ReservationService
    {
        #region Singleton

        private static ReservationService instance = null;
        public static ReservationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReservationService();
                }
                return instance;
            }
        }

        // EMPECHE L'INSTANCIATION DE LA CLASSE
        private ReservationService()
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

        public List<Reservation> ChargerReservations()
        {
            List<Reservation> list = new List<Reservation>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT  ";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                //TODO
            }

            CloseConnection();

            return list;
        }

        public List<Reservation> ChargerReservationsByDate(DateTime date)
        {
            List<Reservation> list = new List<Reservation>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT reservation.id, reservation.number, reservation.date, reservation.dateStart, reservation.dateEnd, customer.idCustomer, customer.lastname, customer.firstname, customer.address, customer.cityCode, customer.city, customer.email, customer.phone FROM reservation, customer WHERE reservation.id_Customer = customer.idCustomer";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Reservation reservation = new Reservation
                {
                    Id = reader.GetInt32("id"),
                    Number = reader.GetString("number"),
                    Date = reader.GetDateTime("date"),
                    DateStart = reader.GetDateTime("dateStart"),
                    DateEnd = reader.GetDateTime("dateEnd"),
                    Customer = new Customer
                    {
                        Id = reader.GetInt32("idCustomer"),
                        Lastname = reader.GetString("lastname"),
                        Firstname = reader.GetString("firstname"),
                        Address = reader.GetString("address"),
                        CityCode = reader.GetString("cityCode"),
                        City = reader.GetString("city"),
                        Email = reader.GetString("email"),
                        Phone = reader.GetString("phone")
                    }
                };
                reservation.ListBedroom = ChargerBedroomByReservation(reservation.Id);
                reservation.ListOptions = ChargerOptionsByReservation(reservation.Id);
                reservation.ListMeal = ChargerMealByReservation(reservation.Id);

                list.Add(reservation);
            }

            CloseConnection();

            return list;
        }

        private List<Bedroom> ChargerBedroomByReservation(int id)
        {
            List<Bedroom> list = new List<Bedroom>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT bedroom.id, bedroom.number, bedroom.state, typebedroom.id AS typeId, typebedroom.name, typebedroom.price FROM bedroom, typebedroom, link_reservationbedroomoptions WHERE link_reservationbedroomoptions.id_Reservation = " + id + " AND link_reservationbedroomoptions.id_Bedroom = bedroom.id AND bedroom.id_TypeBedroom = typebedroom.id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader2 = mySqlCommand.ExecuteReader();
            while (reader2.Read())
            {
                Bedroom bedroom = new Bedroom
                {
                    Id = reader2.GetInt32("id"),
                    Number = reader2.GetInt32("number"),
                    State = reader2.GetString("state"),
                    TypeBedroom = new TypeBedroom
                    {
                        Id = reader2.GetInt32("typeId"),
                        Name = reader2.GetString("name"),
                        Price = reader2.GetFloat("price")
                    }
                };

                list.Add(bedroom);
            }
            return list;
        }

        private List<Options> ChargerOptionsByReservation(int id)
        {
            List<Options> list = new List<Options>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT options.id, options.name, options.price FROM options, link_reservationbedroomoptions WHERE link_reservationbedroomoptions.id_Reservation = " + id + " AND link_reservationbedroomoptions.id_Options = options.id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Options option = new Options
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetFloat("price")
                };

                list.Add(option);
            }
            return list;
        }

        private List<Meal> ChargerMealByReservation(int id)
        {
            List<Meal> list = new List<Meal>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT meal.id, meal.name, meal.price, link_reservationmeal.date FROM meal, link_reservationmeal WHERE link_reservationmeal.id_Reservation = " + id + " AND link_reservationmeal.id_Meal = meal.id";
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
            }
            return list;
        }

        public int SaveContact(Reservation reservation)
        {
            if (OpenConnection() == false) return 0;

            string req;
            if (reservation.Id > 0)
            {
                req = "UPDATE personne SET TODO";
            }
            else
            {
                req = "INSERT INTO personne (TODO) VALUES (TODO)";
            }
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            if (reservation.Id > 0)
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", reservation.Id));
            }
            else
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", null));
            }
            //mySqlCommand.Parameters.Add(new MySqlParameter("@nom", reservation.Nom));
            
            int res = mySqlCommand.ExecuteNonQuery();

            CloseConnection();
            return reservation.Id;
        }

        public bool DelReservation(Reservation reservation)
        {
            //TODO in database
            return true;
        }

    }
}

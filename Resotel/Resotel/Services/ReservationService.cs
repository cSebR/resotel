using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Resotel.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resotel.ViewModels.VMReservation;

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

                list.Add(reservation);
            }

            CloseConnection();

            return list;
        }

        public List<Reservation> ChargerReservationsByDate(string date)
        {
            List<Reservation> list = new List<Reservation>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT reservation.id, reservation.number, reservation.date, reservation.dateStart, reservation.dateEnd, customer.idCustomer, customer.lastname, customer.firstname, customer.address, customer.cityCode, customer.city, customer.email, customer.phone FROM reservation, customer WHERE reservation.dateStart <= '" + date + "' AND reservation.dateEnd >= '" + date + "' AND reservation.id_Customer = customer.idCustomer";
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

                list.Add(reservation);
            }

            CloseConnection();

            return list;
        }

        public List<Reservation> ChargerReservationsByCustomer(int id)
        {
            List<Reservation> list = new List<Reservation>();

            if (OpenConnection() == false)
            {
                return list;
            }
            string req = "SELECT reservation.id, reservation.number, reservation.date, reservation.dateStart, reservation.dateEnd, customer.idCustomer, customer.lastname, customer.firstname, customer.address, customer.cityCode, customer.city, customer.email, customer.phone FROM reservation JOIN customer ON reservation.id_Customer = customer.idCustomer WHERE reservation.id_Customer = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@id", id));
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

                list.Add(reservation);
            }

            CloseConnection();

            return list;
        }

        public List<Bedroom> ChargerAllBedroom()
        {
            List<Bedroom> list = new List<Bedroom>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT bedroom.id, bedroom.number, bedroom.state, bedroom.date_last_clean, typebedroom.id AS typeId, typebedroom.name, typebedroom.price FROM bedroom JOIN typebedroom ON bedroom.id_TypeBedroom = typebedroom.id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader2 = mySqlCommand.ExecuteReader();
            while (reader2.Read())
            {
                Bedroom bedroom = new Bedroom
                {
                    Id = reader2.GetInt32("id"),
                    Number = reader2.GetInt32("number"),
                    State = reader2.GetString("state"),
                    DateLastClean = reader2.GetDateTime("date_last_clean"),
                    TypeBedroom = new TypeBedroom
                    {
                        Id = reader2.GetInt32("typeId"),
                        Name = reader2.GetString("name"),
                        Price = reader2.GetFloat("price")
                    }
                };

                list.Add(bedroom);
            }

            CloseConnection();

            return list;
        }

        public List<Customer> ChargerAllCustomers()
        {
            List<Customer> list = new List<Customer>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT customer.idCustomer, customer.lastname, customer.firstname, customer.address , customer.cityCode, customer.city, customer.email, customer.phone FROM customer";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader2 = mySqlCommand.ExecuteReader();
            while (reader2.Read())
            {
                Customer customer = new Customer
                {
                    Id = reader2.GetInt32("idCustomer"),
                    Lastname = reader2.GetString("lastname"),
                    Firstname = reader2.GetString("firstname"),
                    Address = reader2.GetString("address"),
                    CityCode = reader2.GetString("cityCode"),
                    City = reader2.GetString("city"),
                    Email = reader2.GetString("email"),
                    Phone = reader2.GetString("phone")
                };

                list.Add(customer);
            }

            CloseConnection();

            return list;
        }

        public List<Bedroom> ChargerAllAvailableBedroom()
        {
            List<Bedroom> list = new List<Bedroom>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT bedroom.id, bedroom.number, bedroom.state, bedroom.date_last_clean, typebedroom.id AS typeId, typebedroom.name, typebedroom.price FROM bedroom JOIN typebedroom ON bedroom.id_TypeBedroom = typebedroom.id LEFT JOIN link_reservationbedroomoptions ON bedroom.id = link_reservationbedroomoptions.id_Bedroom LEFT JOIN reservation ON link_reservationbedroomoptions.id_Reservation = reservation.id WHERE link_reservationbedroomoptions.id_Bedroom IS NULL OR NOW() NOT BETWEEN reservation.dateStart AND reservation.dateEnd ORDER BY bedroom.id ASC";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader2 = mySqlCommand.ExecuteReader();
            while (reader2.Read())
            {
                Bedroom bedroom = new Bedroom
                {
                    Id = reader2.GetInt32("id"),
                    Number = reader2.GetInt32("number"),
                    State = reader2.GetString("state"),
                    DateLastClean = reader2.GetDateTime("date_last_clean"),
                    TypeBedroom = new TypeBedroom
                    {
                        Id = reader2.GetInt32("typeId"),
                        Name = reader2.GetString("name"),
                        Price = reader2.GetFloat("price")
                    }
                };

                list.Add(bedroom);
            }

            CloseConnection();

            return list;
        }

        public List<Bedroom> ChargerAllBedroomToClean()
        {
            List<Bedroom> list = new List<Bedroom>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "UPDATE bedroom LEFT JOIN link_reservationbedroomoptions ON bedroom.id = link_reservationbedroomoptions.id_Bedroom LEFT JOIN reservation ON link_reservationbedroomoptions.id_Reservation = reservation.id SET bedroom.state = 'Non nettoyé' WHERE(TO_DAYS(now()) - TO_DAYS(bedroom.date_last_clean)) > 3 OR reservation.dateEnd = NOW(); " +

                "SELECT bedroom.id, bedroom.number, bedroom.state, bedroom.date_last_clean, typebedroom.id AS typeId, typebedroom.name, typebedroom.price FROM bedroom JOIN typebedroom ON bedroom.id_TypeBedroom = typebedroom.id WHERE bedroom.state = 'Non nettoyé' ;";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader2 = mySqlCommand.ExecuteReader();
            while (reader2.Read())
            {
                Bedroom bedroom = new Bedroom
                {
                    Id = reader2.GetInt32("id"),
                    Number = reader2.GetInt32("number"),
                    State = reader2.GetString("state"),
                    DateLastClean = reader2.GetDateTime("date_last_clean"),
                    TypeBedroom = new TypeBedroom
                    {
                        Id = reader2.GetInt32("typeId"),
                        Name = reader2.GetString("name"),
                        Price = reader2.GetFloat("price")
                    }
                };

                list.Add(bedroom);
            }

            CloseConnection();

            return list;
        }

        public List<Option> ChargerAllOptions()
        {
            List<Option> list = new List<Option>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT options.id, options.name, options.price FROM options";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Option option = new Option
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetFloat("price")
                };

                list.Add(option);
            }

            CloseConnection();

            return list;
        }

        public List<Meal> ChargerAllMeals()
        {
            List<Meal> list = new List<Meal>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT meal.id, meal.name, meal.price FROM meal";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Meal meal = new Meal
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetFloat("price")
                };

                list.Add(meal);
            }

            CloseConnection();

            return list;
        }

        public List<Invoice> ChargerAllInvoices()
        {
            List<Invoice> list = new List<Invoice>();
            return list;
        }

        public List<LineInvoice> ChargerLineInvoicesByInvoice(int id)
        {
            List<LineInvoice> list = new List<LineInvoice>();
            return list;
        }

        public List<Bedroom> ChargerBedroomByReservation(int id)
        {
            List<Bedroom> list = new List<Bedroom>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT bedroom.id, bedroom.number, bedroom.state, bedroom.date_last_clean, typebedroom.id AS typeId, typebedroom.name, typebedroom.price FROM bedroom, typebedroom, link_reservationbedroomoptions WHERE link_reservationbedroomoptions.id_Reservation = " + id + " AND link_reservationbedroomoptions.id_Bedroom = bedroom.id AND bedroom.id_TypeBedroom = typebedroom.id GROUP BY id_Bedroom";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader2 = mySqlCommand.ExecuteReader();
            while (reader2.Read())
            {
                Bedroom bedroom = new Bedroom
                {
                    Id = reader2.GetInt32("id"),
                    Number = reader2.GetInt32("number"),
                    State = reader2.GetString("state"),
                    DateLastClean = reader2.GetDateTime("date_last_clean"),
                    TypeBedroom = new TypeBedroom
                    {
                        Id = reader2.GetInt32("typeId"),
                        Name = reader2.GetString("name"),
                        Price = reader2.GetFloat("price")
                    }
                };

                list.Add(bedroom);
            }

            CloseConnection();

            return list;
        }

        public List<Option> ChargerOptionByReservation(int id)
        {
            List<Option> list = new List<Option>();

            if (OpenConnection() == false)
            {
                return list;
            }

            string req = "SELECT options.id, options.name, options.price FROM options, link_reservationbedroomoptions WHERE link_reservationbedroomoptions.id_Reservation = " + id + " AND link_reservationbedroomoptions.id_Options = options.id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Option option = new Option
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetFloat("price")
                };

                list.Add(option);
            }

            CloseConnection();

            return list;
        }

        public List<Meal> ChargerMealByReservation(int id)
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

                list.Add(meal);
            }

            CloseConnection();

            return list;
        }

        public int SaveCustomer(Customer customer)
        {
            if (OpenConnection() == false) return 0;

            string req;
            if (customer.Id > 0)
            {
                req = "UPDATE customer SET lastname = @lastname, firstname = @firstname, address = @address, cityCode = @cityCode, city = @city, email = @email, phone = @phone WHERE idCustomer = @id";
            }
            else
            {
                req = "INSERT INTO customer (idCustomer, lastname, firstname, address, cityCode, city, email, phone) VALUES (@id, @lastname, @firstname, @address, @cityCode, @city, @email, @phone)";
            }
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            if (customer.Id > 0)
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", customer.Id));
            }
            else
            {
                mySqlCommand.Parameters.Add(new MySqlParameter("@id", null));
            }
            mySqlCommand.Parameters.Add(new MySqlParameter("@lastname", customer.Lastname));
            mySqlCommand.Parameters.Add(new MySqlParameter("@firstname", customer.Firstname));
            mySqlCommand.Parameters.Add(new MySqlParameter("@address", customer.Address));
            mySqlCommand.Parameters.Add(new MySqlParameter("@cityCode", customer.CityCode));
            mySqlCommand.Parameters.Add(new MySqlParameter("@city", customer.City));
            mySqlCommand.Parameters.Add(new MySqlParameter("@email", customer.Email));
            mySqlCommand.Parameters.Add(new MySqlParameter("@phone", customer.Phone));

            int res = mySqlCommand.ExecuteNonQuery();

            CloseConnection();

            return customer.Id;
        }

        public bool DelCustomer(Customer customer)
        {
            if (OpenConnection() == false) return false;

            string req = "DELETE FROM customer WHERE idCustomer = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@id", customer.Id));
            int res = mySqlCommand.ExecuteNonQuery();

            CloseConnection();

            return true;
        }

        public int SaveReservation(Reservation reservation, Users user)
        {
            if (OpenConnection() == false) return 0;

            string req;
            if (reservation.Id > 0)
            {
                req = "UPDATE personne SET TODO = TODO";
            }
            else
            {
                req = "INSERT INTO reservation(id, number, date, dateStart, dateEnd, id_Customer) VALUES (@id, @number, @date, @dateStart, @dateEnd, @id_Customer)";
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
            mySqlCommand.Parameters.Add(new MySqlParameter("@number", reservation.Number));
            mySqlCommand.Parameters.Add(new MySqlParameter("@date", reservation.Date));
            mySqlCommand.Parameters.Add(new MySqlParameter("@dateStart", reservation.DateStart));
            mySqlCommand.Parameters.Add(new MySqlParameter("@dateEnd", reservation.DateEnd));
            mySqlCommand.Parameters.Add(new MySqlParameter("@id_Customer", reservation.Customer.Id));

            int res = mySqlCommand.ExecuteNonQuery();

            int idReservation = (int) mySqlCommand.LastInsertedId;

            foreach (MealViewModel m in reservation.ListMeal)
            {
                req = "INSERT INTO link_reservationmeal (id_Meal, id_Reservation, date) VALUES (@idMeal, @idReservation, @date)";
                MySqlCommand mySqlCommand2 = new MySqlCommand(req, mySqlConnection);
                mySqlCommand2.Parameters.Add(new MySqlParameter("@idMeal", m.Meal.Id));
                mySqlCommand2.Parameters.Add(new MySqlParameter("@idReservation", idReservation));
                mySqlCommand2.Parameters.Add(new MySqlParameter("@date", m.Meal.Date));

                mySqlCommand2.ExecuteNonQuery();
            }

            foreach (BedroomViewModel b in reservation.ListBedroom)
            {
                foreach (OptionViewModel o in reservation.ListOptions)
                {
                    req = "INSERT INTO link_reservationbedroomoptions (id_Bedroom, id_Options, id_Reservation) VALUES (@idBedroom, @idOption, @idReservation)";
                    MySqlCommand mySqlCommand3 = new MySqlCommand(req, mySqlConnection);
                    mySqlCommand3.Parameters.Add(new MySqlParameter("@idBedroom", b.Bedroom.Id));
                    mySqlCommand3.Parameters.Add(new MySqlParameter("@idOption", o.Option.Id));
                    mySqlCommand3.Parameters.Add(new MySqlParameter("@idReservation", idReservation));

                    mySqlCommand3.ExecuteNonQuery();
                }
            }

            req = "INSERT INTO link_usersreservation (id_Reservation, id_Users) VALUES (@idReservation, @idUser)";
            MySqlCommand mySqlCommand4 = new MySqlCommand(req, mySqlConnection);
            mySqlCommand4.Parameters.Add(new MySqlParameter("@idReservation", idReservation));
            mySqlCommand4.Parameters.Add(new MySqlParameter("@idUser", user.Id));

            mySqlCommand4.ExecuteNonQuery();

            CloseConnection();

            return reservation.Id;
        }

        public bool DelReservation(Reservation reservation)
        {
            if (OpenConnection() == false) return false;

            string req = "DELETE FROM link_reservationmeal WHERE id_Reservation = @id;" +
                "DELETE FROM link_reservationbedroomoptions WHERE id_Reservation = @id;" +
                "DELETE FROM reservation WHERE id = @id;";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@id", reservation.Id));
            int res = mySqlCommand.ExecuteNonQuery();

            CloseConnection();

            return true;
        }

        public int ChangeBedroomStatus(Bedroom bedroom)
        {
            if (OpenConnection() == false) return 0;

            string req = "UPDATE bedroom SET state = @state, date_last_clean = @dateLastClean WHERE id = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@state", bedroom.State));
            mySqlCommand.Parameters.Add(new MySqlParameter("@dateLastClean", bedroom.DateLastClean));
            mySqlCommand.Parameters.Add(new MySqlParameter("@id", bedroom.Id));
            int res = mySqlCommand.ExecuteNonQuery();

            CloseConnection();

            return bedroom.Id;
        }

        public Users CheckConnect(string login, string password)
        {
            Users user = null;

            if (OpenConnection() == false) return null;

            string req = "SELECT id, lastname, firstname, login, password, role FROM users WHERE login = @login AND password = @password";
            MySqlCommand mySqlCommand = new MySqlCommand(req, mySqlConnection);
            mySqlCommand.Parameters.Add(new MySqlParameter("@login", login));
            mySqlCommand.Parameters.Add(new MySqlParameter("@password", password));
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                user = new Users
                {
                    Id = reader.GetInt32("id"),
                    Lastname = reader.GetString("lastname"),
                    Firstname = reader.GetString("firstname"),
                    Login = reader.GetString("login"),
                    Password = reader.GetString("password"),
                    Role = reader.GetString("role")
                };
            }

            return user;
        }

    }
}

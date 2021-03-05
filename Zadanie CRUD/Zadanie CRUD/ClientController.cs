using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Zadanie_CRUD
{
    class ClientController
    {
        public DataReader DataReader { get; }
        public ClientRepository ClientRepository { get; }
        public CustomerPanel CustomerPanel { get; }
        private SqlConnection connection;

        public ClientController()
        {
            DataReader = new DataReader();
            ClientRepository = new ClientRepository();
            CustomerPanel = new CustomerPanel();
            connection = new SqlConnection(@"Data Source=DESKTOP-N5HH4R4\BAZYDANYCHI;Initial Catalog=ZNorthwind;Integrated Security=True");
        }

        public void Run()
        {
            connection.Open();
            int menuOption;
            do
            {
                menuOption = CustomerPanel.Menu();
                switch (menuOption)
                {
                    case 1: CreateClient(); break;
                    case 2: SelectClient(); break;
                    case 3: SelectClients(); break;
                    case 4: UpdateClient(); break;
                    case 5: DeleteClient(); break;
                    case 6: Environment.Exit(0); break;
                }

            } while (menuOption != 6);



            connection.Close();
        }

        public void CreateClient()
        {
            var data = CustomerPanel.CreateClient();
            Client client = data.Item1;
            try
            {
                switch (data.Item2)
                {
                    case 1:
                        {

                            SqlCommand command = ClientRepository.SimpleCreateClient(client);
                            command.Connection = connection;
                            command.ExecuteNonQuery();
                        }
                        break;

                    case 2:
                        {

                            SqlCommand command = ClientRepository.CreateClient(client);
                            command.Connection = connection;
                            command.ExecuteNonQuery();
                        }
                        break;
                }
                Console.WriteLine("Pomyślnie dodano użytkownika");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Podane dane istnieją juz w bazie");
            }
            finally
            {
                Console.ReadKey();
            }


        }

        public void SelectClient()
        {
            string clientIdOrCompanyName = CustomerPanel.SelectClient();
            SqlCommand command = ClientRepository.SelectClient(clientIdOrCompanyName);
            command.Connection = connection;
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                Client client = new Client();

                try
                {
                    client.ClientId = reader["IDklienta"].ToString();
                    client.CompanyName = reader["NazwaFirmy"].ToString();
                    client.Agent = reader["Przedstawiciel"].ToString();
                    client.AgentWorkplace = reader["StanowiskoPrzedstawiciela"].ToString();
                    client.Adress = reader["Adres"].ToString();
                    client.City = reader["Miasto"].ToString();
                    client.Region = reader["Region"].ToString();
                    client.PostCode = reader["KodPocztowy"].ToString();
                    client.Country = reader["Kraj"].ToString();
                    client.PhoneNumber = reader["Telefon"].ToString();
                    client.Fax = reader["Faks"].ToString();

                    Console.WriteLine(client.ToString());
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("Nie znaleziono klienta o podanym id badź nazwie firmy");
                }
                finally
                {
                    Console.ReadKey();
                }
            }

        }

        public void SelectClients()
        {
            SqlCommand command = ClientRepository.SelectClients();
            command.Connection = connection;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " | " + reader[1] + " | " + reader[2] + " | " + reader[3] + " | " + reader[4] + " | " + reader[5] + " | " + reader[6] + " | " + reader[7] + " | " + reader[8] + " | " + reader[9] + " | " + reader[10]);
                }
            }

            Console.ReadKey();
        }

        public void DeleteClient()
        {
            string clientIdOrCompanyName = CustomerPanel.DeleteClient();
            SqlCommand command = ClientRepository.DeleteClient(clientIdOrCompanyName);
            command.Connection = connection;
            command.ExecuteNonQuery();
            Console.WriteLine("Pomyślnie usunięto wskazana dane");
            Console.ReadKey();
        }


        public void UpdateClient()
        {
            Dictionary<string, string> parameters = CustomerPanel.UpdateClient();
            Console.WriteLine(parameters["columnName"] + parameters["newValue"] + parameters["clientId"]);
            SqlCommand command = ClientRepository.UpdateClient(parameters["columnName"], parameters["newValue"], parameters["clientId"]);
            command.Connection = connection;
            command.ExecuteNonQuery();
            Console.WriteLine("Pomyślnie zmodyfikowano dane");
            Console.ReadKey();
        }

    }


}

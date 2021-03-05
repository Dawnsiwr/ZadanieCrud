using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Zadanie_CRUD
{
    class ClientRepository
    {

        public SqlCommand SelectClient(string clientIdOrCompanyName)
        {
            var selectSql = $"SELECT * FROM Klienci WHERE IDklienta = @ClientIdOrCompanyName OR NazwaFirmy = @ClientIdOrCompanyName";
            var command = new SqlCommand();
            command.CommandText = selectSql;
            command.Parameters.AddWithValue("@ClientIdOrCompanyName", clientIdOrCompanyName);

            return command;

        }

        public SqlCommand SelectClients()
        {
            var selectSql = $"SELECT * FROM Klienci ";
            var command = new SqlCommand();
            command.CommandText = selectSql;
            return command;

        }



        public SqlCommand UpdateClient(Client client, string clientId)
        {
            var updateSql = $"UPDATE Klienci SET IDklienta = @NewClientId, NazwaFirmy = @CompanyName, Przedstawiciel = @Agent, StanowiskoPrzedstawiciela = @AgentWorkplace " +
                            $"Adres = @Adress, Miasto = @City, Region = @Region, KodPocztowy = @PostCode, Kraj = @Country, Telefon = @PhoneNumber, Faks = @Fax " +
                            $"WHERE IDklienta = @ClientId";
            var command = new SqlCommand();
            command.CommandText = updateSql;
            command.Parameters.AddWithValue("@NewClientId", client.ClientId);
            command.Parameters.AddWithValue("@CompanyName", client.CompanyName);
            command.Parameters.AddWithValue("@Agent", client.Agent);
            command.Parameters.AddWithValue("@AgentWorkplace", client.AgentWorkplace);
            command.Parameters.AddWithValue("@Adress", client.Adress);
            command.Parameters.AddWithValue("@City", client.City);
            command.Parameters.AddWithValue("@Region", client.Region);
            command.Parameters.AddWithValue("@PostCode", client.PostCode);
            command.Parameters.AddWithValue("@Country", client.Country);
            command.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
            command.Parameters.AddWithValue("@Fax", client.Fax);
            command.Parameters.AddWithValue("@ClientId", clientId);

            return command;


        }

        public SqlCommand UpdateClient(string column, string value, string clientId)
        {

            var updateSql = $"UPDATE Klienci SET @Column=@Value WHERE IDklienta = @ClientId ";
            var command = new SqlCommand();
            command.CommandText = updateSql;
            command.Parameters.AddWithValue("@Column", column);
            command.Parameters.AddWithValue("@Value", value);
            command.Parameters.AddWithValue("@ClientId", clientId);


            return command;
        }

        public SqlCommand DeleteClient(string clientIdOrCompanyName)
        {
            var deleteSql = $"DELETE FROM Klienci WHERE IDklienta = @ClientIdOrCompanyName or NazwaFirmy = @ClientIdOrCompanyName";
            var command = new SqlCommand();
            command.CommandText = deleteSql;
            command.Parameters.AddWithValue("@ClientIdOrCompanyName", clientIdOrCompanyName);

            return command;
        }

        public SqlCommand SimpleCreateClient(Client client)
        {
            var createSql = $"INSERT INTO Klienci (Idklienta, NazwaFirmy) VALUES (@ClientId, @CompanyName)";
            var command = new SqlCommand();
            command.CommandText = createSql;
            command.Parameters.AddWithValue("@ClientId", client.ClientId);
            command.Parameters.AddWithValue("@CompanyName", client.CompanyName);

            return command;
        }

        public SqlCommand CreateClient(Client client)
        {
            var createSql = $"INSERT INTO Klienci (IDklienta, NazwaFirmy, Przedstawiciel, StanowiskoPrzedstawiciela, Adres, Miasto, Region, KodPocztowy, Kraj, Telefon, Faks) " +
                $"VALUES (@ClientId, @CompanyName, @Agent, @AgentWorkplace, @Adress, @City, @Region, @PostCode, @Country, @PhoneNumber, @Fax)";
            var command = new SqlCommand();
            command.CommandText = createSql;
            command.Parameters.AddWithValue("@ClientId", client.ClientId);
            command.Parameters.AddWithValue("@CompanyName", client.CompanyName);
            command.Parameters.AddWithValue("@Agent", client.Agent);
            command.Parameters.AddWithValue("@AgentWorkplace", client.AgentWorkplace);
            command.Parameters.AddWithValue("@Adress", client.Adress);
            command.Parameters.AddWithValue("@City", client.City);
            command.Parameters.AddWithValue("@Region", client.Region);
            command.Parameters.AddWithValue("@PostCode", client.PostCode);
            command.Parameters.AddWithValue("@Country", client.Country);
            command.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
            command.Parameters.AddWithValue("@Fax", client.Fax);

            return command;
        }
    }
}

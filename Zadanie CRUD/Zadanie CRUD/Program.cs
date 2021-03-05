using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Zadanie_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientController controller = new ClientController();
            controller.Run();
        }
    }
}

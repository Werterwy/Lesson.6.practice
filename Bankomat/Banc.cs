using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Bank
    {
        private Client[] clients;

        public Bank()
        {
            clients = new Client[10]; // Максимальное количество клиентов
        }

        public Client OpenAccount(string password)
        {
            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i] == null)
                {
                    var client = new Client(i, password);
                    clients[i] = client;
                    return client;
                }
            }
            return null; // Банк переполнен
        }

        public Client Authenticate(int clientId, string password)
        {
            if (clientId >= 0 && clientId < clients.Length && clients[clientId] != null && clients[clientId].Password == password)
            {
                return clients[clientId];
            }
            return null; // Неверный идентификатор клиента или пароль
        }
    }
}

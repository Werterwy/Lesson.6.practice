using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Client
    {
        public int ClientId { get; }
        public string Password { get; }
        public Account Account { get; }

        public Client(int clientId, string password)
        {
            ClientId = clientId;
            Password = password;
            Account = new Account(clientId);
        }
    }
}

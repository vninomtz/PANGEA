using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA
{
    class SingletonAccount
    {
        private static Cuentas account;

        private SingletonAccount() { }


        public static void SetAccount(Cuentas cuenta)
        {
            account = cuenta;
        }

        public static Cuentas GetAccount()
        {
            return account;
        }

    }
}

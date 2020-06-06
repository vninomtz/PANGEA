using DataAccess;

namespace Cliente_PANGEA
{
    class SingletonPersonal
    {
        private static Personal personalAccount;

        private SingletonPersonal() { }

        
        public static void SetPersonal(Personal personal)
        {
            personalAccount = personal;
        }

        public static Personal GetPersonal()
        {
            return personalAccount;
        }
    }
}

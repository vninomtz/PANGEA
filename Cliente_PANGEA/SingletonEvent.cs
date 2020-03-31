using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA
{
    class SingletonEvent
    {
        private static Eventos SingleEvento;

        private SingletonEvent() { }

        public static void SetSingletonEvent(Eventos evento)
        {
            SingleEvento = evento;
        }

        public static Eventos GetEvent()
        {
            return SingleEvento;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TestWork
{
    public static class ResponseService
    {
        public static void SendGoodResponse()
        {
            Console.WriteLine("ACK");
            Console.WriteLine();
        }

        public static void SendBadResponse()
        {
            Console.WriteLine("NACK");
            Console.WriteLine();
        }
    }
}

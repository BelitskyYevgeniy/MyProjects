using System;
using ChatConsoleClient.ServiceChatConsole;
using System.Threading;
namespace ChatConsoleClient
{
    class Program : IServiceChatCallback
    {
        static object locker = new object();
        static ServiceChatClient client;
        static int id;
        static void Main(string[] args)
        {
            if (args.Length != 1)
                return;
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(new Program()));
            id = client.Connect(args[0]);


            
            while(true)
            {
                PrintMenu();
                Console.WriteLine("Input option");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch(key)
                {
                    case 'w':
                        {
                            int receiverId;
                            string mes;
                            lock (locker)
                            {
                                Console.WriteLine("Write receiver Id");
                                if (!Int32.TryParse(Console.ReadLine(), out receiverId))
                                {
                                    Console.WriteLine("Wrong input!");
                                    continue;
                                }
                                Console.WriteLine("Write message");
                                mes = Console.ReadLine();
                            }
                            client.SendMsg(mes, receiverId, id);
                        };break;
                    case 'u':
                        {
                            Console.WriteLine("Users ID: ");
                            var usersId = client.GetServerUsers();
                            for(int i=0;i<usersId.Length;i++)
                            {
                                Console.Write(usersId[i] + " ");
                            }
                            Console.WriteLine();
                        };break;
                    case 'i':
                        {
                            Console.WriteLine("Your data:\n" +
                                               $"\tID - {id}\n" +
                                               $"\tNickName - {args[0]}"
                                );
                        };break;
                    case 'e':
                        {
                            client.Disconnect(id);
                            Console.WriteLine("Disconnect...");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong command!");
                            continue;
                        }
                }

            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("Menu:\n" +
                                "\tw - write message\n" +
                                "\tu - see users ID\n" +
                                "\ti - see your information\n" +
                                "\te - exit program\n");
        }
        

        public void SendMsgCallback(string msg)
        {
            lock (locker)
            {
                Console.WriteLine(msg);
            }

        }



    }
}

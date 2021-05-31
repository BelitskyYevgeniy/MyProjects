using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ServiceModel;
using System.Text;


namespace wcf_chat
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        private readonly List<ServerUser> Users = new List<ServerUser>();
        int nextId = 1;

        public int Connect(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return 0;
            }
            ServerUser user = new ServerUser() {
                ID = nextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextId++;
            Users.Add(user);
            Thread threadCheck = new Thread(new ParameterizedThreadStart(CheckBeingServerUser));
            threadCheck.Start(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = FindUserById(id);
            if (user != null)
            {
                Users.Remove(user);
            }
        }

        public void SendMsg(string msg, int receiverId, int senderId)
        {
            var receiver = FindUserById(receiverId);
            var sender = FindUserById(senderId);
            if (receiver == null || sender == null || msg == null)
            {
                return;
            }

            receiver.operationContext.GetCallbackChannel<IServerChatCallback>()
                .SendMsgCallback(ToMessageFormat(sender, msg));
        }

        public int[] GetServerUsers()
        {
            int[] users = new int[Users.Count];
            for (int i = 0; i < Users.Count; i++)
            {
                users[i] = Users[i].ID;
            }
            return users;
        }

        private void CheckBeingServerUser(object user)
        {
            ServerUser u = (ServerUser)user;
            while (true)
            {
                Thread.Sleep(5 * 60 * 1000);
                if (u.operationContext.Channel.State >= CommunicationState.Closing)
                {
                    Users.Remove(u);
                    return;
                }
            }


        }

       private ServerUser FindUserById(int id)
       {
            return Users.FirstOrDefault<ServerUser>(u => u.ID == id);
       }
        private string ToMessageFormat(ServerUser sender, string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[').Append(DateTime.Now).Append(']').Append('\n');
            sb.Append(sender.Name).Append(": ").Append(msg);
            return sb.ToString();
        }
        
    }
}

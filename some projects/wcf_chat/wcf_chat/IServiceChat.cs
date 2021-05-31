using System.ServiceModel;
using System.Collections.Generic;
namespace wcf_chat
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int receiverId, int senderId);

        [OperationContract]
        int[] GetServerUsers();

    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendMsgCallback(string msg);


    }
}

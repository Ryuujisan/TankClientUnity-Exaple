using System;
using Protocol;
using ProtoBuf.Meta;

namespace ProtocolSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = TypeModel.Create();

            model.Add(typeof(Packet), true);

            model.Add(typeof(Ping), true);

            model.Add(typeof(Lobby), true);
            model.Add(typeof(JoinGame), true);
            model.Add(typeof(LeaveGame), true);

            model.Add(typeof(Room), true);
            model.Add(typeof(PlayerJoined), true);
            model.Add(typeof(PlayerLeaved), true);
            model.Add(typeof(Chat), true);

            model.Add(typeof(GameStart), true);
            model.Add(typeof(GameCurrentStatus), true);
            model.Add(typeof(GameEnd), true);
            model.Add(typeof(Update), true);

            model.AllowParseableTypes = true;
            model.AutoAddMissingTypes = true;

            model.Compile("ProtocolSerializer", "ProtocolSerializer.dll");
        }
    }
}

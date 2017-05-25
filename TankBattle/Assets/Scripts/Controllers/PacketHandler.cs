using UnityEngine;
using System.IO;

public class PacketHandler : MonoBehaviour
{
    private ProtocolSerializer protocolSerializer = new ProtocolSerializer();

    void Awake()
    {
        if (GameManager.PacketHandler == null)
        {
            GameManager.PacketHandler = this;
        }
    }

    public void HandleServerPacket(byte[] bytes)
    {
        MemoryStream stream = GetPacketStream(bytes);
        Protocol.Packet packet = (Protocol.Packet)protocolSerializer.Deserialize(stream, null, typeof(Protocol.Packet));

        if (packet.ping != null)
        {
            Protocol.Ping ping = packet.ping;

#if DEBUG_LOG
            Debug.Log(string.Format("[Ping] Data: {0}", ping.data));
#endif
        }
        else if (packet.lobby != null)
        {
            Protocol.Lobby lobby = packet.lobby;

#if DEBUG_LOG
            Debug.Log("[Lobby]");
#endif
        }
        else if (packet.room != null)
        {
            Protocol.Room room = packet.room;

#if DEBUG_LOG
            Debug.Log(string.Format("[Room] Local Id: {0} | Players: {1}", room.localId, room.players.Count));
            for (int i = 0; i < room.players.Count; ++i)
            {
                Debug.Log(string.Format("[Player {0}] Player Id: {1} | Player Name: {2}", i, room.players[i].id, room.players[i].name));
            }
#endif
        }
        else if (packet.playerJoined != null)
        {
            Protocol.PlayerJoined playerJoined = packet.playerJoined;

#if DEBUG_LOG
            Debug.Log(string.Format("[Player Joined] Player Id: {0} | Player Name: {1}", playerJoined.id, playerJoined.name));
#endif
        }
        else if (packet.playerLeaved != null)
        {
            Protocol.PlayerLeaved playerLeaved = packet.playerLeaved;

#if DEBUG_LOG
            Debug.Log(string.Format("[Player Left] Player Id: {0} | Player Name: {1}", playerLeaved.id, playerLeaved.reason));
#endif
        }
        else if (packet.chat != null)
        {
            Protocol.Chat chat = packet.chat;

#if DEBUG_LOG
            Debug.Log(string.Format("[Chat] Player Id: {0} | Message: {1}", chat.playerId, chat.text));
#endif
        }
        else if (packet.gameStart != null)
        {
            Protocol.GameStart gameStart = packet.gameStart;

#if DEBUG_LOG
            Debug.Log("[Game Start]");
#endif
        }
        else if (packet.gameCurrentStatus != null)
        {
            Protocol.GameCurrentStatus gameCurrentStatus = packet.gameCurrentStatus;

#if DEBUG_LOG
            Debug.Log("[Game Current Status]");
#endif
        }
        else if (packet.gameEnd != null)
        {
            Protocol.GameEnd gameEnd = packet.gameEnd;

#if DEBUG_LOG
            Debug.Log("[Game End]");
#endif
        }
        else if (packet.update != null)
        {
            Protocol.Update update = packet.update;
#if DEBUG_LOG
            Debug.Log(string.Format("[Update] Events: {0}", update.events.Count));
            for (int i = 0; i < update.events.Count; ++i)
            {
                Debug.Log(string.Format("[Event {0}]", i));
            }
#endif
        }
    }

    // Server Packets

    public byte[] CreateChatPacket(int playerId, string message)
    {
        Protocol.Chat chat = new Protocol.Chat();
        chat.playerId = playerId;
        chat.text = message;

        Protocol.Packet packet = new Protocol.Packet();
        packet.chat = chat;

        return GetPacketBytes(packet);
    }

    public byte[] CreatePingPacket(int data)
    {
        Protocol.Ping ping = new Protocol.Ping();
        ping.data = data;

        Protocol.Packet packet = new Protocol.Packet();
        packet.ping = ping;

        return GetPacketBytes(packet);
    }

    public byte[] CreateJoinGamePacket(string playerName)
    {
        Protocol.JoinGame joinGame = new Protocol.JoinGame();
        joinGame.name = playerName;

        Protocol.Packet packet = new Protocol.Packet();
        packet.joinGame = joinGame;

        return GetPacketBytes(packet);
    }

    public byte[] CreateLeaveGamePacket()
    {
        Protocol.LeaveGame leaveGame = new Protocol.LeaveGame();

        Protocol.Packet packet = new Protocol.Packet();
        packet.leaveGame = leaveGame;

        return GetPacketBytes(packet);
    }

    // Utils

    private MemoryStream GetPacketStream(byte[] bytes)
    {
        MemoryStream stream = new MemoryStream(bytes);
        return stream;
    }

    private byte[] GetPacketBytes(object packetObject)
    {
        MemoryStream stream = new MemoryStream();
        protocolSerializer.Serialize(stream, packetObject);
        return stream.ToArray();
    }
}

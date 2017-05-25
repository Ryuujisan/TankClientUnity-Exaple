﻿using System;
using ProtoBuf;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: protocol.proto
namespace Protocol
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Packet")]
    public partial class Packet : global::ProtoBuf.IExtensible
    {
        public Packet() { }

        private Protocol.Ping _ping = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"ping", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.Ping ping
        {
            get { return _ping; }
            set { _ping = value; }
        }
        private Protocol.Lobby _lobby = null;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"lobby", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.Lobby lobby
        {
            get { return _lobby; }
            set { _lobby = value; }
        }
        private Protocol.JoinGame _joinGame = null;
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"joinGame", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.JoinGame joinGame
        {
            get { return _joinGame; }
            set { _joinGame = value; }
        }
        private Protocol.LeaveGame _leaveGame = null;
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"leaveGame", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.LeaveGame leaveGame
        {
            get { return _leaveGame; }
            set { _leaveGame = value; }
        }
        private Protocol.Room _room = null;
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"room", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.Room room
        {
            get { return _room; }
            set { _room = value; }
        }
        private Protocol.PlayerJoined _playerJoined = null;
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"playerJoined", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.PlayerJoined playerJoined
        {
            get { return _playerJoined; }
            set { _playerJoined = value; }
        }
        private Protocol.PlayerLeaved _playerLeaved = null;
        [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"playerLeaved", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.PlayerLeaved playerLeaved
        {
            get { return _playerLeaved; }
            set { _playerLeaved = value; }
        }
        private Protocol.Chat _chat = null;
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"chat", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.Chat chat
        {
            get { return _chat; }
            set { _chat = value; }
        }
        private Protocol.GameStart _gameStart = null;
        [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name = @"gameStart", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.GameStart gameStart
        {
            get { return _gameStart; }
            set { _gameStart = value; }
        }
        private Protocol.GameCurrentStatus _gameCurrentStatus = null;
        [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name = @"gameCurrentStatus", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.GameCurrentStatus gameCurrentStatus
        {
            get { return _gameCurrentStatus; }
            set { _gameCurrentStatus = value; }
        }
        private Protocol.GameEnd _gameEnd = null;
        [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name = @"gameEnd", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.GameEnd gameEnd
        {
            get { return _gameEnd; }
            set { _gameEnd = value; }
        }
        private Protocol.Update _update = null;
        [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name = @"update", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Protocol.Update update
        {
            get { return _update; }
            set { _update = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Ping")]
    public partial class Ping : global::ProtoBuf.IExtensible
    {
        public Ping() { }

        private int _data;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"data", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int data
        {
            get { return _data; }
            set { _data = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Lobby")]
    public partial class Lobby : global::ProtoBuf.IExtensible
    {
        public Lobby() { }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"JoinGame")]
    public partial class JoinGame : global::ProtoBuf.IExtensible
    {
        public JoinGame() { }

        private string _name;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"LeaveGame")]
    public partial class LeaveGame : global::ProtoBuf.IExtensible
    {
        public LeaveGame() { }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Room")]
    public partial class Room : global::ProtoBuf.IExtensible
    {
        public Room() { }

        private readonly global::System.Collections.Generic.List<Protocol.PlayerJoined> _players = new global::System.Collections.Generic.List<Protocol.PlayerJoined>();
        [global::ProtoBuf.ProtoMember(1, Name = @"players", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<Protocol.PlayerJoined> players
        {
            get { return _players; }
        }

        private int _localId;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"localId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int localId
        {
            get { return _localId; }
            set { _localId = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"PlayerJoined")]
    public partial class PlayerJoined : global::ProtoBuf.IExtensible
    {
        public PlayerJoined() { }

        private int _id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"PlayerLeaved")]
    public partial class PlayerLeaved : global::ProtoBuf.IExtensible
    {
        public PlayerLeaved() { }

        private int _id;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _reason;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"reason", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Chat")]
    public partial class Chat : global::ProtoBuf.IExtensible
    {
        public Chat() { }

        private int _playerId = default(int);
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"playerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(default(int))]
        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }
        private string _text;
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"text", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"GameStart")]
    public partial class GameStart : global::ProtoBuf.IExtensible
    {
        public GameStart() { }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"GameCurrentStatus")]
    public partial class GameCurrentStatus : global::ProtoBuf.IExtensible
    {
        public GameCurrentStatus() { }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"GameEnd")]
    public partial class GameEnd : global::ProtoBuf.IExtensible
    {
        public GameEnd() { }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Update")]
    public partial class Update : global::ProtoBuf.IExtensible
    {
        public Update() { }

        private readonly global::System.Collections.Generic.List<Protocol.Update.Event> _events = new global::System.Collections.Generic.List<Protocol.Update.Event>();
        [global::ProtoBuf.ProtoMember(1, Name = @"events", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<Protocol.Update.Event> events
        {
            get { return _events; }
        }

        [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Event")]
        public partial class Event : global::ProtoBuf.IExtensible
        {
            public Event() { }

            private global::ProtoBuf.IExtension extensionObject;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

}
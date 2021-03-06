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
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Packet")]
  public partial class Packet : global::ProtoBuf.IExtensible
  {
    public Packet() {}
    
    private Protocol.Ping _ping = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ping", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Ping ping
    {
      get { return _ping; }
      set { _ping = value; }
    }
    private Protocol.Lobby _lobby = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"lobby", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Lobby lobby
    {
      get { return _lobby; }
      set { _lobby = value; }
    }
    private Protocol.JoinGame _joinGame = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"joinGame", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.JoinGame joinGame
    {
      get { return _joinGame; }
      set { _joinGame = value; }
    }
    private Protocol.LeaveGame _leaveGame = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"leaveGame", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.LeaveGame leaveGame
    {
      get { return _leaveGame; }
      set { _leaveGame = value; }
    }
    private Protocol.Room _room = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"room", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Room room
    {
      get { return _room; }
      set { _room = value; }
    }
    private Protocol.PlayerJoined _playerJoined = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"playerJoined", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.PlayerJoined playerJoined
    {
      get { return _playerJoined; }
      set { _playerJoined = value; }
    }
    private Protocol.PlayerLeaved _playerLeaved = null;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"playerLeaved", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.PlayerLeaved playerLeaved
    {
      get { return _playerLeaved; }
      set { _playerLeaved = value; }
    }
    private Protocol.Chat _chat = null;
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"chat", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Chat chat
    {
      get { return _chat; }
      set { _chat = value; }
    }
    private Protocol.GameStart _gameStart = null;
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"gameStart", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.GameStart gameStart
    {
      get { return _gameStart; }
      set { _gameStart = value; }
    }
    private Protocol.GameCurrentStatus _gameCurrentStatus = null;
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"gameCurrentStatus", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.GameCurrentStatus gameCurrentStatus
    {
      get { return _gameCurrentStatus; }
      set { _gameCurrentStatus = value; }
    }
    private Protocol.GameEnd _gameEnd = null;
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"gameEnd", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.GameEnd gameEnd
    {
      get { return _gameEnd; }
      set { _gameEnd = value; }
    }
    private Protocol.Update _update = null;
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"update", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Update update
    {
      get { return _update; }
      set { _update = value; }
    }
    private Protocol.PlayerStering _playerStering = null;
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"playerStering", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.PlayerStering playerStering
    {
      get { return _playerStering; }
      set { _playerStering = value; }
    }
    private Protocol.Respawn _respawn = null;
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"respawn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Respawn respawn
    {
      get { return _respawn; }
      set { _respawn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Ping")]
  public partial class Ping : global::ProtoBuf.IExtensible
  {
    public Ping() {}
    
    private int _data;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int data
    {
      get { return _data; }
      set { _data = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Lobby")]
  public partial class Lobby : global::ProtoBuf.IExtensible
  {
    public Lobby() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"JoinGame")]
  public partial class JoinGame : global::ProtoBuf.IExtensible
  {
    public JoinGame() {}
    
    private string _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LeaveGame")]
  public partial class LeaveGame : global::ProtoBuf.IExtensible
  {
    public LeaveGame() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Room")]
  public partial class Room : global::ProtoBuf.IExtensible
  {
    public Room() {}
    
    private readonly global::System.Collections.Generic.List<Protocol.PlayerJoined> _players = new global::System.Collections.Generic.List<Protocol.PlayerJoined>();
    [global::ProtoBuf.ProtoMember(1, Name=@"players", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Protocol.PlayerJoined> players
    {
      get { return _players; }
    }
  
    private int _localId;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"localId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int localId
    {
      get { return _localId; }
      set { _localId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PlayerJoined")]
  public partial class PlayerJoined : global::ProtoBuf.IExtensible
  {
    public PlayerJoined() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PlayerLeaved")]
  public partial class PlayerLeaved : global::ProtoBuf.IExtensible
  {
    public PlayerLeaved() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _reason;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"reason", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string reason
    {
      get { return _reason; }
      set { _reason = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Chat")]
  public partial class Chat : global::ProtoBuf.IExtensible
  {
    public Chat() {}
    
    private int _playerId = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"playerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int playerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }
    private string _text;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"text", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string text
    {
      get { return _text; }
      set { _text = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PlayerStering")]
  public partial class PlayerStering : global::ProtoBuf.IExtensible
  {
    public PlayerStering() {}
    
    private float _dirX = default(float);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"dirX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float dirX
    {
      get { return _dirX; }
      set { _dirX = value; }
    }
    private float _dirY = default(float);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"dirY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float dirY
    {
      get { return _dirY; }
      set { _dirY = value; }
    }
    private float _barrelDirX = default(float);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"barrelDirX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float barrelDirX
    {
      get { return _barrelDirX; }
      set { _barrelDirX = value; }
    }
    private float _barrelDirY = default(float);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"barrelDirY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float barrelDirY
    {
      get { return _barrelDirY; }
      set { _barrelDirY = value; }
    }
    private bool _accelerates = default(bool);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"accelerates", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool accelerates
    {
      get { return _accelerates; }
      set { _accelerates = value; }
    }
    private bool _shot = default(bool);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"shot", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool shot
    {
      get { return _shot; }
      set { _shot = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Respawn")]
  public partial class Respawn : global::ProtoBuf.IExtensible
  {
    public Respawn() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GameStart")]
  public partial class GameStart : global::ProtoBuf.IExtensible
  {
    public GameStart() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GameCurrentStatus")]
  public partial class GameCurrentStatus : global::ProtoBuf.IExtensible
  {
    public GameCurrentStatus() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GameEnd")]
  public partial class GameEnd : global::ProtoBuf.IExtensible
  {
    public GameEnd() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Player")]
  public partial class Player : global::ProtoBuf.IExtensible
  {
    public Player() {}
    
    private int _id = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private float _positionX = default(float);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"positionX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float positionX
    {
      get { return _positionX; }
      set { _positionX = value; }
    }
    private float _postionY = default(float);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"postionY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float postionY
    {
      get { return _postionY; }
      set { _postionY = value; }
    }
    private float _tankCourse = default(float);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"tankCourse", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float tankCourse
    {
      get { return _tankCourse; }
      set { _tankCourse = value; }
    }
    private float _barrelCourse = default(float);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"barrelCourse", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float barrelCourse
    {
      get { return _barrelCourse; }
      set { _barrelCourse = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Dead")]
  public partial class Dead : global::ProtoBuf.IExtensible
  {
    public Dead() {}
    
    private int _id = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private float _positionX = default(float);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"positionX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float positionX
    {
      get { return _positionX; }
      set { _positionX = value; }
    }
    private float _positionY = default(float);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"positionY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float positionY
    {
      get { return _positionY; }
      set { _positionY = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Hit")]
  public partial class Hit : global::ProtoBuf.IExtensible
  {
    public Hit() {}
    
    private float _positionX = default(float);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"positionX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float positionX
    {
      get { return _positionX; }
      set { _positionX = value; }
    }
    private float _positionY = default(float);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"positionY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float positionY
    {
      get { return _positionY; }
      set { _positionY = value; }
    }
    private Protocol.Hit.Target _target = Protocol.Hit.Target.NONE;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"target", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Protocol.Hit.Target.NONE)]
    public Protocol.Hit.Target target
    {
      get { return _target; }
      set { _target = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"Target")]
    public enum Target
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"NONE", Value=0)]
      NONE = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GROUND", Value=1)]
      GROUND = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TANK", Value=2)]
      TANK = 2
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UpdateGamePlay")]
  public partial class UpdateGamePlay : global::ProtoBuf.IExtensible
  {
    public UpdateGamePlay() {}
    
    private readonly global::System.Collections.Generic.List<Protocol.Player> _player = new global::System.Collections.Generic.List<Protocol.Player>();
    [global::ProtoBuf.ProtoMember(1, Name=@"player", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Protocol.Player> player
    {
      get { return _player; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Update")]
  public partial class Update : global::ProtoBuf.IExtensible
  {
    public Update() {}
    
    private readonly global::System.Collections.Generic.List<Protocol.Update.Event> _events = new global::System.Collections.Generic.List<Protocol.Update.Event>();
    [global::ProtoBuf.ProtoMember(1, Name=@"events", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Protocol.Update.Event> events
    {
      get { return _events; }
    }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Event")]
  public partial class Event : global::ProtoBuf.IExtensible
  {
    public Event() {}
    
    private Protocol.UpdateGamePlay _updateGamePlay = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"updateGamePlay", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.UpdateGamePlay updateGamePlay
    {
      get { return _updateGamePlay; }
      set { _updateGamePlay = value; }
    }
    private Protocol.Dead _dead = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"dead", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Dead dead
    {
      get { return _dead; }
      set { _dead = value; }
    }
    private Protocol.Hit _hit = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"hit", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Protocol.Hit hit
    {
      get { return _hit; }
      set { _hit = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
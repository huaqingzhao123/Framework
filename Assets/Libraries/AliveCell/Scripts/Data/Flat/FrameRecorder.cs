// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace AliveCell.Flat
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct PlayerData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static PlayerData GetRootAsPlayerData(ByteBuffer _bb) { return GetRootAsPlayerData(_bb, new PlayerData()); }
  public static PlayerData GetRootAsPlayerData(ByteBuffer _bb, PlayerData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public PlayerData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int PlayerType { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string PlayerID { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPlayerIDBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetPlayerIDBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetPlayerIDArray() { return __p.__vector_as_array<byte>(6); }
  public int Id { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int BirthIndex { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int GroupId { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<AliveCell.Flat.PlayerData> CreatePlayerData(FlatBufferBuilder builder,
      int playerType = 0,
      StringOffset playerIDOffset = default(StringOffset),
      int id = 0,
      int birthIndex = 0,
      int groupId = 0) {
    builder.StartTable(5);
    PlayerData.AddGroupId(builder, groupId);
    PlayerData.AddBirthIndex(builder, birthIndex);
    PlayerData.AddId(builder, id);
    PlayerData.AddPlayerID(builder, playerIDOffset);
    PlayerData.AddPlayerType(builder, playerType);
    return PlayerData.EndPlayerData(builder);
  }

  public static void StartPlayerData(FlatBufferBuilder builder) { builder.StartTable(5); }
  public static void AddPlayerType(FlatBufferBuilder builder, int playerType) { builder.AddInt(0, playerType, 0); }
  public static void AddPlayerID(FlatBufferBuilder builder, StringOffset playerIDOffset) { builder.AddOffset(1, playerIDOffset.Value, 0); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(2, id, 0); }
  public static void AddBirthIndex(FlatBufferBuilder builder, int birthIndex) { builder.AddInt(3, birthIndex, 0); }
  public static void AddGroupId(FlatBufferBuilder builder, int groupId) { builder.AddInt(4, groupId, 0); }
  public static Offset<AliveCell.Flat.PlayerData> EndPlayerData(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<AliveCell.Flat.PlayerData>(o);
  }
  public PlayerDataT UnPack() {
    var _o = new PlayerDataT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(PlayerDataT _o) {
    _o.PlayerType = this.PlayerType;
    _o.PlayerID = this.PlayerID;
    _o.Id = this.Id;
    _o.BirthIndex = this.BirthIndex;
    _o.GroupId = this.GroupId;
  }
  public static Offset<AliveCell.Flat.PlayerData> Pack(FlatBufferBuilder builder, PlayerDataT _o) {
    if (_o == null) return default(Offset<AliveCell.Flat.PlayerData>);
    var _playerID = _o.PlayerID == null ? default(StringOffset) : builder.CreateString(_o.PlayerID);
    return CreatePlayerData(
      builder,
      _o.PlayerType,
      _playerID,
      _o.Id,
      _o.BirthIndex,
      _o.GroupId);
  }
};

public class PlayerDataT
{
  [Newtonsoft.Json.JsonProperty("playerType")]
  public int PlayerType { get; set; }
  [Newtonsoft.Json.JsonProperty("playerID")]
  public string PlayerID { get; set; }
  [Newtonsoft.Json.JsonProperty("id")]
  public int Id { get; set; }
  [Newtonsoft.Json.JsonProperty("birthIndex")]
  public int BirthIndex { get; set; }
  [Newtonsoft.Json.JsonProperty("groupId")]
  public int GroupId { get; set; }

  public PlayerDataT() {
    this.PlayerType = 0;
    this.PlayerID = null;
    this.Id = 0;
    this.BirthIndex = 0;
    this.GroupId = 0;
  }
}

public struct InputData : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p = new Struct(_i, _bb); }
  public InputData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { return __p.bb.GetInt(__p.bb_pos + 0); } }
  public int KeyCode { get { return __p.bb.GetInt(__p.bb_pos + 4); } }
  public byte AxisValue { get { return __p.bb.Get(__p.bb_pos + 8); } }

  public static Offset<AliveCell.Flat.InputData> CreateInputData(FlatBufferBuilder builder, int Id, int KeyCode, byte AxisValue) {
    builder.Prep(4, 12);
    builder.Pad(3);
    builder.PutByte(AxisValue);
    builder.PutInt(KeyCode);
    builder.PutInt(Id);
    return new Offset<AliveCell.Flat.InputData>(builder.Offset);
  }
  public InputDataT UnPack() {
    var _o = new InputDataT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(InputDataT _o) {
    _o.Id = this.Id;
    _o.KeyCode = this.KeyCode;
    _o.AxisValue = this.AxisValue;
  }
  public static Offset<AliveCell.Flat.InputData> Pack(FlatBufferBuilder builder, InputDataT _o) {
    if (_o == null) return default(Offset<AliveCell.Flat.InputData>);
    return CreateInputData(
      builder,
      _o.Id,
      _o.KeyCode,
      _o.AxisValue);
  }
};

public class InputDataT
{
  [Newtonsoft.Json.JsonProperty("id")]
  public int Id { get; set; }
  [Newtonsoft.Json.JsonProperty("keyCode")]
  public int KeyCode { get; set; }
  [Newtonsoft.Json.JsonProperty("axisValue")]
  public byte AxisValue { get; set; }

  public InputDataT() {
    this.Id = 0;
    this.KeyCode = 0;
    this.AxisValue = 0;
  }
}

public struct FrameData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static FrameData GetRootAsFrameData(ByteBuffer _bb) { return GetRootAsFrameData(_bb, new FrameData()); }
  public static FrameData GetRootAsFrameData(ByteBuffer _bb, FrameData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FrameData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int FrameIndex { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public AliveCell.Flat.InputData? Inputs(int j) { int o = __p.__offset(6); return o != 0 ? (AliveCell.Flat.InputData?)(new AliveCell.Flat.InputData()).__assign(__p.__vector(o) + j * 12, __p.bb) : null; }
  public int InputsLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<AliveCell.Flat.FrameData> CreateFrameData(FlatBufferBuilder builder,
      int frameIndex = 0,
      VectorOffset inputsOffset = default(VectorOffset)) {
    builder.StartTable(2);
    FrameData.AddInputs(builder, inputsOffset);
    FrameData.AddFrameIndex(builder, frameIndex);
    return FrameData.EndFrameData(builder);
  }

  public static void StartFrameData(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddFrameIndex(FlatBufferBuilder builder, int frameIndex) { builder.AddInt(0, frameIndex, 0); }
  public static void AddInputs(FlatBufferBuilder builder, VectorOffset inputsOffset) { builder.AddOffset(1, inputsOffset.Value, 0); }
  public static void StartInputsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(12, numElems, 4); }
  public static Offset<AliveCell.Flat.FrameData> EndFrameData(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<AliveCell.Flat.FrameData>(o);
  }
  public FrameDataT UnPack() {
    var _o = new FrameDataT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(FrameDataT _o) {
    _o.FrameIndex = this.FrameIndex;
    _o.Inputs = new List<AliveCell.Flat.InputDataT>();
    for (var _j = 0; _j < this.InputsLength; ++_j) {_o.Inputs.Add(this.Inputs(_j).HasValue ? this.Inputs(_j).Value.UnPack() : null);}
  }
  public static Offset<AliveCell.Flat.FrameData> Pack(FlatBufferBuilder builder, FrameDataT _o) {
    if (_o == null) return default(Offset<AliveCell.Flat.FrameData>);
    var _inputs = default(VectorOffset);
    if (_o.Inputs != null) {
      StartInputsVector(builder, _o.Inputs.Count);
      for (var _j = _o.Inputs.Count - 1; _j >= 0; --_j) { AliveCell.Flat.InputData.Pack(builder, _o.Inputs[_j]); }
      _inputs = builder.EndVector();
    }
    return CreateFrameData(
      builder,
      _o.FrameIndex,
      _inputs);
  }
};

public class FrameDataT
{
  [Newtonsoft.Json.JsonProperty("frameIndex")]
  public int FrameIndex { get; set; }
  [Newtonsoft.Json.JsonProperty("inputs")]
  public List<AliveCell.Flat.InputDataT> Inputs { get; set; }

  public FrameDataT() {
    this.FrameIndex = 0;
    this.Inputs = null;
  }
}

public struct FrameRecorder : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static FrameRecorder GetRootAsFrameRecorder(ByteBuffer _bb) { return GetRootAsFrameRecorder(_bb, new FrameRecorder()); }
  public static FrameRecorder GetRootAsFrameRecorder(ByteBuffer _bb, FrameRecorder obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FrameRecorder __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int MapId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SelfId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public AliveCell.Flat.PlayerData? Players(int j) { int o = __p.__offset(8); return o != 0 ? (AliveCell.Flat.PlayerData?)(new AliveCell.Flat.PlayerData()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int PlayersLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
  public AliveCell.Flat.FrameData? Frames(int j) { int o = __p.__offset(10); return o != 0 ? (AliveCell.Flat.FrameData?)(new AliveCell.Flat.FrameData()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int FramesLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }
  public int GameMode { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<AliveCell.Flat.FrameRecorder> CreateFrameRecorder(FlatBufferBuilder builder,
      int mapId = 0,
      int selfId = 0,
      VectorOffset playersOffset = default(VectorOffset),
      VectorOffset framesOffset = default(VectorOffset),
      int gameMode = 0) {
    builder.StartTable(5);
    FrameRecorder.AddGameMode(builder, gameMode);
    FrameRecorder.AddFrames(builder, framesOffset);
    FrameRecorder.AddPlayers(builder, playersOffset);
    FrameRecorder.AddSelfId(builder, selfId);
    FrameRecorder.AddMapId(builder, mapId);
    return FrameRecorder.EndFrameRecorder(builder);
  }

  public static void StartFrameRecorder(FlatBufferBuilder builder) { builder.StartTable(5); }
  public static void AddMapId(FlatBufferBuilder builder, int mapId) { builder.AddInt(0, mapId, 0); }
  public static void AddSelfId(FlatBufferBuilder builder, int selfId) { builder.AddInt(1, selfId, 0); }
  public static void AddPlayers(FlatBufferBuilder builder, VectorOffset playersOffset) { builder.AddOffset(2, playersOffset.Value, 0); }
  public static VectorOffset CreatePlayersVector(FlatBufferBuilder builder, Offset<AliveCell.Flat.PlayerData>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreatePlayersVectorBlock(FlatBufferBuilder builder, Offset<AliveCell.Flat.PlayerData>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartPlayersVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddFrames(FlatBufferBuilder builder, VectorOffset framesOffset) { builder.AddOffset(3, framesOffset.Value, 0); }
  public static VectorOffset CreateFramesVector(FlatBufferBuilder builder, Offset<AliveCell.Flat.FrameData>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateFramesVectorBlock(FlatBufferBuilder builder, Offset<AliveCell.Flat.FrameData>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartFramesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddGameMode(FlatBufferBuilder builder, int gameMode) { builder.AddInt(4, gameMode, 0); }
  public static Offset<AliveCell.Flat.FrameRecorder> EndFrameRecorder(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<AliveCell.Flat.FrameRecorder>(o);
  }
  public static void FinishFrameRecorderBuffer(FlatBufferBuilder builder, Offset<AliveCell.Flat.FrameRecorder> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedFrameRecorderBuffer(FlatBufferBuilder builder, Offset<AliveCell.Flat.FrameRecorder> offset) { builder.FinishSizePrefixed(offset.Value); }
  public FrameRecorderT UnPack() {
    var _o = new FrameRecorderT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(FrameRecorderT _o) {
    _o.MapId = this.MapId;
    _o.SelfId = this.SelfId;
    _o.Players = new List<AliveCell.Flat.PlayerDataT>();
    for (var _j = 0; _j < this.PlayersLength; ++_j) {_o.Players.Add(this.Players(_j).HasValue ? this.Players(_j).Value.UnPack() : null);}
    _o.Frames = new List<AliveCell.Flat.FrameDataT>();
    for (var _j = 0; _j < this.FramesLength; ++_j) {_o.Frames.Add(this.Frames(_j).HasValue ? this.Frames(_j).Value.UnPack() : null);}
    _o.GameMode = this.GameMode;
  }
  public static Offset<AliveCell.Flat.FrameRecorder> Pack(FlatBufferBuilder builder, FrameRecorderT _o) {
    if (_o == null) return default(Offset<AliveCell.Flat.FrameRecorder>);
    var _players = default(VectorOffset);
    if (_o.Players != null) {
      var __players = new Offset<AliveCell.Flat.PlayerData>[_o.Players.Count];
      for (var _j = 0; _j < __players.Length; ++_j) { __players[_j] = AliveCell.Flat.PlayerData.Pack(builder, _o.Players[_j]); }
      _players = CreatePlayersVector(builder, __players);
    }
    var _frames = default(VectorOffset);
    if (_o.Frames != null) {
      var __frames = new Offset<AliveCell.Flat.FrameData>[_o.Frames.Count];
      for (var _j = 0; _j < __frames.Length; ++_j) { __frames[_j] = AliveCell.Flat.FrameData.Pack(builder, _o.Frames[_j]); }
      _frames = CreateFramesVector(builder, __frames);
    }
    return CreateFrameRecorder(
      builder,
      _o.MapId,
      _o.SelfId,
      _players,
      _frames,
      _o.GameMode);
  }
};

public class FrameRecorderT
{
  [Newtonsoft.Json.JsonProperty("mapId")]
  public int MapId { get; set; }
  [Newtonsoft.Json.JsonProperty("selfId")]
  public int SelfId { get; set; }
  [Newtonsoft.Json.JsonProperty("players")]
  public List<AliveCell.Flat.PlayerDataT> Players { get; set; }
  [Newtonsoft.Json.JsonProperty("frames")]
  public List<AliveCell.Flat.FrameDataT> Frames { get; set; }
  [Newtonsoft.Json.JsonProperty("gameMode")]
  public int GameMode { get; set; }

  public FrameRecorderT() {
    this.MapId = 0;
    this.SelfId = 0;
    this.Players = null;
    this.Frames = null;
    this.GameMode = 0;
  }

  public static FrameRecorderT DeserializeFromJson(string jsonText) {
    return Newtonsoft.Json.JsonConvert.DeserializeObject<FrameRecorderT>(jsonText);
  }
  public string SerializeToJson() {
    return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
  }
  public static FrameRecorderT DeserializeFromBinary(byte[] fbBuffer) {
    return FrameRecorder.GetRootAsFrameRecorder(new ByteBuffer(fbBuffer)).UnPack();
  }
  public byte[] SerializeToBinary() {
    var fbb = new FlatBufferBuilder(0x10000);
    fbb.Finish(FrameRecorder.Pack(fbb, this).Value);
    return fbb.DataBuffer.ToSizedArray();
  }
}


}

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: voteService.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MessageBoard.Voting.GRPC {

  /// <summary>Holder for reflection information generated from voteService.proto</summary>
  public static partial class VoteServiceReflection {

    #region Descriptor
    /// <summary>File descriptor for voteService.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static VoteServiceReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChF2b3RlU2VydmljZS5wcm90bxIYTWVzc2FnZUJvYXJkLlZvdGluZy5HUlBD",
            "IjMKCkFkZFJlcXVlc3QSEQoJc3ViamVjdElkGAEgASgJEhIKCm9wdGlvbk5h",
            "bWUYAiABKAkiMQoMVm90ZVJlc3BvbnNlEhIKCm9wdGlvbk5hbWUYASABKAkS",
            "DQoFY291bnQYAiABKA0iNQoLTG9hZFJlcXVlc3QSEQoJc3ViamVjdElkGAEg",
            "ASgJEhMKC29wdGlvbk5hbWVzGAIgAygJIkUKDExvYWRSZXNwb25zZRI1CgV2",
            "b3RlcxgBIAMoCzImLk1lc3NhZ2VCb2FyZC5Wb3RpbmcuR1JQQy5Wb3RlUmVz",
            "cG9uc2UiOgoQTG9hZEJhdGNoUmVxdWVzdBIRCglzdWJqZWN0SWQYASADKAkS",
            "EwoLb3B0aW9uTmFtZXMYAiADKAkixAEKEUxvYWRCYXRjaFJlc3BvbnNlEk4K",
            "BXZvdGVzGAEgAygLMj8uTWVzc2FnZUJvYXJkLlZvdGluZy5HUlBDLkxvYWRC",
            "YXRjaFJlc3BvbnNlLlN1YmplY3RMaXN0UmVzcG9uc2UaXwoTU3ViamVjdExp",
            "c3RSZXNwb25zZRIRCglzdWJqZWN0SWQYASABKAkSNQoFdm90ZXMYAiADKAsy",
            "Ji5NZXNzYWdlQm9hcmQuVm90aW5nLkdSUEMuVm90ZVJlc3BvbnNlMqUCCgtW",
            "b3RlU2VydmljZRJVCgNBZGQSJC5NZXNzYWdlQm9hcmQuVm90aW5nLkdSUEMu",
            "QWRkUmVxdWVzdBomLk1lc3NhZ2VCb2FyZC5Wb3RpbmcuR1JQQy5Wb3RlUmVz",
            "cG9uc2UiABJXCgRMb2FkEiUuTWVzc2FnZUJvYXJkLlZvdGluZy5HUlBDLkxv",
            "YWRSZXF1ZXN0GiYuTWVzc2FnZUJvYXJkLlZvdGluZy5HUlBDLkxvYWRSZXNw",
            "b25zZSIAEmYKCUxvYWRCYXRjaBIqLk1lc3NhZ2VCb2FyZC5Wb3RpbmcuR1JQ",
            "Qy5Mb2FkQmF0Y2hSZXF1ZXN0GisuTWVzc2FnZUJvYXJkLlZvdGluZy5HUlBD",
            "LkxvYWRCYXRjaFJlc3BvbnNlIgBiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MessageBoard.Voting.GRPC.AddRequest), global::MessageBoard.Voting.GRPC.AddRequest.Parser, new[]{ "SubjectId", "OptionName" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MessageBoard.Voting.GRPC.VoteResponse), global::MessageBoard.Voting.GRPC.VoteResponse.Parser, new[]{ "OptionName", "Count" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MessageBoard.Voting.GRPC.LoadRequest), global::MessageBoard.Voting.GRPC.LoadRequest.Parser, new[]{ "SubjectId", "OptionNames" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MessageBoard.Voting.GRPC.LoadResponse), global::MessageBoard.Voting.GRPC.LoadResponse.Parser, new[]{ "Votes" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MessageBoard.Voting.GRPC.LoadBatchRequest), global::MessageBoard.Voting.GRPC.LoadBatchRequest.Parser, new[]{ "SubjectId", "OptionNames" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MessageBoard.Voting.GRPC.LoadBatchResponse), global::MessageBoard.Voting.GRPC.LoadBatchResponse.Parser, new[]{ "Votes" }, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::MessageBoard.Voting.GRPC.LoadBatchResponse.Types.SubjectListResponse), global::MessageBoard.Voting.GRPC.LoadBatchResponse.Types.SubjectListResponse.Parser, new[]{ "SubjectId", "Votes" }, null, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AddRequest : pb::IMessage<AddRequest> {
    private static readonly pb::MessageParser<AddRequest> _parser = new pb::MessageParser<AddRequest>(() => new AddRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AddRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MessageBoard.Voting.GRPC.VoteServiceReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddRequest(AddRequest other) : this() {
      subjectId_ = other.subjectId_;
      optionName_ = other.optionName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AddRequest Clone() {
      return new AddRequest(this);
    }

    /// <summary>Field number for the "subjectId" field.</summary>
    public const int SubjectIdFieldNumber = 1;
    private string subjectId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SubjectId {
      get { return subjectId_; }
      set {
        subjectId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "optionName" field.</summary>
    public const int OptionNameFieldNumber = 2;
    private string optionName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string OptionName {
      get { return optionName_; }
      set {
        optionName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AddRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AddRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (SubjectId != other.SubjectId) return false;
      if (OptionName != other.OptionName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (SubjectId.Length != 0) hash ^= SubjectId.GetHashCode();
      if (OptionName.Length != 0) hash ^= OptionName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (SubjectId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(SubjectId);
      }
      if (OptionName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(OptionName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (SubjectId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SubjectId);
      }
      if (OptionName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OptionName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AddRequest other) {
      if (other == null) {
        return;
      }
      if (other.SubjectId.Length != 0) {
        SubjectId = other.SubjectId;
      }
      if (other.OptionName.Length != 0) {
        OptionName = other.OptionName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            SubjectId = input.ReadString();
            break;
          }
          case 18: {
            OptionName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class VoteResponse : pb::IMessage<VoteResponse> {
    private static readonly pb::MessageParser<VoteResponse> _parser = new pb::MessageParser<VoteResponse>(() => new VoteResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<VoteResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MessageBoard.Voting.GRPC.VoteServiceReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VoteResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VoteResponse(VoteResponse other) : this() {
      optionName_ = other.optionName_;
      count_ = other.count_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VoteResponse Clone() {
      return new VoteResponse(this);
    }

    /// <summary>Field number for the "optionName" field.</summary>
    public const int OptionNameFieldNumber = 1;
    private string optionName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string OptionName {
      get { return optionName_; }
      set {
        optionName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "count" field.</summary>
    public const int CountFieldNumber = 2;
    private uint count_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Count {
      get { return count_; }
      set {
        count_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as VoteResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(VoteResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OptionName != other.OptionName) return false;
      if (Count != other.Count) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (OptionName.Length != 0) hash ^= OptionName.GetHashCode();
      if (Count != 0) hash ^= Count.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (OptionName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(OptionName);
      }
      if (Count != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(Count);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (OptionName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OptionName);
      }
      if (Count != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Count);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(VoteResponse other) {
      if (other == null) {
        return;
      }
      if (other.OptionName.Length != 0) {
        OptionName = other.OptionName;
      }
      if (other.Count != 0) {
        Count = other.Count;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            OptionName = input.ReadString();
            break;
          }
          case 16: {
            Count = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoadRequest : pb::IMessage<LoadRequest> {
    private static readonly pb::MessageParser<LoadRequest> _parser = new pb::MessageParser<LoadRequest>(() => new LoadRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoadRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MessageBoard.Voting.GRPC.VoteServiceReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadRequest(LoadRequest other) : this() {
      subjectId_ = other.subjectId_;
      optionNames_ = other.optionNames_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadRequest Clone() {
      return new LoadRequest(this);
    }

    /// <summary>Field number for the "subjectId" field.</summary>
    public const int SubjectIdFieldNumber = 1;
    private string subjectId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SubjectId {
      get { return subjectId_; }
      set {
        subjectId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "optionNames" field.</summary>
    public const int OptionNamesFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_optionNames_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> optionNames_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> OptionNames {
      get { return optionNames_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoadRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoadRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (SubjectId != other.SubjectId) return false;
      if(!optionNames_.Equals(other.optionNames_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (SubjectId.Length != 0) hash ^= SubjectId.GetHashCode();
      hash ^= optionNames_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (SubjectId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(SubjectId);
      }
      optionNames_.WriteTo(output, _repeated_optionNames_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (SubjectId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SubjectId);
      }
      size += optionNames_.CalculateSize(_repeated_optionNames_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoadRequest other) {
      if (other == null) {
        return;
      }
      if (other.SubjectId.Length != 0) {
        SubjectId = other.SubjectId;
      }
      optionNames_.Add(other.optionNames_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            SubjectId = input.ReadString();
            break;
          }
          case 18: {
            optionNames_.AddEntriesFrom(input, _repeated_optionNames_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoadResponse : pb::IMessage<LoadResponse> {
    private static readonly pb::MessageParser<LoadResponse> _parser = new pb::MessageParser<LoadResponse>(() => new LoadResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoadResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MessageBoard.Voting.GRPC.VoteServiceReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadResponse(LoadResponse other) : this() {
      votes_ = other.votes_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadResponse Clone() {
      return new LoadResponse(this);
    }

    /// <summary>Field number for the "votes" field.</summary>
    public const int VotesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::MessageBoard.Voting.GRPC.VoteResponse> _repeated_votes_codec
        = pb::FieldCodec.ForMessage(10, global::MessageBoard.Voting.GRPC.VoteResponse.Parser);
    private readonly pbc::RepeatedField<global::MessageBoard.Voting.GRPC.VoteResponse> votes_ = new pbc::RepeatedField<global::MessageBoard.Voting.GRPC.VoteResponse>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::MessageBoard.Voting.GRPC.VoteResponse> Votes {
      get { return votes_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoadResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoadResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!votes_.Equals(other.votes_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= votes_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      votes_.WriteTo(output, _repeated_votes_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += votes_.CalculateSize(_repeated_votes_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoadResponse other) {
      if (other == null) {
        return;
      }
      votes_.Add(other.votes_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            votes_.AddEntriesFrom(input, _repeated_votes_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoadBatchRequest : pb::IMessage<LoadBatchRequest> {
    private static readonly pb::MessageParser<LoadBatchRequest> _parser = new pb::MessageParser<LoadBatchRequest>(() => new LoadBatchRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoadBatchRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MessageBoard.Voting.GRPC.VoteServiceReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadBatchRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadBatchRequest(LoadBatchRequest other) : this() {
      subjectId_ = other.subjectId_.Clone();
      optionNames_ = other.optionNames_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadBatchRequest Clone() {
      return new LoadBatchRequest(this);
    }

    /// <summary>Field number for the "subjectId" field.</summary>
    public const int SubjectIdFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _repeated_subjectId_codec
        = pb::FieldCodec.ForString(10);
    private readonly pbc::RepeatedField<string> subjectId_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> SubjectId {
      get { return subjectId_; }
    }

    /// <summary>Field number for the "optionNames" field.</summary>
    public const int OptionNamesFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_optionNames_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> optionNames_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> OptionNames {
      get { return optionNames_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoadBatchRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoadBatchRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!subjectId_.Equals(other.subjectId_)) return false;
      if(!optionNames_.Equals(other.optionNames_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= subjectId_.GetHashCode();
      hash ^= optionNames_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      subjectId_.WriteTo(output, _repeated_subjectId_codec);
      optionNames_.WriteTo(output, _repeated_optionNames_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += subjectId_.CalculateSize(_repeated_subjectId_codec);
      size += optionNames_.CalculateSize(_repeated_optionNames_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoadBatchRequest other) {
      if (other == null) {
        return;
      }
      subjectId_.Add(other.subjectId_);
      optionNames_.Add(other.optionNames_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            subjectId_.AddEntriesFrom(input, _repeated_subjectId_codec);
            break;
          }
          case 18: {
            optionNames_.AddEntriesFrom(input, _repeated_optionNames_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoadBatchResponse : pb::IMessage<LoadBatchResponse> {
    private static readonly pb::MessageParser<LoadBatchResponse> _parser = new pb::MessageParser<LoadBatchResponse>(() => new LoadBatchResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoadBatchResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MessageBoard.Voting.GRPC.VoteServiceReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadBatchResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadBatchResponse(LoadBatchResponse other) : this() {
      votes_ = other.votes_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoadBatchResponse Clone() {
      return new LoadBatchResponse(this);
    }

    /// <summary>Field number for the "votes" field.</summary>
    public const int VotesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::MessageBoard.Voting.GRPC.LoadBatchResponse.Types.SubjectListResponse> _repeated_votes_codec
        = pb::FieldCodec.ForMessage(10, global::MessageBoard.Voting.GRPC.LoadBatchResponse.Types.SubjectListResponse.Parser);
    private readonly pbc::RepeatedField<global::MessageBoard.Voting.GRPC.LoadBatchResponse.Types.SubjectListResponse> votes_ = new pbc::RepeatedField<global::MessageBoard.Voting.GRPC.LoadBatchResponse.Types.SubjectListResponse>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::MessageBoard.Voting.GRPC.LoadBatchResponse.Types.SubjectListResponse> Votes {
      get { return votes_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoadBatchResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoadBatchResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!votes_.Equals(other.votes_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= votes_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      votes_.WriteTo(output, _repeated_votes_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += votes_.CalculateSize(_repeated_votes_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoadBatchResponse other) {
      if (other == null) {
        return;
      }
      votes_.Add(other.votes_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            votes_.AddEntriesFrom(input, _repeated_votes_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the LoadBatchResponse message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public sealed partial class SubjectListResponse : pb::IMessage<SubjectListResponse> {
        private static readonly pb::MessageParser<SubjectListResponse> _parser = new pb::MessageParser<SubjectListResponse>(() => new SubjectListResponse());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<SubjectListResponse> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::MessageBoard.Voting.GRPC.LoadBatchResponse.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SubjectListResponse() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SubjectListResponse(SubjectListResponse other) : this() {
          subjectId_ = other.subjectId_;
          votes_ = other.votes_.Clone();
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SubjectListResponse Clone() {
          return new SubjectListResponse(this);
        }

        /// <summary>Field number for the "subjectId" field.</summary>
        public const int SubjectIdFieldNumber = 1;
        private string subjectId_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string SubjectId {
          get { return subjectId_; }
          set {
            subjectId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        /// <summary>Field number for the "votes" field.</summary>
        public const int VotesFieldNumber = 2;
        private static readonly pb::FieldCodec<global::MessageBoard.Voting.GRPC.VoteResponse> _repeated_votes_codec
            = pb::FieldCodec.ForMessage(18, global::MessageBoard.Voting.GRPC.VoteResponse.Parser);
        private readonly pbc::RepeatedField<global::MessageBoard.Voting.GRPC.VoteResponse> votes_ = new pbc::RepeatedField<global::MessageBoard.Voting.GRPC.VoteResponse>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<global::MessageBoard.Voting.GRPC.VoteResponse> Votes {
          get { return votes_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as SubjectListResponse);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(SubjectListResponse other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (SubjectId != other.SubjectId) return false;
          if(!votes_.Equals(other.votes_)) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (SubjectId.Length != 0) hash ^= SubjectId.GetHashCode();
          hash ^= votes_.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (SubjectId.Length != 0) {
            output.WriteRawTag(10);
            output.WriteString(SubjectId);
          }
          votes_.WriteTo(output, _repeated_votes_codec);
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (SubjectId.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(SubjectId);
          }
          size += votes_.CalculateSize(_repeated_votes_codec);
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(SubjectListResponse other) {
          if (other == null) {
            return;
          }
          if (other.SubjectId.Length != 0) {
            SubjectId = other.SubjectId;
          }
          votes_.Add(other.votes_);
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 10: {
                SubjectId = input.ReadString();
                break;
              }
              case 18: {
                votes_.AddEntriesFrom(input, _repeated_votes_codec);
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: voteService.proto
// </auto-generated>
#pragma warning disable 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace MessageBoard.Voting.GRPC {
  public static partial class VoteService
  {
    static readonly string __ServiceName = "MessageBoard.Voting.GRPC.VoteService";

    static readonly grpc::Marshaller<global::MessageBoard.Voting.GRPC.AddRequest> __Marshaller_AddRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MessageBoard.Voting.GRPC.AddRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MessageBoard.Voting.GRPC.VoteResponse> __Marshaller_VoteResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MessageBoard.Voting.GRPC.VoteResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MessageBoard.Voting.GRPC.SingleRequest> __Marshaller_SingleRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MessageBoard.Voting.GRPC.SingleRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MessageBoard.Voting.GRPC.SingleResponse> __Marshaller_SingleResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MessageBoard.Voting.GRPC.SingleResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::MessageBoard.Voting.GRPC.AddRequest, global::MessageBoard.Voting.GRPC.VoteResponse> __Method_Add = new grpc::Method<global::MessageBoard.Voting.GRPC.AddRequest, global::MessageBoard.Voting.GRPC.VoteResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_AddRequest,
        __Marshaller_VoteResponse);

    static readonly grpc::Method<global::MessageBoard.Voting.GRPC.SingleRequest, global::MessageBoard.Voting.GRPC.SingleResponse> __Method_Single = new grpc::Method<global::MessageBoard.Voting.GRPC.SingleRequest, global::MessageBoard.Voting.GRPC.SingleResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Single",
        __Marshaller_SingleRequest,
        __Marshaller_SingleResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::MessageBoard.Voting.GRPC.VoteServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of VoteService</summary>
    public abstract partial class VoteServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::MessageBoard.Voting.GRPC.VoteResponse> Add(global::MessageBoard.Voting.GRPC.AddRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MessageBoard.Voting.GRPC.SingleResponse> Single(global::MessageBoard.Voting.GRPC.SingleRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for VoteService</summary>
    public partial class VoteServiceClient : grpc::ClientBase<VoteServiceClient>
    {
      /// <summary>Creates a new client for VoteService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public VoteServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for VoteService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public VoteServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected VoteServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected VoteServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::MessageBoard.Voting.GRPC.VoteResponse Add(global::MessageBoard.Voting.GRPC.AddRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Add(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::MessageBoard.Voting.GRPC.VoteResponse Add(global::MessageBoard.Voting.GRPC.AddRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Add, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::MessageBoard.Voting.GRPC.VoteResponse> AddAsync(global::MessageBoard.Voting.GRPC.AddRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::MessageBoard.Voting.GRPC.VoteResponse> AddAsync(global::MessageBoard.Voting.GRPC.AddRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Add, null, options, request);
      }
      public virtual global::MessageBoard.Voting.GRPC.SingleResponse Single(global::MessageBoard.Voting.GRPC.SingleRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Single(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::MessageBoard.Voting.GRPC.SingleResponse Single(global::MessageBoard.Voting.GRPC.SingleRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Single, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::MessageBoard.Voting.GRPC.SingleResponse> SingleAsync(global::MessageBoard.Voting.GRPC.SingleRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SingleAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::MessageBoard.Voting.GRPC.SingleResponse> SingleAsync(global::MessageBoard.Voting.GRPC.SingleRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Single, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override VoteServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new VoteServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(VoteServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Add, serviceImpl.Add)
          .AddMethod(__Method_Single, serviceImpl.Single).Build();
    }

  }
}
#endregion

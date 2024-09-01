// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/taskManagementService.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace TasksManagmentService {
  public static partial class TaskManagementService
  {
    static readonly string __ServiceName = "taskManagement.TaskManagementService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.CreateNewSpaceRequest> __Marshaller_taskManagement_CreateNewSpaceRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.CreateNewSpaceRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.CreateNewSpaceResponse> __Marshaller_taskManagement_CreateNewSpaceResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.CreateNewSpaceResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.AddStatusRequest> __Marshaller_taskManagement_AddStatusRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.AddStatusRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.AddStatusResponse> __Marshaller_taskManagement_AddStatusResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.AddStatusResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.AddNewTaskRequest> __Marshaller_taskManagement_AddNewTaskRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.AddNewTaskRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.AddNewTaskResponse> __Marshaller_taskManagement_AddNewTaskResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.AddNewTaskResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.GetSpaceInfoRequest> __Marshaller_taskManagement_GetSpaceInfoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.GetSpaceInfoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.GetSpaceInfoResponse> __Marshaller_taskManagement_GetSpaceInfoResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.GetSpaceInfoResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.GetTaskInfoRequest> __Marshaller_taskManagement_GetTaskInfoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.GetTaskInfoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.GetTaskInfoResponse> __Marshaller_taskManagement_GetTaskInfoResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.GetTaskInfoResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.GetStatusInfoRequest> __Marshaller_taskManagement_GetStatusInfoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.GetStatusInfoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.GetStatusInfoResponse> __Marshaller_taskManagement_GetStatusInfoResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.GetStatusInfoResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.RemoveTaskRequest> __Marshaller_taskManagement_RemoveTaskRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.RemoveTaskRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.RemoveTaskResponse> __Marshaller_taskManagement_RemoveTaskResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.RemoveTaskResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.AddDefaultStatusRequest> __Marshaller_taskManagement_AddDefaultStatusRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.AddDefaultStatusRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::TasksManagmentService.AddDefaultStatusResponse> __Marshaller_taskManagement_AddDefaultStatusResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TasksManagmentService.AddDefaultStatusResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.CreateNewSpaceRequest, global::TasksManagmentService.CreateNewSpaceResponse> __Method_CreateNewSpace = new grpc::Method<global::TasksManagmentService.CreateNewSpaceRequest, global::TasksManagmentService.CreateNewSpaceResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateNewSpace",
        __Marshaller_taskManagement_CreateNewSpaceRequest,
        __Marshaller_taskManagement_CreateNewSpaceResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.AddStatusRequest, global::TasksManagmentService.AddStatusResponse> __Method_AddNewStatus = new grpc::Method<global::TasksManagmentService.AddStatusRequest, global::TasksManagmentService.AddStatusResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddNewStatus",
        __Marshaller_taskManagement_AddStatusRequest,
        __Marshaller_taskManagement_AddStatusResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.AddNewTaskRequest, global::TasksManagmentService.AddNewTaskResponse> __Method_AddNewTask = new grpc::Method<global::TasksManagmentService.AddNewTaskRequest, global::TasksManagmentService.AddNewTaskResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddNewTask",
        __Marshaller_taskManagement_AddNewTaskRequest,
        __Marshaller_taskManagement_AddNewTaskResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.GetSpaceInfoRequest, global::TasksManagmentService.GetSpaceInfoResponse> __Method_GetSpaceInfo = new grpc::Method<global::TasksManagmentService.GetSpaceInfoRequest, global::TasksManagmentService.GetSpaceInfoResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSpaceInfo",
        __Marshaller_taskManagement_GetSpaceInfoRequest,
        __Marshaller_taskManagement_GetSpaceInfoResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.GetTaskInfoRequest, global::TasksManagmentService.GetTaskInfoResponse> __Method_GetTaskInfo = new grpc::Method<global::TasksManagmentService.GetTaskInfoRequest, global::TasksManagmentService.GetTaskInfoResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetTaskInfo",
        __Marshaller_taskManagement_GetTaskInfoRequest,
        __Marshaller_taskManagement_GetTaskInfoResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.GetStatusInfoRequest, global::TasksManagmentService.GetStatusInfoResponse> __Method_GetStatusInfo = new grpc::Method<global::TasksManagmentService.GetStatusInfoRequest, global::TasksManagmentService.GetStatusInfoResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetStatusInfo",
        __Marshaller_taskManagement_GetStatusInfoRequest,
        __Marshaller_taskManagement_GetStatusInfoResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.RemoveTaskRequest, global::TasksManagmentService.RemoveTaskResponse> __Method_RemoveTask = new grpc::Method<global::TasksManagmentService.RemoveTaskRequest, global::TasksManagmentService.RemoveTaskResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveTask",
        __Marshaller_taskManagement_RemoveTaskRequest,
        __Marshaller_taskManagement_RemoveTaskResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::TasksManagmentService.AddDefaultStatusRequest, global::TasksManagmentService.AddDefaultStatusResponse> __Method_AddDefaultStatus = new grpc::Method<global::TasksManagmentService.AddDefaultStatusRequest, global::TasksManagmentService.AddDefaultStatusResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddDefaultStatus",
        __Marshaller_taskManagement_AddDefaultStatusRequest,
        __Marshaller_taskManagement_AddDefaultStatusResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::TasksManagmentService.TaskManagementServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of TaskManagementService</summary>
    [grpc::BindServiceMethod(typeof(TaskManagementService), "BindService")]
    public abstract partial class TaskManagementServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.CreateNewSpaceResponse> CreateNewSpace(global::TasksManagmentService.CreateNewSpaceRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.AddStatusResponse> AddNewStatus(global::TasksManagmentService.AddStatusRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.AddNewTaskResponse> AddNewTask(global::TasksManagmentService.AddNewTaskRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.GetSpaceInfoResponse> GetSpaceInfo(global::TasksManagmentService.GetSpaceInfoRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.GetTaskInfoResponse> GetTaskInfo(global::TasksManagmentService.GetTaskInfoRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.GetStatusInfoResponse> GetStatusInfo(global::TasksManagmentService.GetStatusInfoRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.RemoveTaskResponse> RemoveTask(global::TasksManagmentService.RemoveTaskRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::TasksManagmentService.AddDefaultStatusResponse> AddDefaultStatus(global::TasksManagmentService.AddDefaultStatusRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(TaskManagementServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateNewSpace, serviceImpl.CreateNewSpace)
          .AddMethod(__Method_AddNewStatus, serviceImpl.AddNewStatus)
          .AddMethod(__Method_AddNewTask, serviceImpl.AddNewTask)
          .AddMethod(__Method_GetSpaceInfo, serviceImpl.GetSpaceInfo)
          .AddMethod(__Method_GetTaskInfo, serviceImpl.GetTaskInfo)
          .AddMethod(__Method_GetStatusInfo, serviceImpl.GetStatusInfo)
          .AddMethod(__Method_RemoveTask, serviceImpl.RemoveTask)
          .AddMethod(__Method_AddDefaultStatus, serviceImpl.AddDefaultStatus).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, TaskManagementServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateNewSpace, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.CreateNewSpaceRequest, global::TasksManagmentService.CreateNewSpaceResponse>(serviceImpl.CreateNewSpace));
      serviceBinder.AddMethod(__Method_AddNewStatus, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.AddStatusRequest, global::TasksManagmentService.AddStatusResponse>(serviceImpl.AddNewStatus));
      serviceBinder.AddMethod(__Method_AddNewTask, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.AddNewTaskRequest, global::TasksManagmentService.AddNewTaskResponse>(serviceImpl.AddNewTask));
      serviceBinder.AddMethod(__Method_GetSpaceInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.GetSpaceInfoRequest, global::TasksManagmentService.GetSpaceInfoResponse>(serviceImpl.GetSpaceInfo));
      serviceBinder.AddMethod(__Method_GetTaskInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.GetTaskInfoRequest, global::TasksManagmentService.GetTaskInfoResponse>(serviceImpl.GetTaskInfo));
      serviceBinder.AddMethod(__Method_GetStatusInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.GetStatusInfoRequest, global::TasksManagmentService.GetStatusInfoResponse>(serviceImpl.GetStatusInfo));
      serviceBinder.AddMethod(__Method_RemoveTask, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.RemoveTaskRequest, global::TasksManagmentService.RemoveTaskResponse>(serviceImpl.RemoveTask));
      serviceBinder.AddMethod(__Method_AddDefaultStatus, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TasksManagmentService.AddDefaultStatusRequest, global::TasksManagmentService.AddDefaultStatusResponse>(serviceImpl.AddDefaultStatus));
    }

  }
}
#endregion

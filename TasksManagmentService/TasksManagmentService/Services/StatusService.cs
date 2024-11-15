using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using TasksManagmentService.Data;
using Status = TasksManagmentService.Data.Entities.Status;

namespace TasksManagmentService.Services;

public class StatusService
{
    private readonly ApplicationContext _db;

    public StatusService(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<AddStatusResponse> AddNewStatus(AddStatusRequest request, ServerCallContext context)
    {
        if (string.IsNullOrEmpty(request.StatusName) || request.SpaceId == 0)
        {
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        }

        if (!await _db.Spaces.AnyAsync(s => s.Id == request.SpaceId))
            throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
                $"Space With Id {request.SpaceId} Not Found"));
        var newStatus = new Status()
        {
            Name = request.StatusName,
            SpaceId = request.SpaceId
        };
        await _db.Statuses.AddAsync(newStatus);
        await _db.SaveChangesAsync();
        return new AddStatusResponse()
        {
            StatusId = newStatus.Id
        };
    }

    public Task<GetAllSpaceStatusInfoResponse> GetSpaceStatusesInfo(GetAllSpaceStatusInfoRequest request,
        ServerCallContext context)
    {
        if (request.SpaceId == 0)
        {
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        }

        var statuses = _db.Statuses.Where(s => s.SpaceId == request.SpaceId).Select(s => new GetStatusInfoResponse()
        {
            StatusId = s.Id,
            StatusName = s.Name
        });
        var response = new GetAllSpaceStatusInfoResponse();
        response.SpaceStatuses.AddRange(statuses);
        return Task.FromResult(response);
    }

    public  async Task<AddDefaultStatusResponse> AddDefaultStatus(AddDefaultStatusRequest request,
        ServerCallContext context)
    {
        if (string.IsNullOrEmpty(request.StatusName))
        {
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        }

        var newDefaultStatus = new Status()
        {
            isDefault = true,
            Name = request.StatusName
        };
        await _db.AddAsync(newDefaultStatus);
        await _db.SaveChangesAsync();
        return new AddDefaultStatusResponse()
        {
            Result = true
        };
    }
}
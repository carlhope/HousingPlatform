using Housing.Api.Contracts.Landlords;
using Housing.Api.Contracts.Tenancies;
using Housing.Api.Mappers;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Housing.Api.Features.Tenancy.Terminate;

public class TerminateTenancyHandler : IRequestHandler<TerminateTenancyCommand, TenancyDto>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public TerminateTenancyHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<TenancyDto> Handle(TerminateTenancyCommand request, CancellationToken ct)
    {
        var tenancy = await _db.Tenancies.FindAsync([request.Id], ct);
        if (tenancy is null)
            throw new Exception($"Tenancy with id {request.Id} not found");

        if (tenancy.EndDate is not null)
            throw new Exception($"Tenancy with id {request.Id} already ended");
        
        tenancy.End(request.EndDate);
        await _db.SaveChangesAsync(ct);

        await _cache.RemoveAsync("tenancies:all");
        await _cache.RemoveAsync($"tenancy:{request.Id}");
        var dto = tenancy.ToDto();

        return dto;
    }
}

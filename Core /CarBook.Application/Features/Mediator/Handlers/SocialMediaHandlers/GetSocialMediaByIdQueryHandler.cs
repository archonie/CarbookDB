using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaByIdQueryHandler: IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IRepository<SocialMedia> _repository;

    public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetSocialMediaByIdQueryResult
        {
            SocialMediaID =  value.SocialMediaID,
            Name = value.Name,
            Icon = value.Icon,
            Url = value.Url,
        };
    }
}
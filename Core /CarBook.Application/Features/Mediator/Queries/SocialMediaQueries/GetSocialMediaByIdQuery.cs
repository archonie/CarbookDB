using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

public class GetSocialMediaByIdQuery: IRequest<GetSocialMediaByIdQueryResult>
{
    public GetSocialMediaByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    
}
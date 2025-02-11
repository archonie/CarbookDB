using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class UpdateSocialMediaCommandHandler: IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.SocialMediaID);
        value.Name = request.Name;
        value.Icon = request.Icon;
        value.Url = request.Url;
        await _repository.UpdateAsync(value);
    }
}
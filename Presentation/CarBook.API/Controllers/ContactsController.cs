using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController: ControllerBase
{
    private readonly GetContactQueryHandler _getContactQueryHandler;
    private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
    private readonly CreateContactCommandHandler _createContactCommandHandler;
    private readonly UpdateContactCommandHandler _updateContactCommandHandler;
    private readonly RemoveContactCommandHandler _removeContactCommandHandler;

    public ContactsController(
        GetContactQueryHandler getContactQueryHandler,
        GetContactByIdQueryHandler getContactByIdQueryHandler, 
        CreateContactCommandHandler createContactCommandHandler,
        UpdateContactCommandHandler updateContactCommandHandler, 
        RemoveContactCommandHandler removeContactCommandHandler)
    {
        _getContactQueryHandler = getContactQueryHandler;
        _getContactByIdQueryHandler = getContactByIdQueryHandler;
        _createContactCommandHandler = createContactCommandHandler;
        _updateContactCommandHandler = updateContactCommandHandler;
        _removeContactCommandHandler = removeContactCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        var contacts = await _getContactQueryHandler.Handle();
        return Ok(contacts);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        var contact = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand command)
    {
        await _createContactCommandHandler.Handle(command);
        return Ok("Contact created");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
    {
        await _updateContactCommandHandler.Handle(command);
        return Ok("Contact updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveContact(int id)
    {
        await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
        return Ok("Contact removed");
    }
}
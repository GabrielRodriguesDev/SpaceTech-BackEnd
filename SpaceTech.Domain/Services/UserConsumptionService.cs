using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Commands.UserConsumption;
using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Interfaces.Services;

namespace SpaceTech.Domain.Services;
public class UserConsumptionService : IUserConsumptionService
{
    private IUserConsumptionRepository _userConsumptionRepository;
    private IUserRepository _userRepository;
    private IUnitOfWork _uow;

    public UserConsumptionService(
        IUserConsumptionRepository userConsumptionRepository,
        IUserRepository userRepository,
        IUnitOfWork uow)
    {
        _userConsumptionRepository = userConsumptionRepository;
        _userRepository = userRepository;
        _uow = uow;
    }

    public GenericCommandResult Create(CreateUserConsumptionCommand command, CancellationToken cancellationToken)
    {
        command.Validate();
        if (command.Invalid) return new GenericCommandResult(false, "Ops! Something went wrong.", command.Notifications);

        var user = _userRepository.Get(command.UserId!.Value);
        if (user is null) return new GenericCommandResult(false, "Sorry, user not found.");

        string? consumedAPI = "";
        if (command.Url!.Contains("https://api.nasa.gov/neo")) {
            consumedAPI = "API de Eventos";
        } else if(command.Url!.Contains("https://api.nasa.gov/mars"))
        {
            consumedAPI = "API de Marte";
        } else if (command.Url!.Contains("https://eonet.gsfc.nasa.gov/docs"))
        {
            consumedAPI = "API de Asteróides";
        } else
        {
            return new GenericCommandResult(false, "Ops! URL not validated.");
        }

        command.ConsumedAPI = consumedAPI;
        UserConsumption userConsumption = new UserConsumption(command);

        _uow.BeginTransaction();

        try
        {
            _userConsumptionRepository.Create(userConsumption);
            _uow.Commit();
        }
        catch (Exception)
        {
            _uow.Rollback();
            throw;
        }

        return new GenericCommandResult(true, "User consumption sucessfully registered.");
    }
}

using Grpc.Core;

namespace ServerGrpc.Services;

public class UtilisateursService : Utilisateurs.UtilisateursBase
{

    private IDataService dataSvc;

    public UtilisateursService(IDataService dataService)
    {
        dataSvc = dataService;
    }

    public override Task<CountUser> GetCountUser(Empty request, ServerCallContext context)
    {
        int nombre = dataSvc.GetCountUser();
        return Task.FromResult(new CountUser() { NombreUser = nombre});
    }

    public override Task<UserResponse> GetUserById(UserIdRequest request, ServerCallContext context)
    {
        // Récupération de l'utilisateur.
        User user = dataSvc.GetUser(request.IdUser);
        return Task.FromResult(CreateResponse(user));
    }

    public override Task<AllUsersResponse> GetAll(Empty request, ServerCallContext context)
    {
        var allUsers = dataSvc.GetAllUser();

        AllUsersResponse response = new AllUsersResponse();
        foreach (var user in allUsers)
        {
            response.AllUsers.Add(CreateResponse(user));
        }

        return Task.FromResult(response);
    }


    private UserResponse CreateResponse(User user)
    {
        // Création de UserSelected (correspondant à notre "message" gRPC)
        UserResponse userReponse = new UserResponse()
        {
            About = user.about,
            Address = user.address,
            Age = user.age,
            Balance = user.balance,
            Company = user.company,
            Email = user.email,
            EyeColor = user.eyeColor,
            FavoriteFruit = user.favoriteFruit,
            Gender = user.gender,
            Greeting = user.greeting,
            Guid = user.guid,
            Id = user._id,
            Index = user.index,
            IsActive = user.isActive,
            Latitude = user.latitude,
            Longitude = user.longitude,
            Name = user.name,
            Phone = user.phone,
            Picture = user.picture,
            Registered = user.registered,
        };

        // Pour les listes de string.
        foreach (var tag in user.tags)
        {
            userReponse.Tags.Add(tag);
        }

        // Pour les listes d'un autre objet.
        foreach (var amis in user.friends)
        {
            userReponse.Friends.Add(new Friends() { Id = amis.id, Name = amis.name });
        }

        return userReponse;
    }

}
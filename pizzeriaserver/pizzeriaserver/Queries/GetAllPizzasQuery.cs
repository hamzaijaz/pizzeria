using MediatR;
using pizzeriaserver.Models;

namespace pizzeriaserver.Queries
{
    public class GetAllPizzasQuery : IRequest<List<Pizza>>
    {
    }
}

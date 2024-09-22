using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entry;
using Template.Infrastructure.Persistence.Repository.Base;

namespace Template.Infrastructure.Persistence.Repository;

public class UserRepository(AppDbContext context) : BaseRepository_0<AppDbContext, User, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO>(context), IUserRepository
{
}
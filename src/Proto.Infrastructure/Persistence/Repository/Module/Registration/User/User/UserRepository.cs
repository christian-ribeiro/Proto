using Microsoft.EntityFrameworkCore;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Infrastructure.Persistence.Context;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;
using Proto.Infrastructure.Persistence.Repository.Module.Base;

namespace Proto.Infrastructure.Persistence.Repository.Module.Registration;

public class UserRepository(AppDbContext context) : BaseRepository_0<AppDbContext, User, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO>(context), IUserRepository
{
    public UserDTO? GetByPasswordRecoveryCode(string passwordRecoveryCode)
    {
        return FromEntityToDTO(_context.User.AsNoTracking().Where(x => x.PasswordRecoveryCode == passwordRecoveryCode).FirstOrDefault()!);
    }
}
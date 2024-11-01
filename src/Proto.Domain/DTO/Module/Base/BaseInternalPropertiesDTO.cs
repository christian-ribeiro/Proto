﻿using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.General.Session;

namespace Proto.Domain.DTO.Module.Base;

public class BaseInternalPropertiesDTO_0 : BaseInternalPropertiesDTO<BaseInternalPropertiesDTO_0> { }

public class BaseInternalPropertiesDTO<TInternalPropertiesDTO> : BaseSetProperty<TInternalPropertiesDTO>
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
{
    public long Id { get; private set; }
    public virtual DateTime CreationDate { get; private set; }
    public virtual DateTime? ChangeDate { get; private set; }
    public virtual long? CreationUserId { get; private set; }
    public virtual long? ChangeUserId { get; private set; }

    public TInternalPropertiesDTO SetInternalData(long id, DateTime creationDate, DateTime? changeDate, long? creationUserId, long? changeUserId)
    {
        Id = id;
        CreationDate = creationDate;
        ChangeDate = changeDate;
        CreationUserId = creationUserId;
        ChangeUserId = changeUserId;
        return (TInternalPropertiesDTO)this;
    }

    public TInternalPropertiesDTO SetInternalDataCreate(DateTime creationDate, long? creationUserId)
    {
        CreationDate = creationDate;
        CreationUserId = creationUserId;
        return (TInternalPropertiesDTO)this;
    }

    public TInternalPropertiesDTO SetInternalDataChange(DateTime? changeDate, long? changeUserId)
    {
        ChangeDate = changeDate;
        ChangeUserId = changeUserId;
        return (TInternalPropertiesDTO)this;
    }

    public TInternalPropertiesDTO SetInternalData(long id)
    {
        Id = id;
        return (TInternalPropertiesDTO)this;
    }

    public TInternalPropertiesDTO SetCreateData(Guid guidSessionDataRequest)
    {
        CreationDate = DateTime.Now;

        LoggedUser? loggedUser = SessionData.GetLoggedUser(guidSessionDataRequest);
        if (loggedUser != null)
            CreationUserId = loggedUser.Id;

        return (TInternalPropertiesDTO)this;
    }

    public TInternalPropertiesDTO SetUpdateData(Guid guidSessionDataRequest)
    {
        ChangeDate = DateTime.Now;

        LoggedUser? loggedUser = SessionData.GetLoggedUser(guidSessionDataRequest);
        if (loggedUser != null)
            ChangeUserId = loggedUser.Id;

        return (TInternalPropertiesDTO)this;
    }
}
﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Infrastructure.Persistence.Entry.Base;

public class BaseEntry<TEntry> where TEntry : BaseEntry<TEntry>
{
    public long Id { get; private set; }
    [NotMapped]
    public virtual DateTime CreationDate { get; private set; }
    [NotMapped]
    public virtual DateTime? ChangeDate { get; private set; }
    [NotMapped]
    public virtual long? CreationUserId { get; private set; }
    [NotMapped]
    public virtual long? ChangeUserId { get; private set; }

    #region Virtual Properties
    #region Internal
    [NotMapped]
    public virtual User? CreationUser { get; private set; }
    [NotMapped]
    public virtual User? ChangeUser { get; private set; }
    #endregion
    #endregion

    public TEntry SetCreateData()
    {
        CreationDate = DateTime.Now;
        return (TEntry)this;
    }

    public TEntry SetChangeData()
    {
        ChangeDate = DateTime.Now;
        return (TEntry)this;
    }

    public TEntry SetInternalData(long id, DateTime creationDate, DateTime? changeDate, long? creationUserId, long? changeUserId)
    {
        Id = id;
        CreationDate = creationDate;
        ChangeDate = changeDate;
        CreationUserId = creationUserId;
        ChangeUserId = changeUserId;
        return (TEntry)this;
    }

    public TEntry SetInternalData(long id)
    {
        Id = id;
        return (TEntry)this;
    }

    public TEntry SetInternalDataCreate(DateTime creationDate, long? creationUserId)
    {
        CreationDate = creationDate;
        CreationUserId = creationUserId;
        return (TEntry)this;
    }

    public TEntry SetInternalDataChange(DateTime? changeDate, long? changeUserId)
    {
        ChangeDate = changeDate;
        ChangeUserId = changeUserId;
        return (TEntry)this;
    }
}
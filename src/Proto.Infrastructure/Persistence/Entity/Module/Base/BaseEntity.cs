using System.ComponentModel.DataAnnotations.Schema;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;

namespace Proto.Infrastructure.Persistence.Entity.Module.Base;

public class BaseEntity<TEntity> where TEntity : BaseEntity<TEntity>
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

    public TEntity SetCreateData()
    {
        CreationDate = DateTime.Now;
        return (TEntity)this;
    }

    public TEntity SetChangeData()
    {
        ChangeDate = DateTime.Now;
        return (TEntity)this;
    }

    public TEntity SetInternalData(long id, DateTime creationDate, DateTime? changeDate, long? creationUserId, long? changeUserId)
    {
        Id = id;
        CreationDate = creationDate;
        ChangeDate = changeDate;
        CreationUserId = creationUserId;
        ChangeUserId = changeUserId;
        return (TEntity)this;
    }

    public TEntity SetInternalData(long id)
    {
        Id = id;
        return (TEntity)this;
    }

    public TEntity SetInternalDataCreate(DateTime creationDate, long? creationUserId)
    {
        CreationDate = creationDate;
        CreationUserId = creationUserId;
        return (TEntity)this;
    }

    public TEntity SetInternalDataChange(DateTime? changeDate, long? changeUserId)
    {
        ChangeDate = changeDate;
        ChangeUserId = changeUserId;
        return (TEntity)this;
    }
}
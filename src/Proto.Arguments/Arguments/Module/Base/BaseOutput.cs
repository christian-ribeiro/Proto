using Proto.Arguments.Arguments.Module.Registration;

namespace Proto.Arguments.Arguments.Module.Base;

public class BaseOutput<TOutput> where TOutput : BaseOutput<TOutput>
{
    public long Id { get; private set; }
    public virtual DateTime CreationDate { get; private set; }
    public virtual DateTime? ChangeDate { get; private set; }
    public virtual long? CreationUserId { get; private set; }
    public virtual long? ChangeUserId { get; private set; }
    public virtual OutputUser? CreationUser { get; private set; }
    public virtual OutputUser? ChangeUser { get; private set; }

    public TOutput SetInternalData(long id, DateTime creationDate, DateTime? changeDate, long? creationUserId, long? changeUserId, OutputUser? creationUser, OutputUser? changeUser)
    {
        Id = id;
        CreationDate = creationDate;
        ChangeDate = changeDate;
        CreationUserId = creationUserId;
        ChangeUserId = changeUserId;
        CreationUser = creationUser;
        ChangeUser = changeUser;
        return (TOutput)this;
    }
}
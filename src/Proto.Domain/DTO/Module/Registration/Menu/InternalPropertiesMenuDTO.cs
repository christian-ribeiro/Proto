using System.Text.Json.Serialization;
using Proto.Domain.DTO.Module.Base;

namespace Proto.Domain.DTO.Module.Registration;

public class InternalPropertiesMenuDTO : BaseInternalPropertiesDTO<InternalPropertiesMenuDTO>
{
    public string Route { get; private set; }
    public string Description { get; private set; }
    public string Icon { get; private set; }
    public int Position { get; private set; }
    public long? ParentMenuId { get; private set; }

    public InternalPropertiesMenuDTO() { }

    [JsonConstructor]
    public InternalPropertiesMenuDTO(string route, string description, string icon, int position, long? parentMenuId)
    {
        Route = route;
        Description = description;
        Icon = icon;
        Position = position;
        ParentMenuId = parentMenuId;
    }
}
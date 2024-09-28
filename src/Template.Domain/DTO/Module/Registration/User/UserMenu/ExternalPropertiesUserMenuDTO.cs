using System.Text.Json.Serialization;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class ExternalPropertiesUserMenuDTO : BaseExternalPropertiesDTO<ExternalPropertiesUserMenuDTO>
{
    public long MenuId { get; private set; }
    public int Position { get; private set; }
    public bool Favorite { get; private set; }
    public bool Visible { get; private set; }

    public ExternalPropertiesUserMenuDTO() { }

    [JsonConstructor]
    public ExternalPropertiesUserMenuDTO(long menuId, int position, bool favorite, bool visible)
    {
        MenuId = menuId;
        Position = position;
        Favorite = favorite;
        Visible = visible;
    }
}
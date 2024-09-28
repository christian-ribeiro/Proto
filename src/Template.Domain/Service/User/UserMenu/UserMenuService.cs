using Template.Arguments.Arguments;
using Template.Arguments.Enum;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository;
using Template.Domain.Interface.Service;
using Template.Domain.Service.Base;

namespace Template.Domain.Service;

public class UserMenuService(IUserMenuRepository repository, IMenuRepository menuRepository) : BaseService_0<IUserMenuRepository, OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu, UserMenuDTO, UserMenuValidateDTO, InternalPropertiesUserMenuDTO, ExternalPropertiesUserMenuDTO, AuxiliaryPropertiesUserMenuDTO>(repository), IUserMenuService
{
    private readonly IMenuRepository _menuRepository = menuRepository;

    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<UserMenuValidateDTO> listUserMenuValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            case EnumProcessType.Create:
                break;
            case EnumProcessType.Update:
                break;
            case EnumProcessType.Delete:
                break;
        }
        return true;
    }
    #endregion

    #region Create
    public override List<long> Create(List<InputCreateUserMenu> listInputCreateUserMenu)
    {
        List<UserMenuDTO> listOriginalUserMenuDTO = _repository.GetListByListIdentifier((from i in listInputCreateUserMenu select new InputIdentifierUserMenu(0, i.MenuId)).ToList(), getOnlyPrincipal: true);
        List<MenuDTO> listRelatedMenuDTO = _menuRepository.GetListByListId((from i in listInputCreateUserMenu select i.MenuId).ToList(), true);

        var listCreate = (from i in listInputCreateUserMenu
                          let originalUserMenuDTO = (from j in listOriginalUserMenuDTO where j.ExternalPropertiesDTO.MenuId == i.MenuId select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreateUserMenu.IndexOf(i),
                              InputCreateUserMenu = i,
                              OriginalUserMenuDTO = originalUserMenuDTO,
                              RelatedMenuDTO = (from j in listRelatedMenuDTO where j.InternalPropertiesDTO.Id == i.MenuId select j).FirstOrDefault()
                          }).ToList();

        List<UserMenuValidateDTO> listUserMenuValidateDTO = (from i in listCreate select new UserMenuValidateDTO().ValidateCreate(i.InputCreateUserMenu, i.OriginalUserMenuDTO, i.RelatedMenuDTO)).ToList();
        CanExecuteProcess(listUserMenuValidateDTO, EnumProcessType.Create);
        if (!HasValidItem(listUserMenuValidateDTO))
            return [];


        List<UserMenuDTO> listCreateUserMenu = (from i in GetListValidDTO(listUserMenuValidateDTO) select new UserMenuDTO().Create(_guidSessionDataRequest, i.InputCreateUserMenu!)).ToList();
        return _repository.Create(listCreateUserMenu);
    }
    #endregion

    #region Update
    public override List<long> Update(List<InputIdentityUpdateUserMenu> listInputIdentityUpdateUserMenu)
    {
        List<UserMenuDTO> listOriginalUserMenuDTO = _repository.GetListByListId((from i in listInputIdentityUpdateUserMenu select i.Id).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdateUserMenu
                          let originalUserMenuDTO = (from j in listOriginalUserMenuDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdateUserMenu.IndexOf(i),
                              InputIdentityUpdateUserMenu = i,
                              OriginalUserMenuDTO = originalUserMenuDTO
                          }).ToList();

        List<UserMenuValidateDTO> listUserMenuValidateDTO = (from i in listUpdate select new UserMenuValidateDTO().ValidateUpdate(i.InputIdentityUpdateUserMenu, i.OriginalUserMenuDTO)).ToList();
        CanExecuteProcess(listUserMenuValidateDTO, EnumProcessType.Update);
        if (!HasValidItem(listUserMenuValidateDTO))
            return [];

        List<UserMenuDTO> listUpdateUserMenu = (from i in GetListValidDTO(listUserMenuValidateDTO) select new UserMenuDTO().Update(_guidSessionDataRequest, i.InputIdentityUpdateUserMenu!.InputUpdate!, i.OriginalUserMenuDTO!.InternalPropertiesDTO)).ToList();
        return _repository.Update(listUpdateUserMenu);
    }
    #endregion

    #region Delete
    public override bool Delete(List<InputIdentityDeleteUserMenu> listInputIdentityDeleteUserMenu)
    {
        List<UserMenuDTO> listOriginalUserMenuDTO = _repository.GetListByListId((from i in listInputIdentityDeleteUserMenu select i.Id).ToList(), true);

        var listDelete = (from i in listInputIdentityDeleteUserMenu
                          let originalUserMenuDTO = (from j in listOriginalUserMenuDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityDeleteUserMenu.IndexOf(i),
                              InputIdentityDeleteUserMenu = i,
                              OriginalUserMenuDTO = originalUserMenuDTO
                          }).ToList();

        List<UserMenuValidateDTO> listUserMenuValidateDTO = (from i in listDelete select new UserMenuValidateDTO().ValidateDelete(i.InputIdentityDeleteUserMenu, i.OriginalUserMenuDTO)).ToList();
        CanExecuteProcess(listUserMenuValidateDTO, EnumProcessType.Delete);
        if (!HasValidItem(listUserMenuValidateDTO))
            return false;


        List<UserMenuDTO> listUpdateUserMenu = (from i in GetListValidDTO(listUserMenuValidateDTO) select i.OriginalUserMenuDTO).ToList();
        return _repository.Delete(listUpdateUserMenu);
    }
    #endregion
    #endregion
}
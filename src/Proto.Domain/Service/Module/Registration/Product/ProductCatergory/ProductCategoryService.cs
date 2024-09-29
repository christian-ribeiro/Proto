using Proto.Arguments.Arguments.Module.Registration;
using Proto.Arguments.Enum;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Domain.Interface.Service.Module.Registration;
using Proto.Domain.Service.Module.Base;

namespace Proto.Domain.Service.Module.Registration;

public class ProductCategoryService(IProductCategoryRepository repository) : BaseService_0<IProductCategoryRepository, OutputProductCategory, InputIdentifierProductCategory, InputCreateProductCategory, InputUpdateProductCategory, InputIdentityUpdateProductCategory, InputIdentityDeleteProductCategory, ProductCategoryDTO, ProductCategoryValidateDTO, InternalPropertiesProductCategoryDTO, ExternalPropertiesProductCategoryDTO, AuxiliaryPropertiesProductCategoryDTO>(repository), IProductCategoryService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<ProductCategoryValidateDTO> listProductCategoryValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            case EnumProcessType.Create:
                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where i.OriginalProductCategoryDTO != null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductCategoryValidateDTO.IndexOf(i), "Já existe um registro com esse identificador")).ToList();

                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where i.InputCreateProductCategory == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductCategoryValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where InvalidLength(1, 6, i.InputCreateProductCategory?.Code)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProductCategory(i.InputCreateProductCategory!.Code), "Código deve ter entre 1 e 6 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateProductCategory?.Description)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProductCategory(i.InputCreateProductCategory!.Code), "Descrição deve ter entre 1 e 100 caracteres")).ToList();
                break;

            case EnumProcessType.Update:
                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where i.OriginalProductCategoryDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductCategoryValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where i.InputIdentityUpdateProductCategory?.InputUpdate == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductCategoryValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateProductCategory?.InputUpdate?.Description)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProductCategory!.Id, new InputIdentifierProductCategory(i.OriginalProductCategoryDTO!.ExternalPropertiesDTO.Code), "Descrição deve ter entre 1 e 100 caracteres")).ToList();

                break;
            case EnumProcessType.Delete:
                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where i.OriginalProductCategoryDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductCategoryValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listProductCategoryValidateDTO)
                     where i.InputIdentityDeleteProductCategory == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductCategoryValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                break;
        }
        return true;
    }
    #endregion

    #region Create
    public override List<long> Create(List<InputCreateProductCategory> listInputCreateProductCategory)
    {
        List<ProductCategoryDTO> listOriginalProductCategoryDTO = _repository.GetListByListIdentifier((from i in listInputCreateProductCategory select new InputIdentifierProductCategory(i.Code)).ToList(), getOnlyPrincipal: true);

        var listCreate = (from i in listInputCreateProductCategory
                          let originalProductCategoryDTO = (from j in listOriginalProductCategoryDTO where j.ExternalPropertiesDTO.Code == i.Code select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreateProductCategory.IndexOf(i),
                              InputCreateProductCategory = i,
                              OriginalProductCategoryDTO = originalProductCategoryDTO
                          }).ToList();

        List<ProductCategoryValidateDTO> listProductCategoryValidateDTO = (from i in listCreate select new ProductCategoryValidateDTO().ValidateCreate(i.InputCreateProductCategory, i.OriginalProductCategoryDTO)).ToList();
        CanExecuteProcess(listProductCategoryValidateDTO, EnumProcessType.Create);
        if (!HasValidItem(listProductCategoryValidateDTO))
            return [];


        List<ProductCategoryDTO> listCreateProductCategory = (from i in GetListValidDTO(listProductCategoryValidateDTO) select new ProductCategoryDTO().Create(_guidSessionDataRequest, i.InputCreateProductCategory!)).ToList();
        return _repository.Create(listCreateProductCategory);
    }
    #endregion

    #region Update
    public override List<long> Update(List<InputIdentityUpdateProductCategory> listInputIdentityUpdateProductCategory)
    {
        List<ProductCategoryDTO> listOriginalProductCategoryDTO = _repository.GetListByListId((from i in listInputIdentityUpdateProductCategory select i.Id).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdateProductCategory
                          let originalProductCategoryDTO = (from j in listOriginalProductCategoryDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdateProductCategory.IndexOf(i),
                              InputIdentityUpdateProductCategory = i,
                              OriginalProductCategoryDTO = originalProductCategoryDTO
                          }).ToList();

        List<ProductCategoryValidateDTO> listProductCategoryValidateDTO = (from i in listUpdate select new ProductCategoryValidateDTO().ValidateUpdate(i.InputIdentityUpdateProductCategory, i.OriginalProductCategoryDTO)).ToList();
        CanExecuteProcess(listProductCategoryValidateDTO, EnumProcessType.Update);
        if (!HasValidItem(listProductCategoryValidateDTO))
            return [];

        List<ProductCategoryDTO> listUpdateProductCategory = (from i in GetListValidDTO(listProductCategoryValidateDTO) select new ProductCategoryDTO().Update(_guidSessionDataRequest, i.InputIdentityUpdateProductCategory!.InputUpdate!, i.OriginalProductCategoryDTO!.InternalPropertiesDTO)).ToList();
        return _repository.Update(listUpdateProductCategory);
    }
    #endregion

    #region Delete
    public override bool Delete(List<InputIdentityDeleteProductCategory> listInputIdentityDeleteProductCategory)
    {
        List<ProductCategoryDTO> listOriginalProductCategoryDTO = _repository.GetListByListId((from i in listInputIdentityDeleteProductCategory select i.Id).ToList(), true);

        var listDelete = (from i in listInputIdentityDeleteProductCategory
                          let originalProductCategoryDTO = (from j in listOriginalProductCategoryDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityDeleteProductCategory.IndexOf(i),
                              InputIdentityDeleteProductCategory = i,
                              OriginalProductCategoryDTO = originalProductCategoryDTO
                          }).ToList();

        List<ProductCategoryValidateDTO> listProductCategoryValidateDTO = (from i in listDelete select new ProductCategoryValidateDTO().ValidateDelete(i.InputIdentityDeleteProductCategory, i.OriginalProductCategoryDTO)).ToList();
        CanExecuteProcess(listProductCategoryValidateDTO, EnumProcessType.Delete);
        if (!HasValidItem(listProductCategoryValidateDTO))
            return false;


        List<ProductCategoryDTO> listUpdateProductCategory = (from i in GetListValidDTO(listProductCategoryValidateDTO) select i.OriginalProductCategoryDTO).ToList();
        return _repository.Delete(listUpdateProductCategory);
    }
    #endregion
    #endregion
}
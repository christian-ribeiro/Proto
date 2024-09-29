using Proto.Arguments.Arguments.Module.Registration;
using Proto.Arguments.Enum;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Domain.Interface.Service.Module.Registration;
using Proto.Domain.Service.Module.Base;

namespace Proto.Domain.Service.Module.Registration;

public class BrandService(IBrandRepository repository) : BaseService_0<IBrandRepository, OutputBrand, InputIdentifierBrand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, BrandDTO, BrandValidateDTO, InternalPropertiesBrandDTO, ExternalPropertiesBrandDTO, AuxiliaryPropertiesBrandDTO>(repository), IBrandService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<BrandValidateDTO> listBrandValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            case EnumProcessType.Create:
                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where i.OriginalBrandDTO != null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where i.InputCreateBrand == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where InvalidLength(1, 6, i.InputCreateBrand?.Code)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateBrand?.Description)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();
                break;
            case EnumProcessType.Update:
                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where i.OriginalBrandDTO == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where i.InputIdentityUpdateBrand?.InputUpdate == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateBrand?.InputUpdate?.Description)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                break;
            case EnumProcessType.Delete:
                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where i.OriginalBrandDTO == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listBrandValidateDTO)
                     where i.InputIdentityDeleteBrand == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                break;
        }
        return true;
    }
    #endregion

    #region Create
    public override List<long> Create(List<InputCreateBrand> listInputCreateBrand)
    {
        List<BrandDTO> listOriginalBrandDTO = _repository.GetListByListIdentifier((from i in listInputCreateBrand select new InputIdentifierBrand(i.Code)).ToList(), getOnlyPrincipal: true);

        var listCreate = (from i in listInputCreateBrand
                          let originalBrandDTO = (from j in listOriginalBrandDTO where j.ExternalPropertiesDTO.Code == i.Code select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreateBrand.IndexOf(i),
                              InputCreateBrand = i,
                              OriginalBrandDTO = originalBrandDTO
                          }).ToList();

        List<BrandValidateDTO> listBrandValidateDTO = (from i in listCreate select new BrandValidateDTO().ValidateCreate(i.InputCreateBrand, i.OriginalBrandDTO)).ToList();
        CanExecuteProcess(listBrandValidateDTO, EnumProcessType.Create);
        if (!HasValidItem(listBrandValidateDTO))
            return [];


        List<BrandDTO> listCreateBrand = (from i in GetListValidDTO(listBrandValidateDTO) select new BrandDTO().Create(_guidSessionDataRequest, i.InputCreateBrand!)).ToList();
        return _repository.Create(listCreateBrand);
    }
    #endregion

    #region Update
    public override List<long> Update(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand)
    {
        List<BrandDTO> listOriginalBrandDTO = _repository.GetListByListId((from i in listInputIdentityUpdateBrand select i.Id).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdateBrand
                          let originalBrandDTO = (from j in listOriginalBrandDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdateBrand.IndexOf(i),
                              InputIdentityUpdateBrand = i,
                              OriginalBrandDTO = originalBrandDTO
                          }).ToList();

        List<BrandValidateDTO> listBrandValidateDTO = (from i in listUpdate select new BrandValidateDTO().ValidateUpdate(i.InputIdentityUpdateBrand, i.OriginalBrandDTO)).ToList();
        CanExecuteProcess(listBrandValidateDTO, EnumProcessType.Update);
        if (!HasValidItem(listBrandValidateDTO))
            return [];

        List<BrandDTO> listUpdateBrand = (from i in GetListValidDTO(listBrandValidateDTO) select new BrandDTO().Update(_guidSessionDataRequest, i.InputIdentityUpdateBrand!.InputUpdate!, i.OriginalBrandDTO!.InternalPropertiesDTO)).ToList();
        return _repository.Update(listUpdateBrand);
    }
    #endregion

    #region Delete
    public override bool Delete(List<InputIdentityDeleteBrand> listInputIdentityDeleteBrand)
    {
        List<BrandDTO> listOriginalBrandDTO = _repository.GetListByListId((from i in listInputIdentityDeleteBrand select i.Id).ToList(), true);

        var listDelete = (from i in listInputIdentityDeleteBrand
                          let originalBrandDTO = (from j in listOriginalBrandDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityDeleteBrand.IndexOf(i),
                              InputIdentityDeleteBrand = i,
                              OriginalBrandDTO = originalBrandDTO
                          }).ToList();

        List<BrandValidateDTO> listBrandValidateDTO = (from i in listDelete select new BrandValidateDTO().ValidateDelete(i.InputIdentityDeleteBrand, i.OriginalBrandDTO)).ToList();
        CanExecuteProcess(listBrandValidateDTO, EnumProcessType.Delete);
        if (!HasValidItem(listBrandValidateDTO))
            return false;


        List<BrandDTO> listUpdateBrand = (from i in GetListValidDTO(listBrandValidateDTO) select i.OriginalBrandDTO).ToList();
        return _repository.Delete(listUpdateBrand);
    }
    #endregion
    #endregion
}
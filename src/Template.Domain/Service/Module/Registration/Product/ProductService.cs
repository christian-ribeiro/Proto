using Template.Arguments.Arguments.Module.Registration;
using Template.Arguments.Enum;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Registration;
using Template.Domain.Interface.Service.Module.Registration;
using Template.Domain.Service.Module.Base;

namespace Template.Domain.Service.Module.Registration;

public class ProductService(IProductRepository repository, IBrandRepository brandRepository) : BaseService_0<IProductRepository, OutputProduct, InputIdentifierProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, ProductDTO, ProductValidateDTO, InternalPropertiesProductDTO, ExternalPropertiesProductDTO, AuxiliaryPropertiesProductDTO>(repository), IProductService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<ProductValidateDTO> listProductValidateDTO, EnumProcessType processType)
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
    public override List<long> Create(List<InputCreateProduct> listInputCreateProduct)
    {
        List<ProductDTO> listOriginalProductDTO = _repository.GetListByListIdentifier((from i in listInputCreateProduct select new InputIdentifierProduct(i.Code)).ToList(), getOnlyPrincipal: true);
        List<BrandDTO> listRelatedBrandDTO = brandRepository.GetListByListId((from i in listInputCreateProduct select i.BrandId).ToList(), true);

        var listCreate = (from i in listInputCreateProduct
                          let originalProductDTO = (from j in listOriginalProductDTO where j.ExternalPropertiesDTO.Code == i.Code select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreateProduct.IndexOf(i),
                              InputCreateProduct = i,
                              OriginalProductDTO = originalProductDTO,
                              RelatedBrandDTO = (from j in listRelatedBrandDTO where j.InternalPropertiesDTO.Id == i.BrandId select j).FirstOrDefault(),
                          }).ToList();

        List<ProductValidateDTO> listProductValidateDTO = (from i in listCreate select new ProductValidateDTO().ValidateCreate(i.InputCreateProduct, i.OriginalProductDTO, i.RelatedBrandDTO)).ToList();
        CanExecuteProcess(listProductValidateDTO, EnumProcessType.Create);
        if (!HasValidItem(listProductValidateDTO))
            return [];


        List<ProductDTO> listCreateProduct = (from i in GetListValidDTO(listProductValidateDTO) select new ProductDTO().Create(_guidSessionDataRequest, i.InputCreateProduct!)).ToList();
        return _repository.Create(listCreateProduct);
    }
    #endregion

    #region Update
    public override List<long> Update(List<InputIdentityUpdateProduct> listInputIdentityUpdateProduct)
    {
        List<ProductDTO> listOriginalProductDTO = _repository.GetListByListId((from i in listInputIdentityUpdateProduct select i.Id).ToList(), true);
        List<BrandDTO> listRelatedBrandDTO = brandRepository.GetListByListId((from i in listInputIdentityUpdateProduct select i.InputUpdate!.BrandId).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdateProduct
                          let originalProductDTO = (from j in listOriginalProductDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdateProduct.IndexOf(i),
                              InputIdentityUpdateProduct = i,
                              OriginalProductDTO = originalProductDTO,
                              RelatedBrandDTO = (from j in listRelatedBrandDTO where j.InternalPropertiesDTO.Id == i.InputUpdate!.BrandId select j).FirstOrDefault(),
                          }).ToList();

        List<ProductValidateDTO> listProductValidateDTO = (from i in listUpdate select new ProductValidateDTO().ValidateUpdate(i.InputIdentityUpdateProduct, i.OriginalProductDTO, i.RelatedBrandDTO)).ToList();
        CanExecuteProcess(listProductValidateDTO, EnumProcessType.Update);
        if (!HasValidItem(listProductValidateDTO))
            return [];

        List<ProductDTO> listUpdateProduct = (from i in GetListValidDTO(listProductValidateDTO) select new ProductDTO().Update(_guidSessionDataRequest, new ExternalPropertiesProductDTO(i.OriginalProductDTO!.ExternalPropertiesDTO.Code, i.InputIdentityUpdateProduct!.InputUpdate!.Description, i.InputIdentityUpdateProduct!.InputUpdate!.BarCode, i.InputIdentityUpdateProduct!.InputUpdate!.CostValue, i.InputIdentityUpdateProduct!.InputUpdate!.SaleValue, i.InputIdentityUpdateProduct!.InputUpdate!.Status, i.InputIdentityUpdateProduct!.InputUpdate!.Weight, i.InputIdentityUpdateProduct!.InputUpdate!.NetWeight, i.InputIdentityUpdateProduct!.InputUpdate!.Observation, i.InputIdentityUpdateProduct!.InputUpdate!.BrandId), i.OriginalProductDTO!.InternalPropertiesDTO)).ToList();
        return _repository.Update(listUpdateProduct);
    }
    #endregion

    #region Delete
    public override bool Delete(List<InputIdentityDeleteProduct> listInputIdentityDeleteProduct)
    {
        List<ProductDTO> listOriginalProductDTO = _repository.GetListByListId((from i in listInputIdentityDeleteProduct select i.Id).ToList(), true);

        var listDelete = (from i in listInputIdentityDeleteProduct
                          let originalProductDTO = (from j in listOriginalProductDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityDeleteProduct.IndexOf(i),
                              InputIdentityDeleteProduct = i,
                              OriginalProductDTO = originalProductDTO
                          }).ToList();

        List<ProductValidateDTO> listProductValidateDTO = (from i in listDelete select new ProductValidateDTO().ValidateDelete(i.InputIdentityDeleteProduct, i.OriginalProductDTO)).ToList();
        CanExecuteProcess(listProductValidateDTO, EnumProcessType.Delete);
        if (!HasValidItem(listProductValidateDTO))
            return false;


        List<ProductDTO> listUpdateProduct = (from i in GetListValidDTO(listProductValidateDTO) select i.OriginalProductDTO).ToList();
        return _repository.Delete(listUpdateProduct);
    }
    #endregion
    #endregion
}
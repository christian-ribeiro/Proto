using Proto.Arguments.Arguments.Module.Registration;
using Proto.Arguments.Enum;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Domain.Interface.Service.Module.Registration;
using Proto.Domain.Service.Module.Base;

namespace Proto.Domain.Service.Module.Registration;

public class ProductService(IProductRepository repository, IBrandRepository brandRepository, IProductCategoryRepository productCategoryRepository) : BaseService_0<IProductRepository, OutputProduct, InputIdentifierProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, ProductDTO, ProductValidateDTO, InternalPropertiesProductDTO, ExternalPropertiesProductDTO, AuxiliaryPropertiesProductDTO>(repository), IProductService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<ProductValidateDTO> listProductValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            case EnumProcessType.Create:
                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where i.OriginalProductDTO != null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductValidateDTO.IndexOf(i), "Já existe um registro com esse identificador")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where i.InputCreateProduct == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidLength(1, 6, i.InputCreateProduct?.Code)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Código deve ter entre 1 e 6 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateProduct?.Description)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Descrição deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateProduct?.BarCode)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Código de barras deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputCreateProduct?.CostValue)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Valor de custo não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputCreateProduct?.SaleValue)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Valor de venda não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputCreateProduct?.Weight)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Peso não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputCreateProduct?.NetWeight)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Peso líquido não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidLength(0, 400, i.InputCreateProduct?.Observation)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Observação deve ter entre 0 e 400 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidRelatedProperty(i.InputCreateProduct!.BrandId, i.RelatedBrandDTO)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Informe uma marca válida")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidRelatedProperty(i.InputCreateProduct!.ProductCategoryId, i.RelatedProductCategoryDTO)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierProduct(i.InputCreateProduct!.Code), "Informe uma categoria válida")).ToList();

                break;
            case EnumProcessType.Update:
                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where i.OriginalProductDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where i.InputIdentityUpdateProduct?.InputUpdate == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateProduct?.InputUpdate?.Description)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Descrição deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateProduct?.InputUpdate?.BarCode)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Código de barras deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputIdentityUpdateProduct?.InputUpdate?.CostValue)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Valor de custo não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputIdentityUpdateProduct?.InputUpdate?.SaleValue)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Valor de venda não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputIdentityUpdateProduct?.InputUpdate?.Weight)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Peso não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where DecimalLowerThan(0, i.InputIdentityUpdateProduct?.InputUpdate?.NetWeight)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Peso líquido não pode ser menor que 0")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidLength(0, 400, i.InputIdentityUpdateProduct?.InputUpdate?.Observation)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Observação deve ter entre 0 e 400 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidRelatedProperty(i.InputIdentityUpdateProduct?.InputUpdate!.BrandId, i.RelatedBrandDTO)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Informe uma marca válida")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where InvalidRelatedProperty(i.InputIdentityUpdateProduct?.InputUpdate!.ProductCategoryId, i.RelatedProductCategoryDTO)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateProduct!.Id, new InputIdentifierProduct(i.OriginalProductDTO!.ExternalPropertiesDTO.Code), "Informe uma categoria válida")).ToList();

                break;
            case EnumProcessType.Delete:
                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where i.OriginalProductDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listProductValidateDTO)
                     where i.InputIdentityDeleteProduct == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listProductValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

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
        List<ProductCategoryDTO> listRelatedProductCategoryDTO = productCategoryRepository.GetListByListId((from i in listInputCreateProduct where i.ProductCategoryId != null select i.ProductCategoryId!.Value).ToList(), true);

        var listCreate = (from i in listInputCreateProduct
                          let originalProductDTO = (from j in listOriginalProductDTO where j.ExternalPropertiesDTO.Code == i.Code select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreateProduct.IndexOf(i),
                              InputCreateProduct = i,
                              OriginalProductDTO = originalProductDTO,
                              RelatedBrandDTO = (from j in listRelatedBrandDTO where j.InternalPropertiesDTO.Id == i.BrandId select j).FirstOrDefault(),
                              RelatedProductCategoryDTO = (from j in listRelatedProductCategoryDTO where j.InternalPropertiesDTO.Id == i.ProductCategoryId select j).FirstOrDefault(),
                          }).ToList();

        List<ProductValidateDTO> listProductValidateDTO = (from i in listCreate select new ProductValidateDTO().ValidateCreate(i.InputCreateProduct, i.OriginalProductDTO, i.RelatedBrandDTO, i.RelatedProductCategoryDTO)).ToList();
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
        List<ProductCategoryDTO> listRelatedProductCategoryDTO = productCategoryRepository.GetListByListId((from i in listInputIdentityUpdateProduct where i.InputUpdate!.ProductCategoryId != null select i.InputUpdate!.ProductCategoryId!.Value).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdateProduct
                          let originalProductDTO = (from j in listOriginalProductDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdateProduct.IndexOf(i),
                              InputIdentityUpdateProduct = i,
                              OriginalProductDTO = originalProductDTO,
                              RelatedBrandDTO = (from j in listRelatedBrandDTO where j.InternalPropertiesDTO.Id == i.InputUpdate!.BrandId select j).FirstOrDefault(),
                              RelatedProductCategoryDTO = (from j in listRelatedProductCategoryDTO where j.InternalPropertiesDTO.Id == i.InputUpdate!.ProductCategoryId select j).FirstOrDefault(),
                          }).ToList();

        List<ProductValidateDTO> listProductValidateDTO = (from i in listUpdate select new ProductValidateDTO().ValidateUpdate(i.InputIdentityUpdateProduct, i.OriginalProductDTO, i.RelatedBrandDTO, i.RelatedProductCategoryDTO)).ToList();
        CanExecuteProcess(listProductValidateDTO, EnumProcessType.Update);
        if (!HasValidItem(listProductValidateDTO))
            return [];

        List<ProductDTO> listUpdateProduct = (from i in GetListValidDTO(listProductValidateDTO) select new ProductDTO().Update(_guidSessionDataRequest, new ExternalPropertiesProductDTO(i.OriginalProductDTO!.ExternalPropertiesDTO.Code, i.InputIdentityUpdateProduct!.InputUpdate!.Description, i.InputIdentityUpdateProduct!.InputUpdate!.BarCode, i.InputIdentityUpdateProduct!.InputUpdate!.CostValue, i.InputIdentityUpdateProduct!.InputUpdate!.SaleValue, i.InputIdentityUpdateProduct!.InputUpdate!.Status, i.InputIdentityUpdateProduct!.InputUpdate!.Weight, i.InputIdentityUpdateProduct!.InputUpdate!.NetWeight, i.InputIdentityUpdateProduct!.InputUpdate!.Observation, i.InputIdentityUpdateProduct!.InputUpdate!.BrandId, i.InputIdentityUpdateProduct!.InputUpdate!.ProductCategoryId), i.OriginalProductDTO!.InternalPropertiesDTO)).ToList();
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
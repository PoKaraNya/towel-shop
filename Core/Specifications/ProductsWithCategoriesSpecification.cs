using Core.Entities;

namespace Core.Specifications;

public class ProductsWithCategoriesSpecification : BaseSpecification<Product>
{
    public ProductsWithCategoriesSpecification(ProductSpecParams productSpecParams)
        : base(x =>
            (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
            &&
            (!productSpecParams.CategoryId.HasValue || x.ProductCategoryId == productSpecParams.CategoryId)
        )
    {
        AddInclude(x => x.ProductCategory);
        AddOrderBy(x => x.Name);
        ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

        if (!string.IsNullOrEmpty(productSpecParams.Sort))
        {
            switch (productSpecParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
    }

    public ProductsWithCategoriesSpecification(int id)
        : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductCategory);
    }
}
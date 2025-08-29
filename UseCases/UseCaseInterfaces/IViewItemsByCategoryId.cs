using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewItemsByCategoryId
    {
        IEnumerable<Item> Execute(int categoryId);
    }
}
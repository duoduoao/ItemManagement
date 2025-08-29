using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewItemsUseCase
    {
        IEnumerable<Item> Execute();
    }
}
using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewItemsUseCase : IViewItemsUseCase
    {
        private readonly IItemRepository itemRepository;

        public ViewItemsUseCase(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public IEnumerable<Item> Execute()
        {
            return itemRepository.GetItems();
        }
    }
}

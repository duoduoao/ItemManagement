using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetItemByIdUseCase : IGetItemByIdUseCase
    {
        private readonly IItemRepository itemRepository;

        public GetItemByIdUseCase(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public Item Execute(int ItemId)
        {
            return itemRepository.GetItemById(ItemId);
        }
    }
}

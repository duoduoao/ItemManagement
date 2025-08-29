using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddItemUseCase : IAddItemUseCase
    {
        private readonly IItemRepository ItemRepository;

        public AddItemUseCase(IItemRepository ItemRepository)
        {
            this.ItemRepository = ItemRepository;
        }

        public void Execute(Item Item)
        {
            ItemRepository.AddItem(Item);
        }
    }
}

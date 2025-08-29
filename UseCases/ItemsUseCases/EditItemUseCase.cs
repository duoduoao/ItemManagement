using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditItemUseCase : IEditItemUseCase
    {
        private readonly IItemRepository itemRepository;

        public EditItemUseCase(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void Execute(Item Item)
        {
            itemRepository.UpdateItem(Item);
        }
    }
}

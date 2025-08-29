using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteItemtUseCase : IDeleteItemUseCase
    {
        private readonly IItemRepository ItemRepository;

        public DeleteItemtUseCase(IItemRepository ItemRepository)
        {
            this.ItemRepository = ItemRepository;
        }

        public void Execute(int ItemId)
        {
            ItemRepository.DeleteItem(ItemId);
        }
    }
}

using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{

    //for selling
    public class ViewItemsByCategoryId : IViewItemsByCategoryId
    {
        private readonly IItemRepository itemRepository;

        public ViewItemsByCategoryId(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public IEnumerable<Item> Execute(int categoryId)
        {
            return itemRepository.GetItemsByCategoryId(categoryId);
        }
    }
}

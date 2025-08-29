using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        void AddItem(Item Item);
        void UpdateItem(Item Item);
        Item GetItemById(int ItemId);
        void DeleteItem(int ItemId);
        IEnumerable<Item> GetItemsByCategoryId(int categoryId);
    }
}

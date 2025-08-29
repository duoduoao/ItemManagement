using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ItemInMemoryRepository : IItemRepository
    {
        private List<Item> Items;

        public ItemInMemoryRepository()
        {
            // Init with default values
            Items = new List<Item>()
            {
                new Item { ItemId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99},
                new Item { ItemId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99},
                new Item { ItemId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50},
                new Item { ItemId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50},
            };
        }

        public void AddItem(Item Item)
        {
            if (Items.Any(x => x.Name.Equals(Item.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (Items != null && Items.Count > 0)
            {
                var maxId = Items.Max(x => x.ItemId);
                Item.ItemId = maxId + 1;
            }
            else
            {
                Item.ItemId = 1;
            }


            Items.Add(Item);
        }

        public IEnumerable<Item> GetItems()
        {
            return Items;
        }

        public void UpdateItem(Item Item)
        {
            var ItemToUpdate = GetItemById(Item.ItemId);
            if (ItemToUpdate != null)
            {
                ItemToUpdate.Name = Item.Name;
                ItemToUpdate.CategoryId = Item.CategoryId;
                ItemToUpdate.Price = Item.Price;
                ItemToUpdate.Quantity = Item.Quantity;
            }
        }

        public Item GetItemById(int ItemId)
        {
            return Items.FirstOrDefault(x => x.ItemId == ItemId);
        }

        public void DeleteItem(int ItemId)
        {
            var ItemToDelete = GetItemById(ItemId);
            if (ItemToDelete != null) Items.Remove(ItemToDelete);
        }

        public IEnumerable<Item> GetItemsByCategoryId(int categoryId)
        {
            return Items.Where(x => x.CategoryId == categoryId);
        }
    }
}

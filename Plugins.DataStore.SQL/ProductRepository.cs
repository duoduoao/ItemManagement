using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ItemRepository : IItemRepository
    {
        private readonly MarketContext db;

        public ItemRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddItem(Item Item)
        {
            db.Items.Add(Item);
            db.SaveChanges();
        }

        public void DeleteItem(int ItemId)
        {
            var Item = db.Items.Find(ItemId);
            if (Item == null) return;

            db.Items.Remove(Item);
            db.SaveChanges();
        }

        public Item GetItemById(int ItemId)
        {
            return db.Items.Find(ItemId);
        }

        public IEnumerable<Item> GetItems()
        {
            return db.Items.ToList();
        }

        public IEnumerable<Item> GetItemsByCategoryId(int categoryId)
        {
            return db.Items.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateItem(Item Item)
        {
            var prod = db.Items.Find(Item.ItemId);
            prod.CategoryId = Item.CategoryId;
            prod.Name = Item.Name;
            prod.Price = Item.Price;
            prod.Quantity = Item.Quantity;

            db.SaveChanges();
        }
    }
}

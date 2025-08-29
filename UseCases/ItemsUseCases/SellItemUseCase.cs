using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class SellItemUseCase : ISellItemUseCase
    {
        private readonly IItemRepository itemRepository;
        private readonly IRecordTransactionUseCase recordTransactionUseCase;

        public SellItemUseCase(
            IItemRepository itemRepository,
            IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.itemRepository = itemRepository;
            this.recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName, int itemId, int qtyToSell)
        {
            var item = itemRepository.GetItemById(itemId);
            if (item == null) return;
            
            //need update Tran first, then update Prod - fix load issue
            recordTransactionUseCase.Execute(cashierName, itemId, qtyToSell);
            item.Quantity -= qtyToSell;
            itemRepository.UpdateItem(item);            
        }
    }
}

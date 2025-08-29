using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetItemByIdUseCase getItemByIdUseCase;

        public RecordTransactionUseCase(
            ITransactionRepository transactionRepository,
            IGetItemByIdUseCase getItemByIdUseCase)
        {
            this.transactionRepository = transactionRepository;
            this.getItemByIdUseCase = getItemByIdUseCase;
        }

        public void Execute(string cashierName, int ItemId, int qty)
        {
            var Item = getItemByIdUseCase.Execute(ItemId);
            transactionRepository.Save(cashierName, ItemId, Item.Name, Item.Price.Value, Item.Quantity.Value, qty);
        }
    }
}

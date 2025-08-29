namespace UseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int itemId, int qty);
    }
}
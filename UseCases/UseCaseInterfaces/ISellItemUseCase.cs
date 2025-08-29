namespace UseCases
{
    public interface ISellItemUseCase
    {
        void Execute(string cashierName, int itemId, int qtyToSell);
    }
}
using CoreBusiness;

namespace UseCases
{
    public interface IGetItemByIdUseCase
    {
        Item Execute(int ItemId);
    }
}
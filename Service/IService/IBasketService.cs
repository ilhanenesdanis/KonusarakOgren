using Core.Entity;
using Core.IService;
using DTO;

namespace Service.IService
{
    public interface IBasketService:IService<Basket>
    {
        List<BasketDto> GetMemberBasket(int memberId); 
    }
}

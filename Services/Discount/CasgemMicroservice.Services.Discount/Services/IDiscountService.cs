using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Model;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Services.Discount.Services
{
	public interface IDiscountService
	{
		Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponAsync();
		Task<Response<ResultDiscountDto>> GetByIdDiscountCouponAsync(int id);
		Task<Response<NoContent>> CreateDiscountCouponsAsync(CreateDiscountDto createDiscountDto);
		Task<Response<NoContent>> UpdateDiscountCouponsAsync(UpdateDiscountDto updateDiscountDto);
		Task<Response<NoContent>> DeleteDiscountCouponsAsync(int id);


	}
}

using Dapper;
using ECommerce.Discount.Context;
using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        // Dapper ORM'i ile ekleme işlemi bu şekilde yapılır ADONET'ten daha yavaştır ancak daha az kodla aynı işi yapar 
        // Hız olarak ADONET- Dapper- EntityFrameWork'tür. ADONET en hızlıdır.
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "insert into Coupons (CouponCode, CouponRate, IsActive, CouponValidDate) values (@couponCode, @couponRate, @isActive, @couponValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", createDiscountCouponDto.CouponCode);
            parameters.Add("@couponRate", createDiscountCouponDto.CouponRate);
            parameters.Add("@isActive", createDiscountCouponDto.IsActive);
            parameters.Add("@couponValidDate", createDiscountCouponDto.CouponValidDate);
            using (var connection = _dapperContext.createConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete from Coupons where CouponID = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.createConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _dapperContext.createConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * from Coupons where CouponID = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.createConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string couponCode)
        {
            string query = "Select * from Coupons where CouponCode = @couponCode";
            var parameter = new DynamicParameters();
            parameter.Add("@couponCode", couponCode);
            using (var connection = _dapperContext.createConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameter);
                return values;
            }
        }

        public int GetDiscountCouponCouponRate(string couponCode)
        {
            string query = "Select CouponRate from Coupons where CouponCode = @couponCode";
            var parameter = new DynamicParameters();
            parameter.Add("@couponCode", couponCode);
            using (var connection = _dapperContext.createConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameter);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "Update Coupons Set CouponCode = @couponCode, CouponRate = @couponRate, IsActive = @isActive, CouponValidDate = @couponValidDate where(CouponID = @couponId)";
            
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", updateDiscountCouponDto.CouponCode);
            parameters.Add("@couponRate", updateDiscountCouponDto.CouponRate);
            parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
            parameters.Add("@couponValidDate", updateDiscountCouponDto.CouponValidDate);
            parameters.Add("@couponId", updateDiscountCouponDto.CouponID);
            using (var connection = _dapperContext.createConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

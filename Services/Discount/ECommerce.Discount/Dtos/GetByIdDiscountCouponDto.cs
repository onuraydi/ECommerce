namespace ECommerce.Discount.Dtos
{
    public class GetByIdDiscountCouponDto
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int CouponRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CouponValidDate { get; set; }
    }
}

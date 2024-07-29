namespace ECommerce.Discount.Dtos
{
    public class UpdateDiscountCouponDto
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int CouponRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CouponValidDate { get; set; }
    }
}

namespace ECommerce.Discount.Dtos
{
    public class CreateDiscountCouponDto
    {
        public string CouponCode { get; set; }
        public int CouponRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CouponValidDate { get; set; }
    }
}

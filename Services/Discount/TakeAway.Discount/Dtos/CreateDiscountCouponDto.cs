﻿namespace TakeAway.Discount.Dtos
{
    public class CreateDiscountCouponDto
    {
        //public int CouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
    }
}

﻿namespace Inventory.Managment.Core.Specification.product_specs
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 10;
        private int pageSize = MaxPageSize;


        public int PageSize
        {
            get { return pageSize; }
            set => pageSize = value > MaxPageSize || value <= 0 ? MaxPageSize : value;
        }

        public string? Search { get; set; }

        public int PageIndex { get; set; } = 1;

        public string? Sort { get; set; }

        public int? CategoryId { get; set; }
    }
}

﻿namespace Event_Sourcing_with_CQRS.Infrastructure
{
    public class ProductReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

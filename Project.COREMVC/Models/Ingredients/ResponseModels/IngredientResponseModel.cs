﻿namespace Project.COREMVC.Models.Ingredients.ResponseModels
{
    public class IngredientResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

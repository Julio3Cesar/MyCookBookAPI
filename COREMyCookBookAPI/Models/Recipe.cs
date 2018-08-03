
using System;

namespace COREMyCookBookAPI.Models
{
    public class Recipe : Entity
    {
        public String Title { get; set; }
        public String Type { get; set; }
        public String Cuisine { get; set; }
        public String Difficulty { get; set; }
        public Double PreparationTime { get; set; }
        public String Ingredients { get; set; }
        public String Preparation { get; set; }
    }
}

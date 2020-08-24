

namespace DAN_LV_Milica_Karetic.Model
{
    /// <summary>
    /// Pizza order class
    /// </summary>
    class OrderPizza
    {
        public int OrderID { get; set; }
        public string Size { get; set; }
        //public SortedList<string, bool?> Ingredients { get; set; }
        public bool Salami { get; set; }
        public bool Ham { get; set; }
        public bool Kulen { get; set; }
        public bool Ketchup { get; set; }
        public bool ChillyPepper { get; set; }
        public bool Mayonnaise { get; set; }
        public bool Olives { get; set; }
        public bool Oregano { get; set; }
        public bool Sesame { get; set; }
        public bool Cheese { get; set; }


        //public OrderPizza()
        //{
        //    Ingredients = new SortedList<string, bool?>
        //    {
        //        { "Salami", false },
        //        { "Ham", false },
        //        { "Kulen", false },
        //        { "Ketchup", false },
        //        { "Mayonnaise", false },
        //        { "Chilly pepper", false },
        //        { "Olives", false },
        //        { "Oregano", false },
        //        { "Sesame", false },
        //        { "Cheese", false }
        //    };
        //}
    }
}

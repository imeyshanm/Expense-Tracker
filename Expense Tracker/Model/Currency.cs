using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Model
{
    public class Currency
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }

    }
}

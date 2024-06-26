﻿using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Model
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}

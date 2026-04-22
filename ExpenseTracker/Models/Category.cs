using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        [Key]
<<<<<<< HEAD
        //id
=======
>>>>>>> 0c97ba31be0c7b46906025f42adb5601357ead19
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<ExpenseTracker> Expenses { get; set; } = new List<ExpenseTracker>();
    }
}

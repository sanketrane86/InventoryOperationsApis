using System.ComponentModel.DataAnnotations;

namespace InventoryOperationsApis.Models.RequestModels
{
    public class TableOperations
    {
        public TableOperations() {
        
        }

        public string? FilterTerm { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
        public int SortIndex { get; set; }

        [Required]
        public string? SortDirection { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
        public int StartRowNum { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
        public int EndRowNum { get; set; }

    }
    public class TablePaging
    {
        public TablePaging()
        {

        }
        public int iTotalDisplayRecords { get; set; }
        public int iTotalRecords { get; set; }
    }
}

namespace TinyLibraryWeb_M3.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsBorrowed { get; set; }
        public string BorrowedBy { get; set; }
        public string DueDate { get; set; }
    }
}

using System.Runtime.Serialization;

namespace TinyLibraryWeb_M3.Services
{
    [DataContract]
    public class LoanItemDTO
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public string User { get; set; }
        [DataMember] public string DueDate { get; set; }   // yyyy-MM-dd
    }
}

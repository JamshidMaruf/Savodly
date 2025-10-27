namespace Savodly.Domain.Entities;

public class CourseChatMessageFile : Auditable
{ 
    public int CourseChatMessageId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }

    public CourseChatMessage CourseChatMessage { get; set; }
}


namespace Savodly.Domain.Entities;

public class OnlineLesson : Auditable
{
    public int CourseId {  get; set; }
    public DateTime StartTime { get; set; }
    public string ZoomLink { get; set; }
    public string GoogleMeetLink { get; set; }

    public Course Course { get; set; }
}
namespace lr2;

public class TimeOfDayService
{
    public string GetTimeOfDayMessage()
    {
        var hour = DateTime.Now.Hour;
        return hour switch
        {
            >= 12 and < 18 => "зараз день",
            >= 18 and < 24 => "зараз вечір",
            >= 0 and < 6 => "зараз ніч",
            _ => "зараз ранок"
        };
    }
}
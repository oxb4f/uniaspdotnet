namespace lr2;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("time-of-day")]
public class TimeOfDayController(TimeOfDayService timeOfDayService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetTimeOfDay() => Ok(timeOfDayService.GetTimeOfDayMessage());
}

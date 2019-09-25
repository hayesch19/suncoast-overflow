using Microsoft.AspNetCore.Mvc;
using suncoast_overflow.Models;

namespace suncoast_overflow.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class QuestionsController : ControllerBase
  {
    private DatabaseContext context;

    public QuestionsController(DatabaseContext _context)
    {
      this.context = _context;
    }

    // Create Question
    [HttpPost]
    public ActionResult<Questions> CreateEntry([FromBody] Questions entry)
    {
      context.Question.Add(entry);
      context.SaveChanges();
      return entry;
    }
  }
}
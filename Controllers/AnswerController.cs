using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using suncoast_overflow.Models;


namespace suncoast_overflow.Controllers
{


  [Route("api/[controller]")]
  [ApiController]
  public class AnswersController : ControllerBase
  {
    private DatabaseContext context;

    public AnswersController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpPost]
    public ActionResult<Answers> CreateEntry([FromBody] Answers entry)
    {
      context.Answer.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Answers>> GetAllAnswers()
    {
      var a = context.Answer.OrderByDescending(l => l.DateAsked);
      return a.ToList();
    }

  }

}
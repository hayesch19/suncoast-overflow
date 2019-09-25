using System.Collections.Generic;
using System.Linq;
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

    // Get A Question
    // [HttpGet("{id}")]
    // public ActionResult GetOneItem(int id)
    // {
    //   var question = context.Question.FirstOrDefault(q => q.Id == id);
    //   if (question == null)
    //   {
    //     return NotFound();
    //   }
    //   else
    //   {
    //     return Ok(question);
    //   }
    // }

    // Get All Questions
    // [HttpGet]
    // public ActionResult<IEnumerable<Questions>> GetAllItems()
    // {
    //   var question = context.Question.OrderByDescending(question => question.DateAsked);
    //   return question.ToList();
    // }
    // Delete A Question
  }
}
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

    // Create Answer
    [HttpPost]
    public ActionResult<Answers> CreateEntry([FromBody] Answers entry)
    {
      context.Answer.Add(entry);
      context.SaveChanges();
      return entry;
    }
    // Get All Answers
    [HttpGet]
    public ActionResult<IEnumerable<Answers>> GetAllItems()
    {
      var answers = context.Answer.OrderByDescending(answer => answer.DateAsked);
      return answers.ToList();
    }
    // Get A Answer
    [HttpGet("{id}")]
    public ActionResult GetOneItem(int id)
    {
      var answer = context.Answer.FirstOrDefault(a => a.Id == id);
      if (answer == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(answer);
      }
    }
    // Update Answer
    [HttpPut("{id}")]
    public ActionResult<Answers> UpdateAnswer(int id, [FromBody]Answers newDetails)
    {
      if (id != newDetails.Id)
      {
        return BadRequest();
      }
      context.Entry(newDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      context.SaveChanges();
      return newDetails;
    }
    // Delete Answer
    [HttpDelete("{id}")]
    public ActionResult<Answers> DeleteEntry([FromBody]Answers entry, int id)
    {
      var answerToDelete = context.Answer.FirstOrDefault(answer => answer.Id == id);
      context.Answer.Remove(answerToDelete);
      context.SaveChanges();
      return answerToDelete;
    }
  }

}
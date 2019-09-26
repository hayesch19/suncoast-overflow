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
    [HttpGet("{id}")]
    public ActionResult GetOneItem(int id)
    {
      var question = context.Question.FirstOrDefault(q => q.Id == id);
      if (question == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(question);
      }
    }

    // Get All Questions
    [HttpGet]
    public ActionResult<IEnumerable<Questions>> GetAllItems()
    {
      var questions = context.Question.OrderByDescending(question => question.DateAsked);
      return questions.ToList();
    }

    // Update Question
    [HttpPut("{id}")]
    public ActionResult<Questions> UpdateQuestion(int id, [FromBody]Questions newDetails)
    {
      if (id != newDetails.Id)
      {
        return BadRequest();
      }
      context.Entry(newDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      context.SaveChanges();
      return newDetails;
    }

    // Delete A Question
    [HttpDelete("{id}")]
    public ActionResult<Questions> DeleteEntry([FromBody]Questions entry, int id)
    {
      var questionToDelete = context.Question.FirstOrDefault(question => question.Id == id);
      context.Question.Remove(questionToDelete);
      context.SaveChanges();
      return questionToDelete;
    }

    // Adding Answers To Questions
    [HttpPost("{QuestionsId}/Answer")]
    public ActionResult<Answers> CreateAnswer(int QuestionsId, [FromBody]Answers answers)
    {
      var questions = context.Question.FirstOrDefault(q => q.Id == QuestionsId);
      if (questions == null)
      {
        return NotFound();
      }
      else
      {
        answers.QuestionsId = QuestionsId;
        context.Answer.Add(answers);
        context.SaveChanges();
        return Ok();

      }
    }
  }
}
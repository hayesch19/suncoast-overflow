using System.Collections.Generic;
using System.Linq;
using blogapi;
using BlogApi.Models;
using BlogApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnswerController : ControllerBase
  {

    [HttpGet]
    public ActionResult<IEnumerable<Answers>> GetAllAnswers()
    {

      var context = DatabaseContext();
      // 2. do the thing
      var answers = context.Answers.OrderByDescending(answers => answers.DateCreated);
      // 3. return the thing
      return answers.ToList();
    }
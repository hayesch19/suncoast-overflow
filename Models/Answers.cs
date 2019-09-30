using System;

namespace suncoast_overflow.Models
{
  public class Answers
  {
    public int Id { get; set; }
    public string Answer { get; set; }
    public DateTime DateAsked { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }


    public int? QuestionsId { get; set; }
    public Questions Questions { get; set; }
  }
}
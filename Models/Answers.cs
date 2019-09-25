using System;

namespace suncoast_overflow.Models
{
  public class Answers
  {
    public int Id { get; set; }
    public string Answer { get; set; }
    public DateTime DateAsked { get; set; }
    public int UpVoteDownVote { get; set; }
  }
}
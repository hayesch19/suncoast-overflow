using System;
using System.Collections.Generic;

namespace suncoast_overflow.Models
{
  public class Questions
  {
    public int Id { get; set; }
    public string Question { get; set; }
    public DateTime DateAsked { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }


    public List<Answers> Answers { get; set; } = new List<Answers>();
  }
}
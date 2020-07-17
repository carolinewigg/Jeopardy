using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FileToDbQuestionInserter
{
    public class Round
    {
        [Key]
        public int Id { get; set; }
        public string RoundName { get; set; }
    }
}

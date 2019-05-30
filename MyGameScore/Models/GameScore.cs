using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameScore.Models
{
    public class GameScore
    {

        public int Id { get; set; }

        [Range(0, 1000, ErrorMessage = "{0} must be from {1} to {2}")]
        public int score { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]
        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public GameScore()
        {
        }

        public GameScore(int id, int score, DateTime date)
        {
            Id = id;
            this.score = score;
            this.date = date;
        }
    } 
}

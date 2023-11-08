using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace dotnetapp.Models
{
    public class Team{
        [Key]
        public int Id{get;set;}
        public string Name{get;set;}
        public ICollection<Player>Player{get;set;}
    }
}
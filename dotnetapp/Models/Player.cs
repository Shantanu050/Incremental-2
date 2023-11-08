// Models/Player.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnetapp.Models
{
    public class Player
    {
        [Key]
        public int Id{get;set;}
        public string Name{get;set;}
        public string Category{get;set;}
        public decimal BiddingAmount{get;set;}
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OffPractice.Data
{
    public class Coach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CID { get; set; }
        public string CN { get; set; }
        public int TID { get; set; }
        public string TN { get; set; }
        public DateTime ReleaseDate { get; internal set; }
    }
}

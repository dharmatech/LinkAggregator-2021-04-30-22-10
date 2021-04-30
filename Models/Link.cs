using System;
using System.ComponentModel.DataAnnotations;

namespace LinkAggregator.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Title { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Api
{
    public class SampleInfo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public DateTimeOffset Created { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [DisplayFormat(DataFormatString = "{0:d.M.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        [Range(typeof(DateTime), "1/1/1966", "1/1/2020")]
        public DateTime releaseDate { get; set; }

        [RegularExpression(@"^[A-Ö]+[a-öA-Ö''-'\s]*$")]
        [Display(Name = "Genre")]
        public string genre { get; set; }

        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Display(Name = "Rating")]
        public string rating { get; set; }
    }
}

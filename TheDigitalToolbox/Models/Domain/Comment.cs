using System;
using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Comment
    {
        public int commentId { get; set; }
        public User commenter { get; set; }
        public DateTime date { get; set; }


        //Creating code-accessible limits for the string length of the member variable
        private const int TextMinLength = 1;
        private const int TextMaxLength = 300;
        public StringLength TextSL = new StringLength(TextMinLength, TextMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(TextMaxLength, MinimumLength = TextMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Text { get; set; }       

    }
}

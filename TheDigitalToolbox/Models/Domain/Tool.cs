﻿using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public abstract class Tool
    {
        // There will be many tools in the toolbox of varying uses, structure, and source of synthesis, but all tools will need the following:

        // Which user uploaded the tool, automatically set by the site (no need for validation)
        public User Uploader { get; set; }

        //The people(s) or organization credited for the creation of the tool, specifically in reference to its top-level functionality
        //Creating code-accessible limits for the string length of the member variable
        private const int CreatorMinLength = 1;
        private const int CreatorMaxLength = 60;
        public StringLength CreatorSL = new StringLength(CreatorMinLength, CreatorMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(CreatorMaxLength, MinimumLength = CreatorMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Creator { get; set; }

        // A Title (or name)
        //Creating code-accessible limits for the string length of the member variable
        private const int TitleMinLength = 1;
        private const int TitleMaxLength = 60;
        public StringLength TitleSL = new StringLength(TitleMinLength, TitleMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Title { get; set; }

        // A Description highlighting what it does and how to use it
        //Creating code-accessible limits for the string length of the member variable
        private const int DescriptionMinLength = 15;
        private const int DescriptionMaxLength = 1000;
        public StringLength DescriptionSL = new StringLength(DescriptionMinLength, DescriptionMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Description { get; set; }

        // A URL where the tool itself can be found, or the sourcecode used to build the tool
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [Url(ErrorMessage = "Share URL must be a web address")]
        public string ShareURL { get; set; }
    }
}

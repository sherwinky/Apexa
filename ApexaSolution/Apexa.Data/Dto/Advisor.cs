using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;


namespace Apexa.Data.Dto
{
    /// <summary>
    /// advisor dto
    /// </summary>
    public class Advisor : BaseDto
    {
        [Required(ErrorMessage = "Full name is a required failed"), MaxLength(255, ErrorMessage = "The maximum length of full name is {1}")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "SIN is a required failed"), 
         MinLength(9, ErrorMessage = "The minimum length of SIN is {1}"), 
         MaxLength(9, ErrorMessage = "The maximum length of SIN is {1}")]
        public string? Sin { get; set; }

        [MaxLength(255, ErrorMessage = "The maximum length of Address is {1}")]
        public string? Address { get; set; }

        [MinLength(10, ErrorMessage = "The minimum length of Phone Number is {1}"),
         MaxLength(10, ErrorMessage = "The maximum length of Phone Number is {1}")]
        public string? PhoneNumber { get; set; }

        public HealthStatus Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HairClinic.Models
{
    public class Login
    {
        [Required]
        
        [RegularExpression("[A-Za-z0-9-._@+]*")]
        
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$_-])(?=\S+$).{8,16}", ErrorMessage = "Password  Format: < br /> -No spaces.< br /> -Minimum 1 numeric.< br /> -Minimum 1 upper case &lower case alphabet.< br /> -Minimum 1, any of these Special characters: -, _, @, #, $.<br />-Should be ranging between 8 - 16 chars.")]

        public string password { get; set; }    

        public string returnUrl {  get; set; }
    }
}
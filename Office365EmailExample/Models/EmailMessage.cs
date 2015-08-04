using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Office365EmailExample.Models
{
    public class EmailMessage
    {
        [Required]
        [StringLength(128)]
        [MinLength(6)]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Recipient Address")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$")]
        public string RecipientAddress { get; set; }

        [Required]
        [StringLength(100)]
        [MinLength(1)]
        public string Subject { get; set; }

        [Required]
        [StringLength(1000)]
        [MinLength(2)]
        public string Body { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Office 365 Password")]
        public string CredentialsPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Office 365 Username")]
        public string CredentialsUsername { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Office 365 User Email Display Name")]
        public string CredentialsFullName { get; set; }


    }
}
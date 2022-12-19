using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class RequestModel : BaseModel
    {
        [Required]
        public string? FirstName{get; set;}
        [Required] 
        public string? LastName {get; set;}
        [Required] 
        public string? ShortName { get; set;}
        public string? Description { get; set;}
        [Required] 
        public string? DisplayName { get; set;}
        [Required] 
        public string? JobTitle { get; set;}
        [Required] 
        public string? Country { get; set;}
        [Required] 
        public string? Location { get; set;}
        public string? Company { get; set;}
        public string? Manager { get; set;}
        public string? CostCenter {get; set;}
        public string? Department { get; set;}
        [Required] 
        public bool Vpn { get; set; }
        [Required] 
        public bool OutlookMailbox { get; set;}
        [Required]
        public bool Confidential { get; set; }
    }
}

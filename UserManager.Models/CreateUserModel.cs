using System.ComponentModel.DataAnnotations;

namespace UserManager.Models
{
    public class CreateUserModel : BaseModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? CostCenter { get; set; }
        [Required] 
        public string? CompCode { get; set; }
        [Required] 
        public string? SPGroup { get; set; }
        public bool Vpn { get; set; }
        [Required] 
        public string? VpnGroup { get; set; }
        [Required] 
        public string? CountryCode { get; set; }
        public bool Mail { get; set; }
        [Required] 
        public string? EmailDomain { get; set; }
        [Required] 
        public string? ItUser { get; set; }
        [Required] 
        public string? TeamEmail { get; set; }
        [Required] 
        public string? Manager { get; set; }
        [Required] 
        public string? Mandatory { get; set; }
        [Required] 
        public string? LocGroup { get; set; }
        [Required] 
        public string? TuvOu { get; set; }
        public bool Confidential { get; set; }

    }
}
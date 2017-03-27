﻿//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Linq;
//using System.Web;

//namespace Mvc.Models
//{
//    public partial class UserMetadata
//    {
//        //public UserProfile UsersContext()
//        //{
//        //}

//        //public DbSet<UserProfile> UserProfiles { get; set; }
//    }

  
//    public partial class UserProfile
//    {
//        [Key]
//        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
//        public int UserId { get; set; }
//        public string UserName { get; set; }
//    }
//    public class RegisterModel
//    {
//        [Required]
//        [Display(Name = "User name")]
//        public string UserName { get; set; }

//        //[Required]
//        //[Display(Name = "Role")]
//        public int RoleID = 1;


//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }


//        [Required]
//        [DataType(DataType.EmailAddress)]
//        [Display(Name = "Email")]
//        public string UserMail { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm password")]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }

//    public class RegisterExternalLoginModel
//    {
//        [Required]
//        [Display(Name = "User name")]
//        public string UserName { get; set; }

//        public string ExternalLoginData { get; set; }
//    }

//    public partial class LocalPasswordModel
//    {
      
//        [Required]
//        [DataType(DataType.Password)]
//        [Display(Name = "Current password")]
//        public string OldPassword { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "New password")]
//        public string NewPassword { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm new password")]
//        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }

//    public class LoginModel
//    {
//        [Required]
//        [Display(Name = "User name")]
//        public string UserName { get; set; }

//        [Required]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }

//        [Display(Name = "Remember me?")]
//        public bool RememberMe { get; set; }
//    }

//    public class RegisterModel
//    {
//        [Required]
//        [Display(Name = "User name")]
//        public string UserName { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm password")]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }

//    public class ExternalLogin
//    {
//        public string Provider { get; set; }
//        public string ProviderDisplayName { get; set; }
//        public string ProviderUserId { get; set; }
//    }

    
//}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public partial class UserMetadata
    {
        //public UserProfile UsersContext()
        //{
        //}

        //public DbSet<UserProfile> UserProfiles { get; set; }
    }


    public partial class UserProfile
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public partial class LocalPasswordModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        //[Required]
        //[Display(Name = "Role")]
        public int RoleID = 1;


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string UserMail { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }


}
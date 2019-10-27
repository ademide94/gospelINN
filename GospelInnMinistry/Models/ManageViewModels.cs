using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.Mvc;

namespace GospelInnMinistry.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
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
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }


    public class SendEmailViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Message { get; set; }

        public User LoggedInUser { get; set; }
    }



    public class NewsLetterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

   public class EventsViewModel
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Location { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> GroupId { get; set; }
    }

    public class GroupEventViewModel
    {
		public List<Group> _groups { get; set; }
		public Group _group { get; set; }
        public IEnumerable<Event> _event { get; set; }
        public Event  _eventSingle { get; set; }
        public IEnumerable<Medium> _grouppictures { get; set; }

		 
		public Medium _LatestVedio { get; set; }

    }

    public class picturesViewModel
    {

        [RegularExpression(@"^.*\.(jpg|gif|jpeg|png|bmp|JPG)$",ErrorMessage = "Please use an image with an extension of .jpg, .png, .gif, .bmp")]
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
    
        [Required]
        public SelectList Group { get; set; }
    }
  
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }




	public class MediumViewModel
	{
		public int Id { get; set; }
		public string MediaName { get; set; }
		[DataType(DataType.Date)]
		public Nullable<System.DateTime> DateCreated { get; set; }
		
	//[RegularExpression("((?:http|https)(?::\\/{2}[\\w]+)(?:[\\/|\\.]?)(?:[^\\s\u0022]*))", ErrorMessage = "Invalid First Name")]
    	[Url]
		public string ContentLocation { get; set; }
		public Nullable<int> CreatedBy { get; set; }
		public Nullable<int> groupId { get; set; }
		public Nullable<bool> isVedio { get; set; }
		public string VedioPreacher { get; set; }
		public string VedioDesciption { get; set; }
 
	}
}
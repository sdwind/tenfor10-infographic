using System.ComponentModel.DataAnnotations;

namespace TenFor10.Infographic.Models
{
	public class LoginModel
	{
		[Required]
		public string Password { get; set; }
	}
}
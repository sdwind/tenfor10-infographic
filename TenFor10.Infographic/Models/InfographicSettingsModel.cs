using System.ComponentModel.DataAnnotations;

namespace TenFor10.Infographic.Models
{
	public class InfographicSettingsModel
	{
		[Required(ErrorMessage = "Required")]
		[Display(Name = "Goal for event (in number of signups)")]
		public int? Goal { get; set; }

		[Display(Name = "Total signups for event")]
		public int? SignUps { get; set; }

		[Required(ErrorMessage = "Required")]
		[Display(Name = "Number of signups per icon")]
		public int? SignUpsPerIcon { get; set; }

		[Required(ErrorMessage = "Required")]
		[Display(Name = "Number of icons per row")]
		public int? IconsPerRow { get; set; }
	}
}
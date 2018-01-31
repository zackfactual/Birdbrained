using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Birdbrained.Models
{
	[MetadataType(typeof(Bird.Metadata))]
	public partial class Bird
	{
		sealed class Metadata
		{
			[Key]
			public System.Guid Id { get; set; }

			[Required]
			[Display(Name = "English Name")]
			public string EnglishName { get; set; }

			[Required]
			public string Class { get; set; }

			[Required]
			public string Order { get; set; }

			[Required]
			public string Family { get; set; }

			public string Subfamily { get; set; }

			[Required]
			public string Genus { get; set; }

			[Required]
			public string Species { get; set; }

			[Required]
			[Display(Name = "Learn More Here")]
			public string LearnMoreHyperlink { get; set; }

			[Required]
			public string Photo { get; set; }
		}
	}
}
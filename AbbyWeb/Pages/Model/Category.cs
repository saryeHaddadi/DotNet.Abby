﻿using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Pages.Model;

public class Category
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	public int DisplayOrder { get; set; }
}

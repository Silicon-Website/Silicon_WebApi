﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
    public int Id { get; set; }
    public bool IsBestSeller { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public string Hours { get; set; } = null!;
    public string LikesInProcent { get; set; } = null!;
    public string LikesInNumbers { get; set; } = null!;

}

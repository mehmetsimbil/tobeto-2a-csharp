﻿using Core.Entities;

namespace Entities.Concrete;

public class Brand : Entity<int>
{
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public bool Premium { get; set; }
    public double Rating { get; set; }
    public Brand()
    {
        
    }
    public Brand(string name, string logoUrl = null, bool premium = false, double rating = 0)
    {
        Name = name;
        LogoUrl = logoUrl;
        Premium = premium;
        Rating = rating;
    }
}

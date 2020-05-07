﻿using System;
using Domain.Base;

namespace Domain
{
    public abstract class Person : Entity<int>
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Person() { }
        
    }
}
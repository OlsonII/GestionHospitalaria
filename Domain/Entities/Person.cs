﻿using Domain.Base;

namespace Domain
{
    public abstract class Person : Entity<string>
    {
        public override string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
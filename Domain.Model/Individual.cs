﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Individual
    {
        public Guid Id { get; set; }
        public string IndividualRef { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
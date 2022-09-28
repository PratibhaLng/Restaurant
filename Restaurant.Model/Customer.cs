﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.Model
{
    public class Customer
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]

        public string PhoneNo { get; set; }


    }
}

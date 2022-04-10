﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

// Paul Chu
// C00124175
// CMPS 358
// CMPS 358 Spring 2021 Programming Project #8

namespace p8_C00124175
{
    [Table("Supplier")]
    public partial class Supplier
    {
        [Key]
        [Column(TypeName = "int                  identity")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string CompanyName { get; set; } = null!;
        [Column(TypeName = "nvarchar(50)")]
        public string? ContactName { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? ContactTitle { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? City { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? Country { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string? Phone { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string? Fax { get; set; }
    }
}

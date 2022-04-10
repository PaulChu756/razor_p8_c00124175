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
    [Table("Order")]
    public partial class Order
    {
        [Key]
        [Column(TypeName = "int                  identity")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string OrderDate { get; set; } = null!;
        [Column(TypeName = "nvarchar(10)")]
        public string? OrderNumber { get; set; }
        [Column(TypeName = "int")]
        public long CustomerId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public byte[]? TotalAmount { get; set; }
    }
}

using System;
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
    [Table("OrderItem")]
    public partial class OrderItem
    {
        [Key]
        [Column(TypeName = "int                  identity")]
        public long Id { get; set; }
        [Column(TypeName = "int")]
        public long OrderId { get; set; }
        [Column(TypeName = "int")]
        public long ProductId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public byte[] UnitPrice { get; set; } = null!;
        [Column(TypeName = "int")]
        public long Quantity { get; set; }
    }
}

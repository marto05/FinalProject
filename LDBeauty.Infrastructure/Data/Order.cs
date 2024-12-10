﻿using LDBeauty.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDBeauty.Infrastructure.Data
{
    public class Order
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(50)]
        public string ClientFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientLastName { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(17)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public IList<AddedProduct> Products { get; set; } = new List<AddedProduct>();

        public decimal TotalPrice { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

    }
}

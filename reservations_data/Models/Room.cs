using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reservations_data.Models
{
    public class Room
    {
        [Key]
        [Required]
        public int RoomId { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MinLength(50)]
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }

        [Required]
        public TimeSpan From { get; set; }

        [Required]
        public TimeSpan To { get; set; }

        public IList<Reservation> Reservations { get; set; }

    }
}
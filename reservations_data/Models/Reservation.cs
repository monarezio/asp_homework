using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using reservations_data.Models.Attributes;

namespace reservations_data.Models
{
    public class Reservation
    {
        [Key]
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public DateTime From { get; set; }

        /// <summary>
        /// A possible future request could be to implement different time range for each reservations
        /// </summary>
        [Required]
        public DateTime To { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [ClientEmail]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
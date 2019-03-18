using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace asp_homework.Models.Data.Models
{
    public class Reservation
    {
        [Key]
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey("Reservation")]
        public int RoomId { get; set; }

        public Reservation()
        {
        }

        public Reservation(string firstName, string lastName, string email, string phoneNumber, DateTime date, string description = null)
        {
            Date = date;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Description = description;
        }
    }
}
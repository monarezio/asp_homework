using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using asp_homework.Models.Data.Models.HelperModels;

namespace asp_homework.Models.Data.Models
{
    public class Room
    {
        [Key]
        [Required]
        public int RoomId { get; set; }
        
        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(500)]
        [MinLength(50)]
        public string Description { get; set; }

        /// <summary>
        /// Opening hours from
        /// TODO: Create a Range object?
        /// </summary>
        [Required] 
        public byte From { get; set; }

        /// <summary>
        /// Opening hours to
        /// TODO: Create a Range object?
        /// </summary>
        [Required]
        public byte To { get; set; }

        /// <summary>
        /// Linked reservation
        /// </summary>
        public IList<Reservation> Reservations { get; set; }
        
        /// <summary>
        /// Represents the time range
        /// </summary>
        [NotMapped]
        public TimeRange TimeRange => new TimeRange(From, To);

        public Room()
        {
        }

        public Room(string name, byte from, byte to, string description, IList<Reservation> reservations)
        {
            Name = name;
            Description = description;
            From = from;
            To = to;
            Reservations = reservations;
        }

        public Room(string name, byte from, byte to, string description = null) : this(name, from, to, description, new List<Reservation>())
        {
        }
    }
}
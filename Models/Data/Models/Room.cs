using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public IList<Reservation> Reservation { get; set; }

    }
}
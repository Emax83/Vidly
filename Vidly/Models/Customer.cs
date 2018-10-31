﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribed to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }


        [Display(Name ="Membership type")]
        [Min18YearsValidation]
        public byte MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        public string Thumbnail
        {
            get
            {
                return string.Format("{0}/{1}", Id, "Thumb.jpg");
            }
        }

    }
}
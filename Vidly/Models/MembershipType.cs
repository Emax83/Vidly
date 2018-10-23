using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        //use byte because i have only few numbers
        public byte Id { get; set; }

        [Display(Name = "Membership type")]
        public string Name { get; set; }

        [Display(Name = "Fee")]
        public short SignUpFee { get; set; }

        [Display(Name = "Duration in month")]
        public byte DurationInMonths { get; set; }

        [Display(Name = "Discount Rate")]
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}
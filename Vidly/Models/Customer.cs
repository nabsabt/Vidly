using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]  //this is a data annotation. With this, the column "Name" will be no longer nullable
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }  //this is a navigation property. It navigates from Customer to MembershipType
        public byte MembershipTypeId { get; set; }  //entity framework recognizes this convention, and treats this property as foreign key

    }
}
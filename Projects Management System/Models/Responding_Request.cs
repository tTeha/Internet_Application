//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projects_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Responding_Request
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Request_ID { get; set; }
        public bool Respond { get; set; }
    
        public virtual User User { get; set; }
        public virtual Sending_Request Sending_Requests { get; set; }
    }
}

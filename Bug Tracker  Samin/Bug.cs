//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bug_Tracker__Samin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Pic { get; set; }
        public string Solution { get; set; }
        public string IssueStatus { get; set; }
        public string IssueBy { get; set; }
        public string AnsweredBy { get; set; }
    }
}
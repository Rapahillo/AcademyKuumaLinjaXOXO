//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcademyKuumaLinjaXOXO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Messages = new HashSet<Message>();
        }
    
        public int Person_Id { get; set; }
        public string NickName { get; set; }
        public string Hometown { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public string Password { get; set; }
        public Nullable<int> PasswordHash { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}

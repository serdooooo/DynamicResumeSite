//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCCV.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Education
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Bu alani bos gecemezsiniz")]
        public string Title { get; set; }    
        public string Subtitle1 { get; set; }
        public string Subtitle2 { get; set; }
        [StringLength(10,ErrorMessage ="Lutfen en fazla 10 karakterlik veri girisi yapiniz")]
        public string GNO { get; set; }
        public string EducationDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Adda.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}

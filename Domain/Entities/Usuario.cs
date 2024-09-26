﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEKenable.ProjectTemplate.Services.Entities
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }
        public string role_name { get; set; }

        public virtual List<User> Users { get; set; }
    }

    public enum Roles
    {
        Administrator = 1,
        Normal = 2
    }
}

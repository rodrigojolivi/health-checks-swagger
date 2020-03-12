using System;

namespace HealthChecksSwagger.Model
{
    public class User
    {
        public Guid IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

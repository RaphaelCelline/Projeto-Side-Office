using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SideOffice.Domain.Entities
{
    public class User
    {
        public Guid     User_id { get; set; }
	    public string   Name { get; set; }
        public string   Last_name { get; set; }
        public string   Email { get; set; }
	    public string   Document { get; set; }
        public string   Password { get; set; }
	    public DateTime Registration_datetime { get; set; }
	    public string   Country_code { get; set; }
	    public DateTime Last_login_datetime { get; set; }                 
        public string   Status { get; set; }

        // Relação 1pN - Um usuário pode ter Varios alugueis
        public virtual IEnumerable<Rent> Rents { get; set; }

        public User(string name, string last_name, string email, string document, string password, string country_code)
        {
            User_id = Guid.NewGuid();
            Name = name;
            Last_name = last_name;
            Email = email;
            Document = document;
            Password = password;
            Registration_datetime = DateTime.Now;
            Country_code = country_code;
            Last_login_datetime = DateTime.Now;
            Status = "P";
        }

        public bool NeedCofirmEmail(User user)
        {
            return user.Status.Equals("P");
        }
        public bool isActive(User user)
        {
            return user.Status.Equals("A");
        }
    }
}

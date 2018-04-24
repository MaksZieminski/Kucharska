using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplikacjaWebowa.Models;

namespace AplikacjaWebowa.ViewModels
{
    public class NewUserViewModel
    {
        public User user { get; set; }
        public List<User> users { get; set; }
    }


    
}
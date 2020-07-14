using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Models
{
    public class ChildViewModel
    {
        public string Name { get; set; }
        public IFormFile Avatar { get; set; }
    }
}

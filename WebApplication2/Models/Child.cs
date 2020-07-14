using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Models
{
    public class Child
    {
        public int Id { get; set; }
        public int ParrentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public string Snails { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Path { get; set; }
        public string Male { get; set; }

        public byte[] Avatar { get; set; }
    }
}

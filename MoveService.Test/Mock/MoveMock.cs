using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Mock
{
    public class MoveMock : DbContext
    {
        public int Id { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public int Accuracy { get; set; }
        public string Name { get; set; } = string.Empty;

        public void AddUser(var userDto)
        {
            this.Name = userDto.Name;
            this.Description = userDto.Description;
            this.Email = userDto.Email;
            this.Password = userDto.Password;
            this.PlatfromID = userDto.PlatformID;
            this.UserName = userDto.UserName;
        }
    }
}
﻿namespace TakeAway.IdentityServer.Dtos
{
    public class CreateUserRegisterDto
    {
        public string Username { get; set; }
        public string Email {  get; set; }
        public string  Name { get; set; }
        public string  Surname { get; set; }
        public string  Password { get; set; }
    }
}

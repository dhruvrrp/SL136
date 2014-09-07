namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class AuthorizeService
    {
        private readonly IAuthorizeRepository repository;

        private Regex emailCheck = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");

        public AuthorizeService(IAuthorizeRepository repository)
        {
            this.repository = repository;
        }

        public Logon Authenticate(string email, string password, ref List<string> errors)
        {
            if (!this.emailCheck.IsMatch(email))
            {
                errors.Add("Invalid email");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                errors.Add("Invalid email or password.");
                throw new ArgumentException();
            }

            return this.repository.Authenticate(email, password, ref errors);
        }
    }
}

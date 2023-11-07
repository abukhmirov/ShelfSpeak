using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ShelfSpeak.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [StringLength(100, ErrorMessage = "UserName cannot exceed 100 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public List<Message> Posts { get; set; } = new List<Message>();



        public User()
        {

        }


        public User(string name, string userName, string password)
        {
            Name = name;
            UserName = userName;
            Password = password;
        }



        public string GetDigestedPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }

            HashAlgorithm sha = SHA256.Create();

            string PasswordInput = password;

            byte[] firstInputBytes = Encoding.ASCII.GetBytes(PasswordInput);

            byte[] firstInputDigested = sha.ComputeHash(firstInputBytes);

            StringBuilder firstInputBuilder = new StringBuilder();

            foreach (byte b in firstInputDigested)
            {
                Console.Write(b + ", ");
                firstInputBuilder.Append(b.ToString("x2"));
            }

            return firstInputBuilder.ToString();

        }





        public bool VerifyPassword(string password)
        {
            string inputHash = GetDigestedPassword(password).ToString();

            return inputHash == Password;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SportStore.API.Entities
{
    public class User
    {
        public Guid guid { get; set; }
        [MinLength(5, ErrorMessage = "Минимальная длина имени - 5 символов")]
        [Validations.MaxLength(10)]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

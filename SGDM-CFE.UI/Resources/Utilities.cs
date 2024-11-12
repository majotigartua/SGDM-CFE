using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace SGDM_CFE.UI.Resources
{
    public class Utilities
    {
        public static string ComputeSHA256Hash(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hashedPassword = new StringBuilder();
            for (int bit = 0; bit < bytes.Length; bit++)
            {
                hashedPassword.Append(bytes[bit].ToString("x2"));
            }
            return hashedPassword.ToString();
        }

        public static List<Entity> GetFields<T>(T entity)
        {
            if (entity == null) return [];
            return (from property in entity.GetType().GetProperties()
                    select new Entity
                    {
                        Field = property.Name,
                        Value = property.GetValue(entity)?.ToString()
                    }).ToList();
        }

        public class Entity
        {
            public string? Field { get; set; }
            public string? Value { get; set; }
        }
    }
}
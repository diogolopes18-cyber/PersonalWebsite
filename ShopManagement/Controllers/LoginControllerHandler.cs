using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ShopManagement.DatabaseModel;

namespace ShopManagement.Controllers;

internal static class LoginControllerHandler
{
    private static string CreateHash(string password)
    {
        byte[] salt = new byte[128 / 8];
        
        //Generate random salt with non zero values
        using var randomGenerator = new RNGCryptoServiceProvider();
        randomGenerator.GetNonZeroBytes(salt);

        string hashedString = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hashedString;
    }

    private static string Hash(string password)
    {
        return CreateHash(password);
    }

    private static bool PasswordsMatch(string password, string confirmedPassword)
    {
        int comparison = string.CompareOrdinal(password, confirmedPassword);

        return comparison switch
        {
            1 => false,
            0 => true,
            -1 => false,
            _ => false
        };
    }

    internal static void SaveUserDetails(string username, string password,
        string confirmedPassword, string email, DatabaseContext context)
    {
        if (!PasswordsMatch(password, confirmedPassword))
        {
            throw new Exception("Passwords do not match!");
        }
        
        List<UserDetails> userLogin = new List<UserDetails>()
        {
            new()
            {
                Username = username,
                Email = email,
                Hash = Hash(password)
            }
        };

        foreach (var detail in userLogin)
        {
            context.User.Add(detail);
        }

        context.SaveChanges();
    }
}

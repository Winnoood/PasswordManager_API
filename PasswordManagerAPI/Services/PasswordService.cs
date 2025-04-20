using Microsoft.EntityFrameworkCore;
using PasswordManagerAPI.Data;
using PasswordManagerAPI.Helpers;
using PasswordManagerAPI.Models;

namespace PasswordManagerAPI.Services
{
    public class PasswordService
    {
        private readonly PasswordContext _context;

        public PasswordService(PasswordContext context)
        {
            _context = context;
        }

        public async Task<Password> AddPasswordAsync(Password password)
        {
            password.EncryptedPassword = EncryptionHelper.EncryptPassword(password.DecryptedPassword);
            _context.Passwords.Add(password);
            await _context.SaveChangesAsync();
            return password;
        }

        public async Task<List<Password>> GetPasswordsAsync()
        {
            return await _context.Passwords.ToListAsync();
        }

        public async Task<Password> GetPasswordAsync(int id)
        {
            var password = await _context.Passwords.FindAsync(id);            
            return password;
        }

        public async Task<Password> UpdatePasswordAsync(int id, Password password)
        {
            var existingPassword = await _context.Passwords.FindAsync(id);
            if (existingPassword == null) return null;

            existingPassword.Category = password.Category;
            existingPassword.App = password.App;
            existingPassword.UserName = password.UserName;
            existingPassword.EncryptedPassword = password.EncryptedPassword;
            existingPassword.DecryptedPassword = password.DecryptedPassword;

            await _context.SaveChangesAsync();
            return existingPassword;
        }

        public async Task<bool> DeletePasswordAsync(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password == null) return false;

            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PasswordManagerAPI.Models;
using PasswordManagerAPI.Services;

namespace PasswordManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController: ControllerBase
    {
        private readonly PasswordService _passwordService;

        public PasswordController(PasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        // POST: api/passwords
        [HttpPost]
        public async Task<ActionResult<Password>> AddPassword(Password password)
        {
            var createdPassword = await _passwordService.AddPasswordAsync(password);
            return CreatedAtAction(nameof(GetPassword), new { id = createdPassword.Id }, createdPassword);
        }

        // GET: api/passwords
        [HttpGet]
        public async Task<ActionResult<List<Password>>> GetPasswords()
        {
            var passwords = await _passwordService.GetPasswordsAsync();
            return Ok(passwords);
        }

        // GET: api/passwords/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Password>> GetPassword(int id)
        {
            var password = await _passwordService.GetPasswordAsync(id);
            if (password == null)
            {
                return NotFound();
            }
            return Ok(password);
        }

        // PUT: api/passwords/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassword(int id, Password password)
        {
            var updatedPassword = await _passwordService.UpdatePasswordAsync(id, password);
            if (updatedPassword == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/passwords/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            var success = await _passwordService.DeletePasswordAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

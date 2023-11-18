using Finder.Data;
using Finder.Handlers;
using Finder.Interfaces.Repositories;
using Finder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Finder.Repositories;

/// <inheritdoc />
public class UserAuthRepository : IUserAuthRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher _passwordHasher;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="context">Контекст БД</param>
    public UserAuthRepository(ApplicationDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher();
    }

    public string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email)
            // Добавьте другие необходимые claims
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Устанавливаем срок действия токена
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<bool> CreateUser(User newUser, string password)
    {
        string hashedPassword = _passwordHasher.HashPassword(password);
        newUser.Password = hashedPassword;

        try
        {
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<User?> Authenticate(string username, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == username);

        if (user != null && _passwordHasher.VerifyPassword(password, user.Password))
        {
            return user;
        }

        return null;
    }
}

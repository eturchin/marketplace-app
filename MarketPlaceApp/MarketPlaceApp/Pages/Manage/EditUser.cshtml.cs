using System.ComponentModel.DataAnnotations;
using MarketPlace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketPlace.Pages.Manage;

[Authorize(Policy = "AdminOnly")]
public class EditUserModel : PageModel
{
    private readonly IConfiguration _config;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public EditUserModel(IUserService userService, IConfiguration config, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
        _config = config;
    }

    public long Id { get; set; }

    [Required] public string Login { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    public async Task<IActionResult> OnGetAsync(long id)
    {
        var token = HttpContext.Session.GetString("Token");

        if (!_tokenService.IsTokenValid(_config["AppSettings:Token"], token)) return RedirectToPage("/Index");

        var user = await _userService.GetUserByIdAsync(id);

        if (user == null) return NotFound();

        Id = user.Id;
        Login = user.Login;
        Email = user.Email;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var user = await _userService.GetUserByIdAsync(Id);

        if (user == null) return NotFound();

        user.Login = Login;
        user.Email = Email;
        
        return Page();
    }
}
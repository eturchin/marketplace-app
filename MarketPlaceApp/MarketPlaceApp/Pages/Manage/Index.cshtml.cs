using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Data.Persistent.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketPlace.Pages.Manage;

[Authorize(Policy = "AdminOnly")]
public class IndexModel : PageModel
{
    private readonly IConfiguration _config;

    private readonly ITokenService _tokenService;

    private readonly IUserService _userService;

    public IEnumerable<User> Users { get; set; }
    
    public IndexModel(IUserService userService, ITokenService tokenService, IConfiguration config)
    {
        _userService = userService;
        _tokenService = tokenService;
        _config = config;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var token = HttpContext.Session.GetString("Token");

        if (!_tokenService.IsTokenValid(_config["AppSettings:Token"], token))
        {
            return RedirectToPage("/Index");
        }

        Users = await _userService.GetAllUsersAsync();

        return Page();
    }
}
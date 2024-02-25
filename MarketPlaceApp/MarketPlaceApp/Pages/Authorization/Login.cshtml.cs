using MarketPlace.Application.Dto;
using MarketPlace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketPlace.Pages.Authorization;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly IUserService _userService;
    
    [BindProperty] public LogInDto LogInDto { get; set; }

    public LoginModel(IUserService userService)
    {
        _userService = userService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrEmpty(LogInDto.Login) || string.IsNullOrEmpty(LogInDto.Password))
        {
            return RedirectToAction("Error");
        }

        var validUser = await _userService.LogInAsync(LogInDto);

        if (validUser.Data == null)
        {
            return RedirectToPage("/Index");
        }

        HttpContext.Session.SetString("Token", validUser.Data);

        return RedirectToPage("/Index");
    }
}
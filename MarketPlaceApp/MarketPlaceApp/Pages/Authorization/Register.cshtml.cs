using MarketPlace.Application.Dto;
using MarketPlace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketPlace.Pages.Authorization;

public class RegisterModel : PageModel
{
    private readonly IUserService _userService;

    [BindProperty] public UserDto UserDto { get; set; }

    public RegisterModel(IUserService userService)
    {
        _userService = userService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var response = await _userService.RegisterAsync(UserDto);

        return RedirectToPage(response.Success ? "/Authorization/Login" : "/Index");
    }
}
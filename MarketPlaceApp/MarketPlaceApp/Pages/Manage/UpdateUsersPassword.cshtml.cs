using MarketPlace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketPlace.Pages.Manage;

[Authorize(Policy = "AdminOnly")]
public class UpdateUsersPasswordModel : PageModel
{
    private readonly IUserService _userService;

    private readonly IHttpContextAccessor _httpContextAccessor;

    public long Id { get; set; }

    [BindProperty] public string Password { get; set; }

    public UpdateUsersPasswordModel(IUserService userService,IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var idString = _httpContextAccessor.HttpContext.Request.Query["id"];
        Id = Convert.ToInt32(idString);
        var user = await _userService.GetUserByIdAsync(Id);
        var response = await _userService.UpdatePasswordAsync(user.Login, Password);

        return RedirectToPage(response.Success ? "/Manage/Index" : "/Manage/UpdateUserPassword");
    }
}
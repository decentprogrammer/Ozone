using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Ozone.DAL;
using Ozone.DAL.Utility;
using Ozone.Models;

namespace Ozone.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            //IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
      
        [BindProperty]
        public string Authorization { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            [Display(Name = "Civil Id Number")]
            public string CivilId { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            [StringLength(50)]
            public string FirstName { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            [StringLength(50)]
            public string MiddleName { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            [StringLength(50)]
            public string LastName { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            [StringLength(25)]
            public string Phone { get; set; }
            public bool Active { get; set; } = false;
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            public int OrgzCategoryId { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            public string Role { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "* Required field")]
            public int UnitId { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
                returnUrl = returnUrl ?? Url.Content("~/");
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUserModel
                    {
                        UserName = Input.Email,
                        Email = Input.Email,
                        CivilId = Input.CivilId,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        MiddleName = Input.MiddleName,
                        Phone = Input.Phone,
                        Active = Input.Active,
                        OrgzCategoryId = Input.OrgzCategoryId,
                        Role = Input.Role,
                        UnitId = Input.UnitId
                    };

                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        if (!await _roleManager.RoleExistsAsync(StaticDetails.Administrator))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(StaticDetails.Administrator));
                        }
                        if (!await _roleManager.RoleExistsAsync(StaticDetails.Admin))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(StaticDetails.Admin));
                        }
                        if (!await _roleManager.RoleExistsAsync(StaticDetails.Manager))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(StaticDetails.Manager));
                        }
                        if (!await _roleManager.RoleExistsAsync(StaticDetails.User))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(StaticDetails.User));
                        }
                        if (!await _roleManager.RoleExistsAsync(StaticDetails.Guest))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(StaticDetails.Guest));
                        }

                        await _userManager.AddToRoleAsync(user, Authorization);


                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        //$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                // If we got this far, something failed, redisplay form
                return Page();
            }
            catch (OzoneException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

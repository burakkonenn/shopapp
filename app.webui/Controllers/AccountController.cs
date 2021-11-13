using System;
using System.Threading.Tasks;
using app.business.Abstract;
using app.webui.EmailServices;
using app.webui.Identity;
using app.webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace app.webui.Controllers
{
    public class AccountController:Controller
    {
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;
        private SignInManager<User> _signInManager;
        private ICartService _cartService;
        public AccountController(UserManager<User> userManager, IEmailSender emailSender, SignInManager<User> signInManager, ICartService cartService)
        {
            this._userManager = userManager;
            this._emailSender = emailSender;
            this._signInManager = signInManager;
            this._cartService = cartService;
        }
         public void CreateMessage(string errormessage, string type)
        {
            var msg = new AlertMessage()
            {
                ErrorMessage = errormessage,
                Type = type
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
        }

         public IActionResult Login(string ReturnUrl=null)
        {
            return View(new Login()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if(!ModelState.IsValid)
            {   
                return View(model);
            }

            // var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Sifre);

            if(user==null)
            {
                ModelState.AddModelError("","Bu kullanıcı adı ile daha önce hesap oluşturulmamış");
                return View(model);
            } 

            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("","Lütfen email hesabınıza gelen link ile üyeliğinizi onaylayınız.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user,model.Sifre,false,false);

            if(result.Succeeded) 
            {
                return Redirect(model.ReturnUrl??"~/");
            }

            ModelState.AddModelError("","Girilen kullanıcı adı veya parola yanlış");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Firstname  = model.Adı,
                Lastname = model.Soyadı,
                UserName = model.KullanıcıAdı,
                Email = model.Eposta    
            };           

            var result = await _userManager.CreateAsync(user,model.Sifre);
            if(result.Succeeded)
            {
                // generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new {
                    userId = user.Id,
                    token = code    
                });
                

                // email
                await _emailSender.SendEmailAsync(model.Eposta,"Hesabınızı onaylayınız.",$"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");
                return RedirectToAction("Login","Account");
            }           

            ModelState.AddModelError("","Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }
       
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if(userId==null || token ==null)
            {
                CreateMessage("Geçersiz token","danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user,token);
                if(result.Succeeded)
                {
                    _cartService.InitializeCart(user.Id);
                   CreateMessage("Hesap onaylandı","success");
                   
                    return View();
                }
            }
          
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if(user==null)
            {
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword","Account",new {
                userId = user.Id,
                token = code
            });

            // email
            await _emailSender.SendEmailAsync(Email,"Reset Password",$"Parolanızı yenilemek için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");

            return View();
        }
      
       
         public IActionResult ResetPassword(string userId,string token)
        {
            if(userId==null || token==null)
            {
                return RedirectToAction("Home","Index");
            }

            var model = new Reset {Token=token};

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(Reset model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user==null)
            {
                return RedirectToAction("Home","Index");
            }

            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Login","Account");
            }

            return View(model);
        }     
   
        public async Task<IActionResult> logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
   
   
   
    }
}
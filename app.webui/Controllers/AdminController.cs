using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.business.Abstract;
using app.data.Concrete.EfCore;
using app.entity;
using app.webui.EmailServices;
using app.webui.Identity;
using app.webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace app.webui.Controllers
{
    public class AdminController:Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;
        public AdminController(IProductService productService, ICategoryService categoryService, RoleManager<IdentityRole> roleManager,UserManager<User> userManager, IEmailSender emailSender)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._emailSender = emailSender;
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

        public IActionResult Panel()
        {
            var context = new ShopContext();

            var manProductCount = context.ManProducts.Count();
            var womanProductCount = context.WomanProducts.Count();
            var userCountt = _userManager.Users.Count();
            var model = new ProductCountModel()
            {
                ManProductsCount = manProductCount,
                WomanProductsCount = womanProductCount,
                UserCount = userCountt
            };
            return View(model);
        }
        
        public IActionResult Products()
        {
            var model = new ProductModel()
            {
                Products = _productService.GetAll()
                
            };
            return View(model);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProduct model)
        {
            if(!ModelState.IsValid)
            {
                CreateMessage("Lütfen boş bırakılan alanları doldurunuz","danger");
                return View(model);
            }
            var entity = new ManProduct()
            {
                Name = model.Name,
                Url = model.Url,
                Image = model.Image,
                Price = model.Price,
            };
            _productService.Create(entity);
            return RedirectToAction("Products");
        
        }

        public IActionResult ProductEdit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = _productService.GetProductAndCategory((int)id);
            if(model == null)
            {
                return NotFound();
            }
            var entity = new ProductEdit()
            {
                ProductId = model.Id,
                Name = model.Name,
                Url = model.Url,
                Price = model.Price,
                Image = model.Image
            };
            ViewBag.Categories = _categoryService.GetAll();

            return View(entity);
        }
        [HttpPost]
        public IActionResult ProductEdit(ProductEdit model, int[] categoryIds)
        {
            if(ModelState.IsValid)
            {
                var entity = _productService.GetById(model.ProductId);
                if(entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Url = model.Url;
                entity.Image = model.Image;
                CreateMessage("Ürün güncellendi","success");
                return RedirectToAction("Products");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        public IActionResult deleteproduct(int? productId)
        {
            var Model = _productService.GetById((int)productId);
            if(Model != null)
            {
                _productService.Delete(Model);
                CreateMessage("Ürün silindi","success");
                return RedirectToAction("Products");
            }
            return RedirectToAction("Products");

        }

        public IActionResult CategoryList()
        {
            var model = _categoryService.GetAll();
            var entity = new Cat()
            {
                Categories = model
            };

            return View(entity);
        }

        public IActionResult CategoryEdit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = _categoryService.GetCategoryByProduct((int)id);
            if(model == null)
            {
                return NotFound();
            }
            var entity = new ModelCategory()
            {
                CategoryId = model.Id,
                Name = model.Name,
                Url = model.Url,
            };

            return View(entity);
        }

        [HttpPost]
        public IActionResult CategoryEdit(ModelCategory model)
        {
             if(ModelState.IsValid)
            {
                var entity = _categoryService.GetById(model.CategoryId);
                if(entity==null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Url = model.Url;

                _categoryService.Update(entity);

                return RedirectToAction("CategoryList");
            }
            return View(model);
        }

        public IActionResult deletecategory(int? categoryId)
        {
            if(categoryId == null)
            {
                return NotFound();
            }
            var model = _categoryService.GetById((int)categoryId);
            if(model != null)
            {
                _categoryService.Delete(model);
                CreateMessage("Ürün silindi","success");
                
            }
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryCreate(ModelCategory model)
        {
            if(!ModelState.IsValid)
            {
                CreateMessage("Boş bırakılan yerleri doldurunuz.","danger");
                return View(model);
            }
            var entity = new MansCategory()
            {
                Name = model.Name,
                Url = model.Url
            };
            _categoryService.Create(entity);

            return RedirectToAction("CategoryList");
        }
 
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId, categoryId);
            CreateMessage("Ürün silindi","success");
            return RedirectToAction("CategoryList");
        }
 
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if(result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View(model);
        }
 
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
 
        public async Task<IActionResult> RoleEdit(string id)
        {
           var role = await _roleManager.FindByIdAsync(id);
           var members = new List<User>();
           var nonmembers = new List<User>();
           foreach (var users in _userManager.Users)
           {
               var list = await _userManager.IsInRoleAsync(users, role.Name)?members:nonmembers;
               list.Add(users);
           }
           var model = new RoleDetails()
           {
               Role = role,
               Members = members,
               NonMembers = nonmembers
           };
           return View(model);
            
        }
 
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
          if(ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                              foreach (var error in result.Errors)
                              { 
                                ModelState.AddModelError("", error.Description);  
                              }  
                        }
                    }
                }
          
                foreach (var userId in model.IdsToDelete ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                              foreach (var error in result.Errors)
                              { 
                                ModelState.AddModelError("", error.Description);  
                              }  
                        }
                    }
                }
            }
            return Redirect("/admin/roles/"+model.RoleId);
        
        }
        
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var SelectedRoles = await _userManager.GetRolesAsync(user);
                var role = _roleManager.Roles.Select(i => i.Name);
                ViewBag.roles = role;

                return View(new UserModel(){
                    userId = user.Id,
                    Username = user.UserName,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    SelectedRoles = SelectedRoles
                });
            }
        
        
        
            return RedirectToAction("UserList");
        }
     

 }


}
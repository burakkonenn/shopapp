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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private ShopContext context;
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
            var commentsCount = context.Comment.Count();
            var model = new ProductCountModel()
            {
                ManProductsCount = manProductCount,
                WomanProductsCount = womanProductCount,
                UserCount = userCountt,
                CommentCount = commentsCount
            };
            return View(model);
        }
        
        public IActionResult Products()
        {

            return View();
        }
       
        public IActionResult ManProducts(int? id)
        {
            var context = new ShopContext();
            var totalCount = context.Comment.Where(i => i.ProductId == id).Count();
            var manProducts = context.ManProducts.Include(i => i.ManProductBodies)
                                              .Include(i => i.MansBrands)
                                              .Include(i => i.MansCategory)
                                              .Include(i => i.Comments)
                                              .Include(i => i.Genders)
                                              .Include(i => i.ManProductBodies).ToList();

           

            var model = new ProductModel()
            {
                AllProducts = manProducts,
                TotalCount = totalCount,

            };
            return View(model);
        }
        public IActionResult WomanProducts(int? id)
        {
            var context = new ShopContext();
            var totalCount = context.Comment.Where(i => i.ProductId == id).Count();
            var womanProducts = context.WomanProducts.Include(i => i.WomanProductBodies)
                                              .Include(i => i.WomansCategory)
                                              .Include(i => i.WomansBrand)
                                              .Include(i => i.Comments).ToList();

           

            var model = new ProductModel()
            {
                WomanProducts = womanProducts,
                TotalCount = totalCount,

            };
            return View(model);
        }
        public IActionResult CreateWomanProducts()
        {
            var context = new ShopContext();

            ViewBag.WomanCategories = new SelectList(context.WomansCategories,"Id","Name").ToList();
            ViewBag.WomanBrands = new SelectList(context.WomansBrands,"Id","Name").ToList();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateWomanProducts(CreateProduct model)
        {
            var context = new ShopContext();
            ViewBag.WomanCategories = new SelectList(context.WomansCategories,"Id","Name").ToList();
            ViewBag.WomanBrands = new SelectList(context.WomansBrands,"Id","Name").ToList();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            if(!ModelState.IsValid)
            {
                CreateMessage("Tüm alanları tekrar kontrol ederek deneyiniz.","danger");
                return View(model);
            }
            var products = new WomanProduct()
            {
                Name = model.Name,
                Price = model.Price,
                Url = model.Url,
                Image = model.Image,
                Description = model.Description,
                WomansBrandsId = model.WomansBrandsId,
                WomansCategoryId = model.WomansCategoryId,
                GendersId = model.GendersId
            };
            context.Add(products);
            context.SaveChanges();


            return RedirectToAction("WomanProducts");
        }
        public IActionResult CreateManProduct()
        {
            var context = new ShopContext();

            ViewBag.ManCategories = new SelectList(context.MansCategories,"Id","Name").ToList();
            ViewBag.MansBrands = new SelectList(context.MansBrands,"Id","Name").ToList();
            ViewBag.Persons = new SelectList(context.Genders,"Id","Name").ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateManProduct(CreateProduct model)
        {
            var context = new ShopContext();
            ViewBag.ManCategories = new SelectList(context.MansCategories,"Id","Name").ToList();
            ViewBag.MansBrands = new SelectList(context.MansBrands,"Id","Name").ToList();
            ViewBag.Persons = new SelectList(context.Genders,"Id","Name").ToList();
            if(ModelState.IsValid)
            {
                var products = new ManProduct()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Url = model.Url,
                    Image = model.Image,
                    Description = model.Description,
                    MansBrandsId = model.MansBrandsId,
                    MansCategoryId = model.MansCategoryId,
                    GendersId = model.GendersId
                };
                context.Add(products);
                context.SaveChanges();
                return RedirectToAction("ManProducts");
            }
            return View(model);
        }
        public IActionResult CreateManCategory()
        {
            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateManCategory(ModelCategory model)
        {
            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            if(ModelState.IsValid)
            {
                var entity = new MansCategory()
                {
                    Name = model.Name,
                    GendersId = model.GendersId,
                    Url = model.Url
                };
                context.Add(entity);
                context.SaveChanges();
                CreateMessage("Ürün eklendi","success");
                return RedirectToAction("ManCategoryList");     
            }
            return View(model);
        }
        public IActionResult ManProductsBrands()
        {
            var context = new ShopContext();
            var model = new ManBrandsModel()
            {
                ManBrands = context.MansBrands.Include(i => i.Genders).Include(i => i.MansCategory).ToList()
            };

            return View(model);
        }
        public IActionResult CreateManBrands()
        {
            var context = new ShopContext();
            ViewBag.Categories = new SelectList(context.MansCategories,"Id","Name").ToList();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateManBrands(CreateManBrandsModel model)
        {
            var context = new ShopContext();
            ViewBag.Categories = new SelectList(context.MansCategories,"Id","Name").ToList();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            if(ModelState.IsValid)
            {
                var brands = new MansBrands()
                {
                    Name = model.Name,
                    Url = model.Url,
                    MansCategoryId = model.MansCategoryId,
                    GendersId = model.GendersId
                };
                context.Add(brands);
                context.SaveChanges();
                CreateMessage("Ürün eklendi","success");
                return RedirectToAction("ManProductsBrands");
            }
            return View(model);
        }
        public IActionResult WomanCategoryList()
        {
            var context = new ShopContext();
            var model = context.WomansCategories.Include(i=> i.Genders).ToList();
            var entity = new WomanCategoryModel()
            {
                WomanCategory = model
            };
            return View(entity);
        }
        public IActionResult CreateWomanCategory()
        {
            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateWomanCategory(ModelCategory model)
        {
            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            if(ModelState.IsValid)
            {
                 var entity = new WomansCategory()
                {
                    Name = model.Name,
                    Url = model.Url,
                    GendersId = model.GendersId
                };
                context.Add(entity);
                context.SaveChanges();

                return RedirectToAction("WomanCategoryList");
            }
            return View(model);
        }
        public IActionResult WomanProductsBrands()
        {
            var context = new ShopContext();
            var model = new WomanBrandsModel()
            {
                WomanBrands = context.WomansBrands.Include(i => i.Genders).Include(i => i.WomansCategory).ToList()
            };

            return View(model);
        }
        public IActionResult CreateWomanBrands()
        {
            var context = new ShopContext();
            ViewBag.Categories = new SelectList(context.WomansCategories,"Id","Name").ToList();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateWomanBrands(CreateWomanBrandsModel model)
        {
            var context = new ShopContext();
            ViewBag.Categories = new SelectList(context.WomansCategories,"Id","Name").ToList();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            if(ModelState.IsValid)
            {
                var entity = new WomansBrands()
                {
                    Name = model.Name,
                    Url = model.Url,
                    GendersId = model.GendersId,
                    WomansCategoryId = model.WomansCategoryId
                };
                context.Add(entity);
                context.SaveChanges();
                return RedirectToAction("WomanProductsBrands");
            }
            return View(model);
        }
        public IActionResult ManCategoryList()
        {
            var context = new ShopContext();
            var model = context.MansCategories.Include(i => i.MansBrands).Include(i => i.Genders).ToList();
            var entity = new Cat()
            {
                Categories = model
            };

            return View(entity);
        }
       
        public IActionResult ManProductsEdit(int id)
        {
            var context = new ShopContext();
            ViewBag.ManCategories = new SelectList(context.MansCategories,"Id","Name").ToList();
            ViewBag.MansBrands = new SelectList(context.MansBrands,"Id","Name").ToList();
            ViewBag.Persons = new SelectList(context.Genders,"Id","Name").ToList();
            var model = context.ManProducts.Find(id);
            var ManProducts = new CreateProduct()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                Description = model.Description,
                Price = model.Price,
                Image = model.Image,
                MansBrandsId = model.MansBrandsId,
                MansCategoryId = model.MansCategoryId,
                GendersId = model.GendersId
            };
            return View(ManProducts);
        }
        [HttpPost]
        public IActionResult ManProductsEdit(CreateProduct model)
        {
            var context = new ShopContext();
            if(ModelState.IsValid)
            {
                var entity = context.ManProducts.Find(model.Id);
                if(entity==null)
                {
                    return NotFound();
                }
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Url = model.Url;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.Image = model.Image;
                entity.MansBrandsId = model.MansBrandsId;
                entity.MansCategoryId = model.MansCategoryId;
                entity.GendersId = model.GendersId;
                context.SaveChanges();
                return RedirectToAction("ManProducts");
            }
            return View(model);
        }
        public IActionResult DeleteManProducts(int Id)
        {
            var context = new ShopContext();
            var model = context.ManProducts.Find(Id);
            if(model != null)
            {
                context.Remove(model);
                context.SaveChanges();
            }
            return RedirectToAction("ManProducts");
        }
        public IActionResult ManCategoriesEdit(int id)
        {
            
            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            var model = context.MansCategories.Find(id);
            var ManProducts = context.ManProducts.Include(i => i.MansBrands).Include(i => i.Comments).Include(i => i.Genders).Include(i => i.MansCategory).Where(i => i.MansCategory.Id==id).ToList();

            var categories = new ModelCategory()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                ManProducts = ManProducts

            };
            return View(categories);
        }
        [HttpPost]
        public IActionResult ManCategoriesEdit(ModelCategory model)
        {
            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name").ToList();
            if(ModelState.IsValid)
            {
                    var entity = context.MansCategories.Find(model.Id);
                    if(entity == null)
                    {
                    return NotFound();
                    }
                    entity.Name = model.Name;
                    entity.Url = model.Url;
                    entity.GendersId = model.GendersId;
                    context.SaveChanges();
                    return RedirectToAction("ManCategoryList");
            }
            return View(model);
        }
        public IActionResult MansBrandsEdit(int id)
        {
            var context = new ShopContext();
            var brands = context.MansBrands.Find(id);

            var entity = context.ManProducts.Include(i => i.MansCategory)
                                            .Include(i =>i.Genders)
                                            .Where(i => i.MansBrands.Id == id).ToList();

            ViewBag.Categories = new SelectList(context.MansCategories,"Id","Name");       
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name");                                        
            var model = new ManBrandsEditVM()
            {
                Id = brands.Id,
                Name = brands.Name,
                Url = brands.Url,
                MansCategoryId = brands.MansCategoryId,
                GendersId = brands.GendersId,
                ManProducts = entity,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult MansBrandsEdit(ManBrandsEditVM model)
        {
            var context = new ShopContext();
            ViewBag.Categories = new SelectList(context.MansCategories,"Id","Name");       
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name");            
            if(ModelState.IsValid)
            {
                var entity = context.MansBrands.Find(model.Id);
                if(entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Url = model.Url;
                entity.MansCategoryId = model.MansCategoryId;
                entity.GendersId = model.GendersId;
                context.SaveChanges();
                return RedirectToAction("ManProductsBrands");
            };
            return View(model);

        }
        public IActionResult WomansBrandsEdit(int id)
        {
            var context = new ShopContext();
            var woman = context.WomanProducts.Include(i => i.Genders).Include(i => i.WomansCategory).Where(i => i.WomansBrand.Id == id).ToList();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name");
            ViewBag.Category = new SelectList(context.WomansCategories,"Id","Name");
            var model = context.WomansBrands.Find(id);
            if(model == null)
            {
                return NotFound();
            }
            var brands = new CreateWomanBrandsModel()
            {
                Name = model.Name,
                Url = model.Url,
                WomansCategoryId = model.WomansCategoryId,
                GendersId = model.GendersId,
                WomanProducts = woman
            };
            return View(brands);
        }
        public IActionResult WomanCategoryEdit(int? id)
        {
             if(id==null)
            {
                return NotFound();
            }

            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name");
           
            var model = context.WomanProducts.Include(i => i.Genders).Include(i => i.WomansBrand).Include(i => i.WomansCategory).Where(i => i.WomansCategory.Id == id).ToList();
            var category = context.WomansCategories.Find(id);
            if(category == null)
            {
                 return NotFound();
            }

            var womans = new ModelCategory()
            {
                Id = category.Id,
                Name = category.Name,
                Url = category.Url,
                GendersId = category.GendersId,
                WomanProducts = model
            };  

            return View(womans);
        }
        [HttpPost]
        public IActionResult WomanCategoryEdit(ModelCategory model)
        {
            var context = new ShopContext();
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name");
           
            if(ModelState.IsValid)
            {
                    var category = context.WomansCategories.Find(model.Id);
                    if(category == null)
                    {
                        return NotFound();
                        
                    }
                    category.Name = model.Name;
                    category.Url = model.Url;
                    category.GendersId = model.GendersId;
                    context.SaveChanges();
                    return RedirectToAction("WomanCategoryList");
            }
          
            return View(model);

        }
        public IActionResult WomanProductEdit(int id)
        {
            var context = new ShopContext();
            var model = context.WomanProducts.Find(id);
            ViewBag.Genders = new SelectList(context.Genders,"Id","Name");
            ViewBag.Category = new SelectList(context.WomansCategories,"Id","Name");
            ViewBag.Brands = new SelectList(context.WomansBrands,"Id","Name");
            if(model == null)
            {
                return NotFound();
            }
            var WomanProduct = new CreateProduct()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                Description = model.Description,
                Image = model.Image,
                WomansBrandsId = model.WomansBrandsId,
                WomansCategoryId = model.WomansCategoryId,
                GendersId = model.GendersId
            };
            context.SaveChanges();
            return View(WomanProduct);
        }
        [HttpPost]
        public IActionResult WomanProductEdit(CreateProduct model)
        {
            var context = new ShopContext();
            if(ModelState.IsValid)
            {
                var entity = context.WomanProducts.Find(model.Id);
                if(entity == null){
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Url = model.Url;
                entity.Description = model.Description;
                entity.Image = model.Image;
                entity.GendersId = model.GendersId;
                entity.WomansCategoryId = model.WomansCategoryId;
                entity.WomansBrandsId = model.WomansBrandsId;
                context.SaveChanges();
                return RedirectToAction("WomanProducts");
            }
            return View(model);
        }
        public IActionResult DeleteManCategory(int? id)
        {
            var context = new ShopContext();
            if(id == null)
            {
                return NotFound();
            }
            var model = context.MansCategories.Find(id);
            if(model != null)
            {
                context.Remove(model);
                context.SaveChanges();
                CreateMessage("Ürün listeden kaldırıldı.","success");
                return RedirectToAction("ManCategoryList");
            }

            return View(model);
        }
        public IActionResult DeleteManBrands(int? id)
        {
            var context = new ShopContext();
             if(id == null)
            {
                return NotFound();
            }
            var model = context.MansBrands.Find(id);
            if(model != null)
            {
                context.Remove(model);
                context.SaveChanges();
                CreateMessage("Ürün silindi.","success");
                return RedirectToAction("ManProductsBrands");
            }
            return View(model);
            
        }
        public IActionResult DeleteWomanProduct(int? id)
        {
            var context = new ShopContext();
            if(id == null)
            {
                return NotFound();
            }
            var model = context.WomanProducts.Find(id);
            if(model != null)
            {
                context.Remove(model);
                context.SaveChanges();
                CreateMessage("Ürün silindi.","success");
                return RedirectToAction("WomanProducts");
            }
            return View(model);
        }
        public IActionResult DeleteWomanCategory(int? id)
        {
             var context = new ShopContext();
            if(id == null)
            {
                return NotFound();
            }
            var model = context.WomansCategories.Find(id);
            if(model != null)
            {
                context.Remove(model);
                context.SaveChanges();
                CreateMessage("Ürün silindi.","success");
                return RedirectToAction("WomanCategoryList");
            }
            return View(model);
        }
        public IActionResult DeleteWomanBrands(int? id)
        {
            var context = new ShopContext();
            if(id == null)
            {
                return NotFound();
            }
            var model = context.WomansBrands.Find(id);
            if(model!=null)
            {
                context.Remove(model);
                context.SaveChanges();
                CreateMessage("Ürün silindi.","success");
                return RedirectToAction("WomanProductsBrands");
            }
            return View(model);
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
               var role = await _roleManager.CreateAsync(new IdentityRole(model.Name));
               if(role.Succeeded)
               {
                   return RedirectToAction("RoleList");
               }
               else{
                   foreach (var error in role.Errors)
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
            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)?members:nonmembers;
                list.Add(user);
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
                    if(user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }
                    }
                }
            }
            if(ModelState.IsValid)
            {
                foreach (var userId in model.IdsToDelete ?? new string[]{} )
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
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
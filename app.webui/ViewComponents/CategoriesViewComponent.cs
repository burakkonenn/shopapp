using app.business.Abstract;
 using Microsoft.AspNetCore.Mvc;

 namespace app.webui.ViewComponents
 {
     public class CategoriesViewComponent:ViewComponent
     {
         private ICategoryService _categoryService;
         
         public CategoriesViewComponent(ICategoryService categoryService)
         {
             this._categoryService = categoryService;
             
         }
         public IViewComponentResult Invoke()
         {
            
             return View(
                 _categoryService.GetAll()
             );
         }
     }
 }
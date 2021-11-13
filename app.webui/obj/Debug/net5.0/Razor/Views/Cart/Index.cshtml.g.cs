#pragma checksum "C:\app\app.webui\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e12a34fc5955e9dc99a41e28144279a78a553bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\app\app.webui\Views\_ViewImports.cshtml"
using app.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\app\app.webui\Views\_ViewImports.cshtml"
using app.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\app\app.webui\Views\_ViewImports.cshtml"
using app.webui.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\app\app.webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\app\app.webui\Views\_ViewImports.cshtml"
using app.webui.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e12a34fc5955e9dc99a41e28144279a78a553bb", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cd22a74efb2519bc3ce777bdaf0683be681d1a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CartModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-md-12"">
           <div class=""d-flex justify-content-end"">
               <button style=""width: 260px; height:50px;"" class=""btn btn-warning"" type=""submit""><span class=""h"">Sepeti Onayla ></span></button>
            </div>
        </div>
    </div>
</div>

<div class=""container"">
    <div class=""row"">
        <div class=""col-md-9"">
            <div class=""card-header border cl"">
                <i class=""far fa-user me-2 ""></i>
                <span class=""c"">Alışverişinizi daha hızlı tamamlamak için <a class=""s"" href=""/account/login"">Giriş Yap</a></span>
            </div>
        </div>
    </div>
</div>

<div class=""container"">
    <div class=""row mb-3"">
        <div class=""col-md-9"">
");
#nullable restore
#line 26 "C:\app\app.webui\Views\Cart\Index.cshtml"
             foreach (var item in Model.CartItems)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card mt-3\">\n                    <div class=\"card-header\">\n                        <span class=\"c tex-muted\">Ürün adı: <a");
            BeginWriteAttribute("href", " href=\"", 997, "\"", 1004, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"c\">");
#nullable restore
#line 30 "C:\app\app.webui\Views\Cart\Index.cshtml"
                                                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></span>\n                    </div>\n                   <div class=\"row\">\n                        <div class=\"col-md-4 \">\n                                <div class=\"card-body\">\n                                    <input type=\"checkbox\"");
            BeginWriteAttribute("name", " name=\"", 1264, "\"", 1271, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1272, "\"", 1277, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6e12a34fc5955e9dc99a41e28144279a78a553bb6855", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1326, "~/img/", 1326, 6, true);
#nullable restore
#line 36 "C:\app\app.webui\Views\Cart\Index.cshtml"
AddHtmlAttributeValue("", 1332, item.Image, 1332, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                    <span class=\"ms-2 c text-muted\">");
#nullable restore
#line 37 "C:\app\app.webui\Views\Cart\Index.cshtml"
                                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" XLFJL244</span>
                                </div>
                        </div>
                        <div class=""col-md-5  d-flex align-items-center"">
                            <input type=""number"" class=""form-control"" style=""width: 80px;"" step=""1"" min=""1"" value=""1"">
                        </div>
                        <div class=""col-md-3  d-flex align-items-center"">
                            <span class=""c"">");
#nullable restore
#line 44 "C:\app\app.webui\Views\Cart\Index.cshtml"
                                       Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</span>\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e12a34fc5955e9dc99a41e28144279a78a553bb9462", async() => {
                WriteLiteral("\n                                <a");
                BeginWriteAttribute("href", " href=\"", 1972, "\"", 1979, 0);
                EndWriteAttribute();
                WriteLiteral("><i class=\"fas fa-trash-alt ms-4 text-muted\" style=\"color: black;\"></i></a>\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        </div>\n                   </div>\n                  \n                </div>\n");
#nullable restore
#line 52 "C:\app\app.webui\Views\Cart\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n        <div class=\"col-md-3\">\n                <div class=\"card p-3\">\n                    <h1 class=\"l text-center\">Sipariş Özeti</h1>\n                    <div class=\"card-title\">\n                        <span class=\"g\">Ürünün Toplamı ");
#nullable restore
#line 58 "C:\app\app.webui\Views\Cart\Index.cshtml"
                                                  Write(Model.TotalPrice().ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </div>
                    <div class=""cart-text"">
                        <span class=""g"">Kargo toplamı 11.99 TL</span>
                    </div>
                    <p class=""g text-muted"">Kargo ücreti, siparişinizdeki ürünleri kargolayacak satıcı sayısına göre hesaplanmaktadır.</p>
                </div>
                <div class=""col-md-3 mt-3"">
                   <button style=""width: 260px; height:50px;"" class=""btn btn-warning"" type=""submit""><span class=""h"">+  İndirim kodu gir</span></button>
               </div>
        </div>
       
    </div>
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CartModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
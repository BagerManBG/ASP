#pragma checksum "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e84f1bcfa831167b6c0d076bde7d6d66d1904055"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PicComputers.Pages.Product.Pages_Product_Details), @"mvc.1.0.razor-page", @"/Pages/Product/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Product/Details.cshtml", typeof(PicComputers.Pages.Product.Pages_Product_Details), null)]
namespace PicComputers.Pages.Product
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\_ViewImports.cshtml"
using PicComputers;

#line default
#line hidden
#line 3 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\_ViewImports.cshtml"
using PicComputers.Data;

#line default
#line hidden
#line 4 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e84f1bcfa831167b6c0d076bde7d6d66d1904055", @"/Pages/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e362c2e821d3ddac5692ff654aaffbe4bf85d0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Product_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(192, 121, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Product</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(314, 48, false);
#line 18 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Product.Name));

#line default
#line hidden
            EndContext();
            BeginContext(362, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(406, 44, false);
#line 21 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Product.Name));

#line default
#line hidden
            EndContext();
            BeginContext(450, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(494, 49, false);
#line 24 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Product.Price));

#line default
#line hidden
            EndContext();
            BeginContext(543, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(587, 45, false);
#line 27 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Product.Price));

#line default
#line hidden
            EndContext();
            BeginContext(632, 43, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n");
            EndContext();
#line 32 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
     if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
    {

#line default
#line hidden
            BeginContext(749, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(757, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "083192638b57426eb4c9ab06c49440ab", async() => {
                BeginContext(818, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 34 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
                               WriteLiteral(Model.Product.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(826, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 35 "C:\Users\BagerMan\Desktop\ASP Cheat Stuff\repo\PicComputers\PicComputers\Pages\Product\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(835, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(839, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b74f033ee3c84dd5a14ca0652ed4ba7f", async() => {
                BeginContext(861, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(877, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PicComputers.Pages.Product.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PicComputers.Pages.Product.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PicComputers.Pages.Product.DetailsModel>)PageContext?.ViewData;
        public PicComputers.Pages.Product.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

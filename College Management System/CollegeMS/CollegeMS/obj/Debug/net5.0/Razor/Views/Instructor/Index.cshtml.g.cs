#pragma checksum "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c44d1078ea9313f4a281b64d9d74190ea86545c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instructor_Index), @"mvc.1.0.view", @"/Views/Instructor/Index.cshtml")]
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
#line 1 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\_ViewImports.cshtml"
using CollegeMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\_ViewImports.cshtml"
using CollegeMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c44d1078ea9313f4a281b64d9d74190ea86545c4", @"/Views/Instructor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1006be527b5afc8e23b8aad3d69d1387fd65271e", @"/Views/_ViewImports.cshtml")]
    public class Views_Instructor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CollegeMS.Models.Instructor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
  
    ViewData["Title"] = "Instructors";
    int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>All Instructor in College</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c44d1078ea9313f4a281b64d9d74190ea86545c44408", async() => {
                WriteLiteral("Add New Instructor <i class=\"fas fa-plus ms-2\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table table-bordered\">\r\n    <thead class=\"bg-success text-white\">\r\n        <tr>\r\n            <th>\r\n                #\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Dep));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Dep.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new {  id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 67 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete","Instructor", new {  id=item.Id  },new{@class="delete-btn"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 70 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Index.cshtml"
            i++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CollegeMS.Models.Instructor>> Html { get; private set; }
    }
}
#pragma warning restore 1591

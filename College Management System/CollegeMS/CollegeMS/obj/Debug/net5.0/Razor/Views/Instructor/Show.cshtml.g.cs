#pragma checksum "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2eee0f4a4c1bd883d2e0a45e5d988ba0d891b64d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instructor_Show), @"mvc.1.0.view", @"/Views/Instructor/Show.cshtml")]
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
#nullable restore
#line 1 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
using CollegeMS.viewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eee0f4a4c1bd883d2e0a45e5d988ba0d891b64d", @"/Views/Instructor/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1006be527b5afc8e23b8aad3d69d1387fd65271e", @"/Views/_ViewImports.cshtml")]
    public class Views_Instructor_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<StudentCourseModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table table-bordered text-center"">
    <thead class=""text-white bg-danger"">
        <tr>
            <th scope=""col"">StudentName</th>
            <th scope=""col"">Level</th>
            <th scope=""col"">Degree</th>
            <th scope=""col"">SetDegree</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 13 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
         foreach (var Std in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 16 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
               Write(Std.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 17 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
               Write(Std.Level);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 18 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
               Write(Std.degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 579, "\"", 634, 4);
            WriteAttributeValue("", 586, "/Instructor/SetDegree/", 586, 22, true);
#nullable restore
#line 19 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
WriteAttributeValue("", 608, Std.ID, 608, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 615, "?Crs_ID=", 615, 8, true);
#nullable restore
#line 19 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
WriteAttributeValue("", 623, Std.Crs_ID, 623, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">degree</a></td>\r\n            </tr>\r\n");
#nullable restore
#line 21 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<a class=\"btn btn-outline-danger\"");
            BeginWriteAttribute("href", " href=\"", 742, "\"", 794, 2);
            WriteAttributeValue("", 749, "/Instructor/details/", 749, 20, true);
#nullable restore
#line 25 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Instructor\Show.cshtml"
WriteAttributeValue("", 769, ViewData["InstructorID"], 769, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">back to courses</a>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<StudentCourseModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c6c462712d1d70248cd80d64be5e90f4ad237eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_MyCourses), @"mvc.1.0.view", @"/Views/Student/MyCourses.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c6c462712d1d70248cd80d64be5e90f4ad237eb", @"/Views/Student/MyCourses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1006be527b5afc8e23b8aad3d69d1387fd65271e", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_MyCourses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<StudentCourses>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
  
    ViewData["title"] = "My Courses";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""table table-bordered"">
    <thead class=""bg-primary text-white"">
        <tr>
            <th>
                Course Name
            </th>
            <th>
                Course Instructor
            </th>
            <th>
                Course Degree
            </th>
            <th>
                Min Degree
            </th>
            <th>
                Your Degree
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 26 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
         foreach (var sc in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 29 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
               Write(sc.Course.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
               Write(sc.Course.Instructor.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
               Write(sc.Course.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
               Write(sc.Course.MinDegree);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 35 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
                 if (sc.Course.MinDegree > sc.Degree)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"bg-danger text-white\">");
#nullable restore
#line 37 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
                                                Write(sc.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 38 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
                }
                else if(sc.Course.MinDegree <= sc.Degree)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"bg-success text-white\">");
#nullable restore
#line 41 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
                                                 Write(sc.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 42 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Pending</td>\r\n");
#nullable restore
#line 44 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 47 "F:\ITI\Projects\ASP MVC project\College Management System\CollegeMS\CollegeMS\Views\Student\MyCourses.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<StudentCourses>> Html { get; private set; }
    }
}
#pragma warning restore 1591

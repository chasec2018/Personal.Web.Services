#pragma checksum "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9aa2df7c376fead9eba2a8a8f1ec73dc2e08fd00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ResumeService.Pages.Pages_Projects), @"mvc.1.0.razor-page", @"/Pages/Projects.cshtml")]
namespace ResumeService.Pages
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
#line 1 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\_ViewImports.cshtml"
using ResumeService;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9aa2df7c376fead9eba2a8a8f1ec73dc2e08fd00", @"/Pages/Projects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12d8c502b4fbf92426a2ceac81e454934b0f6fd6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Projects : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
  
    ViewData["Title"] = "Projects";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""container-fluid"">
        <div class=""text-center"">
            <button type=""button"" class=""btn btn-info"" data-toggle=""modal"" data-target=""#csharp-project-page"">C#</button>
        </div>

        <div class=""modal fade"" id=""csharp-project-page"" tabindex=""-1"" role=""dialog"" aria-labelledby=""csharp-project-page-title"" aria-hidden=""true"">
            <div class=""modal-dialog modal-xl modal-dialog-scrollable"" role=""document"">
                <div class=""modal-content"">

                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""csharp-project-page-title"">C# Code Behind Pages</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>

                    <div class=""modal-body"">
                        <pre>
                            <code class=""lang-csharp"">
  ");
            WriteLiteral("                              ");
#nullable restore
#line 26 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                           Write(Model.CSharpCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </code>    \r\n                        </pre>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"container-fluid\">\r\n");
#nullable restore
#line 36 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
         foreach (var project in Model.ProjHistory)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"accordion m-2\"");
            BeginWriteAttribute("id", " id=\"", 1478, "\"", 1506, 2);
            WriteAttributeValue("", 1483, "ID-", 1483, 3, true);
#nullable restore
#line 38 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
WriteAttributeValue("", 1486, project.AccordianID, 1486, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"container-fluid\">\r\n                    <div");
            BeginWriteAttribute("id", " id=\"", 1581, "\"", 1606, 2);
            WriteAttributeValue("", 1586, "ID-", 1586, 3, true);
#nullable restore
#line 40 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
WriteAttributeValue("", 1589, project.HeaderID, 1589, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h2 class=\"mb-0\">\r\n                            <button class=\"btn btn-block btn-dark rounded border-0\" type=\"button\" data-toggle=\"collapse\" data-target=\"#ID-");
#nullable restore
#line 42 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                                                                                                                     Write(project.AccordianID);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 42 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                                                                                                                                          Write(project.HeaderID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"true\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 1851, "\"", 1908, 4);
            WriteAttributeValue("", 1867, "ID-", 1867, 3, true);
#nullable restore
#line 42 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
WriteAttributeValue("", 1870, project.AccordianID, 1870, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1890, "-", 1890, 1, true);
#nullable restore
#line 42 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
WriteAttributeValue("", 1891, project.HeaderID, 1891, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 43 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                           Write(project.ProjectTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </button>\r\n                        </h2>\r\n                    </div>\r\n\r\n                    <div");
            BeginWriteAttribute("id", " id=\"", 2091, "\"", 2137, 4);
            WriteAttributeValue("", 2096, "ID-", 2096, 3, true);
#nullable restore
#line 48 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
WriteAttributeValue("", 2099, project.AccordianID, 2099, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2119, "-", 2119, 1, true);
#nullable restore
#line 48 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
WriteAttributeValue("", 2120, project.HeaderID, 2120, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 2155, "\"", 2193, 2);
            WriteAttributeValue("", 2173, "ID-", 2173, 3, true);
#nullable restore
#line 48 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
WriteAttributeValue("", 2176, project.HeaderID, 2176, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-parent=\"#ID-");
#nullable restore
#line 48 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                                                                                                                            Write(project.AccordianID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <div class=\"row m-2\">\r\n                            <div class=\"col\">\r\n                                <h6 class=\"font-italic small m-0\">Timeline: ");
#nullable restore
#line 51 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                                                       Write(project.Timeline);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                <h6 class=\"font-italic small m-0\">Company: ");
#nullable restore
#line 52 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                                                      Write(project.Company);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                <h6 class=\"h6 mt-2 mb-2\">Project Overview</h6>\r\n                                <p class=\"small\">\r\n                                    ");
#nullable restore
#line 55 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                               Write(project.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </p>
                            </div>
                        </div>

                        <div class=""row m-2"">
                            <div class=""col-6"">
                                <h6 class=""h6"">Technologies Utilized</h6>
                                <ul>
");
#nullable restore
#line 64 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                     foreach (var technology in project.Technology)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"small\">\r\n                                            ");
#nullable restore
#line 67 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                       Write(technology);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </li>\r\n");
#nullable restore
#line 69 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </div>\r\n                            <div class=\"col-6\">\r\n                                <h6 class=\"h6\">Languages Utilized</h6>\r\n                                <ul>\r\n");
#nullable restore
#line 75 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                     foreach (var language in project.Languages)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"small\">\r\n                                            ");
#nullable restore
#line 78 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                       Write(language);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </li>\r\n");
#nullable restore
#line 80 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 87 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Projects.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResumeService.Pages.ProjectsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ResumeService.Pages.ProjectsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ResumeService.Pages.ProjectsModel>)PageContext?.ViewData;
        public ResumeService.Pages.ProjectsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

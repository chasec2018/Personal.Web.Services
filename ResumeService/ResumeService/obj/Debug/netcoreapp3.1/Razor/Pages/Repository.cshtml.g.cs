#pragma checksum "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35342ea78dea709d1057a6260b82970652e985f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ResumeService.Pages.Pages_Repository), @"mvc.1.0.razor-page", @"/Pages/Repository.cshtml")]
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
#nullable restore
#line 3 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
using ResumeService.EntryModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35342ea78dea709d1057a6260b82970652e985f7", @"/Pages/Repository.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12d8c502b4fbf92426a2ceac81e454934b0f6fd6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Repository : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
  
    ViewData["Title"] = "Repository";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""container-fluid mb-3"">
        <div class=""text-center"">
            <button type=""button"" class=""btn btn-info"" data-toggle=""modal"" data-target=""#csharp-index-page"">C#</button>
        </div> 

        <div class=""modal fade"" id=""csharp-index-page"" tabindex=""-1"" role=""dialog"" aria-labelledby=""csharp-index-page-title"" aria-hidden=""true"">
            <div class=""modal-dialog modal-xl modal-dialog-scrollable"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""csharp-index-page-title"">C# Code Behind Pages</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <pre>
                            <code class=""lang-csharp"">
        ");
            WriteLiteral("                        ");
#nullable restore
#line 25 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
                           Write(Model.CSharpCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </code>    
                        </pre>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class=""container-fluid"">
        <table class=""table table-sm table-hover"">
            <thead>
                <tr>
                    <th scope=""col"" style=""width:15%"">Title</th>
                    <th scope=""col"" style=""width:30%"">Description</th>
                    <th scope=""col"" style=""width:25%"">Link</th>
                    <th scope=""col"" style=""width:30%"">GIT Request</th>
                    <th scope=""col"" style=""width:5%"">Copy</th>
                </tr>
            </thead>

            <tbody>
");
#nullable restore
#line 48 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
                 foreach (GithubRepositoryEntry Repository in Model.Repositories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"small\">");
#nullable restore
#line 51 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
                                     Write(Repository.RepoName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"small\">");
#nullable restore
#line 52 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
                                     Write(Repository.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"small\"><a");
            BeginWriteAttribute("href", " href=\"", 2206, "\"", 2229, 1);
#nullable restore
#line 53 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
WriteAttributeValue("", 2213, Repository.Link, 2213, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 53 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
                                                                                Write(Repository.Link);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                        <td class=\"small\"");
            BeginWriteAttribute("id", " id=\"", 2315, "\"", 2338, 1);
#nullable restore
#line 54 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
WriteAttributeValue("", 2320, Repository.RepoID, 2320, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">git clone ");
#nullable restore
#line 54 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
                                                                       Write(Repository.GitRequest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <button type=\"button\" class=\"btn btn-sm align-content-center table-tooltip-btn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2516, "\"", 2561, 3);
            WriteAttributeValue("", 2526, "CopyToClipBoard(", 2526, 16, true);
#nullable restore
#line 56 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
WriteAttributeValue("", 2542, Repository.RepoID, 2542, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2560, ")", 2560, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("onmouseout", " onmouseout=\"", 2562, "\"", 2612, 3);
            WriteAttributeValue("", 2575, "ToolTipHover(RTXT-", 2575, 18, true);
#nullable restore
#line 56 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
WriteAttributeValue("", 2593, Repository.RepoID, 2593, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2611, ")", 2611, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span class=\"table-tooltip-btn-text\"");
            BeginWriteAttribute("id", " id=\"", 2684, "\"", 2712, 2);
            WriteAttributeValue("", 2689, "RTXT-", 2689, 5, true);
#nullable restore
#line 57 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
WriteAttributeValue("", 2694, Repository.RepoID, 2694, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Copy to Clipboard</span>
                                <svg viewBox=""0 0 14 16"" version=""1.1"" width=""14"" height=""16"" aria-hidden=""true"">
                                    <path fill-rule=""evenodd"" d=""M2 13h4v1H2v-1zm5-6H2v1h5V7zm2 3V8l-3 3 3 3v-2h5v-2H9zM4.5 9H2v1h2.5V9zM2 12h2.5v-1H2v1zm9 1h1v2c-.02.28-.11.52-.3.7-.19.18-.42.28-.7.3H1c-.55 0-1-.45-1-1V4c0-.55.45-1 1-1h3c0-1.11.89-2 2-2 1.11 0 2 .89 2 2h3c.55 0 1 .45 1 1v5h-1V6H1v9h10v-2zM2 5h8c0-.55-.45-1-1-1H8c-.55 0-1-.45-1-1s-.45-1-1-1-1 .45-1 1-.45 1-1 1H3c-.55 0-1 .45-1 1z"">
                                    </path>
                                </svg>
                            </button>
                        </td>
                    </tr>
");
#nullable restore
#line 65 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Pages\Repository.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RepositoryModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RepositoryModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RepositoryModel>)PageContext?.ViewData;
        public RepositoryModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5db20c8d28fbc8421df87d73a89a2913fca83f8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_ConfirmEmail), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/ConfirmEmail.cshtml")]
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
#line 1 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\_ViewImports.cshtml"
using ResumeService.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\_ViewImports.cshtml"
using ResumeService.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\_ViewImports.cshtml"
using ResumeService.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\_ViewImports.cshtml"
using ResumeService.Areas.Identity.EntityModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\_ViewImports.cshtml"
using ResumeService.Areas.Identity.InputModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using ResumeService.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5db20c8d28fbc8421df87d73a89a2913fca83f8b", @"/Areas/Identity/Pages/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe16a717ba9edc5b1e47ec8c2778b419181bcdcc", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"861d81cfe9293383a7e29fccaaabda7b5071c009", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "Email Confirmed";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"container-fluid\">\r\n        <h4 class=\"h4\">");
#nullable restore
#line 8 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
                  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <p>\r\n            ");
#nullable restore
#line 10 "C:\Users\chase\source\repos\Personal\Personal.Web.Services\ResumeService\ResumeService\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
       Write(Model.StatusMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </p>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ConfirmEmailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfirmEmailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfirmEmailModel>)PageContext?.ViewData;
        public ConfirmEmailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

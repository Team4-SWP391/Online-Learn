#pragma checksum "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaaf780a1f794a61d097d996a36032c27e4c9cca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
#line 1 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\_ViewImports.cshtml"
using Online_Learn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\_ViewImports.cshtml"
using Online_Learn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaaf780a1f794a61d097d996a36032c27e4c9cca", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f4e0d2f8e28077aa96898cd6a6e9be2eb759d8a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/profile.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Account/Profile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aaaf780a1f794a61d097d996a36032c27e4c9cca4819", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"profile\">\r\n    <h2 class=\"profile-heading\">Profile Udemy</h2>\r\n    <div class=\"profile-wrapper\">\r\n        <div class=\"profile-from\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaaf780a1f794a61d097d996a36032c27e4c9cca6108", async() => {
                WriteLiteral("\r\n                <div class=\"profile-from__group\">\r\n                    <label class=\"profile-lable\">Full Name</label><br>\r\n                    <input type=\"text\" class=\"profile-input\" name=\"NewAccount.FulllName\"");
                BeginWriteAttribute("value", " value=\"", 601, "\"", 635, 1);
#nullable restore
#line 16 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 609, ViewBag.account.FulllName, 609, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <input type=\"text\" class=\"profile-input\" name=\"NewAccount.AccountId\"");
                BeginWriteAttribute("value", " value=\"", 727, "\"", 761, 1);
#nullable restore
#line 17 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 735, ViewBag.account.AccountId, 735, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" hidden>
                </div>
                <div class=""profile-from__group"">
                    <p class=""profile-para"">Gender</p>
                    <input type=""radio"" class=""profile-radio"" name=""NewAccount.Gender"" id=""profile-male"" value=""true"" ");
#nullable restore
#line 21 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
                                                                                                                  Write(ViewBag.account.Gender == true ? "checked" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    <label class=\"profile-lable__radio\" for=\"profile-male\">Male</label><br>\r\n                    <input type=\"radio\" class=\"profile-radio\" name=\"NewAccount.Gender\" id=\"profile-female\" value=\"false\" ");
#nullable restore
#line 23 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
                                                                                                                     Write(ViewBag.account.Gender == false ? "checked" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(@" />
                    <label class=""profile-lable__radio"" for=""profile-female"">Female</label><br>
                </div>
                <div class=""profile-from__group"">
                    <label class=""profile-lable"">Day of birth</label><br>
                    <input type=""date"" class=""profile-input"" id=""profile-date"" name=""NewAccount.Dob""");
                BeginWriteAttribute("value", " value=\"", 1693, "\"", 1766, 1);
#nullable restore
#line 28 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 1701, Convert.ToDateTime(ViewBag.account.Dob).ToString("yyyy-MM-dd"), 1701, 65, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n                </div>\r\n                <div class=\"profile-from__group\">\r\n                    <label class=\"profile-lable\">Address</label><br>\r\n                    <input type=\"text\" class=\"profile-input\" name=\"NewAccount.Address\"");
                BeginWriteAttribute("value", " value=\"", 2002, "\"", 2034, 1);
#nullable restore
#line 32 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 2010, ViewBag.account.Address, 2010, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                </div>\r\n                <div class=\"profile-from__group\">\r\n                    <label class=\"profile-lable\">Phone</label><br>\r\n                    <input type=\"number\" class=\"profile-input\" name=\"NewAccount.Phone\"");
                BeginWriteAttribute("value", " value=\"", 2267, "\"", 2297, 1);
#nullable restore
#line 36 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 2275, ViewBag.account.Phone, 2275, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                </div>\r\n                <div class=\"profile-from__group\">\r\n                    <label class=\"profile-lable\">Language</label><br>\r\n                    <input type=\"text\" class=\"profile-input\" name=\"NewAccount.Language\"");
                BeginWriteAttribute("value", " value=\"", 2534, "\"", 2567, 1);
#nullable restore
#line 40 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 2542, ViewBag.account.Language, 2542, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                </div>\r\n                <div class=\"profile-from__group\">\r\n                    <label class=\"profile-lable\">Email</label><br>\r\n                    <input type=\"email\" class=\"profile-input\" name=\"NewAccount.Email\"");
                BeginWriteAttribute("value", " value=\"", 2799, "\"", 2829, 1);
#nullable restore
#line 44 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 2807, ViewBag.account.Email, 2807, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                </div>\r\n                <div class=\"profile-from__group\">\r\n                    <label class=\"profile-lable\">Amount</label><br>\r\n                    <input type=\"number\" disabled class=\"profile-input\" name=\"NewAccount.Amount\"");
                BeginWriteAttribute("value", " value=\"", 3073, "\"", 3104, 1);
#nullable restore
#line 48 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Account\Profile.cshtml"
WriteAttributeValue("", 3081, ViewBag.account.Amount, 3081, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                </div>\r\n                <div class=\"profile-from__group\">\r\n                    <button class=\"from-submit\">Save</button>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div class=\"profile-image\">\r\n            <div class=\"profile-avt\">\r\n                <img src=\"https://source.unsplash.com/random\"");
            BeginWriteAttribute("alt", " alt=\"", 3444, "\"", 3450, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Login\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78c2be9d6ddb88801ed8c17e61cb75b2faa65460"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Login), @"mvc.1.0.view", @"/Views/Login/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78c2be9d6ddb88801ed8c17e61cb75b2faa65460", @"/Views/Login/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f4e0d2f8e28077aa96898cd6a6e9be2eb759d8a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/login.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "78c2be9d6ddb88801ed8c17e61cb75b2faa654604786", async() => {
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
            WriteLiteral(@"
<div class=""content"">
    <div class=""content_title"">
        <h4 class=""text-center"" style=""border-bottom: 1px solid #d1d7dc; padding: 5% 0;"">
            Log In to Your Udemy
            Account!
        </h4>
        <div class=""login"">
            <a class=""login_facebook login_with"">
                <i class=""fab fa-facebook""></i>
                <span>Continue With Facebook</span>
            </a>
            <a class=""login_google login_with"" href='https://accounts.google.com/o/oauth2/auth?scope=email&redirect_uri=https://localhost:44393/Login/Login_Google&response_type=code&client_id=240096817026-hiacplg3lvqrnku3g6ihm26fv3geog3q.apps.googleusercontent.com&approval_prompt=force'>
                <i class=""fab fa-google""></i>
                <span>
                    Continue With Google
                </span>
            </a>
            <div class=""login_account"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78c2be9d6ddb88801ed8c17e61cb75b2faa654606840", async() => {
                WriteLiteral("\r\n                    <div class=\"login_account-form\">\r\n                        <i class=\"fal fa-envelope\"></i>\r\n                        <input name=\"email\" type=\"email\"");
                BeginWriteAttribute("value", " value=\"", 1188, "\"", 1214, 1);
#nullable restore
#line 28 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Login\Login.cshtml"
WriteAttributeValue("", 1196, ViewData["email"], 1196, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form\" placeholder=\"Email\">\r\n                    </div>\r\n                    <div class=\"login_account-form\">\r\n                        <i class=\"fal fa-lock\"></i>\r\n                        <input name=\"pass\" type=\"password\"");
                BeginWriteAttribute("value", " value=\"", 1444, "\"", 1469, 1);
#nullable restore
#line 32 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Login\Login.cshtml"
WriteAttributeValue("", 1452, ViewData["pass"], 1452, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form\" placeholder=\"Password\">\r\n                    </div>\r\n                    <div class=\"login_account-remember\">\r\n                        <input name=\"remember\" type=\"checkbox\"\r\n                               ");
#nullable restore
#line 36 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Login\Login.cshtml"
                           Write( ViewBag.remember ? "checked": "");

#line default
#line hidden
#nullable disable
                WriteLiteral(@" id=""remember"">
                        <label class=""form-check-label"" for=""remember""
                               style=""font-size: 1.1rem; cursor: pointer;"">
                            Remember
                            me
                        </label>
                    </div>
                    <div class=""login_account-err-mess"">
                        <span>");
#nullable restore
#line 44 "D:\PROJECT\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Login\Login.cshtml"
                         Write(ViewData["ErrMess"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"login_account-submit\">\r\n                        <button type=\"submit\">Log In</button>\r\n                    </div>\r\n                ");
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
            WriteLiteral("\r\n                <div class=\"login_account-forgot\">\r\n                    <span>or <a");
            BeginWriteAttribute("href", " href=\"", 2424, "\"", 2431, 0);
            EndWriteAttribute();
            WriteLiteral(">Forgot Password</a></span>\r\n                </div>\r\n            </div>\r\n            <div class=\"login_sigup\">\r\n                <span>Don\'t have an account? <a");
            BeginWriteAttribute("href", " href=\"", 2591, "\"", 2598, 0);
            EndWriteAttribute();
            WriteLiteral(">Sign up</a></span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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

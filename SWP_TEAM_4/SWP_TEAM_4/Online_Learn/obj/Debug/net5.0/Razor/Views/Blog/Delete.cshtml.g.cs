#pragma checksum "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fac968451594bf317ad638b7ef86129aba7d96d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Delete), @"mvc.1.0.view", @"/Views/Blog/Delete.cshtml")]
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
#line 1 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\_ViewImports.cshtml"
using Online_Learn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\_ViewImports.cshtml"
using Online_Learn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fac968451594bf317ad638b7ef86129aba7d96d9", @"/Views/Blog/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f4e0d2f8e28077aa96898cd6a6e9be2eb759d8a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Blog_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Online_Learn.Models.Blog>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/BlogDetails.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fac968451594bf317ad638b7ef86129aba7d96d95711", async() => {
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



    <div class=""blogdetail"">
            <div class=""container my-5"">
                <div class=""row"">
                    <div class=""col-md-1""></div>
                    <div class=""col-md-8"">
                        <div class=""row"">
                            <div class=""col-md-1"">
                                <div class=""avt "">
                                    <a");
            BeginWriteAttribute("href", " href=\"", 584, "\"", 614, 1);
#nullable restore
#line 24 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml"
WriteAttributeValue("", 591, ViewData["AccountImg"], 591, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""text-decoration: none;""></a>
                                </div>
                            </div>
                            <div class=""col-md-4 profile"">
                                <div>
                                    <a href=""https://www.w3schools.com/""
                                        style=""text-decoration: none; color: #5488c7""><b>");
#nullable restore
#line 30 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml"
                                                                                    Write(ViewData["AccountName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b></a>
                                    <span>
                                        <button type=""button""
                                            style=""color: #606266; background-color: white; border: 1px solid gainsboro; border-radius: 3px ;width: 60px;"">
                                            Follow
                                        </button>
                                    </span>

                                </div>
                            </div>
                            <div class=""col-md-7"">
                                <div class=""drop""> ");
#nullable restore
#line 41 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml"
                                              Write(Html.DisplayFor(model => model.UpdateAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            </div>\r\n                        </div>\r\n                        <h3>Are you sure you want to delete this?</h3>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fac968451594bf317ad638b7ef86129aba7d96d99444", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fac968451594bf317ad638b7ef86129aba7d96d99726", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 46 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BlogId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> \r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fac968451594bf317ad638b7ef86129aba7d96d911572", async() => {
                    WriteLiteral("Cancel");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <div class=\"content\">\r\n                            <br>\r\n                            <h1 style=\"font-size: 40px; font-weight: 650;\">");
#nullable restore
#line 52 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml"
                                                                      Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1><br>\r\n\r\n                        </div>\r\n                         \r\n                            \r\n\r\n                        \r\n                        <div class=\"my-5\">\r\n                            <p>");
#nullable restore
#line 60 "C:\Users\Admin\Documents\GitHub\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Blog\Delete.cshtml"
                          Write(Html.DisplayFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p><br>                           
                        </div>
                        <div>
                    

                </div>
                    </div>
                    <div class=""col-md-3"" style=""padding-left: 24px; padding-right: 0px;"">
                        <div class=""row"">
                            <div class=""col-md-8 style-table"">TABLE
                                OF CONTENT</div>
                            <div class=""col"" style=""padding-top: 4px; padding-left: 7px;"">
                                <hr>
                            </div>
                        </div>
                        <div class=""tabl"">
                            <p class=""el-alert__description"">1. Đặt vấn đề</p>
                            <p class=""el-alert__description"">2. Cách Thực Hiện </p>
                            <p class=""el-alert__description"">2.1. Build thư viện local</p>
                            <p class=""el-alert__description"">2.2. Build thư viện local reposito");
            WriteLiteral(@"ry</p>
                        </div>

                        <br>
                        <div class=""row"" style=""margin-left:13px;"">
                            <div class=""col-md-8 style-table"">SUGGESTED COURSE</div>
                            <div class=""col"" style=""padding-top: 4px; padding-left: 7px;"">
                                <hr>
                            </div>
                        </div>
                        <div class=""row cou-sg"">
                            <div class=""col-md-3"">
                                <img src=""https://images.viblo.asia/thumbnail/6fba9e20-cbb1-4b63-aa36-c0e5664d19d1.png""");
            BeginWriteAttribute("alt", "\r\n                                    alt=\"", 4201, "\"", 4244, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"50px\">\r\n                            </div>\r\n                            <div class=\"col-md-9\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 4383, "\"", 4390, 0);
            EndWriteAttribute();
            WriteLiteral(@"><span class=""courses-tilte"">Coding for A/B testing: Run more AB tests, find
                                        more winners</span></a>
                            </div>
                        </div>

                        <div class=""row cou-sg"">
                            <div class=""col-md-3"">
                                <img src=""https://images.viblo.asia/thumbnail/bfed898e-7be3-41c3-bd23-7fc8c7743fc2.png""");
            BeginWriteAttribute("alt", "\r\n                                    alt=\"", 4825, "\"", 4868, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"50px\">\r\n                            </div>\r\n                            <div class=\"col-md-9\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 5007, "\"", 5014, 0);
            EndWriteAttribute();
            WriteLiteral(@"><span class=""courses-tilte""> Coding for A/B testing: Run more AB tests, find
                                        more winners</span></a>
                            </div>
                        </div>

                        <div class=""row cou-sg"">
                            <div class=""col-md-3"">
                                <img src=""https://images.viblo.asia/thumbnail/410433e3-6827-455a-ab74-8d6f9aae1cb5.png
                                """);
            BeginWriteAttribute("alt", " alt=\"", 5484, "\"", 5490, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"50px\">\r\n                            </div>\r\n                            <div class=\"col-md-9\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 5629, "\"", 5636, 0);
            EndWriteAttribute();
            WriteLiteral("><span class=\"courses-tilte\">Coding for A/B testing</span></a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Online_Learn.Models.Blog> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

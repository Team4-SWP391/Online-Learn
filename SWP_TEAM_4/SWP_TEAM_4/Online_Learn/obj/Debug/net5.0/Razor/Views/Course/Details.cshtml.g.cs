#pragma checksum "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Course\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27ea6509547a2a82c92594083f5f5f2076fe8edb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Details), @"mvc.1.0.view", @"/Views/Course/Details.cshtml")]
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
#line 1 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\_ViewImports.cshtml"
using Online_Learn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\_ViewImports.cshtml"
using Online_Learn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27ea6509547a2a82c92594083f5f5f2076fe8edb", @"/Views/Course/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f4e0d2f8e28077aa96898cd6a6e9be2eb759d8a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Course_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Online_Learn.Models.Course>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/home.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/course-update.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/courseDetail.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("course-header__back"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/home.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/courseDetail.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Course\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css\" />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "27ea6509547a2a82c92594083f5f5f2076fe8edb6522", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "27ea6509547a2a82c92594083f5f5f2076fe8edb7637", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "27ea6509547a2a82c92594083f5f5f2076fe8edb8752", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"course-header\">\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27ea6509547a2a82c92594083f5f5f2076fe8edb9908", async() => {
                WriteLiteral("<i class=\"fas fa-angle-left\"></i>Back to course");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
		<span class=""course-header__key"">Keyword research for bloggers</span>
		<span class=""course-header__bold"">Draft</span>
		<span class=""course-header__tt"">Omin of video contenet upload</span>
</div>
<div class=""course-title container-fluid"">
        <div class=""course-preview"" id=""test"">
            <div class=""course-preview__image"">
                <img");
            BeginWriteAttribute("src", " src=\"", 902, "\"", 932, 1);
#nullable restore
#line 22 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Course\Details.cshtml"
WriteAttributeValue("", 908, ViewData["CourseImage"], 908, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 933, "\"", 939, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n            <div class=\"course-preview__cart\">\r\n                <h1 class=\"course-preview__price\">");
#nullable restore
#line 25 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Course\Details.cshtml"
                                             Write(ViewData["CoursePrice"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"$</h1>
                <button class=""course-preview__btnatc"">Add to cart</button><br>
                <button class=""course-preview__btnbn"">Buy now</button><br>
                <span class=""course-preview__gua"">30-Day Money-Black Guarantee</span>
            </div>
            <div class=""course-preview__info"">
                <h5 class=""course-preview__heading"">This course includes:</h5>
                <ul class=""course-preview__list"">
                    <li class=""course-preview__items""><i class=""fas fa-laptop""></i> 6.5 hourse on-demand video</li>
                    <li class=""course-preview__items""><i class=""fas fa-file""></i> 2 articles</li>
                    <li class=""course-preview__items""><i class=""fas fa-folder""></i> 28 downloadable</li>
                    <li class=""course-preview__items""><i class=""fas fa-infinity""></i> Full lifetime access</li>
                    <li class=""course-preview__items""><i class=""fas fa-mobile-alt""></i> Access on mobile and TV</li>
                    ");
            WriteLiteral(@"<li class=""course-preview__items""><i class=""fas fa-trophy""></i> Certificate of completion</li>
                </ul>
            </div>
            <div class=""course-preview__bussiness"">
                <h5 class=""course-preview__train"">Training 5 or more people?</h5>
                <p class=""course-preview__doc"">Get your team access to 15,000+ top Udemy courses anytime, anywhere.</p>
                <button class=""course-preview__try"">Try Udemy Business</button>
            </div>
        </div>
        <div class=""course-title__main"">
            <h1 class=""course-title__name"">");
#nullable restore
#line 48 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Course\Details.cshtml"
                                      Write(ViewData["CourseName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <p class=\"course-title__content\">");
#nullable restore
#line 49 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Course\Details.cshtml"
                                        Write(ViewData["CourseDepartment"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            <span class=""course-title__level""> <span class=""course-title__seller"">Bestseller</span>
                <span class=""course-title__totalstar"">4.6</span>
                <div class=""rate"">
                    <i data-star='0' class=""fas fa-star stars starActive""></i>
                    <i data-star='1' class=""fas fa-star stars starActive""></i>
                    <i data-star='2' class=""fas fa-star stars starActive""></i>
                    <i data-star='3' class=""fas fa-star stars starActive""></i>
                    <i data-star='4' class=""fas fa-star stars starActive""></i>
                </div>
                (11,321 ratings) <span class=""course-title__totalstudent"">53,275 students</span>
            </span><br>
            <span class=""course-title__createby"">Created by <span class=""course-title__author"">Mosh
                    Hamedani</span></span>
            <br>
            <span class=""course-title__cc""><i class=""fas fa-laptop-code""></i> Java, Spring MVC, Spring bo");
            WriteLiteral(@"ot, SQL,
                MySQL</span>
        </div>
    </div>

    <div class=""course"">
        <div class=""course-learn"">
            <h2 class=""course-learn__heading"">What you'll learn</h2>
            <div class=""course-learn__wrap"">
                <div class=""course-learn__will"">
                    <span class=""course-learn__skin""><i class=""fad fa-check""></i>Have an intermediate skill level of
                        Python
                        programming.</span> <br>
                    <span class=""course-learn__skin""><i class=""fad fa-check""></i>Use the numpy library to create and
                        manipulate
                        arrays.</span><br>
                    <span class=""course-learn__skin""><i class=""fad fa-check""></i>Learn how to work with various data
                        formats
                        within python, including: JSON,HTML, and MS Excel Worksheets.</span><br>
                    <span class=""course-learn__skin""><i class=""fad fa-check""></");
            WriteLiteral(@"i>Have a portfolio of various data
                        analysis
                        projects.</span><br>
                </div>
                <div class=""course-learn__will"">
                    <span class=""course-learn__skin""><i class=""fad fa-check""></i>Use the Jupyter Notebook
                        Environment.</span><br>
                    <span class=""course-learn__skin""><i class=""fad fa-check""></i>Use the pandas module with Python to
                        create
                        and
                        structure data.</span><br>
                    <span class=""course-learn__skin""><i class=""fad fa-check""></i>Create data visualizations using
                        matplotlib
                        and
                        the seaborn modules with python.</span><br>
                    <span class=""course-learn__skin""><i class=""fad fa-check""></i>Create data visualizations using
                        matplotlib
                        and
                 ");
            WriteLiteral(@"       the seaborn modules with python.</span><br>
                </div>
            </div>
        </div>
        <div class=""course-content"">
            <h3 class=""course-content__heading"">Course content</h3>
            <p class=""course-content__section"">15 sections - 110 lectures</p>
            <div class=""course-content__lesson"">
                <ul class=""course-content__list"">
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Intro to Course and Python</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Setup</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Learning Numpy</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Intro to Pandas</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Working with Data: Part 1</li>
                    <li class=""course-content__items""><i class=""fas fa");
            WriteLiteral(@"-angle-down""></i>Working with Data: Part 2</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Working with Data: Part 3</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Data Vidualization</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Example Project</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>Machine Learning</li>
                    <li class=""course-content__items""><i class=""fas fa-angle-down""></i>SQL adnd Python</li>

                </ul>
            </div>
        </div>
        <div class=""course-requir"">
            <h3 class=""course-requir__heading"">Description</h3>
            <p class=""course-requir__desc"">");
#nullable restore
#line 127 "D:\GITHUB\Online-Learn\SWP_TEAM_4\SWP_TEAM_4\Online_Learn\Views\Course\Details.cshtml"
                                      Write(ViewData["CourseDesc"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
        </div>
        <div class=""course-instruc"">
            <h3 class=""course-instruc__heading"">Instructor</h3>
            <h3 class=""course-instruc__author"">Jose Portilla</h3>
            <p class=""course-instruc__slogan"">Head of Data Science at Pierian Training</p>
            <div class=""course-instruc__view"">
                <div class=""course-instruc__img"">
                    <img src=""https://img-c.udemycdn.com/user/200_H/9685726_67e7_4.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 8214, "\"", 8220, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""course-instruc__rv"">
                    <span class=""course-instruc__skill""><i class=""fas fa-star""></i>4.6 Instructor Rating</span><br>
                    <span class=""course-instruc__skill""><i class=""fas fa-certificate""></i>899,399 Reviews</span><br>
                    <span class=""course-instruc__skill""><i class=""fas fa-users""></i>2,857,356 Students</span><br>
                    <span class=""course-instruc__skill""><i class=""fas fa-play-circle""></i>50 Course</span><br>
                </div>
            </div>
            <p class=""course-instruc__desc"">Lorem ipsum dolor sit amet consectetur adipisicing elit. Accusantium error
                neque deleniti maxime ipsam, optio rem provident! Explicabo veritatis incidunt ullam quod dignissimos
                harum! Consectetur vitae maxime sunt voluptatem quas.
                Reiciendis maiores tempore ipsam eum commodi modi qui laboriosam ullam in illum at, officiis tenetur,
            ");
            WriteLiteral(@"    molestiae numquam sunt voluptates explicabo autem ratione recusandae cupiditate? Alias eum nobis numquam
                consequuntur veritatis.
                Nostrum ipsam harum reprehenderit doloribus soluta aliquam illum, tempore quas assumenda porro provident
                est aperiam molestias nulla consequatur dolorem laboriosam earum id velit accusamus fugit? Quos
                necessitatibus officia enim eligendi!
                Quam, obcaecati enim? Voluptatibus esse, aliquid iure officia aliquam ipsa libero neque quibusdam unde
                repellat autem! Similique, sequi eius itaque aspernatur placeat voluptates molestias ullam eligendi
                alias odit ea iure!
                Eos, sint sit amet eligendi nulla cum quisquam saepe suscipit et molestiae laudantium nihil placeat nemo
                reprehenderit quaerat odit, iusto sapiente ab eius nisi. Iusto libero distinctio accusantium deleniti
                adipisci!
                Harum inventore quisquam ");
            WriteLiteral(@"minus distinctio obcaecati, a animi. Repellat pariatur inventore tenetur id
                tempora! Ab consectetur iure cupiditate odio officiis fugiat, aspernatur sit a, itaque possimus dolor
                repudiandae ducimus facere.
                Provident quae veritatis ad rerum consequatur sed animi cupiditate iste. Molestiae earum est quibusdam
                dicta, sequi nemo laudantium tempore odio magnam ad totam autem ut labore natus tenetur assumenda velit?
                Culpa eligendi corporis ad accusantium quis saepe nostrum molestias voluptatibus dignissimos error non
                eaque unde, dolores sunt magnam nemo earum qui ducimus fugit iste. Nostrum corporis eaque nobis porro
                ullam.s</p>
        </div>
        <div class=""course-feedback"">
            <h3 class=""course-feedback__heading"">Student feedback</h3>
            <div class=""course-feedback__wrap"">
                <div class=""course-feedback__rating"">
                    <span class=""course-fe");
            WriteLiteral(@"edback__total"">4.7</span> <br>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><br>
                    <span class=""course-feedback__lable"">Course Rating</span>
                </div>
                <div class=""course-feedback__range"">
                    <progress id=""file"" value=""70"" max=""100""></progress>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star s");
            WriteLiteral(@"tars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><span class=""course-feedback__pt"">70%</span><br>
                    <progress id=""file"" value=""25"" max=""100""></progress>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><span class=""course-feedback__pt"">25%</span><br>
                    <progress id=""file"" value=""3"" max=""100""></progress>
                    <div class=""rate"">
                        <i data-st");
            WriteLiteral(@"ar='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><span class=""course-feedback__pt"">4%</span><br>
                    <progress id=""file"" value=""1"" max=""100""></progress>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><spa");
            WriteLiteral(@"n class=""course-feedback__pt"">1%</span><br>
                    <progress id=""file"" value=""1"" max=""100""></progress>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><span class=""course-feedback__pt"">1%</span><br>
                </div>
            </div>
        </div>
        <div class=""course-review"">
            <h3 class=""course-review__heading"">Reviews</h3>
            <div class=""course-review__srv"">
                <input type=""text"" class=""course-review__input"" placeholder=""typing comment...""><button class=""course-review__submit""><i class=""fas fa-search""></i></bu");
            WriteLiteral("tton>\r\n            </div>\r\n            <div class=\"course-review__wrap\">\r\n                <div class=\"course-review__avt\">\r\n                    <img src=\"https://img-c.udemycdn.com/user/50x50/172051766_5a09.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 15600, "\"", 15606, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""course-review__cmt"">
                    <h5 class=""course-review__name"">Bhuvana R.</h5>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><br>
                    <p class=""course-review__com"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum eum
                        expedita facere, officia vel, minus illum autem corrupti blanditiis aliquam id reiciendis odit
                        asperiores iste nam quia ab, similique liberon </p>
                </div>
            </div>
            <div class=""co");
            WriteLiteral("urse-review__wrap\">\r\n                <div class=\"course-review__avt\">\r\n                    <img src=\"https://img-c.udemycdn.com/user/50x50/172051766_5a09.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 16789, "\"", 16795, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""course-review__cmt"">
                    <h5 class=""course-review__name"">Bhuvana R.</h5>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><br>
                    <p class=""course-review__com"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum eum
                        expedita facere, officia vel, minus illum autem corrupti blanditiis aliquam id reiciendis odit
                        asperiores iste nam quia ab, similique liberon </p>
                </div>
            </div>
            <div class=""co");
            WriteLiteral("urse-review__wrap\">\r\n                <div class=\"course-review__avt\">\r\n                    <img src=\"https://img-c.udemycdn.com/user/50x50/172051766_5a09.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 17978, "\"", 17984, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""course-review__cmt"">
                    <h5 class=""course-review__name"">Bhuvana R.</h5>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><br>
                    <p class=""course-review__com"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum eum
                        expedita facere, officia vel, minus illum autem corrupti blanditiis aliquam id reiciendis odit
                        asperiores iste nam quia ab, similique liberon </p>
                </div>
            </div>
            <div class=""co");
            WriteLiteral("urse-review__wrap\">\r\n                <div class=\"course-review__avt\">\r\n                    <img src=\"https://img-c.udemycdn.com/user/50x50/172051766_5a09.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 19167, "\"", 19173, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""course-review__cmt"">
                    <h5 class=""course-review__name"">Bhuvana R.</h5>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><br>
                    <p class=""course-review__com"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum eum
                        expedita facere, officia vel, minus illum autem corrupti blanditiis aliquam id reiciendis odit
                        asperiores iste nam quia ab, similique liberon </p>
                </div>
            </div>
            <div class=""co");
            WriteLiteral("urse-review__wrap\">\r\n                <div class=\"course-review__avt\">\r\n                    <img src=\"https://img-c.udemycdn.com/user/50x50/172051766_5a09.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 20356, "\"", 20362, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""course-review__cmt"">
                    <h5 class=""course-review__name"">Bhuvana R.</h5>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><br>
                    <p class=""course-review__com"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum eum
                        expedita facere, officia vel, minus illum autem corrupti blanditiis aliquam id reiciendis odit
                        asperiores iste nam quia ab, similique liberon </p>
                </div>
            </div>
            <div class=""co");
            WriteLiteral("urse-review__wrap\">\r\n                <div class=\"course-review__avt\">\r\n                    <img src=\"https://img-c.udemycdn.com/user/50x50/172051766_5a09.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 21545, "\"", 21551, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""course-review__cmt"">
                    <h5 class=""course-review__name"">Bhuvana R.</h5>
                    <div class=""rate"">
                        <i data-star='0' class=""fas fa-star stars starActive""></i>
                        <i data-star='1' class=""fas fa-star stars starActive""></i>
                        <i data-star='2' class=""fas fa-star stars starActive""></i>
                        <i data-star='3' class=""fas fa-star stars starActive""></i>
                        <i data-star='4' class=""fas fa-star stars starActive""></i>
                    </div><br>
                    <p class=""course-review__com"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum eum
                        expedita facere, officia vel, minus illum autem corrupti blanditiis aliquam id reiciendis odit
                        asperiores iste nam quia ab, similique liberon </p>
                </div>
            </div>
            <button class=");
            WriteLiteral("\"course-review__more\">See more reviews</button>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
            WriteLiteral(@"

<script type=""text/javascript"" src=""https://code.jquery.com/jquery-1.11.0.min.js""></script>
<script type=""text/javascript"" src=""https://code.jquery.com/jquery-migrate-1.2.1.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js""></script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27ea6509547a2a82c92594083f5f5f2076fe8edb37173", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27ea6509547a2a82c92594083f5f5f2076fe8edb38213", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Online_Learn.Models.Course> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "883ade1e685750d423e2ff6e4c075c8e018030b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DeliveryList), @"mvc.1.0.view", @"/Views/Home/DeliveryList.cshtml")]
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
#line 1 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\_ViewImports.cshtml"
using ComputerStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\_ViewImports.cshtml"
using ComputerStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"883ade1e685750d423e2ff6e4c075c8e018030b1", @"/Views/Home/DeliveryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67e7854bc2f9c50d63e1afcd180501b030ca7077", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DeliveryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ComputerStore.Models.Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/microsoft/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
  
    ViewData["Title"] = "DeliveryList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Заказы на доставку</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Datetimeorderplaced));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 42 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 64 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Datetimeorderplaced));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("                <td>\r\n");
#nullable restore
#line 70 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                     if (string.IsNullOrWhiteSpace(item.CourierId))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                         using (Html.BeginForm("StartDelivery", "Home", new { id = item.Id }, FormMethod.Post))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button class=\"btn btn-secondary\">Взять заказ</button>\r\n");
#nullable restore
#line 75 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                         
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                         using (Html.BeginForm("FinishDelivery", "Home", new { id = item.Id }, FormMethod.Post))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button class=\"btn btn-primary\">Отметить как доставленный</button>\r\n");
#nullable restore
#line 82 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 86 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "883ade1e685750d423e2ff6e4c075c8e018030b110963", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>
        ""use strict"";
    var connection = new signalR.HubConnectionBuilder().withUrl(""/computerStoreHub"").build();
        connection
            .start()
            .catch(() => {
                alert(""Error while establishing connection"");
            });
            connection.on(""");
#nullable restore
#line 101 "C:\Users\lenor\source\repos\ComputerStore\ComputerStore\Views\Home\DeliveryList.cshtml"
                      Write(Configuration["RabbitMq:OnOrdersChanged"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", function () {\r\n                window.location.reload();\r\n        });\r\n\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration Configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ComputerStore.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591

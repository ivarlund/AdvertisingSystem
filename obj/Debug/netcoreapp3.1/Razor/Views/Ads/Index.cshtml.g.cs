#pragma checksum "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d33215f0b2fd12ed5203026ac0ab085ec6f0edc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ads_Index), @"mvc.1.0.view", @"/Views/Ads/Index.cshtml")]
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
#line 1 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\_ViewImports.cshtml"
using AdvertisingSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\_ViewImports.cshtml"
using AdvertisingSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d33215f0b2fd12ed5203026ac0ab085ec6f0edc", @"/Views/Ads/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b4d1e936add377d97f1bfb46b2eb6ec5a0947ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Ads_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AdvertisingSystem.Models.Ad>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 10 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
Write(Html.ActionLink("Create Ad", "Create", "Advertisers"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n<div class=\"card-columns\">\r\n");
#nullable restore
#line 14 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
     foreach (var item in Model)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
         if (item.Advertiser.Subscriber != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card bg-success text-white\">\r\n                <div class=\"card-header text-center\">\r\n                    <h4>");
#nullable restore
#line 20 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n                <div class=\"card-body text-center\">\r\n                    <div class=\"card-subtitle\">\r\n                        <h6>Price: ");
#nullable restore
#line 24 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                              Write(Html.DisplayFor(modelItem => item.ItemPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SEK</h6>\r\n                    </div>\r\n\r\n                    <p class=\"card-text\">");
#nullable restore
#line 27 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                    <div class=\"card-footer\">\r\n                        <p class=\"card-text\">SUBSCRIBER AD</p>\r\n                        <p class=\"card-text\">Ad price: ");
#nullable restore
#line 31 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.AdPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SEK</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 35 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card bg-primary text-white\">\r\n                <div class=\"card-header text-center\">\r\n                    <h4>");
#nullable restore
#line 40 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n                <div class=\"card-body text-center\">\r\n                    <div class=\"card-subtitle\">\r\n                        <h6>Price: ");
#nullable restore
#line 44 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                              Write(Html.DisplayFor(modelItem => item.ItemPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SEK</h6>\r\n                    </div>\r\n\r\n                    <p class=\"card-text\">");
#nullable restore
#line 47 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                    <div class=\"card-footer\">\r\n                        <p class=\"card-text\">COMPANY AD</p>\r\n                        <p class=\"card-text\">Ad price: ");
#nullable restore
#line 51 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.AdPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SEK</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 55 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\Ivarl\source\repos\AdvertisingSystem\AdvertisingSystem\Views\Ads\Index.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AdvertisingSystem.Models.Ad>> Html { get; private set; }
    }
}
#pragma warning restore 1591

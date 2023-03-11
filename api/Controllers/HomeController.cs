using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Microsoft.Extensions.DependencyInjection;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IHostingEnvironment hostEnv;
        public HomeController(IHostingEnvironment hostingEnv) => this.hostEnv = hostingEnv;
        public async Task<IActionResult> Index()
        {
            RenderToStringResult prerenderResult = null;
            try
            {
                prerenderResult = await Methode(Request);
                // This is where everything is now spliced out, and given to .NET in pieces
                ViewData["SpaHtml"] = prerenderResult.Html;
                ViewData["Title"] = prerenderResult.Globals["title"];
                ViewData["Styles"] = prerenderResult.Globals["styles"];
                ViewData["Meta"] = prerenderResult.Globals["meta"];
                ViewData["Links"] = prerenderResult.Globals["links"];
                ViewData["TransferData"] = prerenderResult.Globals["transferData"]; // our transfer data set to window.TRANSFER_CACHE = {};
            }
            catch (System.Exception e)
            {
                ViewData["error"] = e.Message;
            }


            // if (!this.hostEnv.IsDevelopment())
            // {
            //     this.ViewData["ServiceWorker"] = "<script>'serviceWorker'in navigator&&navigator.serviceWorker.register('/serviceworker')</script>";
            // }
            // Let's render that Home/Index view
            return View();
        }

        private async Task<RenderToStringResult> Methode(HttpRequest request)
        {
            var requestFeature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            // By default we're passing down the REQUEST Object (Cookies, Headers, Host) from the Request object here
            TransferData transferData = new TransferData();
            transferData.request = AbstractHttpContextRequestInfo(request); // You can automatically grab things from the REQUEST object in Angular because of this
            transferData.thisCameFromDotNET = "Hi Angular it's asp.net :)";
            // Add more customData here, add it to the TransferData class

            // Prerender / Serialize application (with Universal)
            return await Prerenderer.RenderToString(
                applicationBasePath: "/", // baseURL
                nodeServices: request.HttpContext.RequestServices.GetRequiredService<INodeServices>(),
                applicationStoppingToken: new CancellationTokenSource().Token,
                bootModule: new JavaScriptModuleExport(hostEnv.ContentRootPath + "/dist/server/main"),
                requestAbsoluteUrl: $"{request.Scheme}://{request.Host}{requestFeature.RawTarget}",
                requestPathAndQuery: requestFeature.RawTarget,
                // Our Transfer data here will be passed down to Angular (within the main.server file)
                // Available there via `params.data.yourData`
                customDataParameter: transferData,
                timeoutMilliseconds: 30000, // timeout duration
                requestPathBase: request.PathBase.ToString()
            );
        }

        private IRequest AbstractHttpContextRequestInfo(HttpRequest request)
        {
            IRequest requestSimplified = new IRequest();
            requestSimplified.cookies = request.Cookies;
            requestSimplified.headers = request.Headers;
            requestSimplified.host = request.Host;

            return requestSimplified;
        }

    }
    public class IRequest
    {
        public object cookies { get; set; }
        public object headers { get; set; }
        public object host { get; set; }
    }

    public class TransferData
    {
        // By default we're expecting the REQUEST Object (in the aspnet engine), so leave this one here
        public dynamic request { get; set; }

        // Your data here ?
        public object thisCameFromDotNET { get; set; }
    }

}

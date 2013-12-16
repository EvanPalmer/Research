using System.Web;
using PostSharp.Aspects;

namespace TheMvcApp.Aspects.AspectArgumentAdapters
{
    public class AngularAntiForgeryTokenArgumentAdapter : IAngularAntiForgeryTokenArgumentAdapter 
    {
        private const string HeaderKey = "X-XSRF-TOKEN";
        private const string CookieKey = "XSRF-TOKEN";

        private readonly MethodExecutionArgs _args;

        public AngularAntiForgeryTokenArgumentAdapter(MethodExecutionArgs args)
        {
            _args = args;
        }

        public string TokenFromHeader
        {
            get { return HttpContext.Current.Request.Headers[HeaderKey]; }
        }

        public string TokenFromCookie
        {
            get { return HttpContext.Current.Request.Cookies[CookieKey].Value; }
        }

        public FlowBehavior FlowBehavior
        {
            get { return _args.FlowBehavior; }
            set { _args.FlowBehavior = value; }
        }
    }

    public interface IAngularAntiForgeryTokenArgumentAdapter
    {
        string TokenFromHeader { get; }
        string TokenFromCookie { get; }
        FlowBehavior FlowBehavior { get; set; }
    }
}
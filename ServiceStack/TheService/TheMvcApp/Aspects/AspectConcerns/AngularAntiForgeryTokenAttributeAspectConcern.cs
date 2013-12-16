using System;
using PostSharp.Aspects;
using TheMvcApp.Aspects.AspectArgumentAdapters;

namespace TheMvcApp.Aspects.AspectConcerns
{
    [Serializable]
    public class AngularAntiForgeryTokenAttributeAspectConcern : IAngularAntiForgeryTokenAttributeAspectConcern 
    {
        public void OnEntry(IAngularAntiForgeryTokenArgumentAdapter args)
        {
            if (!args.TokenFromCookie.Equals(args.TokenFromHeader) || 
                String.IsNullOrWhiteSpace(args.TokenFromCookie) ||
                String.IsNullOrWhiteSpace(args.TokenFromHeader))
            {
                throw new Exception();
            }

            args.FlowBehavior = FlowBehavior.Continue;
        }
    }

    public interface IAngularAntiForgeryTokenAttributeAspectConcern
    {
        void OnEntry(IAngularAntiForgeryTokenArgumentAdapter args);
    }
}
using System;
using PostSharp.Aspects;
using TheMvcApp.Aspects.AspectArgumentAdapters;
using TheMvcApp.Aspects.AspectConcerns;

namespace TheMvcApp.Aspects
{
    [Serializable]
    public class AngularAntiForgeryTokenAttribute : OnMethodBoundaryAspect
    {
        public static bool Enabled = true;
        AngularAntiForgeryTokenAttributeAspectConcern _concern;

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {
            if (Enabled)
            {
                _concern = new AngularAntiForgeryTokenAttributeAspectConcern();
            }
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (Enabled)
            {
                _concern.OnEntry(new AngularAntiForgeryTokenArgumentAdapter(args));
            }
        }
    }
}
using System;
using System.Windows.Forms;

namespace Presentation
{
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control self, Action action)
        {
            if (self.InvokeRequired)
            {
                self.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
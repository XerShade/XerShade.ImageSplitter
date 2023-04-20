namespace XerShade.ImageSplitter.Extensions
{
    public static class ControlExtensions
    {
        public static void Enable(this Control control, bool state)
        {
            if (control is null) { return; }

            foreach (Control c in control.Controls)
            {
                c.Enable(state);
            }

            try
            {
                control.Invoke((MethodInvoker)(() => {
                    control.Enabled = state;
                }));
            }
            catch
            {
            }
        }
    }
}

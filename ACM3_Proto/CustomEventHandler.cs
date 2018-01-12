using System;

namespace FadingUtility.Helpers
{
    public delegate void ShowErrorEventHandler(object sender, ShowMessageEventArgs e);
    public delegate void ShowInfoEventHandler(object sender, ShowMessageEventArgs e);
    public delegate void RemoveCustomParamElemEventHandler(object sender, CustomParamElemEventArgs e);
    public delegate void LogMessageEventHandler(object sender, LogMessageEventArgs e);
    public delegate void LogExceptionEventHandler(object sender, LogExceptionEventArgs e);
    public delegate bool PromptPasswordEventHandler(object sender, EventArgs e);
    public delegate void CheckLicenseEventHandler(object sender, EventArgs e);
    public delegate bool ConfigDefaultFoldersEventHandler(object sender, EventArgs e);
}

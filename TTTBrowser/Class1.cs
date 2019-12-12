using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Dynamics.Framework.UI.Extensibility;
using Microsoft.Dynamics.Framework.UI.Extensibility.WinForms;

namespace TTTBrowser
{
    [ControlAddInExport("TTTBrowser")]

    public class Class1 : WinFormsControlAddInBase, IValueControlAddInDefinition<string>
    {
        String urlString;
        WebBrowser webBrowser1;
        System.Uri webUri;

        protected override System.Windows.Forms.Control CreateControl()
        {
            urlString = "http://localhost/";

            try
            {
                webBrowser1 = new System.Windows.Forms.WebBrowser();
                webBrowser1.TabIndex = 0;
                webBrowser1.WebBrowserShortcutsEnabled = false;
                webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;

                webUri = new System.Uri(urlString);
                webBrowser1.Url = webUri;
            }
            catch (Exception Exc)
            {
                throw new Exception(Exc.Message);
            }

            return webBrowser1;
        }

        // public event ControlAddInEventHandler ControlAddIn;

        public bool HasValueChanged
        {
            get
            {
                if (webBrowser1.Url != null)
                    return (!webBrowser1.Url.OriginalString.Contains(urlString));
                else
                    return false;
            }
        }

        public String Value
        {
            set
            {
                if (value != null)
                {
                    if (urlString != value)
                    {
                        urlString = value;

                        try
                        {
                            webUri = new System.Uri(urlString);
                            webBrowser1.Url = webUri;
                        }
                        catch (Exception Exc)
                        {
                            throw new Exception(Exc.Message);
                        }
                    }
                }
            }
            get
            {
                return urlString;
            }
        }
    }
}

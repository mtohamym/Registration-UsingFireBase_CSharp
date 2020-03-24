using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInSignUpUsingFireBaseAuth
{
    public partial class WebSite : Form
    {
        UserModel userM;
        public WebSite()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        

        }

        internal UserModel UserM { get => userM; set => userM = value; }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void Welcome_Click(object sender, EventArgs e)
        {
            
        }
    }
}

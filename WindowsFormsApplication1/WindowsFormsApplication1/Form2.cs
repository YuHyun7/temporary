﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

using System.Diagnostics;


namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        Form1 frm;
        string url;
        private string id;
        private string passwd;
        public void setId(string id)
        {
            this.id = id;
        }
        public void setpswd(string passwd)
        {
            this.passwd = passwd;
        }
        public ChromiumWebBrowser browser;
        
        public void InitBrowser(string url)
        {
            this.url = url;
            try
            {
                Cef.Initialize(new CefSettings());
            }
            catch (System.Exception) { }
            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill,
            };
        
            this.Controls.Add(browser);
        }
        public Form2(string url, Form1 _form)
        {
            InitializeComponent();
            InitBrowser(url);
            var settings = new CefSettings();
            frm = _form;
        }

        public void login()
        {
            for (int i = 0; i < 4; i++) { SendKeys.Send("{tab}"); }
            for(int i=0; i<id.Length; i++)
            {
                SendKeys.Send(id[i].ToString());
            }
            SendKeys.Send("{tab}");
            for (int i = 0; i < passwd.Length; i++)
            {
                SendKeys.Send(passwd[i].ToString());
            }
            SendKeys.Send("{ENTER}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gathering Gatherer = new gathering(frm,this);
            browser.Load("https://m.facebook.com/profile.php?v=friends&ref=bookmarks");
            Gatherer.parseHtml();
        }

        private void showDevTools_Click(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}

// 
// Radegast Metaverse Client
// Copyright (c) 2009-2010, Radegast Development Team
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the application "Radegast", nor the names of its
//       contributors may be used to endorse or promote products derived from
//       this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// $Id$
//
using System;
using System.Windows.Forms;

namespace Radegast
{
    public partial class frmDetachedTab : RadegastForm
    {
        private RadegastInstance instance;
        private RadegastTab tab;

        //For reattachment
        private ToolStrip strip;
        private Panel container;

        public frmDetachedTab(RadegastInstance instance, RadegastTab tab)
            :base(instance)
        {
            InitializeComponent();
            Disposed += new EventHandler(frmDetachedTab_Disposed);

            this.instance = instance;
            this.tab = tab;
            ClientSize = tab.Control.Size;
            Controls.Add(tab.Control);
            tab.Control.Visible = true;
            tab.Control.BringToFront();

            this.Text = tab.Label + " - " + Properties.Resources.ProgramName;
            SettingsKeyBase = "tab_window_" + tab.Control.GetType().Name;
            AutoSavePosition = true;
        }

        void frmDetachedTab_Disposed(object sender, EventArgs e)
        {
        }

        private void frmDetachedTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tab.Detached)
            {
                //if (tab.AllowClose)
                //    tab.Close();
                //else
                tab.AttachTo(strip, container);
            }
        }

        public ToolStrip ReattachStrip
        {
            get { return strip; }
            set { strip = value; }
        }

        public Panel ReattachContainer
        {
            get { return container; }
            set { container = value; }
        }
    }
}
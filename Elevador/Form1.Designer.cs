namespace Elevador
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttnConnect = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.BttnDisconnect = new System.Windows.Forms.Button();
            this.bttnRefresh = new System.Windows.Forms.Button();
            this.bttnDown = new System.Windows.Forms.Button();
            this.bttnOpenDoor = new System.Windows.Forms.Button();
            this.bttnCloseDoor = new System.Windows.Forms.Button();
            this.bttnUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnConnect
            // 
            this.bttnConnect.Location = new System.Drawing.Point(25, 89);
            this.bttnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttnConnect.Name = "bttnConnect";
            this.bttnConnect.Size = new System.Drawing.Size(150, 27);
            this.bttnConnect.TabIndex = 0;
            this.bttnConnect.Text = "Conectar";
            this.bttnConnect.UseVisualStyleBackColor = true;
            this.bttnConnect.Click += new System.EventHandler(this.bttnConnect_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(25, 63);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(150, 21);
            this.cbPorts.TabIndex = 1;
            this.cbPorts.Text = "Seleccione su dispositivo";
            // 
            // BttnDisconnect
            // 
            this.BttnDisconnect.Location = new System.Drawing.Point(25, 120);
            this.BttnDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BttnDisconnect.Name = "BttnDisconnect";
            this.BttnDisconnect.Size = new System.Drawing.Size(150, 27);
            this.BttnDisconnect.TabIndex = 2;
            this.BttnDisconnect.Text = "Desconectar";
            this.BttnDisconnect.UseVisualStyleBackColor = true;
            this.BttnDisconnect.Click += new System.EventHandler(this.BttnDisconnect_Click);
            // 
            // bttnRefresh
            // 
            this.bttnRefresh.Location = new System.Drawing.Point(181, 63);
            this.bttnRefresh.Name = "bttnRefresh";
            this.bttnRefresh.Size = new System.Drawing.Size(53, 21);
            this.bttnRefresh.TabIndex = 3;
            this.bttnRefresh.Text = "Refresh";
            this.bttnRefresh.UseVisualStyleBackColor = true;
            this.bttnRefresh.Click += new System.EventHandler(this.bttnRefresh_Click);
            // 
            // bttnDown
            // 
            this.bttnDown.Location = new System.Drawing.Point(100, 208);
            this.bttnDown.Name = "bttnDown";
            this.bttnDown.Size = new System.Drawing.Size(75, 38);
            this.bttnDown.TabIndex = 4;
            this.bttnDown.Text = "Bajar elevador";
            this.bttnDown.UseVisualStyleBackColor = true;
            this.bttnDown.Click += new System.EventHandler(this.bttnDown_Click);
            // 
            // bttnOpenDoor
            // 
            this.bttnOpenDoor.Location = new System.Drawing.Point(25, 179);
            this.bttnOpenDoor.Name = "bttnOpenDoor";
            this.bttnOpenDoor.Size = new System.Drawing.Size(75, 23);
            this.bttnOpenDoor.TabIndex = 5;
            this.bttnOpenDoor.Text = "Abrir pluma";
            this.bttnOpenDoor.UseVisualStyleBackColor = true;
            this.bttnOpenDoor.Click += new System.EventHandler(this.bttnOpenDoor_Click);
            // 
            // bttnCloseDoor
            // 
            this.bttnCloseDoor.Location = new System.Drawing.Point(100, 179);
            this.bttnCloseDoor.Name = "bttnCloseDoor";
            this.bttnCloseDoor.Size = new System.Drawing.Size(75, 23);
            this.bttnCloseDoor.TabIndex = 6;
            this.bttnCloseDoor.Text = "Cerrar pluma";
            this.bttnCloseDoor.UseVisualStyleBackColor = true;
            this.bttnCloseDoor.Click += new System.EventHandler(this.bttnCloseDoor_Click);
            // 
            // bttnUp
            // 
            this.bttnUp.Location = new System.Drawing.Point(25, 208);
            this.bttnUp.Name = "bttnUp";
            this.bttnUp.Size = new System.Drawing.Size(75, 38);
            this.bttnUp.TabIndex = 7;
            this.bttnUp.Text = "Subir elevador\r\n";
            this.bttnUp.UseVisualStyleBackColor = true;
            this.bttnUp.Click += new System.EventHandler(this.bttnUp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 392);
            this.Controls.Add(this.bttnUp);
            this.Controls.Add(this.bttnCloseDoor);
            this.Controls.Add(this.bttnOpenDoor);
            this.Controls.Add(this.bttnDown);
            this.Controls.Add(this.bttnRefresh);
            this.Controls.Add(this.BttnDisconnect);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.bttnConnect);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnConnect;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Button BttnDisconnect;
        private System.Windows.Forms.Button bttnRefresh;
        private System.Windows.Forms.Button bttnDown;
        private System.Windows.Forms.Button bttnOpenDoor;
        private System.Windows.Forms.Button bttnCloseDoor;
        private System.Windows.Forms.Button bttnUp;
    }
}


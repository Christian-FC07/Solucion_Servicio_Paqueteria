namespace Presentacion
{
    partial class frmActualizarContrasena
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
            this.txtContrasenaAntigua = new System.Windows.Forms.TextBox();
            this.txtContrasenaNueva = new System.Windows.Forms.TextBox();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModificarContrasena = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtContrasenaAntigua
            // 
            this.txtContrasenaAntigua.Location = new System.Drawing.Point(185, 121);
            this.txtContrasenaAntigua.Multiline = true;
            this.txtContrasenaAntigua.Name = "txtContrasenaAntigua";
            this.txtContrasenaAntigua.PasswordChar = '*';
            this.txtContrasenaAntigua.Size = new System.Drawing.Size(410, 33);
            this.txtContrasenaAntigua.TabIndex = 0;
            // 
            // txtContrasenaNueva
            // 
            this.txtContrasenaNueva.Location = new System.Drawing.Point(185, 190);
            this.txtContrasenaNueva.Multiline = true;
            this.txtContrasenaNueva.Name = "txtContrasenaNueva";
            this.txtContrasenaNueva.PasswordChar = '*';
            this.txtContrasenaNueva.Size = new System.Drawing.Size(410, 33);
            this.txtContrasenaNueva.TabIndex = 1;
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(185, 270);
            this.txtConfirmarContrasena.Multiline = true;
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '*';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(410, 33);
            this.txtConfirmarContrasena.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraseña antigua";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Castellar", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(181, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(632, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "Actualización de contraseña";
            // 
            // btnModificarContrasena
            // 
            this.btnModificarContrasena.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnModificarContrasena.Font = new System.Drawing.Font("Castellar", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarContrasena.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnModificarContrasena.Location = new System.Drawing.Point(265, 336);
            this.btnModificarContrasena.Name = "btnModificarContrasena";
            this.btnModificarContrasena.Size = new System.Drawing.Size(271, 39);
            this.btnModificarContrasena.TabIndex = 7;
            this.btnModificarContrasena.Text = "Modificar contraseña";
            this.btnModificarContrasena.UseVisualStyleBackColor = false;
            this.btnModificarContrasena.Click += new System.EventHandler(this.btnModificarContrasena_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(295, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contraseña nueva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(272, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Confirmar contraseña";
            // 
            // frmActualizarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnModificarContrasena);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfirmarContrasena);
            this.Controls.Add(this.txtContrasenaNueva);
            this.Controls.Add(this.txtContrasenaAntigua);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActualizarContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Contrasena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContrasenaAntigua;
        private System.Windows.Forms.TextBox txtContrasenaNueva;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnModificarContrasena;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}
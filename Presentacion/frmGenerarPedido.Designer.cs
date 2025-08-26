namespace Presentacion
{
    partial class frmGenerarPedido
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
            this.cmbPaquetes = new System.Windows.Forms.ComboBox();
            this.txtUbicacionRecogida = new System.Windows.Forms.TextBox();
            this.cbEntregaSucursal = new System.Windows.Forms.CheckBox();
            this.cbEntregaDomicilio = new System.Windows.Forms.CheckBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPaquetes
            // 
            this.cmbPaquetes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaquetes.FormattingEnabled = true;
            this.cmbPaquetes.Location = new System.Drawing.Point(49, 52);
            this.cmbPaquetes.Name = "cmbPaquetes";
            this.cmbPaquetes.Size = new System.Drawing.Size(188, 21);
            this.cmbPaquetes.TabIndex = 0;
            // 
            // txtUbicacionRecogida
            // 
            this.txtUbicacionRecogida.Location = new System.Drawing.Point(49, 108);
            this.txtUbicacionRecogida.Multiline = true;
            this.txtUbicacionRecogida.Name = "txtUbicacionRecogida";
            this.txtUbicacionRecogida.Size = new System.Drawing.Size(259, 70);
            this.txtUbicacionRecogida.TabIndex = 1;
            // 
            // cbEntregaSucursal
            // 
            this.cbEntregaSucursal.AutoSize = true;
            this.cbEntregaSucursal.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntregaSucursal.Location = new System.Drawing.Point(435, 52);
            this.cbEntregaSucursal.Name = "cbEntregaSucursal";
            this.cbEntregaSucursal.Size = new System.Drawing.Size(243, 23);
            this.cbEntregaSucursal.TabIndex = 2;
            this.cbEntregaSucursal.Text = "Entrega en sucursal";
            this.cbEntregaSucursal.UseVisualStyleBackColor = true;
            this.cbEntregaSucursal.CheckedChanged += new System.EventHandler(this.cbEntregaSucursal_CheckedChanged);
            // 
            // cbEntregaDomicilio
            // 
            this.cbEntregaDomicilio.AutoSize = true;
            this.cbEntregaDomicilio.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntregaDomicilio.Location = new System.Drawing.Point(619, 52);
            this.cbEntregaDomicilio.Name = "cbEntregaDomicilio";
            this.cbEntregaDomicilio.Size = new System.Drawing.Size(241, 23);
            this.cbEntregaDomicilio.TabIndex = 3;
            this.cbEntregaDomicilio.Text = "Entrega a domicilio";
            this.cbEntregaDomicilio.UseVisualStyleBackColor = true;
            this.cbEntregaDomicilio.CheckedChanged += new System.EventHandler(this.cbEntregaDomicilio_CheckedChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAgregar.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnAgregar.Location = new System.Drawing.Point(193, 204);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 35);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar Pedido";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Paquete a enviar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ubicación de recolección del pedido";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnModificar.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnModificar.Location = new System.Drawing.Point(338, 204);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(140, 35);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar Pedido";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminar.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnEliminar.Location = new System.Drawing.Point(483, 204);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 35);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar Pedido";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLimpiar.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnLimpiar.Location = new System.Drawing.Point(49, 204);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(140, 35);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(47, 258);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersWidth = 62;
            this.dgvPedidos.Size = new System.Drawing.Size(955, 312);
            this.dgvPedidos.TabIndex = 10;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            // 
            // frmGenerarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1031, 612);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cbEntregaDomicilio);
            this.Controls.Add(this.cbEntregaSucursal);
            this.Controls.Add(this.txtUbicacionRecogida);
            this.Controls.Add(this.cmbPaquetes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Pedido";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPaquetes;
        private System.Windows.Forms.TextBox txtUbicacionRecogida;
        private System.Windows.Forms.CheckBox cbEntregaSucursal;
        private System.Windows.Forms.CheckBox cbEntregaDomicilio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvPedidos;
    }
}
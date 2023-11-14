namespace ArrayObjetos.Windows
{
    partial class frmObjeto
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtLado = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            label2 = new Label();
            cboColores = new ComboBox();
            label3 = new Label();
            cboBorde = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 41);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Medida del Radio";
            // 
            // txtLado
            // 
            txtLado.Location = new Point(165, 40);
            txtLado.Name = "txtLado";
            txtLado.Size = new Size(100, 23);
            txtLado.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(116, 293);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(404, 293);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 83);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 0;
            label2.Text = "Color Relleno";
            // 
            // cboColores
            // 
            cboColores.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColores.FormattingEnabled = true;
            cboColores.Location = new Point(165, 80);
            cboColores.Name = "cboColores";
            cboColores.Size = new Size(100, 23);
            cboColores.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 117);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 5;
            label3.Text = "Tipo Borde";
            // 
            // cboBorde
            // 
            cboBorde.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBorde.FormattingEnabled = true;
            cboBorde.Location = new Point(165, 114);
            cboBorde.Name = "cboBorde";
            cboBorde.Size = new Size(100, 23);
            cboBorde.TabIndex = 4;
            // 
            // frmObjeto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 363);
            ControlBox = false;
            Controls.Add(label3);
            Controls.Add(cboBorde);
            Controls.Add(cboColores);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtLado);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmObjeto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmObjeto";
            Load += frmObjeto_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLado;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
        private ComboBox cboColores;
        private Label label2;
        private Label label3;
        private ComboBox cboBorde;
    }
}
namespace ItemDevelopment
{
    partial class FormDevelopmentIten
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
            this.comboBoxSourceDB = new System.Windows.Forms.ComboBox();
            this.labelSourceDb = new System.Windows.Forms.Label();
            this.labelBrands = new System.Windows.Forms.Label();
            this.comboBoxBrands = new System.Windows.Forms.ComboBox();
            this.labelRules = new System.Windows.Forms.Label();
            this.comboBoxRules = new System.Windows.Forms.ComboBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelSKU = new System.Windows.Forms.Label();
            this.textBoxSKU = new System.Windows.Forms.TextBox();
            this.labelManufacturer = new System.Windows.Forms.Label();
            this.comboBoxManufacturer = new System.Windows.Forms.ComboBox();
            this.textBoxTecDocNumber = new System.Windows.Forms.TextBox();
            this.labelItemNumber = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxSupplierSKU = new System.Windows.Forms.TextBox();
            this.labelSupplierSKU = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonAddPhotos = new System.Windows.Forms.Button();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.dataGridViewPictures = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelKg = new System.Windows.Forms.Label();
            this.labelGBP = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.richTextBoxLogger = new System.Windows.Forms.RichTextBox();
            this.textBoxTecDocNumberForDelete = new System.Windows.Forms.TextBox();
            this.labelRemove = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPictures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSourceDB
            // 
            this.comboBoxSourceDB.FormattingEnabled = true;
            this.comboBoxSourceDB.Items.AddRange(new object[] {
            "Regular TecDoc",
            "Elart TecDoc"});
            this.comboBoxSourceDB.Location = new System.Drawing.Point(12, 36);
            this.comboBoxSourceDB.Name = "comboBoxSourceDB";
            this.comboBoxSourceDB.Size = new System.Drawing.Size(187, 21);
            this.comboBoxSourceDB.TabIndex = 0;
            this.comboBoxSourceDB.SelectedIndexChanged += new System.EventHandler(this.comboBoxSourceDB_SelectedIndexChanged);
            // 
            // labelSourceDb
            // 
            this.labelSourceDb.AutoSize = true;
            this.labelSourceDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSourceDb.Location = new System.Drawing.Point(12, 13);
            this.labelSourceDb.Name = "labelSourceDb";
            this.labelSourceDb.Size = new System.Drawing.Size(81, 20);
            this.labelSourceDb.TabIndex = 1;
            this.labelSourceDb.Text = "DataBase";
            // 
            // labelBrands
            // 
            this.labelBrands.AutoSize = true;
            this.labelBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrands.Location = new System.Drawing.Point(12, 60);
            this.labelBrands.Name = "labelBrands";
            this.labelBrands.Size = new System.Drawing.Size(60, 20);
            this.labelBrands.TabIndex = 2;
            this.labelBrands.Text = "Brands";
            // 
            // comboBoxBrands
            // 
            this.comboBoxBrands.FormattingEnabled = true;
            this.comboBoxBrands.Location = new System.Drawing.Point(12, 83);
            this.comboBoxBrands.Name = "comboBoxBrands";
            this.comboBoxBrands.Size = new System.Drawing.Size(187, 21);
            this.comboBoxBrands.TabIndex = 3;
            // 
            // labelRules
            // 
            this.labelRules.AutoSize = true;
            this.labelRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRules.Location = new System.Drawing.Point(12, 111);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(50, 20);
            this.labelRules.TabIndex = 4;
            this.labelRules.Text = "Rules";
            // 
            // comboBoxRules
            // 
            this.comboBoxRules.FormattingEnabled = true;
            this.comboBoxRules.Items.AddRange(new object[] {
            "Use Rules",
            "Use Mumbers"});
            this.comboBoxRules.Location = new System.Drawing.Point(12, 134);
            this.comboBoxRules.Name = "comboBoxRules";
            this.comboBoxRules.Size = new System.Drawing.Size(187, 21);
            this.comboBoxRules.TabIndex = 5;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumber.Location = new System.Drawing.Point(12, 164);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(65, 20);
            this.labelNumber.TabIndex = 6;
            this.labelNumber.Text = "Number";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(12, 187);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(187, 20);
            this.textBoxNumber.TabIndex = 7;
            this.textBoxNumber.TextChanged += new System.EventHandler(this.textBoxNumber_TextChanged);
            // 
            // labelSKU
            // 
            this.labelSKU.AutoSize = true;
            this.labelSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSKU.Location = new System.Drawing.Point(12, 214);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(42, 20);
            this.labelSKU.TabIndex = 8;
            this.labelSKU.Text = "SKU";
            // 
            // textBoxSKU
            // 
            this.textBoxSKU.Location = new System.Drawing.Point(12, 237);
            this.textBoxSKU.Name = "textBoxSKU";
            this.textBoxSKU.ReadOnly = true;
            this.textBoxSKU.Size = new System.Drawing.Size(187, 20);
            this.textBoxSKU.TabIndex = 9;
            // 
            // labelManufacturer
            // 
            this.labelManufacturer.AutoSize = true;
            this.labelManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManufacturer.Location = new System.Drawing.Point(252, 13);
            this.labelManufacturer.Name = "labelManufacturer";
            this.labelManufacturer.Size = new System.Drawing.Size(104, 20);
            this.labelManufacturer.TabIndex = 10;
            this.labelManufacturer.Text = "Manufacturer";
            // 
            // comboBoxManufacturer
            // 
            this.comboBoxManufacturer.FormattingEnabled = true;
            this.comboBoxManufacturer.Location = new System.Drawing.Point(246, 36);
            this.comboBoxManufacturer.Name = "comboBoxManufacturer";
            this.comboBoxManufacturer.Size = new System.Drawing.Size(187, 21);
            this.comboBoxManufacturer.TabIndex = 11;
            // 
            // textBoxTecDocNumber
            // 
            this.textBoxTecDocNumber.Location = new System.Drawing.Point(246, 99);
            this.textBoxTecDocNumber.Name = "textBoxTecDocNumber";
            this.textBoxTecDocNumber.Size = new System.Drawing.Size(187, 20);
            this.textBoxTecDocNumber.TabIndex = 13;
            // 
            // labelItemNumber
            // 
            this.labelItemNumber.AutoSize = true;
            this.labelItemNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemNumber.Location = new System.Drawing.Point(252, 75);
            this.labelItemNumber.Name = "labelItemNumber";
            this.labelItemNumber.Size = new System.Drawing.Size(97, 20);
            this.labelItemNumber.TabIndex = 12;
            this.labelItemNumber.Text = "ItemNumber";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(12, 549);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(96, 30);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxSupplierSKU
            // 
            this.textBoxSupplierSKU.Location = new System.Drawing.Point(12, 291);
            this.textBoxSupplierSKU.Name = "textBoxSupplierSKU";
            this.textBoxSupplierSKU.Size = new System.Drawing.Size(187, 20);
            this.textBoxSupplierSKU.TabIndex = 16;
            // 
            // labelSupplierSKU
            // 
            this.labelSupplierSKU.AutoSize = true;
            this.labelSupplierSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSupplierSKU.Location = new System.Drawing.Point(12, 268);
            this.labelSupplierSKU.Name = "labelSupplierSKU";
            this.labelSupplierSKU.Size = new System.Drawing.Size(100, 20);
            this.labelSupplierSKU.TabIndex = 15;
            this.labelSupplierSKU.Text = "SupplierSKU";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelMessage.Location = new System.Drawing.Point(517, 425);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 20);
            this.labelMessage.TabIndex = 17;
            this.labelMessage.Visible = false;
            // 
            // buttonAddPhotos
            // 
            this.buttonAddPhotos.Location = new System.Drawing.Point(661, 273);
            this.buttonAddPhotos.Name = "buttonAddPhotos";
            this.buttonAddPhotos.Size = new System.Drawing.Size(96, 21);
            this.buttonAddPhotos.TabIndex = 18;
            this.buttonAddPhotos.Text = "Add photo";
            this.buttonAddPhotos.UseVisualStyleBackColor = true;
            this.buttonAddPhotos.Click += new System.EventHandler(this.buttonAddPhotos_Click);
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Items.AddRange(new object[] {
            "Use Rules",
            "Use Mumbers"});
            this.comboBoxSupplier.Location = new System.Drawing.Point(12, 349);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(187, 21);
            this.comboBoxSupplier.TabIndex = 20;
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSupplier.Location = new System.Drawing.Point(12, 326);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(67, 20);
            this.labelSupplier.TabIndex = 19;
            this.labelSupplier.Text = "Supplier";
            // 
            // dataGridViewPictures
            // 
            this.dataGridViewPictures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPictures.Location = new System.Drawing.Point(228, 300);
            this.dataGridViewPictures.Name = "dataGridViewPictures";
            this.dataGridViewPictures.Size = new System.Drawing.Size(532, 145);
            this.dataGridViewPictures.TabIndex = 21;
            this.dataGridViewPictures.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPictures_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(497, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 260);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(12, 412);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(109, 20);
            this.textBoxWeight.TabIndex = 24;
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeight.Location = new System.Drawing.Point(12, 389);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(59, 20);
            this.labelWeight.TabIndex = 23;
            this.labelWeight.Text = "Weight";
            // 
            // labelKg
            // 
            this.labelKg.AutoSize = true;
            this.labelKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKg.Location = new System.Drawing.Point(123, 416);
            this.labelKg.Name = "labelKg";
            this.labelKg.Size = new System.Drawing.Size(23, 16);
            this.labelKg.TabIndex = 25;
            this.labelKg.Text = "kg";
            // 
            // labelGBP
            // 
            this.labelGBP.AutoSize = true;
            this.labelGBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGBP.Location = new System.Drawing.Point(121, 474);
            this.labelGBP.Name = "labelGBP";
            this.labelGBP.Size = new System.Drawing.Size(36, 16);
            this.labelGBP.TabIndex = 28;
            this.labelGBP.Text = "GBP";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(12, 468);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(109, 20);
            this.textBoxPrice.TabIndex = 27;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(12, 445);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(44, 20);
            this.labelPrice.TabIndex = 26;
            this.labelPrice.Text = "Price";
            // 
            // richTextBoxLogger
            // 
            this.richTextBoxLogger.Location = new System.Drawing.Point(227, 458);
            this.richTextBoxLogger.Name = "richTextBoxLogger";
            this.richTextBoxLogger.Size = new System.Drawing.Size(533, 121);
            this.richTextBoxLogger.TabIndex = 29;
            this.richTextBoxLogger.Text = "";
            // 
            // textBoxTecDocNumberForDelete
            // 
            this.textBoxTecDocNumberForDelete.Location = new System.Drawing.Point(246, 214);
            this.textBoxTecDocNumberForDelete.Name = "textBoxTecDocNumberForDelete";
            this.textBoxTecDocNumberForDelete.Size = new System.Drawing.Size(187, 20);
            this.textBoxTecDocNumberForDelete.TabIndex = 30;
            // 
            // labelRemove
            // 
            this.labelRemove.AutoSize = true;
            this.labelRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemove.Location = new System.Drawing.Point(252, 191);
            this.labelRemove.Name = "labelRemove";
            this.labelRemove.Size = new System.Drawing.Size(208, 20);
            this.labelRemove.TabIndex = 31;
            this.labelRemove.Text = "Number with erroneous links";
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRemove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRemove.Location = new System.Drawing.Point(246, 240);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(96, 27);
            this.buttonRemove.TabIndex = 32;
            this.buttonRemove.Text = "Remove links";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // FormDevelopmentIten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 591);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.labelRemove);
            this.Controls.Add(this.textBoxTecDocNumberForDelete);
            this.Controls.Add(this.richTextBoxLogger);
            this.Controls.Add(this.labelGBP);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelKg);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewPictures);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.labelSupplier);
            this.Controls.Add(this.buttonAddPhotos);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.textBoxSupplierSKU);
            this.Controls.Add(this.labelSupplierSKU);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxTecDocNumber);
            this.Controls.Add(this.labelItemNumber);
            this.Controls.Add(this.comboBoxManufacturer);
            this.Controls.Add(this.labelManufacturer);
            this.Controls.Add(this.textBoxSKU);
            this.Controls.Add(this.labelSKU);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.comboBoxRules);
            this.Controls.Add(this.labelRules);
            this.Controls.Add(this.comboBoxBrands);
            this.Controls.Add(this.labelBrands);
            this.Controls.Add(this.labelSourceDb);
            this.Controls.Add(this.comboBoxSourceDB);
            this.Name = "FormDevelopmentIten";
            this.Text = "Item Development";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPictures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSourceDB;
        private System.Windows.Forms.Label labelSourceDb;
        private System.Windows.Forms.Label labelBrands;
        private System.Windows.Forms.ComboBox comboBoxBrands;
        private System.Windows.Forms.Label labelRules;
        private System.Windows.Forms.ComboBox comboBoxRules;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelSKU;
        private System.Windows.Forms.TextBox textBoxSKU;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.ComboBox comboBoxManufacturer;
        private System.Windows.Forms.TextBox textBoxTecDocNumber;
        private System.Windows.Forms.Label labelItemNumber;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxSupplierSKU;
        private System.Windows.Forms.Label labelSupplierSKU;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonAddPhotos;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.DataGridView dataGridViewPictures;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelKg;
        private System.Windows.Forms.Label labelGBP;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.RichTextBox richTextBoxLogger;
        private System.Windows.Forms.TextBox textBoxTecDocNumberForDelete;
        private System.Windows.Forms.Label labelRemove;
        private System.Windows.Forms.Button buttonRemove;
    }
}


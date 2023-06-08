
namespace test_DataBase
{
    partial class Add_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_price2 = new System.Windows.Forms.TextBox();
            this.textBox_postav2 = new System.Windows.Forms.TextBox();
            this.textBox_count2 = new System.Windows.Forms.TextBox();
            this.textBox_type2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_price2);
            this.groupBox1.Controls.Add(this.textBox_postav2);
            this.groupBox1.Controls.Add(this.textBox_count2);
            this.groupBox1.Controls.Add(this.textBox_type2);
            this.groupBox1.Location = new System.Drawing.Point(29, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление новой записи";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Цена:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Поставщик:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Тип товара:";
            // 
            // textBox_price2
            // 
            this.textBox_price2.Location = new System.Drawing.Point(85, 107);
            this.textBox_price2.Name = "textBox_price2";
            this.textBox_price2.Size = new System.Drawing.Size(252, 20);
            this.textBox_price2.TabIndex = 4;
            // 
            // textBox_postav2
            // 
            this.textBox_postav2.Location = new System.Drawing.Point(85, 81);
            this.textBox_postav2.Name = "textBox_postav2";
            this.textBox_postav2.Size = new System.Drawing.Size(252, 20);
            this.textBox_postav2.TabIndex = 3;
            // 
            // textBox_count2
            // 
            this.textBox_count2.Location = new System.Drawing.Point(85, 55);
            this.textBox_count2.Name = "textBox_count2";
            this.textBox_count2.Size = new System.Drawing.Size(252, 20);
            this.textBox_count2.TabIndex = 2;
            // 
            // textBox_type2
            // 
            this.textBox_type2.Location = new System.Drawing.Point(85, 29);
            this.textBox_type2.Name = "textBox_type2";
            this.textBox_type2.Size = new System.Drawing.Size(252, 20);
            this.textBox_type2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(358, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 230);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Add_Form";
            this.Text = "Добавление новой записи";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_price2;
        private System.Windows.Forms.TextBox textBox_postav2;
        private System.Windows.Forms.TextBox textBox_count2;
        private System.Windows.Forms.TextBox textBox_type2;
        private System.Windows.Forms.Button button1;
    }
}
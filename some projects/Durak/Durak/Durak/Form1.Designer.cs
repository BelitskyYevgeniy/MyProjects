namespace Durak_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_no = new System.Windows.Forms.Button();
            this.btn_yes = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_no
            // 
            this.btn_no.Location = new System.Drawing.Point(473, 203);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(164, 63);
            this.btn_no.TabIndex = 0;
            this.btn_no.TabStop = false;
            this.btn_no.Text = "Нет";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.MouseHover += new System.EventHandler(this.btn_no_MouseHover);
            // 
            // btn_yes
            // 
            this.btn_yes.Location = new System.Drawing.Point(177, 203);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Size = new System.Drawing.Size(164, 63);
            this.btn_yes.TabIndex = 2;
            this.btn_yes.Text = "Да";
            this.btn_yes.UseVisualStyleBackColor = true;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            this.btn_yes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_yes_KeyDown);
            this.btn_yes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_yes_MouseMove);
            // 
            // lb
            // 
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb.Location = new System.Drawing.Point(0, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(826, 373);
            this.lb.TabIndex = 3;
            this.lb.Text = "Ты дурак?";
            this.lb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(808, 326);
            this.Controls.Add(this.btn_yes);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.lb);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";


            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.Button btn_yes;
        private System.Windows.Forms.Label lb;
    }
}


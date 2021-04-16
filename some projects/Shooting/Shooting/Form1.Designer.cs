namespace Shooting
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
            this.components = new System.ComponentModel.Container();
            this.tb_shoots = new System.Windows.Forms.TextBox();
            this.bt_shoot = new System.Windows.Forms.Button();
            this.tb_x = new System.Windows.Forms.TextBox();
            this.error_pr_x = new System.Windows.Forms.ErrorProvider(this.components);
            this.tb_y = new System.Windows.Forms.TextBox();
            this.bt_restart = new System.Windows.Forms.Button();
            this.tb_N = new System.Windows.Forms.TextBox();
            this.error_pr_y = new System.Windows.Forms.ErrorProvider(this.components);
            this.tb_R = new System.Windows.Forms.TextBox();
            this.lb_R = new System.Windows.Forms.Label();
            this.lb_N = new System.Windows.Forms.Label();
            this.error_pr_R = new System.Windows.Forms.ErrorProvider(this.components);
            this.error_pr_N = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_N)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_shoots
            // 
            this.tb_shoots.BackColor = System.Drawing.Color.Peru;
            this.tb_shoots.Location = new System.Drawing.Point(420, 0);
            this.tb_shoots.MinimumSize = new System.Drawing.Size(260, 340);
            this.tb_shoots.Multiline = true;
            this.tb_shoots.Name = "tb_shoots";
            this.tb_shoots.ReadOnly = true;
            this.tb_shoots.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_shoots.Size = new System.Drawing.Size(260, 340);
            this.tb_shoots.TabIndex = 0;
            // 
            // bt_shoot
            // 
            this.bt_shoot.Enabled = false;
            this.bt_shoot.Location = new System.Drawing.Point(471, 374);
            this.bt_shoot.Name = "bt_shoot";
            this.bt_shoot.Size = new System.Drawing.Size(141, 23);
            this.bt_shoot.TabIndex = 4;
            this.bt_shoot.Text = "Выстрел!";
            this.bt_shoot.UseVisualStyleBackColor = true;
            this.bt_shoot.Click += new System.EventHandler(this.bt_shoot_Click);
            // 
            // tb_x
            // 
            this.tb_x.ForeColor = System.Drawing.Color.Gray;
            this.tb_x.Location = new System.Drawing.Point(420, 346);
            this.tb_x.Name = "tb_x";
            this.tb_x.Size = new System.Drawing.Size(107, 22);
            this.tb_x.TabIndex = 2;
            this.tb_x.Text = "Значение по X";
            this.tb_x.TextChanged += new System.EventHandler(this.tb_x_TextChanged);
            this.tb_x.GotFocus += new System.EventHandler(this.tb_x_GotFocus);
            this.tb_x.Validated += new System.EventHandler(this.tb_x_Validated);
            // 
            // error_pr_x
            // 
            this.error_pr_x.ContainerControl = this;
            this.error_pr_x.RightToLeftChanged += new System.EventHandler(this.tb_x_GotFocus);
            // 
            // tb_y
            // 
            this.tb_y.ForeColor = System.Drawing.Color.Gray;
            this.tb_y.Location = new System.Drawing.Point(551, 346);
            this.tb_y.Name = "tb_y";
            this.tb_y.Size = new System.Drawing.Size(107, 22);
            this.tb_y.TabIndex = 3;
            this.tb_y.Text = "Значение по Y";
            this.tb_y.TextChanged += new System.EventHandler(this.tb_y_TextChanged);
            this.tb_y.GotFocus += new System.EventHandler(this.tb_y_GotFocus);
            this.tb_y.Validated += new System.EventHandler(this.tb_y_Validated);
            // 
            // bt_restart
            // 
            this.bt_restart.Location = new System.Drawing.Point(487, 403);
            this.bt_restart.Name = "bt_restart";
            this.bt_restart.Size = new System.Drawing.Size(107, 23);
            this.bt_restart.TabIndex = 5;
            this.bt_restart.Text = "Рестарт";
            this.bt_restart.UseVisualStyleBackColor = true;
            this.bt_restart.Click += new System.EventHandler(this.bt_restart_Click);
            // 
            // tb_N
            // 
            this.tb_N.ForeColor = System.Drawing.Color.Gray;
            this.tb_N.Location = new System.Drawing.Point(551, 432);
            this.tb_N.Name = "tb_N";
            this.tb_N.Size = new System.Drawing.Size(107, 22);
            this.tb_N.TabIndex = 7;
            this.tb_N.Text = "Число пуль";
            this.tb_N.TextChanged += new System.EventHandler(this.tb_N_TextChanged);
            this.tb_N.GotFocus += new System.EventHandler(this.tb_N_GotFocus);
            this.tb_N.Validated += new System.EventHandler(this.tb_N_Validated);
            // 
            // error_pr_y
            // 
            this.error_pr_y.ContainerControl = this;
            // 
            // tb_R
            // 
            this.tb_R.ForeColor = System.Drawing.Color.Gray;
            this.tb_R.Location = new System.Drawing.Point(420, 432);
            this.tb_R.Name = "tb_R";
            this.tb_R.Size = new System.Drawing.Size(107, 22);
            this.tb_R.TabIndex = 6;
            this.tb_R.Text = "Радиус";
            this.tb_R.TextChanged += new System.EventHandler(this.tb_R_TextChanged);
            this.tb_R.GotFocus += new System.EventHandler(this.tb_R_GotFocus);
            this.tb_R.Validated += new System.EventHandler(this.tb_R_Validated);
            // 
            // lb_R
            // 
            this.lb_R.AutoSize = true;
            this.lb_R.Location = new System.Drawing.Point(426, 409);
            this.lb_R.Name = "lb_R";
            this.lb_R.Size = new System.Drawing.Size(32, 17);
            this.lb_R.TabIndex = 7;
            this.lb_R.Text = "125";
            // 
            // lb_N
            // 
            this.lb_N.AutoSize = true;
            this.lb_N.Location = new System.Drawing.Point(610, 409);
            this.lb_N.Name = "lb_N";
            this.lb_N.Size = new System.Drawing.Size(24, 17);
            this.lb_N.TabIndex = 8;
            this.lb_N.Text = "10";
            // 
            // error_pr_R
            // 
            this.error_pr_R.ContainerControl = this;
            // 
            // error_pr_N
            // 
            this.error_pr_N.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.lb_N);
            this.Controls.Add(this.lb_R);
            this.Controls.Add(this.tb_R);
            this.Controls.Add(this.tb_N);
            this.Controls.Add(this.bt_restart);
            this.Controls.Add(this.tb_y);
            this.Controls.Add(this.tb_x);
            this.Controls.Add(this.bt_shoot);
            this.Controls.Add(this.tb_shoots);
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Form1";
            this.Text = "Стрельба";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_pr_N)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_shoots;
        private System.Windows.Forms.Button bt_shoot;
        private System.Windows.Forms.TextBox tb_x;
        private System.Windows.Forms.ErrorProvider error_pr_x;
        private System.Windows.Forms.TextBox tb_y;
        private System.Windows.Forms.TextBox tb_N;
        private System.Windows.Forms.Button bt_restart;
        private System.Windows.Forms.ErrorProvider error_pr_y;
        private System.Windows.Forms.TextBox tb_R;
        private System.Windows.Forms.Label lb_N;
        private System.Windows.Forms.Label lb_R;
        private System.Windows.Forms.ErrorProvider error_pr_R;
        private System.Windows.Forms.ErrorProvider error_pr_N;
    }
}


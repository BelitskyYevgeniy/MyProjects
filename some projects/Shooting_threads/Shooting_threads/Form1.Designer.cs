namespace Shooting_threads
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
            this.bt_stop_calc = new System.Windows.Forms.Button();
            this.bt_stop_shooting = new System.Windows.Forms.Button();
            this.bt_restart = new System.Windows.Forms.Button();
            this.bt_time_changer_calc = new System.Windows.Forms.Button();
            this.bt_time_changer_shoot = new System.Windows.Forms.Button();
            this.tb_input_calc_changer = new System.Windows.Forms.TextBox();
            this.tb_input_shoot_changer = new System.Windows.Forms.TextBox();
            this.ep_calc = new System.Windows.Forms.ErrorProvider(this.components);
            this.ep_shoot = new System.Windows.Forms.ErrorProvider(this.components);
            this.tb_input_rad = new System.Windows.Forms.TextBox();
            this.ep_restart = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep_calc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_shoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_restart)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_shoots
            // 
            this.tb_shoots.BackColor = System.Drawing.Color.Peru;
            this.tb_shoots.Location = new System.Drawing.Point(420, 0);
            this.tb_shoots.MaximumSize = new System.Drawing.Size(320, 300);
            this.tb_shoots.MinimumSize = new System.Drawing.Size(320, 300);
            this.tb_shoots.Multiline = true;
            this.tb_shoots.Name = "tb_shoots";
            this.tb_shoots.ReadOnly = true;
            this.tb_shoots.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_shoots.Size = new System.Drawing.Size(320, 300);
            this.tb_shoots.TabIndex = 0;
            this.tb_shoots.Text = "Внимание!\r\nВ полях ввода необходимо ввести величину >0 в мс!\r\n\r\nЗадержка между вы" +
    "числениями: 500 мс\r\nЗадержка между выстрелами: 1000 мс\r\nРадиус: 1\r\n";
            // 
            // bt_stop_calc
            // 
            this.bt_stop_calc.Location = new System.Drawing.Point(420, 306);
            this.bt_stop_calc.Name = "bt_stop_calc";
            this.bt_stop_calc.Size = new System.Drawing.Size(142, 56);
            this.bt_stop_calc.TabIndex = 1;
            this.bt_stop_calc.Text = "Прекратить вычисления";
            this.bt_stop_calc.UseVisualStyleBackColor = true;
            // 
            // bt_stop_shooting
            // 
            this.bt_stop_shooting.Location = new System.Drawing.Point(590, 306);
            this.bt_stop_shooting.Name = "bt_stop_shooting";
            this.bt_stop_shooting.Size = new System.Drawing.Size(142, 56);
            this.bt_stop_shooting.TabIndex = 2;
            this.bt_stop_shooting.Text = "Остановить стрельбу";
            this.bt_stop_shooting.UseVisualStyleBackColor = true;
            this.bt_stop_shooting.Click += new System.EventHandler(this.bt_stop_shooting_Click);
            // 
            // bt_restart
            // 
            this.bt_restart.Location = new System.Drawing.Point(517, 368);
            this.bt_restart.Name = "bt_restart";
            this.bt_restart.Size = new System.Drawing.Size(120, 32);
            this.bt_restart.TabIndex = 3;
            this.bt_restart.Text = "Рестарт";
            this.bt_restart.UseVisualStyleBackColor = true;
            this.bt_restart.Click += new System.EventHandler(this.bt_restart_Click);
            // 
            // bt_time_changer_calc
            // 
            this.bt_time_changer_calc.Enabled = false;
            this.bt_time_changer_calc.Location = new System.Drawing.Point(420, 435);
            this.bt_time_changer_calc.Name = "bt_time_changer_calc";
            this.bt_time_changer_calc.Size = new System.Drawing.Size(142, 76);
            this.bt_time_changer_calc.TabIndex = 6;
            this.bt_time_changer_calc.Text = "Изменить задержку между вычислениями ";
            this.bt_time_changer_calc.UseVisualStyleBackColor = true;
            this.bt_time_changer_calc.Click += new System.EventHandler(this.bt_time_changer_calc_Click);
            // 
            // bt_time_changer_shoot
            // 
            this.bt_time_changer_shoot.Enabled = false;
            this.bt_time_changer_shoot.Location = new System.Drawing.Point(590, 435);
            this.bt_time_changer_shoot.Name = "bt_time_changer_shoot";
            this.bt_time_changer_shoot.Size = new System.Drawing.Size(142, 76);
            this.bt_time_changer_shoot.TabIndex = 7;
            this.bt_time_changer_shoot.Text = "Изменить задержку между выстрелами";
            this.bt_time_changer_shoot.UseVisualStyleBackColor = true;
            this.bt_time_changer_shoot.Click += new System.EventHandler(this.bt_time_changer_shoot_Click);
            // 
            // tb_input_calc_changer
            // 
            this.tb_input_calc_changer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tb_input_calc_changer.Location = new System.Drawing.Point(420, 407);
            this.tb_input_calc_changer.Name = "tb_input_calc_changer";
            this.tb_input_calc_changer.Size = new System.Drawing.Size(89, 22);
            this.tb_input_calc_changer.TabIndex = 4;
            this.tb_input_calc_changer.TextChanged += new System.EventHandler(this.tb_input_calc_changer_TextChanged);
            // 
            // tb_input_shoot_changer
            // 
            this.tb_input_shoot_changer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tb_input_shoot_changer.Location = new System.Drawing.Point(643, 407);
            this.tb_input_shoot_changer.Name = "tb_input_shoot_changer";
            this.tb_input_shoot_changer.Size = new System.Drawing.Size(89, 22);
            this.tb_input_shoot_changer.TabIndex = 5;
            this.tb_input_shoot_changer.TextChanged += new System.EventHandler(this.tb_input_shoot_changer_TextChanged);
            // 
            // ep_calc
            // 
            this.ep_calc.ContainerControl = this;
            // 
            // ep_shoot
            // 
            this.ep_shoot.ContainerControl = this;
            this.ep_shoot.RightToLeft = true;
            // 
            // tb_input_rad
            // 
            this.tb_input_rad.Enabled = false;
            this.tb_input_rad.Location = new System.Drawing.Point(538, 407);
            this.tb_input_rad.Name = "tb_input_rad";
            this.tb_input_rad.Size = new System.Drawing.Size(82, 22);
            this.tb_input_rad.TabIndex = 8;
            this.tb_input_rad.TextChanged += new System.EventHandler(this.tb_input_rad_TextChanged);
            // 
            // ep_restart
            // 
            this.ep_restart.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(732, 513);
            this.Controls.Add(this.tb_input_rad);
            this.Controls.Add(this.tb_input_shoot_changer);
            this.Controls.Add(this.tb_input_calc_changer);
            this.Controls.Add(this.bt_time_changer_shoot);
            this.Controls.Add(this.bt_time_changer_calc);
            this.Controls.Add(this.bt_restart);
            this.Controls.Add(this.bt_stop_shooting);
            this.Controls.Add(this.bt_stop_calc);
            this.Controls.Add(this.tb_shoots);
            this.MaximumSize = new System.Drawing.Size(750, 560);
            this.MinimumSize = new System.Drawing.Size(750, 560);
            this.Name = "Form1";
            this.Text = "Стрельба";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ep_calc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_shoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_restart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_shoots;
        private System.Windows.Forms.Button bt_stop_calc;
        private System.Windows.Forms.Button bt_stop_shooting;
        private System.Windows.Forms.Button bt_restart;
        private System.Windows.Forms.Button bt_time_changer_calc;
        private System.Windows.Forms.Button bt_time_changer_shoot;
        private System.Windows.Forms.TextBox tb_input_calc_changer;
        private System.Windows.Forms.TextBox tb_input_shoot_changer;
        private System.Windows.Forms.ErrorProvider ep_calc;
        private System.Windows.Forms.ErrorProvider ep_shoot;
        private System.Windows.Forms.TextBox tb_input_rad;
        private System.Windows.Forms.ErrorProvider ep_restart;
        //private System.Windows.Forms.Button bt_shoot;
        //private System.Windows.Forms.TextBox tb_x;
        //private System.Windows.Forms.ErrorProvider error_pr_x;
        //private System.Windows.Forms.TextBox tb_y;
        //private System.Windows.Forms.TextBox tb_N;
        //private System.Windows.Forms.Button bt_restart;
        //private System.Windows.Forms.ErrorProvider error_pr_y;
        //private System.Windows.Forms.TextBox tb_R;
        //private System.Windows.Forms.Label lb_N;
        //private System.Windows.Forms.Label lb_R;
        //private System.Windows.Forms.ErrorProvider error_pr_R;
        //private System.Windows.Forms.ErrorProvider error_pr_N;
    }
}


﻿namespace ĐỒ_ÁN
{
    partial class LichSuCanHo
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
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Huy = new Guna.UI2.WinForms.Guna2Button();
            this.dgv_LichSu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(279, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 26);
            this.label6.TabIndex = 61;
            this.label6.Text = "LỊCH SỬ CĂN HỘ";
            // 
            // btn_Huy
            // 
            this.btn_Huy.BorderRadius = 10;
            this.btn_Huy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Huy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Huy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.ForeColor = System.Drawing.Color.White;
            this.btn_Huy.Location = new System.Drawing.Point(304, 395);
            this.btn_Huy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(166, 48);
            this.btn_Huy.TabIndex = 62;
            this.btn_Huy.Text = "Đóng";
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // dgv_LichSu
            // 
            this.dgv_LichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_LichSu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_LichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_LichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LichSu.Location = new System.Drawing.Point(12, 57);
            this.dgv_LichSu.Name = "dgv_LichSu";
            this.dgv_LichSu.RowHeadersWidth = 62;
            this.dgv_LichSu.RowTemplate.Height = 28;
            this.dgv_LichSu.Size = new System.Drawing.Size(787, 329);
            this.dgv_LichSu.TabIndex = 70;
            // 
            // LichSuCanHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.dgv_LichSu);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.label6);
            this.Name = "LichSuCanHo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LichSuCanHo";
            this.Load += new System.EventHandler(this.LichSuCanHo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btn_Huy;
        private System.Windows.Forms.DataGridView dgv_LichSu;
    }
}
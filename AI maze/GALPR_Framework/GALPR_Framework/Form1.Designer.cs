
namespace GALPR_Framework
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertRoGrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saturateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saturation05ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hueRotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hueRotation20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxCustom1 = new GALPR_Framework.PictureBoxCustom();
            this.pictureBoxCustom2 = new GALPR_Framework.PictureBoxCustom();
            this.vRAM100X100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustom1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustom2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.imageOperationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // imageOperationsToolStripMenuItem
            // 
            this.imageOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertRoGrayscaleToolStripMenuItem,
            this.saturateToolStripMenuItem,
            this.saturation05ToolStripMenuItem,
            this.hueRotationToolStripMenuItem,
            this.hueRotation20ToolStripMenuItem});
            this.imageOperationsToolStripMenuItem.Name = "imageOperationsToolStripMenuItem";
            this.imageOperationsToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.imageOperationsToolStripMenuItem.Text = "Image Operations";
            // 
            // convertRoGrayscaleToolStripMenuItem
            // 
            this.convertRoGrayscaleToolStripMenuItem.Name = "convertRoGrayscaleToolStripMenuItem";
            this.convertRoGrayscaleToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.convertRoGrayscaleToolStripMenuItem.Text = "Convert ro Grayscale";
            this.convertRoGrayscaleToolStripMenuItem.Click += new System.EventHandler(this.convertRoGrayscaleToolStripMenuItem_Click);
            // 
            // saturateToolStripMenuItem
            // 
            this.saturateToolStripMenuItem.Name = "saturateToolStripMenuItem";
            this.saturateToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.saturateToolStripMenuItem.Text = "Saturation 1.5";
            this.saturateToolStripMenuItem.Click += new System.EventHandler(this.saturateToolStripMenuItem_Click);
            // 
            // saturation05ToolStripMenuItem
            // 
            this.saturation05ToolStripMenuItem.Name = "saturation05ToolStripMenuItem";
            this.saturation05ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.saturation05ToolStripMenuItem.Text = "Saturation 0.5";
            this.saturation05ToolStripMenuItem.Click += new System.EventHandler(this.saturation05ToolStripMenuItem_Click);
            // 
            // hueRotationToolStripMenuItem
            // 
            this.hueRotationToolStripMenuItem.Name = "hueRotationToolStripMenuItem";
            this.hueRotationToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.hueRotationToolStripMenuItem.Text = "Hue Rotation +20";
            this.hueRotationToolStripMenuItem.Click += new System.EventHandler(this.hueRotationToolStripMenuItem_Click);
            // 
            // hueRotation20ToolStripMenuItem
            // 
            this.hueRotation20ToolStripMenuItem.Name = "hueRotation20ToolStripMenuItem";
            this.hueRotation20ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.hueRotation20ToolStripMenuItem.Text = "Hue Rotation -20";
            this.hueRotation20ToolStripMenuItem.Click += new System.EventHandler(this.hueRotation20ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Open Image";
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(21, 20);
            this.toolStripStatusLabel1.Text = "--";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxCustom1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxCustom2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 396);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBoxCustom1
            // 
            this.pictureBoxCustom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCustom1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBoxCustom1.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCustom1.Name = "pictureBoxCustom1";
            this.pictureBoxCustom1.Size = new System.Drawing.Size(394, 390);
            this.pictureBoxCustom1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCustom1.TabIndex = 0;
            this.pictureBoxCustom1.TabStop = false;
            // 
            // pictureBoxCustom2
            // 
            this.pictureBoxCustom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCustom2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBoxCustom2.Location = new System.Drawing.Point(403, 3);
            this.pictureBoxCustom2.Name = "pictureBoxCustom2";
            this.pictureBoxCustom2.Size = new System.Drawing.Size(394, 390);
            this.pictureBoxCustom2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCustom2.TabIndex = 1;
            this.pictureBoxCustom2.TabStop = false;
            // 
            // vRAM100X100ToolStripMenuItem
            // 
            this.vRAM100X100ToolStripMenuItem.Name = "vRAM100X100ToolStripMenuItem";
            this.vRAM100X100ToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.vRAM100X100ToolStripMenuItem.Text = "VRAM 100 x 100 White";
            this.vRAM100X100ToolStripMenuItem.Click += new System.EventHandler(this.vRAM100X100ToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vRAM100X100ToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustom1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustom2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PictureBoxCustom pictureBoxCustom1;
        private PictureBoxCustom pictureBoxCustom2;
        private System.Windows.Forms.ToolStripMenuItem imageOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertRoGrayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saturateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hueRotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saturation05ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hueRotation20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vRAM100X100ToolStripMenuItem;
    }
}


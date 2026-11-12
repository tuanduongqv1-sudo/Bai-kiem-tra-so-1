namespace Bai5_4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblView = new System.Windows.Forms.Label();
            this.cboView = new System.Windows.Forms.ComboBox();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tvDepartments = new System.Windows.Forms.TreeView();
            this.lsvEmployees = new System.Windows.Forms.ListView();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colPosition = new System.Windows.Forms.ColumnHeader();
            this.colStartDate = new System.Windows.Forms.ColumnHeader();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.imgLarge = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.lblView);
            this.pnlTop.Controls.Add(this.cboView);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(784, 40);
            this.pnlTop.TabIndex = 0;
            //
            // lblView
            //
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(12, 12);
            this.lblView.Name = "lblView";
            this.lblView.Text = "Chế độ xem:";
            //
            // cboView
            //
            this.cboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboView.Location = new System.Drawing.Point(100, 9);
            this.cboView.Name = "cboView";
            this.cboView.Size = new System.Drawing.Size(150, 23);
            this.cboView.TabIndex = 0;
            this.cboView.SelectedIndexChanged += new System.EventHandler(this.cboView_SelectedIndexChanged);
            //
            // splitMain
            //
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 40);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Controls.Add(this.tvDepartments);
            this.splitMain.Panel2.Controls.Add(this.lsvEmployees);
            this.splitMain.Size = new System.Drawing.Size(784, 499);
            this.splitMain.SplitterDistance = 250;
            this.splitMain.TabIndex = 1;
            //
            // tvDepartments
            //
            this.tvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDepartments.HideSelection = false;
            this.tvDepartments.ImageList = this.imgSmall;
            this.tvDepartments.Location = new System.Drawing.Point(0, 0);
            this.tvDepartments.Name = "tvDepartments";
            this.tvDepartments.Size = new System.Drawing.Size(250, 499);
            this.tvDepartments.TabIndex = 0;
            this.tvDepartments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDepartments_AfterSelect);
            //
            // lsvEmployees
            //
            this.lsvEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colId, this.colName, this.colPosition, this.colStartDate});
            this.lsvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvEmployees.FullRowSelect = true;
            this.lsvEmployees.GridLines = true;
            this.lsvEmployees.LargeImageList = this.imgLarge;
            this.lsvEmployees.Location = new System.Drawing.Point(0, 0);
            this.lsvEmployees.Name = "lsvEmployees";
            this.lsvEmployees.Size = new System.Drawing.Size(530, 499);
            this.lsvEmployees.SmallImageList = this.imgSmall;
            this.lsvEmployees.TabIndex = 0;
            this.lsvEmployees.UseCompatibleStateImageBehavior = false;
            this.lsvEmployees.View = System.Windows.Forms.View.Details;
            //
            // colId
            //
            this.colId.Text = "Mã NV";
            this.colId.Width = 80;
            //
            // colName
            //
            this.colName.Text = "Họ Tên";
            this.colName.Width = 170;
            //
            // colPosition
            //
            this.colPosition.Text = "Chức vụ";
            this.colPosition.Width = 130;
            //
            // colStartDate
            //
            this.colStartDate.Text = "Ngày vào làm";
            this.colStartDate.Width = 110;
            //
            // imgSmall
            //
            this.imgSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imgSmall.TransparentColor = System.Drawing.Color.Transparent;
            //
            // imgLarge
            //
            this.imgLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.imgLarge.TransparentColor = System.Drawing.Color.Transparent;
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            //
            // lblStatus
            //
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Sẵn sàng";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân sự theo phòng ban";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.ComboBox cboView;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView tvDepartments;
        private System.Windows.Forms.ListView lsvEmployees;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPosition;
        private System.Windows.Forms.ColumnHeader colStartDate;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.ImageList imgLarge;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

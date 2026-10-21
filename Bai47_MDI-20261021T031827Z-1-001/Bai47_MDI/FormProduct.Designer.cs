namespace Bai47_MDI
{
    partial class FormProduct
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dgvProducts = new DataGridView();
            this.grpInput = new GroupBox();
            this.lblProductId = new Label();
            this.txtProductId = new TextBox();
            this.lblProductName = new Label();
            this.txtProductName = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
            this.grpActions = new GroupBox();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnUpdate = new Button();
            this.bindingSource1 = new BindingSource(this.components);

            this.contextMenuDGV = new ContextMenuStrip(this.components);
            this.ctxXoaDong = new ToolStripMenuItem();
            this.ctxLamMoi = new ToolStripMenuItem();
            this.ctxXemChiTiet = new ToolStripMenuItem();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.contextMenuDGV.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();

            // ContextMenuStrip
            this.contextMenuDGV.Items.AddRange(new ToolStripItem[] {
                this.ctxXoaDong, this.ctxLamMoi, new ToolStripSeparator(), this.ctxXemChiTiet });
            this.ctxXoaDong.Text = "Xóa dòng";
            this.ctxLamMoi.Text = "Làm mới dữ liệu";
            this.ctxXemChiTiet.Text = "Xem chi tiết";

            // DataGridView
            this.dgvProducts.Location = new Point(12, 12);
            this.dgvProducts.Size = new Size(500, 220);
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = SystemColors.Window;
            this.dgvProducts.ContextMenuStrip = this.contextMenuDGV;

            // Group Input
            this.grpInput.Text = "Thông tin Sản phẩm";
            this.grpInput.Location = new Point(12, 240);
            this.grpInput.Size = new Size(350, 190);
            this.grpInput.Controls.Add(this.lblProductId);
            this.grpInput.Controls.Add(this.txtProductId);
            this.grpInput.Controls.Add(this.lblProductName);
            this.grpInput.Controls.Add(this.txtProductName);
            this.grpInput.Controls.Add(this.lblPrice);
            this.grpInput.Controls.Add(this.txtPrice);
            this.grpInput.Controls.Add(this.lblQuantity);
            this.grpInput.Controls.Add(this.txtQuantity);

            this.lblProductId.Text = "Mã SP:";
            this.lblProductId.Location = new Point(15, 30);
            this.lblProductId.Size = new Size(80, 23);
            this.lblProductId.TextAlign = ContentAlignment.MiddleLeft;
            this.txtProductId.Location = new Point(100, 30);
            this.txtProductId.Size = new Size(230, 23);

            this.lblProductName.Text = "Tên SP:";
            this.lblProductName.Location = new Point(15, 65);
            this.lblProductName.Size = new Size(80, 23);
            this.lblProductName.TextAlign = ContentAlignment.MiddleLeft;
            this.txtProductName.Location = new Point(100, 65);
            this.txtProductName.Size = new Size(230, 23);

            this.lblPrice.Text = "Đơn giá:";
            this.lblPrice.Location = new Point(15, 100);
            this.lblPrice.Size = new Size(80, 23);
            this.lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            this.txtPrice.Location = new Point(100, 100);
            this.txtPrice.Size = new Size(230, 23);

            this.lblQuantity.Text = "Số lượng:";
            this.lblQuantity.Location = new Point(15, 135);
            this.lblQuantity.Size = new Size(80, 23);
            this.lblQuantity.TextAlign = ContentAlignment.MiddleLeft;
            this.txtQuantity.Location = new Point(100, 135);
            this.txtQuantity.Size = new Size(230, 23);

            // Group Actions
            this.grpActions.Text = "Chức năng";
            this.grpActions.Location = new Point(370, 240);
            this.grpActions.Size = new Size(142, 190);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.btnUpdate);

            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new Point(12, 30);
            this.btnAdd.Size = new Size(118, 38);
            this.btnAdd.BackColor = Color.FromArgb(46, 139, 87);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Cursor = Cursors.Hand;

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new Point(12, 78);
            this.btnDelete.Size = new Size(118, 38);
            this.btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Cursor = Cursors.Hand;

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new Point(12, 126);
            this.btnUpdate.Size = new Size(118, 38);
            this.btnUpdate.BackColor = Color.FromArgb(0, 123, 255);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Cursor = Cursors.Hand;

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(525, 445);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpActions);
            this.Name = "FormProduct";
            this.Text = "Quản lý Sản phẩm";

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.contextMenuDGV.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProducts;
        private GroupBox grpInput;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private GroupBox grpActions;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private BindingSource bindingSource1;
        private ContextMenuStrip contextMenuDGV;
        private ToolStripMenuItem ctxXoaDong;
        private ToolStripMenuItem ctxLamMoi;
        private ToolStripMenuItem ctxXemChiTiet;
    }
}

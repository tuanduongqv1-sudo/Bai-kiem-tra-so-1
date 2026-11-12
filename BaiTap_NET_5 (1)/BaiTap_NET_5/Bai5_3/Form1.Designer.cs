namespace Bai5_3
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
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsProducts = new System.Windows.Forms.BindingSource(this.components);
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducts)).BeginInit();
            this.SuspendLayout();
            //
            // grpInfo
            //
            this.grpInfo.Controls.Add(this.lblId);
            this.grpInfo.Controls.Add(this.txtId);
            this.grpInfo.Controls.Add(this.lblName);
            this.grpInfo.Controls.Add(this.txtName);
            this.grpInfo.Controls.Add(this.lblPrice);
            this.grpInfo.Controls.Add(this.txtPrice);
            this.grpInfo.Controls.Add(this.lblQuantity);
            this.grpInfo.Controls.Add(this.nudQuantity);
            this.grpInfo.Controls.Add(this.lblCategory);
            this.grpInfo.Controls.Add(this.cboCategory);
            this.grpInfo.Location = new System.Drawing.Point(12, 12);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(450, 170);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin sản phẩm";
            //
            // lblId
            //
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(15, 30);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Mã SP:";
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(100, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(130, 23);
            this.txtId.TabIndex = 0;
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 62);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Tên SP:";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(100, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(330, 23);
            this.txtName.TabIndex = 1;
            //
            // lblPrice
            //
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(15, 94);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Đơn giá:";
            //
            // txtPrice
            //
            this.txtPrice.Location = new System.Drawing.Point(100, 91);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(130, 23);
            this.txtPrice.TabIndex = 2;
            //
            // lblQuantity
            //
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(250, 94);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Text = "Số lượng:";
            //
            // nudQuantity
            //
            this.nudQuantity.Location = new System.Drawing.Point(320, 91);
            this.nudQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(110, 23);
            this.nudQuantity.TabIndex = 3;
            this.nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblCategory
            //
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(15, 126);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Danh mục:";
            //
            // cboCategory
            //
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new System.Drawing.Point(100, 123);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 23);
            this.cboCategory.TabIndex = 4;
            //
            // grpActions
            //
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Controls.Add(this.btnEdit);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.lblSearch);
            this.grpActions.Controls.Add(this.txtSearch);
            this.grpActions.Controls.Add(this.btnSearch);
            this.grpActions.Location = new System.Drawing.Point(475, 12);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(250, 170);
            this.grpActions.TabIndex = 1;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Chức năng";
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(15, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(90, 25);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 32);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(165, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 85);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Tìm theo Tên SP:";
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(15, 107);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 23);
            this.txtSearch.TabIndex = 3;
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(15, 133);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(215, 28);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colName, this.colPrice, this.colQuantity, this.colCategory});
            this.dgvProducts.Location = new System.Drawing.Point(12, 195);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(713, 250);
            this.dgvProducts.TabIndex = 2;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            //
            // colId
            //
            this.colId.DataPropertyName = "ProductId";
            this.colId.HeaderText = "Mã SP";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 90;
            //
            // colName
            //
            this.colName.DataPropertyName = "ProductName";
            this.colName.HeaderText = "Tên SP";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 240;
            //
            // colPrice
            //
            this.colPrice.DataPropertyName = "UnitPrice";
            this.colPrice.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle {
                Format = "N0", Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight };
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 120;
            //
            // colQuantity
            //
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Số lượng";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 90;
            //
            // colCategory
            //
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "Danh mục";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 170;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 460);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.dgvProducts);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh sách sản phẩm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducts)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.BindingSource bsProducts;
    }
}

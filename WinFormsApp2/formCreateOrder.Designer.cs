
namespace WinFormsApp2
{
    partial class formCreateOrder
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
            this.components = new System.ComponentModel.Container();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNext = new System.Windows.Forms.Button();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCurrentOrder = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishCategoryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.btnBackToOrders = new System.Windows.Forms.Button();
            this.comboBoxDiscounts = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDishConstructor = new System.Windows.Forms.Panel();
            this.btnHideDishConstructor = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvSelectedIngredients = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentOrder)).BeginInit();
            this.panelDishConstructor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMenu
            // 
            this.dgvMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMenu.AutoGenerateColumns = false;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dishCategoryDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.Add});
            this.dgvMenu.DataSource = this.menuItemBindingSource;
            this.dgvMenu.Location = new System.Drawing.Point(78, 45);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersWidth = 72;
            this.dgvMenu.RowTemplate.Height = 25;
            this.dgvMenu.Size = new System.Drawing.Size(555, 150);
            this.dgvMenu.TabIndex = 0;
            this.dgvMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // dishCategoryDataGridViewTextBoxColumn
            // 
            this.dishCategoryDataGridViewTextBoxColumn.DataPropertyName = "DishCategory";
            this.dishCategoryDataGridViewTextBoxColumn.HeaderText = "DishCategory";
            this.dishCategoryDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.dishCategoryDataGridViewTextBoxColumn.Name = "dishCategoryDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "IngredientName";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 160;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 50;
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Add.HeaderText = "Add";
            this.Add.MinimumWidth = 9;
            this.Add.Name = "Add";
            this.Add.Width = 110;
            // 
            // menuItemBindingSource
            // 
            this.menuItemBindingSource.DataSource = typeof(WinFormsApp2.DataAccess.MenuItem);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(786, 405);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(141, 35);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(WinFormsApp2.DataAccess.Order);
            // 
            // menuItemBindingSource1
            // 
            this.menuItemBindingSource1.DataSource = typeof(WinFormsApp2.DataAccess.MenuItem);
            // 
            // dgvCurrentOrder
            // 
            this.dgvCurrentOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCurrentOrder.AutoGenerateColumns = false;
            this.dgvCurrentOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.dishCategoryDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.Quantity,
            this.priceDataGridViewTextBoxColumn1});
            this.dgvCurrentOrder.DataSource = this.menuItemBindingSource;
            this.dgvCurrentOrder.Location = new System.Drawing.Point(78, 226);
            this.dgvCurrentOrder.Name = "dgvCurrentOrder";
            this.dgvCurrentOrder.RowHeadersWidth = 72;
            this.dgvCurrentOrder.RowTemplate.Height = 25;
            this.dgvCurrentOrder.Size = new System.Drawing.Size(555, 150);
            this.dgvCurrentOrder.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.Width = 50;
            // 
            // dishCategoryDataGridViewTextBoxColumn1
            // 
            this.dishCategoryDataGridViewTextBoxColumn1.DataPropertyName = "DishCategory";
            this.dishCategoryDataGridViewTextBoxColumn1.HeaderText = "DishCategory";
            this.dishCategoryDataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.dishCategoryDataGridViewTextBoxColumn1.Name = "dishCategoryDataGridViewTextBoxColumn1";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "IngredientName";
            this.nameDataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.Width = 160;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 9;
            this.Quantity.Name = "Quantity";
            // 
            // priceDataGridViewTextBoxColumn1
            // 
            this.priceDataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn1.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.priceDataGridViewTextBoxColumn1.Name = "priceDataGridViewTextBoxColumn1";
            this.priceDataGridViewTextBoxColumn1.Width = 50;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(78, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Menu:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(78, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current order:";
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmOrder.Location = new System.Drawing.Point(460, 398);
            this.btnConfirmOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(76, 20);
            this.btnConfirmOrder.TabIndex = 6;
            this.btnConfirmOrder.Text = "Confirm";
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // btnBackToOrders
            // 
            this.btnBackToOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBackToOrders.Location = new System.Drawing.Point(554, 398);
            this.btnBackToOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackToOrders.Name = "btnBackToOrders";
            this.btnBackToOrders.Size = new System.Drawing.Size(76, 20);
            this.btnBackToOrders.TabIndex = 7;
            this.btnBackToOrders.Text = "Back";
            this.btnBackToOrders.UseVisualStyleBackColor = true;
            this.btnBackToOrders.Click += new System.EventHandler(this.btnBackToOrders_Click);
            // 
            // comboBoxDiscounts
            // 
            this.comboBoxDiscounts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxDiscounts.FormattingEnabled = true;
            this.comboBoxDiscounts.Location = new System.Drawing.Point(78, 400);
            this.comboBoxDiscounts.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDiscounts.Name = "comboBoxDiscounts";
            this.comboBoxDiscounts.Size = new System.Drawing.Size(125, 23);
            this.comboBoxDiscounts.TabIndex = 8;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAddress.Location = new System.Drawing.Point(219, 400);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(104, 23);
            this.txtAddress.TabIndex = 9;
            // 
            // txtContact
            // 
            this.txtContact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtContact.Location = new System.Drawing.Point(340, 400);
            this.txtContact.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(104, 23);
            this.txtContact.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 384);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Discount:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 384);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Address:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 384);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Contact:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelDishConstructor
            // 
            this.panelDishConstructor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDishConstructor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDishConstructor.Controls.Add(this.btnHideDishConstructor);
            this.panelDishConstructor.Controls.Add(this.btnConfirm);
            this.panelDishConstructor.Controls.Add(this.label6);
            this.panelDishConstructor.Controls.Add(this.dgvSelectedIngredients);
            this.panelDishConstructor.Controls.Add(this.label7);
            this.panelDishConstructor.Controls.Add(this.dgvIngredients);
            this.panelDishConstructor.Location = new System.Drawing.Point(51, 23);
            this.panelDishConstructor.Margin = new System.Windows.Forms.Padding(2);
            this.panelDishConstructor.Name = "panelDishConstructor";
            this.panelDishConstructor.Size = new System.Drawing.Size(613, 402);
            this.panelDishConstructor.TabIndex = 14;
            this.panelDishConstructor.Visible = false;
            this.panelDishConstructor.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnHideDishConstructor
            // 
            this.btnHideDishConstructor.Location = new System.Drawing.Point(394, 375);
            this.btnHideDishConstructor.Margin = new System.Windows.Forms.Padding(2);
            this.btnHideDishConstructor.Name = "btnHideDishConstructor";
            this.btnHideDishConstructor.Size = new System.Drawing.Size(90, 20);
            this.btnHideDishConstructor.TabIndex = 16;
            this.btnHideDishConstructor.Text = "Back";
            this.btnHideDishConstructor.UseVisualStyleBackColor = true;
            this.btnHideDishConstructor.Click += new System.EventHandler(this.btnHideDishConstructor_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(501, 375);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 20);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(18, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Selected ingredients:";
            // 
            // dgvSelectedIngredients
            // 
            this.dgvSelectedIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvSelectedIngredients.Location = new System.Drawing.Point(18, 214);
            this.dgvSelectedIngredients.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSelectedIngredients.Name = "dgvSelectedIngredients";
            this.dgvSelectedIngredients.RowHeadersWidth = 72;
            this.dgvSelectedIngredients.RowTemplate.Height = 37;
            this.dgvSelectedIngredients.Size = new System.Drawing.Size(573, 150);
            this.dgvSelectedIngredients.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IngredientCategory";
            this.dataGridViewTextBoxColumn2.HeaderText = "CategoryId";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "IngredientName";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn5.HeaderText = "Price";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(18, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Select ingredients:";
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1});
            this.dgvIngredients.Location = new System.Drawing.Point(18, 32);
            this.dgvIngredients.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.RowHeadersWidth = 72;
            this.dgvIngredients.RowTemplate.Height = 37;
            this.dgvIngredients.Size = new System.Drawing.Size(573, 150);
            this.dgvIngredients.TabIndex = 10;
            this.dgvIngredients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredients_CellContentClick);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Add";
            this.dataGridViewButtonColumn1.MinimumWidth = 9;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Width = 150;
            // 
            // formCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 440);
            this.Controls.Add(this.panelDishConstructor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.comboBoxDiscounts);
            this.Controls.Add(this.btnBackToOrders);
            this.Controls.Add(this.btnConfirmOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCurrentOrder);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dgvMenu);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "formCreateOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formCreateOrder";
            this.Load += new System.EventHandler(this.formCreateOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentOrder)).EndInit();
            this.panelDishConstructor.ResumeLayout(false);
            this.panelDishConstructor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.BindingSource menuItemBindingSource;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.BindingSource menuItemBindingSource1;
        private System.Windows.Forms.DataGridView dgvCurrentOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirmOrder;
        private System.Windows.Forms.Button btnBackToOrders;
        private System.Windows.Forms.ComboBox comboBoxDiscounts;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelDishConstructor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvSelectedIngredients;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnHideDishConstructor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishCategoryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}
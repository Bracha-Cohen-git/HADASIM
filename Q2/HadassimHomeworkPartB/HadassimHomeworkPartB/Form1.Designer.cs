
namespace HadassimHomeworkPartB
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
            this.dgvPersons = new System.Windows.Forms.DataGridView();
            this.dgvRelationshipsBefore = new System.Windows.Forms.DataGridView();
            this.dgvRelationshipsAfter = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnCompleteSpouses = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationshipsBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationshipsAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersons
            // 
            this.dgvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersons.Location = new System.Drawing.Point(444, 75);
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.Size = new System.Drawing.Size(742, 233);
            this.dgvPersons.TabIndex = 0;
            // 
            // dgvRelationshipsBefore
            // 
            this.dgvRelationshipsBefore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelationshipsBefore.Location = new System.Drawing.Point(16, 58);
            this.dgvRelationshipsBefore.Name = "dgvRelationshipsBefore";
            this.dgvRelationshipsBefore.Size = new System.Drawing.Size(365, 291);
            this.dgvRelationshipsBefore.TabIndex = 1;
            // 
            // dgvRelationshipsAfter
            // 
            this.dgvRelationshipsAfter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelationshipsAfter.Location = new System.Drawing.Point(444, 406);
            this.dgvRelationshipsAfter.Name = "dgvRelationshipsAfter";
            this.dgvRelationshipsAfter.Size = new System.Drawing.Size(363, 254);
            this.dgvRelationshipsAfter.TabIndex = 2;
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnLoadData.Location = new System.Drawing.Point(1192, 146);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(152, 97);
            this.btnLoadData.TabIndex = 3;
            this.btnLoadData.Text = "Load the data";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnCompleteSpouses
            // 
            this.btnCompleteSpouses.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCompleteSpouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCompleteSpouses.Location = new System.Drawing.Point(869, 464);
            this.btnCompleteSpouses.Name = "btnCompleteSpouses";
            this.btnCompleteSpouses.Size = new System.Drawing.Size(213, 117);
            this.btnCompleteSpouses.TabIndex = 4;
            this.btnCompleteSpouses.Text = "Complete spouses and display updated table";
            this.btnCompleteSpouses.UseVisualStyleBackColor = false;
            this.btnCompleteSpouses.Click += new System.EventHandler(this.btnCompleteSpouses_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(703, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 47);
            this.label1.TabIndex = 5;
            this.label1.Text = "Persons";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(83, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 47);
            this.label2.TabIndex = 6;
            this.label2.Text = "Relationships";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(505, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 47);
            this.label3.TabIndex = 7;
            this.label3.Text = "Relationships - Updated";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 666);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCompleteSpouses);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dgvRelationshipsAfter);
            this.Controls.Add(this.dgvRelationshipsBefore);
            this.Controls.Add(this.dgvPersons);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationshipsBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationshipsAfter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersons;
        private System.Windows.Forms.DataGridView dgvRelationshipsBefore;
        private System.Windows.Forms.DataGridView dgvRelationshipsAfter;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnCompleteSpouses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


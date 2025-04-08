using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace HadassimHomeworkPartB
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=DESKTOP-IQUC79O;Database=FamilyTree;Trusted_Connection=True;";


        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData(string query, DataGridView dgv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("There is no data to display in the table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        //Loading the Persons and Relationships table before completion
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Delete data from the Relationships table to start over
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM Relationships;", conn);
                deleteCmd.ExecuteNonQuery();

                //Inserting values into the Relationships table from Persons
                SqlCommand cmdInsertRelationships = new SqlCommand(@"
                    -- Adding parents
                    INSERT INTO Relationships (Person_Id, Relative_Id, Connection_Type)
                    SELECT Person_Id, Father_Id, 'אב' FROM Persons WHERE Father_Id IS NOT NULL;
            
                    INSERT INTO Relationships (Person_Id, Relative_Id, Connection_Type)
                    SELECT Person_Id, Mother_Id, 'אם' FROM Persons WHERE Mother_Id IS NOT NULL;

                    -- Adding sibling relationships (by common parents)
                    INSERT INTO Relationships (Person_Id, Relative_Id, Connection_Type)
                    SELECT p1.Person_Id, p2.Person_Id, CASE WHEN p2.Gender = 'זכר' THEN 'אח' ELSE 'אחות' END
                    FROM Persons p1
                    JOIN Persons p2 ON p1.Father_Id = p2.Father_Id OR p1.Mother_Id = p2.Mother_Id
                    WHERE p1.Person_Id <> p2.Person_Id;

                    -- Adding children (by parents)
                    INSERT INTO Relationships (Person_Id, Relative_Id, Connection_Type)
                    SELECT Father_Id, Person_Id, CASE WHEN p.Gender = 'זכר' THEN 'בן' ELSE 'בת' END
                    FROM Persons p WHERE Father_Id IS NOT NULL;
            
                    INSERT INTO Relationships (Person_Id, Relative_Id, Connection_Type)
                    SELECT Mother_Id, Person_Id, CASE WHEN p.Gender = 'זכר' THEN 'בן' ELSE 'בת' END
                    FROM Persons p WHERE Mother_Id IS NOT NULL;

                    -- Adding spouses
                    INSERT INTO Relationships (Person_Id, Relative_Id, Connection_Type)
                    SELECT Person_Id, Spouse_Id, CASE WHEN Gender = 'זכר' THEN 'בת זוג' ELSE 'בן זוג' END
                    FROM Persons WHERE Spouse_Id IS NOT NULL;
                ", conn);
                        cmdInsertRelationships.ExecuteNonQuery();

            }

            LoadData("SELECT * FROM Persons", dgvPersons);
            LoadData("SELECT * FROM Relationships", dgvRelationshipsBefore);
        }

        // Exercise 2: Completing the missing spouse data
        private void btnCompleteSpouses_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Relationships (Person_Id, Relative_Id, Connection_Type)
                    SELECT p2.Person_Id, p1.Person_Id, 
                           CASE WHEN p2.Gender = 'זכר' THEN 'בת זוג' ELSE 'בן זוג' END
                    FROM Persons p1
                    JOIN Persons p2 ON p1.Spouse_Id = p2.Person_Id
                    LEFT JOIN Relationships r ON p2.Person_Id = r.Person_Id AND p1.Person_Id = r.Relative_Id
                    WHERE p1.Spouse_Id IS NOT NULL  
                      AND r.Person_Id IS NULL;
                ", conn);
                cmd.ExecuteNonQuery();
            }

            // Viewing Relationships after completion
            LoadData("SELECT * FROM Relationships", dgvRelationshipsAfter);
        }

        private void btnLoadData_Click_1(object sender, EventArgs e)
        {
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

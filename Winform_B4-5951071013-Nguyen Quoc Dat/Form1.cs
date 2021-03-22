using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Winform_B4_5951071013_Nguyen_Quoc_Dat
{
    public partial class Form1 : Form
    {
         
        public Form1()
        {
            InitializeComponent();
            GetStudentsRecord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=DAT-NGUYEN;Initial Catalog=NguyenQuocDat_5951071013;Integrated Security=True");
        private void GetStudentsRecord()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from StudentTb", con);
            DataTable dt = new DataTable();
            
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            dgv.DataSource = dt;
            con.Close();
        }
        private bool IsValidData()
        {
            if (txbHName.Text == String.Empty
               || txbNName.Text == String.Empty
               || String.IsNullOrEmpty(txbPhone.Text)
               || String.IsNullOrEmpty(txbRoll.Text))
            {
                MessageBox.Show("có chỗ chưa nhập dữ liệu !!! ",
                                "lỗi dữ liệu ", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                SqlCommand cmd = new SqlCommand("select into StudentIb values " +

                    "(@Name,@FatherName,@RollNumber,@Address,@Mobile", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txbHName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txbNName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txbRoll.Text);
                cmd.Parameters.AddWithValue("@Address", txbAddress.Text);
                cmd.Parameters.AddWithValue("@Moblie", txbPhone.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
            }
        }
        public int StudentID;
        private void StudentRecordData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(StudentRecordData.SelectedRows[0].Cells[0].Value);
            txbHName.Text = StudentRecordData.SelectedRows[0].Cells[1].Value.ToString();
            txbNName.Text = StudentRecordData.SelectedRows[0].Cells[2].Value.ToString();
            txbRoll.Text = StudentRecordData.SelectedRows[0].Cells[3].Value.ToString();
            txbAddress.Text = StudentRecordData.SelectedRows[0].Cells[4].Value.ToString();
            txbPhone.Text = StudentRecordData.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("update StudentTb set " +
                    "Name =@Name ,FatherName = @FatherName," +
                    "RollNumber = @RollNumber, Address=@Address ," +
                    "Moblie = @Mobile where StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txbHName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txbNName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txbRoll.Text);
                cmd.Parameters.AddWithValue("@Address", txbAddress.Text);
                cmd.Parameters.AddWithValue("@Moblie", txbPhone.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();

            }
            else
            {
                MessageBox.Show("Cập Nhật bị lỗi !!! ", "lỗi !",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("delete from StudentId where StudentId= @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();

            }
            else
            {
                MessageBox.Show("cập nhật bị lỗi !!! ", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

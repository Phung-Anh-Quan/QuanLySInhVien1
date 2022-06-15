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
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace BaiCuoiKi
{
    public partial class DangKy : Form
    {
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private SqlDataReader reader;
        private string sqlstr;
        public bool CheckAcount (string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool CheckEmail (string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9]{3,20}@gmail.com(.vn|)$");
        }
        public DangKy()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        { 
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["kn"].ConnectionString.ToString();
            string tk = txtDn.Text;
            string mk = txtmk.Text;
            string xn = txtxn.Text;
            string em = txtem.Text;
            if (!CheckAcount(tk)) { MessageBox.Show("Vui Lòng Nhập Tên Tài Khoản Dài 6->24 Ký Tự, Với Các Ký Tự Số Và Chữ, Chữ Hoa Và Chữ Thường");return; }
            if(!CheckAcount(mk)) { MessageBox.Show("Vui Lòng Nhập Tên Mật Khẩu Dài 6->24 Ký Tự, Với Các Ký Tự Số Và Chữ, Chữ Hoa Và Chữ Thường"); return; }
            if(xn != mk) { MessageBox.Show("Vui Lòng xác nhận mật khẩu chính xác!");return; }
            if (!CheckEmail(em)) { MessageBox.Show("Vui Lòng Nhập Lại Định Dạng Email");return; }
            try
            {
                string sql = ("Insert into DangNhap values('"+tk+"','"+mk+"','"+em+"')");
                command = new SqlCommand(sql, conn);
                reader = command.ExecuteReader();
                if (reader.Read() == true)
                {
                    MessageBox.Show("Đăng ký Thành Công", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DangNhap dn = new DangNhap();
                    dn.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng Ký Thất Bại");
                }

            }
            catch
            {
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

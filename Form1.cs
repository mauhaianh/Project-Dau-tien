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

namespace KetNoiCSDL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoaiHang();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoaiHang()
        {
            //Ham hien thi bang LoaiHang trong csdl len dataGridView
            dgv.DataSource = Class1.Query("select * from LoaiHang");
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Hàm hiển thị ô dữ liệu đang chọn
            txtma.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtten.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            //Hàm thêm dữ liệu vào bảng LoaiHang
            if (txtma.Text == "" || txtten.Text == "") return;
            try
            {
                Class1.Execute("insert LoaiHang values('" + txtma.Text + "', N'" + txtten.Text + "')");
            }
            catch (Exception)
            {
                return;
            }
            LoaiHang();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            //Hàm xóa dữ liệu khỏi bảng LoaiHang
            if(dgv.CurrentRow == null) return; // nếu bảng dữ liệu trống thì không làm gì cả
            Class1.Execute("delete LoaiHang where MaLoaiHang = '" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
            LoaiHang();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            //Hàm sửa dữ liệu đang chọn bằng dữ liệu mới
            if (txtma.Text == "" || txtten.Text == "") return;
            if (dgv.CurrentRow == null) return; // nếu bảng dữ liệu trống thì không làm gì cả
            Class1.Execute("update LoaiHang set MaLoaiHang = '" + txtma.Text + "'," + " TenLoaiHang = N'" + txtten.Text + "' " + " where MaLoaiHang = '" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
            LoaiHang();
        }
    }
}

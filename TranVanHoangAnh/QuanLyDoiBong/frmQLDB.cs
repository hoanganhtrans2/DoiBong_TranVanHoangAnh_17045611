using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BUS;


namespace QuanLyDoiBong
{
    public partial class frmQLDoiBong : Form
    {
        public frmQLDoiBong()
        {
            InitializeComponent();
        }
        CauThuBUS cThu;
        DoiBongBUS dbBus;
        private void frmQLDoiBong_Load(object sender, EventArgs e)
        {
            cThu = new CauThuBUS();
            dbBus = new DoiBongBUS();
            List<eCauThu> lsCT = cThu.getAllCauThu();
            foreach (eCauThu item in lsCT)
            {
                lvwDSCauThu.Items.Add(CreateItem(item));
            }
            List<eDoiBong> lsDB = new List<eDoiBong>();
            lsDB = dbBus.getAllDoiBong();
            eDoiBong doiBong = new eDoiBong();
            doiBong.TenDoiBong = "Get all";
            doiBong.MaDoiBong = "Get all";
            lsDB.Add(doiBong);
            cboDoiBong.DataSource = lsDB;
            cboDoiBong.DisplayMember = "TenDoiBong";
            cboDoiBong.ValueMember = "MaDoiBong";
            cboDoiBong.SelectedIndex = 2;
           
        }
        public ListViewItem CreateItem(eCauThu ct)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(ct.MaCauThu);
            item.SubItems.Add(ct.TenCauThu);
            item.SubItems.Add(ct.Email);
            item.SubItems.Add(ct.SoDienThoai);
            item.SubItems.Add(ct.MaDoiBong);
            item.Tag = ct;
            return item;
        }
        public void UpDateListView(eCauThu ct)
        {
            txtEmail.Text = ct.Email;
            txtMaCauThu.Text = ct.MaCauThu;
            txtMaDoiBong.Text = ct.MaDoiBong;
            txtSDT.Text = ct.SoDienThoai;
            txtTenCauThu.Text = ct.TenCauThu;
        }
        int vt = 0;
        private void lvwDSCauThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDSCauThu.SelectedItems.Count > 0)
            {
                vt = lvwDSCauThu.SelectedIndices[0];
                eCauThu ct = (eCauThu)lvwDSCauThu.SelectedItems[0].Tag;
                UpDateListView(ct);
            }            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            eCauThu nct = new eCauThu();
            nct.MaCauThu = txtMaCauThu.Text;
            nct.MaDoiBong = txtMaDoiBong.Text;
            nct.SoDienThoai = txtSDT.Text;
            nct.TenCauThu = txtTenCauThu.Text;
            nct.Email = txtEmail.Text;
            if (cThu.themThanhVien(nct) == 1)
            {
                MessageBox.Show("thêm thành công");
                List<eCauThu> lsCT = cThu.getAllCauThu();
                foreach (eCauThu item in lsCT)
                {
                    lvwDSCauThu.Items.Add(CreateItem(item));
                }

            }
            else
            {
                MessageBox.Show("thêm thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCauThu.Text != null)
            {
                if (cThu.XoaCauThu(txtMaCauThu.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    List<eCauThu> lsCT = cThu.getAllCauThu();
                    foreach (eCauThu item in lsCT)
                    {
                        lvwDSCauThu.Items.Add(CreateItem(item));
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            eCauThu nct = new eCauThu();
            nct.MaCauThu = txtMaCauThu.Text;
            nct.MaDoiBong = txtMaDoiBong.Text;
            nct.SoDienThoai = txtSDT.Text;
            nct.TenCauThu = txtTenCauThu.Text;
            nct.Email = txtEmail.Text;
            if (cThu.suaThongTinCauThu(nct))
            {
                MessageBox.Show("Sửa thành công");
                List<eCauThu> lsCT = cThu.getAllCauThu();
                foreach (eCauThu item in lsCT)
                {
                    lvwDSCauThu.Items.Add(CreateItem(item));
                }
            }
            else
            {
                MessageBox.Show("sửa thất bại");
            }

        }

        private void cboDoiBong_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboDoiBong_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cboDoiBong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //  eDoiBong temp = (eDoiBong)cboDoiBong.SelectedValue;
            lvwDSCauThu.Items.Clear();
            List<eCauThu> lsCT = new List<eCauThu>();
            if (cboDoiBong.SelectedValue.ToString()== "Get all")
            {
                lsCT = cThu.getAllCauThu();
            }
            else
            {
                lsCT = cThu.getAlCauThuTheoMaDoiBong(cboDoiBong.SelectedValue.ToString());
            }
            foreach (eCauThu item in lsCT)
            {
                lvwDSCauThu.Items.Add(CreateItem(item));
            }
        }
    }
}

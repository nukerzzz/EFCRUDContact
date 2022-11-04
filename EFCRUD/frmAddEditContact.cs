using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCRUD
{
    public partial class frmAddEditContact : Form
    {
        ContactEntities db;
        public frmAddEditContact(Contact obj)
        {
            InitializeComponent();
            db = new ContactEntities();
            if (obj == null)
            {
                contactBindingSource.DataSource = new Contact();
                db.Contacts.Add(contactBindingSource.Current as Contact);
            }
            else { 
                contactBindingSource.DataSource = obj;
                db.Contacts.Attach(contactBindingSource.Current as Contact);
            }
        }

        private void frmAddEditContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try {
                if (DialogResult == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(txtContactName.Text) ||
                        string.IsNullOrEmpty(txtAddress.Text) ||
                        string.IsNullOrEmpty(txtId.Text) ||
                        string.IsNullOrEmpty(txtGmail.Text) ||
                        string.IsNullOrEmpty(txtPhoneNumber.Text))
                    {
                        MessageBox.Show("Làm ơn nhập dữ liệu cho em", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtContactName.Focus();

                        return;
                    }
                    db.SaveChanges();

                }
                MessageBox.Show("Nhập dữ liệu thành công, Load lại để xem dữ liệu");
            }
            catch(Exception ex) {

            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}

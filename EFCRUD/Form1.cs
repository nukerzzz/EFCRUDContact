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
    public partial class Form1 : Form
    {
        ContactEntities db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new ContactEntities();
            contactBindingSource.DataSource = db.Contacts.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(null);
            frm.Show();
            if (DialogResult == DialogResult.OK)
                    contactBindingSource.DataSource = db.Contacts.ToList();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (contactBindingSource.Current == null)
                return;
            frmAddEditContact frm = new frmAddEditContact(contactBindingSource.Current as Contact);
            frm.Show();
            if (DialogResult == DialogResult.OK)
                    contactBindingSource.DataSource = db.Contacts.ToList();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (contactBindingSource.Current != null)
            {
                if(MessageBox.Show("Xoá thành công", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Contacts.Remove(contactBindingSource.Current as Contact);
                    contactBindingSource.RemoveCurrent();
                    db.SaveChanges();
                }
            }
                
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            db = new ContactEntities();
            contactBindingSource.DataSource = db.Contacts.ToList();
        }
    }
}

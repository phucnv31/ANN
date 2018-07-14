using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pinball;

namespace pinball
{
    public partial class CustomMsgBox : Form
    {
        public CustomMsgBox()
        {
            InitializeComponent();
        }
        static CustomMsgBox MsgBox; static DialogResult result = DialogResult.No;
        public static DialogResult Show(string Text, string Caption,string btnOk, string btnCancel)
        {
            MsgBox = new CustomMsgBox();
            MsgBox.label1.Text = Text;
            MsgBox.button1.Text = btnOk;
            MsgBox.button2.Text = btnCancel;
            MsgBox.Text = Caption;
            MsgBox.ShowDialog();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes; if (this.textBoxcaothu.Text.Trim().Equals("") || this.textBoxcaothu.Text.Length > 25) { MessageBox.Show("Tên không hợp lệ,mời nhập lại"); }
            else { Form1.caothu= this.textBoxcaothu.Text  ; MsgBox.Close(); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;MsgBox.Close();
        }
    }
}

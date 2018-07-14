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
    public partial class Hướng_dẫn_sử_dụng : Form
    {
        public Hướng_dẫn_sử_dụng()
        {
            
            InitializeComponent();
        }

        private void Hướng_dẫn_sử_dụng_Load(object sender, EventArgs e)
        {
            this.labelhd1.Text = "-- Nếu bóng rơi xuống đất bạn sẽ thua\n-- Ăn được 5 food thì super food sẽ xuất hiện\n-- 1 food=10 điểm +1 viên đạn, superfood=30 điểm + 2 viên đạn\n-- Bấm B để bắn đạn,đạn bay hết màn hình sẽ cooldown\n-- Bấm S để tạm dừng và T để tiếp tục";
        }
    }
}

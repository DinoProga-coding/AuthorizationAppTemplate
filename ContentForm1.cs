using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlApp
{
    public partial class ContentForm1 : Form
    {
        public ContentForm1()
        {
            InitializeComponent();
            panelWinter.Visible = false;
            Info1.Text = "1 совет. Во время зимы собирайте \nлёд и складывайте " +
                "его в \nхолодильник. Летом он вам \nпонадобится.";
            Info2.Text = "2 совет. Есть такая штука, как \n" +
                "трость. Она увеличивает скорость\nпередвижения.\n" +
                "Для трости нам нужен клык Макбивня.\n"+
               "Он выпадает с Макбивня, живущего \nв иглу.";
        }

        private void closePanel_Click(object sender, EventArgs e)
        {
            panelWinter.Visible = false;
        }

        private void ActivePanelWinter_Click(object sender, EventArgs e)
        {
            panelWinter.Visible = true;
        }
    }
}

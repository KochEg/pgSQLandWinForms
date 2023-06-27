using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgSQLandWinForms
{
    public partial class AddPersonBase : Form
    {
        public AddPersonBase()
        {
            InitializeComponent();
        }

        internal DialogResult dialogResult;
        private void AddButton_Click(object sender, EventArgs e)
        {
            dialogResult = MessageBox.Show("Добавить в список?", "Подтвердите операцию", MessageBoxButtons.YesNo);
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddPersonBase_Load(object sender, EventArgs e)
        {

        }
    }
}

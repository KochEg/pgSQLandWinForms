using Npgsql;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace pgSQLandWinForms
{
    public partial class BasePerson : Form
    {
        Repository BD = new Repository();
        BindingList<Person> PersonList { get; set; }
        public BasePerson()
        {
            InitializeComponent();
        }

        private void BasePerson_Load(object sender, EventArgs e)
        {
            PersonList = new BindingList<Person>();
            dataGridView1.DataSource= PersonList;
            dataGridView1.Columns["Имя"].Width= 117;
            dataGridView1.Columns["Фамилия"].Width = 117;
            dataGridView1.Columns["Отчество"].Width = 117;
            dataGridView1.Columns["Возраст"].Width = 117;

            LoadData();
        }

        private void LoadData() 
        {
            PersonList.Clear();
            NpgsqlDataReader read = BD.LoadData();
            if(read != null) 
            {
                while(read.Read()) 
                {
                    PersonList.Add(new Person((int)read["id"],
                                              (string)read["name"],
                                              (string)read["surname"],
                                              (string)read["patronymic"],
                                              (int)read["age"]));
                }
                read.Close();
            }
            BD.CloseBD();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddPersonBase addPerson = new AddPersonBase();
            addPerson.ShowDialog();
            if(addPerson.dialogResult == DialogResult.Yes) 
            {
                if(addPerson.textBox1.Text !="" && addPerson.textBox2.Text != "" && addPerson.textBox3.Text != "")
                {
                    Person obj = new Person(addPerson.textBox1.Text, addPerson.textBox2.Text, addPerson.textBox3.Text, int.Parse(addPerson.numericUpDown1.Value.ToString()));
                    BD.InsertData(obj);
                    LoadData();
                }
                else
                    MessageBox.Show("Не все заполнены поля", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            addPerson.textBox1.Text = "";
            addPerson.textBox2.Text = "";
            addPerson.textBox3.Text = "";
            addPerson.numericUpDown1.Value = 0;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
                int idlist = dataGridView1.CurrentCell.RowIndex;
                BD.DeleteData(id);
                PersonList.RemoveAt(idlist);
            }
            else
            {
                MessageBox.Show("Запись не выбрана", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            PersonList.Clear();
            NpgsqlDataReader read = null;
            if (checkBoxFilter.Checked)
            {
                if (textBox1.Text != "" && comboBox1.Text != "")
                {
                    read = BD.FilterData(comboBox1.Text, textBox1.Text);
                }
                else
                {
                    read = BD.LoadData();
                }
            }
            else
            {
                read = BD.LoadData();
            }
            if (read != null)
            {
                while (read.Read())
                {
                    PersonList.Add(new Person(
                        (int)read["id"],
                        (string)read["name"],
                        (string)read["surname"],
                        (string)read["patronymic"],
                        (int)read["age"]
                        ));
                }
                read.Close();
            }
            BD.CloseBD();

            textBox1.Text = "";
            comboBox1.Text = "";
        }
    }
}

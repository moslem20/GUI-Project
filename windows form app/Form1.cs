using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matalaGUI4
{
    public partial class Form : System.Windows.Forms.Form
    {
        QueueFiles queue;
        public Form()
        {
            queue = new QueueFiles();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLabel.Visible = true;
            Startbtn.Visible = true;
        }

        private void LoadLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddFile_Click(object sender, EventArgs e)
        {
            LoadLabel.Visible = false;
            Startbtn.Visible = false;
            AddFileBtn.Visible = true;
            CheckBigBtn.Visible = true;
            SearchTypeBtn.Visible = true;
            PrintBtn.Visible = true;
            RemoveBtn.Visible = true;
        }
        private void AddFileBtn_Click(object sender, EventArgs e)
        {
            FileNameLabel.Visible = true;
            FnameBox.Visible = true;
            DataLabel.Visible = true;
            FdataBox.Visible = true;
            TypeLabel.Visible = true;
            TypeComo.Visible = true;
            AddBtn.Visible = true;
            richTextBox1.Visible = false;

            FnameBox.Text = "";
            FdataBox.Text = "";
            TypeComo.SelectedIndex = -1;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(FnameBox.Text == "" || FdataBox.Text == "" || TypeComo.SelectedIndex == -1) 
            {
                MessageBox.Show("Not all information provided");
                return;
            }
            DataFile file = new DataFile(FnameBox.Text,FdataBox.Text ,(FileTypeExtension)TypeComo.SelectedIndex);
            queue.Enqueue(file);
        }
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            DataFile temp = queue.Dequeue();
            if (temp != null)
            {
                MessageBox.Show("File number " + temp.getFileNum() + " has been removed");
            }
            FnameBox.Text = "";
            FdataBox.Text = "";
            TypeComo.SelectedIndex = -1;
            richTextBox1.Visible = false;
        }

        private void CheckBigBtn_Click(object sender, EventArgs e)
        {
            DataFile temp = queue.BigFile();
            if (temp != null)
            {
                richTextBox1.Visible = false;
                RichBigFile.Visible = true;
                richTextBox1.Visible = false;
                PickTypeLbl.Visible = false;
                PickComo.Visible = false;
                SearchBtn.Visible = false;
                FileNameLabel.Visible = false;
                FnameBox.Visible = false;
                DataLabel.Visible = false;
                FdataBox.Visible = false;
                TypeLabel.Visible = false;
                TypeComo.Visible = false;
                AddBtn.Visible = false;


                RichBigFile.Text = "The Big file is:\n" + temp.PrintFile();
            }
            else
            {
                MessageBox.Show("There is no Files created");
                AddFileBtn_Click(sender, e);
            }
        }

        private void SearchTypeBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            PickTypeLbl.Visible = true;
            PickComo.Visible = true;
            SearchBtn.Visible = true;
            FileNameLabel.Visible = false;
            FnameBox.Visible = false;
            DataLabel.Visible = false;
            FdataBox.Visible = false;
            TypeLabel.Visible = false;
            TypeComo.Visible = false;
            AddBtn.Visible = false;
        }
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            PickTypeLbl.Visible = false;
            PickComo.Visible = false;
            SearchBtn.Visible = false;

            if (FnameBox.Text == "" || FdataBox.Text == "")
            {
                AddFileBtn_Click(sender, e);
                MessageBox.Show("There are no Files created");
            }

            else if (PickComo.SelectedIndex == -1)
                MessageBox.Show("Pick a Type!");
            else
            {
                ByTypeBox.Visible = true;
                DataFile[] res = queue.SearchFileByType((FileTypeExtension)PickComo.SelectedIndex);
                for (int i = 0; i < queue.Length; i++)
                {
                    if (res[i].GetType() == (FileTypeExtension)PickComo.SelectedIndex)
                        ByTypeBox.Text = res[i].PrintFile();
                    MessageBox.Show("There is no files with this Type");
                }
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            string result = queue.PrintQueue();
            if (result != null)
            {
                richTextBox1.Text = result;
                richTextBox1.Visible = true;

                FileNameLabel.Visible = false;
                FnameBox.Visible = false;
                DataLabel.Visible = false;
                FdataBox.Visible = false;
                TypeLabel.Visible = false;
                TypeComo.Visible = false;
                AddBtn.Visible = false;
            }
            else
                AddFileBtn_Click(sender, e);
        }


    }
}

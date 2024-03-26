using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_20_лаба
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        const int Size = 15;
        int[] array = new int[Size];
        int rowNum = 4;
        int colNum = 15;
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateRandomArray(int[] array)
        {
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(10, 100);
                FixUp(i);
            }
        }

        private void Clear_Tab()
        {
            DataGridView[] dataGridViews = { dataGridView1, dataGridView2, dataGridView3 }; 
            foreach (DataGridView dataGridView in dataGridViews)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = "";
                    }
                }
            }
            array = new int[Size];
        }

        private void showData(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = array[i];
            }

            int currentColumn = colNum / 2;
            dataGridView2.Rows[0].Cells[currentColumn].Value = array[0];
            int index = 1;
            for (int i = 1; i < rowNum;i++ ) {
                int indexColumn = currentColumn / 2;
                while(indexColumn < colNum)
                {
                    dataGridView2.Rows[i].Cells[indexColumn].Value = array[index++];
                    indexColumn += currentColumn+1;
                }
                currentColumn /= 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRandomArray(array);
            showData(array);
        }

        private void FixUp(int k)
        {
            while (k > 0 && array[(k-1)/2] < array[k])
            {
                (array[k], array[(k-1) / 2]) = (array[(k-1) / 2], array[k]);
                k = (k-1)/ 2;
            }
        }

        private void FixDown(int k)
        {
            while (k > 1 && array[k / 2] < array[k])
            { 
                (array[k], array[k/2]) = (array[k/2], array[k]);
                k /= 2;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 39;
                dataGridView3.Columns[i].Width = 39;
            }

            dataGridView2.RowCount = rowNum;
            dataGridView2.ColumnCount = colNum;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for(int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    dataGridView2.Columns[j].Width = 39;
                }                
            }
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();

        }

        private void clearQueue(object sender, EventArgs e)
        {
            Clear_Tab();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

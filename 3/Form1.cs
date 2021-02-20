using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_3;
using LibMas;
using Lib_5;

namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2. Дана матрица размера M × N и целое число K (1 ≤ K ≤ N). Найти сумму и произведение элементов K - го столбца данной матрицы. .");
        }
        // выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // открыть
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibMas.WorkingWithArray.OpenFile(sourceTable);
        }
        // сохранить
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibMas.WorkingWithArray.SaveFile(sourceTable);
        }
        // рассчитать
        private void расчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Class1.Go(sourceTable, sumTable);
                Class2.Go(sourceTable, prozTable);
            
        }
        // заполнить
        private void заполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibMas.WorkingWithArray.Fill(sourceTable, Convert.ToInt32(nudMin.Value), Convert.ToInt32(nudMax.Value));
        }
        // очистить
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibMas.WorkingWithArray.Clear(sourceTable);
        }
        // при загрузке формы задаем количество столбцов и строк таблички
        private void Form1_Shown(object sender, EventArgs e)
        {
            sourceTable.ColumnCount = 5;
            sourceTable.RowCount = 5;
            sumTable.RowCount = 5;
            sumTable.ColumnCount = 1;
            prozTable.RowCount = 5;
            prozTable.ColumnCount = 1;
        }
        // при изменении соответствующего nud-а меняем количество столбцов
        private void nudColumns_ValueChanged(object sender, EventArgs e)
        {
            sourceTable.ColumnCount = Convert.ToInt32(nudColumns.Value);
        }
        // при изменении соответствующего nud-а меняем количество строк
        private void nudRows_ValueChanged(object sender, EventArgs e)
        {
            sourceTable.RowCount = Convert.ToInt32(nudRows.Value);
            sumTable.RowCount = Convert.ToInt32(nudRows.Value);
            prozTable.RowCount = Convert.ToInt32(nudRows.Value);
        }
        string dop;
        private void sourceTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (sourceTable.CurrentCell.Value != null) dop = sourceTable.CurrentCell.Value.ToString();

        }

        private void sourceTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt32(sourceTable.CurrentCell.Value);
            }
            catch
            {
                // выводим подсказку 
                MessageBox.Show("Введите целое число");
                // возвращаем ячейке предыдущее значение (до измемения)
                sourceTable.CurrentCell.Value = dop;
            }
        }
    }
}

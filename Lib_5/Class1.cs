using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Lib_5
{
    public class Class2
    {
        public static void Go(DataGridView sourceTable, DataGridView prozTable)
        {
            prozTable.RowCount = sourceTable.RowCount;
            for (int j = 0; j < sourceTable.RowCount; j++)
            {
                // в начале внутреннего цикла сбрасываем сумму
                int proz = 1;
                for (int i = 0; i < sourceTable.ColumnCount; i++)
                {
                    // проверка конвертации
                    if (Int32.TryParse(Convert.ToString(sourceTable[i, j].Value), out int dop))
                    {
                        proz *= dop;

                    }
                    else
                    {
                        MessageBox.Show("Ошибка конвертации!");
                        return;
                    }
                }

                prozTable[0, j].Value = proz;
            }
        }
    }
}

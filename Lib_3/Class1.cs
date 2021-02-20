using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_3
{
    public class Class1
    {
        public static void Go(DataGridView sourceTable, DataGridView sumTable)
        {
            
                

                sumTable.RowCount = sourceTable.RowCount;
                for (int j = 0; j < sourceTable.RowCount; j++)
                {
                    // в начале внутреннего цикла сбрасываем сумму
                    int sum = 0;
                    for (int i = 0; i < sourceTable.ColumnCount; i++)
                    {
                        // проверка конвертации
                        if (Int32.TryParse(Convert.ToString(sourceTable[i, j].Value), out int dop))
                        {
                            sum += dop;

                        }
                        else
                        {
                            MessageBox.Show("Ошибка конвертации!");
                            return;
                        }
                    }

                    sumTable[0, j].Value = sum;
                }
            
        }
    }
}

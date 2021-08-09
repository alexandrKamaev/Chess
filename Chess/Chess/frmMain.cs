using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            label1.Text = "-двойной клик по ячейке - отобразит\n    движение ферзя из точки\n-нажатие на кнопку - отобразит расположение ферзей\n   (включая выбранную точку)";
            // просто добавляем грид
            for (int i = 1; i <=8; i++)
            {
                DataGridViewColumn dc = new DataGridViewColumn() { HeaderText = Extensions.dict[i], Width = 30 };
                dc.CellTemplate = new DataGridViewTextBoxCell();
                dc.Name = i.ToString();
                dgvChess.Columns.Add(dc);
            }

           
            for (int i = 1; i <= 8; i++)
            {
                DataGridViewRowHeaderCell header = new DataGridViewRowHeaderCell() { Value = i.ToString() };
                header.ValueType = typeof(int);
                dgvChess.Rows.Add(new DataGridViewRow() { HeaderCell = header });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearColor();
            Chess chess = new Chess() { curPoint = new Point(3, 6) };
            chess.GetEightFigure(SetColorToDataGridView,Color.BlueViolet, new Point(dgvChess.CurrentCell.RowIndex+1, dgvChess.CurrentCell.ColumnIndex+1), 1);
        }

        private void dgvChess_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            //очищаем цвета
            ClearColor();
            new Chess() { curPoint = new Point(e.ColumnIndex + 1, e.RowIndex + 1) }.WriteMovePoint(SetColorToDataGridView, Color.LightYellow);

        }

        private void ClearColor()
        {
            foreach (DataGridViewColumn c in dgvChess.Columns)
                foreach (DataGridViewRow r in dgvChess.Rows)
                    r.Cells[c.Name].Style.BackColor = Color.White;
        }
        private void SetColorToDataGridView(Point point, Color color)
        {
            dgvChess.Rows[point.Y - 1].Cells[point.X - 1].Style.BackColor = color;
        }
    }
}

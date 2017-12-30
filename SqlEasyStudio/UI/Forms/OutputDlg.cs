using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace SqlEasyStudio.UI.Forms
{
    public partial class OutputDlg : Form
    {
        private SplitContainer _openSplitter;
        private List<DataGridView> _grids = new List<DataGridView>();


        public OutputDlg()
        {
            InitializeComponent();
            _textBox.Font = new System.Drawing.Font("Courier", 8);
            this.SizeChanged += new EventHandler(OutputDlg_SizeChanged);
        }

        public void AddText(string text, Color color)
        {
            _textBox.AppendText(text);

            int start = _textBox.Text.Length - text.Length;
            if (start < 0)
                start = 0;
            _textBox.SelectionStart = start;
            _textBox.SelectionLength = text.Length;
            _textBox.SelectionColor = color;
            _textBox.SelectionLength = 0;
        }

        public void AddMessage(string text)
        {
            AddText(text, Color.Black);
        }

        public void AddError(string text)
        {
            AddText(text, Color.Red);
        }

        public void ClearMessages()
        {
            _textBox.Clear();
        }

        void OutputDlg_SizeChanged(object sender, EventArgs e)
        {
            RefreshLayout();
        }

        public void AddDataGrid(DataTable source)
        {
            SplitContainer splitter = new SplitContainer();
            splitter.Orientation = Orientation.Horizontal;
            splitter.Dock = DockStyle.Top;
            DataGridView grid = CreateDataGrid(source); 
            _grids.Add(grid);
            splitter.Panel1.Controls.Add(grid);
            splitter.Panel2Collapsed = true;            
            splitter.Height = 200;
            


            if (_openSplitter == null)
            {  
                _panel.Controls.Add(splitter); 
                _openSplitter = splitter; 
            }
            else
            {
                _openSplitter.Panel2Collapsed = false;
                _openSplitter.Panel2.Controls.Add(splitter);            
                _openSplitter = splitter;
            }

        }

        public void DoInitialLayout()
        {
            if (_grids.Count == 0)
                return;

            if (_grids.Count == 1)
                _openSplitter.Dock = DockStyle.Fill;
            else
            {
                int gridHeight = _panel.Height / _grids.Count;
                if (gridHeight < 200)
                    gridHeight = 200;

                DoRecurentLayout(_panel.Controls[0] as SplitContainer, _grids.Count * gridHeight, gridHeight);
            }
        }

        public void RefreshLayout()
        {
            if(_grids.Count > 1)
            {
                SplitContainer sp0 = _panel.Controls[0] as SplitContainer;
                if (_panel.Height > sp0.Height)
                {
                    int spd0 = sp0.SplitterDistance;
                    sp0.Height = _panel.Height;
                    sp0.SplitterDistance = spd0;
                    _openSplitter.Dock = DockStyle.Fill;
                }
            }
        }

        private void DoRecurentLayout(SplitContainer sc, int availableHeight, int gridHeight)
        {
            sc.Height = availableHeight;
            sc.SplitterDistance = gridHeight;
            if (sc.Panel2.Controls.Count > 0)
                DoRecurentLayout(sc.Panel2.Controls[0] as SplitContainer, availableHeight - gridHeight, gridHeight);
        }

        private DataGridView CreateDataGrid(DataTable source)
        {
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.DataSource = source;
            grid.ReadOnly = true;
            grid.ShowEditingIcon = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.RowTemplate.Height = 19;
            grid.ColumnHeadersHeight = 19;
            grid.GridColor = Color.FromArgb(240, 240, 240);
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //grid.RowHeadersVisible = false;
            grid.ShowCellToolTips = false;
            //grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            grid.DefaultCellStyle.NullValue = "NULL";
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 207, 241);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(grid_DataBindingComplete);
            //grid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(grid_RowPostPaint);
            //grid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(grid_RowPrePaint);
            grid.CellFormatting += new DataGridViewCellFormattingEventHandler(grid_CellFormatting);            
            

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered", 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                grid,
                new object[] { true });
            
            return grid;
        }

        void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;                        

            if (e.Value == DBNull.Value)
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 225);

            grid.Rows[e.RowIndex].HeaderCell.Value = e.RowIndex.ToString();
        }

        void grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);

            e.PaintHeader(DataGridViewPaintParts.Background
                | DataGridViewPaintParts.Border
                | DataGridViewPaintParts.Focus
                | DataGridViewPaintParts.SelectionBackground
                | DataGridViewPaintParts.ContentForeground);

            e.Handled = true;
        }

        void grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView grid = sender as DataGridView;

            e.Graphics.DrawString(
                e.RowIndex.ToString(),
                grid.Font,
                new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor),
                new PointF((float)e.RowBounds.Left + 2, (float)e.RowBounds.Top + 4));
        }


        void grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            
        }

        public void ClearResults()
        {
            _panel.Controls.Clear();
            _openSplitter = null;
            _grids.Clear();
        }

        public void Clear()
        {
            ClearResults();
            ClearMessages();
        }

        public void SetActiveTab(int tab)
        {
            _tab.SelectTab(tab);
        }
        
    }
}

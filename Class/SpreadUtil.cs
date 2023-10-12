using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Data.Common;

namespace KHK_portfolio
{
    public enum CellType
    {
        BARCODE,
        BUTTON,
        CHECKBOX,
        COLORPICKER,
        COMBOBOX,
        CURRENCY,
        DATETIME,
        EMPTY,
        GENERAL,
        HYPERLINK,
        IMAGE,
        LISTBOX,
        MASK,
        MULTICOLUMNCOMBOBOX,
        MULTIOPTION,
        NUMBER,
        PERCENT,
        TEXT
    }

    public enum DateFormatType
    {
        LONG,
        LONGWITHTIME,
        SHORT,
        SHORTWITHTIME,
        TIME,
    }

    public class SpreadUtil
    {
        /// <summary>
        /// 날짜 포맷
        /// </summary>
        public static readonly string DEFAULT_DATE_FORMAT = "YYYY-MM-DD HH:mm:ss";
        public static readonly string DEFAULT_TIME_FORMAT = "HH:mm:ss";
        public static readonly string DEFAULT_DATETIME_FORMAT = "YYYY-MM-DD HH:mm:ss";

        /// <summary>
        /// GridBackColor
        /// 그리드 배경색 설정
        /// </summary>
        private static class GridBackColor
        {
            public static readonly Color GrayArea = Color.LightGray;
            public static readonly Color Header = Color.FromArgb(125, 183, 240);
            public static readonly Color Background = Color.White;
            public static readonly Color AlternateRow = Color.GhostWhite;
            public static readonly Color Selection = Color.Blue;
            public static readonly Color Edit = Color.White;
            public static readonly Color Readonly = Color.White;
            public static readonly Color Mandatory = SystemColors.Info;
            public static readonly Color SubTotal = Color.Azure;
            public static readonly Color GrandTotal = Color.Blue;
        }

        /// <summary>
        /// GridForeColor
        /// 그리드 전경색 설정
        /// </summary>
        private static class GridForeColor
        {
            public static Color Header = Color.Black;
            public static Color AlternateRow = Color.GhostWhite;
            public static Color Selection = Color.White;
            public static Color Edit = Color.Black;
            public static Color Readonly = Color.Black;
            public static Color Mandatory = Color.Black;
            public static Color SubTotal = Color.Blue;
            public static Color GrandTotal = Color.White;
        }

        public enum GridHorizontalAlignment
        {
            Left = 0,
            Center = 1,
            Right = 2,
            General = 3
        }

        public enum GridVerticalAlignment
        {
            Middle = 0,
            Top = 1,
            Bottom = 2,
            General = 3
        }

        /// <summary>
        /// 그리드 스타일 설정
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="style"></param>
        //public static void SetGridStyle(FpSpread fpSpread, GridStyle style)
        //{
        //    // Skin 설정
        //    fpSpread.Skin = DefaultSpreadSkins.Classic;
        //    fpSpread.ActiveSheet.DefaultStyle.VisualStyles = VisualStyles.On;
        //    fpSpread.InterfaceRenderer = null;

        //    // BackColor, ForeColor 설정
        //    //fpSpread.ActiveSheet.GrayAreaBackColor = GridBackColor.GrayArea;
        //    //fpSpread.ActiveSheet.Columns.Default.BackColor = GridBackColor.Background;
        //    //fpSpread.ActiveSheet.ColumnHeader.DefaultStyle.BackColor = GridBackColor.Header;
        //    //fpSpread.ActiveSheet.RowHeader.DefaultStyle.BackColor = GridBackColor.Header;
        //    //fpSpread.ActiveSheet.SheetCornerStyle.BackColor = GridBackColor.Header;
        //    //fpSpread.ActiveSheet.SelectionBackColor = GridBackColor.Selection;
        //    //fpSpread.ActiveSheet.SelectionForeColor = GridForeColor.Selection;

        //    // 스크롤바 관련 설정
        //    fpSpread.ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
        //    fpSpread.RowSplitBoxPolicy = SplitBoxPolicy.Never;
        //    fpSpread.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
        //    fpSpread.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
        //    fpSpread.ScrollTipPolicy = ScrollTipPolicy.Vertical;

        //    // Column, Row 관련 설정
        //    fpSpread.AllowColumnMove = true;
        //    fpSpread.AllowRowMove = false;
        //    fpSpread.RetainSelectionBlock = false;
        //    fpSpread.EditModeReplace = true;

        //    fpSpread.ActiveSheet.AutoGenerateColumns = false;
        //    fpSpread.ActiveSheet.DataAutoSizeColumns = false;
        //    fpSpread.ActiveSheet.DataAutoCellTypes = false;

        //    // OperationMode (선택모드) 설정
        //    //fpSpread.ActiveSheet.OperationMode = OperationMode.Normal;
        //    //fpSpread.ActiveSheet.SelectionStyle = SelectionStyles.SelectionColors;
        //    //fpSpread.ActiveSheet.SelectionPolicy = SelectionPolicy.MultiRange;
        //    //fpSpread.ActiveSheet.SelectionUnit = SelectionUnit.Cell;

        //    fpSpread.ActiveSheet.Rows.Default.Height = 24;

        //    // 그리드의 모든 행열 삭제
        //    fpSpread.ActiveSheet.ColumnCount = 0;
        //    fpSpread.ActiveSheet.RowCount = 0;

        //    //fpSpread.Enter += new EventHandler(fpSpread_Enter);
        //}

        /// <summary>
        /// 그리드 스타일 설정
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="style"></param>
        public static void SetGridStyle(FpSpread fpSpread, string style)
        {
            // Skin 설정
            fpSpread.Skin = DefaultSpreadSkins.Classic;
            //fpSpread.ActiveSheet.DefaultStyle.VisualStyles = VisualStyles.Off;
            fpSpread.InterfaceRenderer = null;

            // BackColor, ForeColor 설정
            fpSpread.ActiveSheet.GrayAreaBackColor = GridBackColor.Background;
            //fpSpread.ActiveSheet.Columns.Default.BackColor = GridBackColor.Background;
            fpSpread.ActiveSheet.ColumnHeader.DefaultStyle.BackColor = GridBackColor.Header;
            fpSpread.ActiveSheet.RowHeader.DefaultStyle.BackColor = GridBackColor.Header;
            fpSpread.ActiveSheet.SheetCornerStyle.BackColor = GridBackColor.Header;
            //fpSpread.ActiveSheet.SelectionBackColor = GridBackColor.Selection;
            //fpSpread.ActiveSheet.SelectionForeColor = GridForeColor.Selection;
            fpSpread.Tag = style.ToString();

            //BevelBorder bevelBorder1 = new BevelBorder(BevelBorderType.Lowered, Color.FromArgb(182, 214, 245), System.Drawing.Color.Empty);
            //fpSpread.ActiveSheet.DefaultStyle.Border = bevelBorder1;

            //if (style.ToString().Equals(style))
            //{
            //    fpSpread.ActiveSheet.AlternatingRows.Count = 2;
            //    fpSpread.ActiveSheet.AlternatingRows.Get(0).BackColor = Color.White;
            //    fpSpread.ActiveSheet.AlternatingRows.Get(1).BackColor = Color.Azure;
            //}

            // 스크롤바 관련 설정
            fpSpread.ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
            fpSpread.RowSplitBoxPolicy = SplitBoxPolicy.Never;
            fpSpread.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
            fpSpread.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
            fpSpread.ScrollTipPolicy = ScrollTipPolicy.Vertical;

            // Column, Row 관련 설정
            fpSpread.AllowColumnMove = false;
            fpSpread.AllowRowMove = false;
            fpSpread.RetainSelectionBlock = false;
            fpSpread.EditModeReplace = true;

            fpSpread.ActiveSheet.AutoGenerateColumns = false;
            fpSpread.ActiveSheet.DataAutoSizeColumns = false;
            fpSpread.ActiveSheet.DataAutoCellTypes = false;

            // OperationMode (선택모드) 설정
            //fpSpread.ActiveSheet.SelectionStyle = SelectionStyles.SelectionColors;
            //fpSpread.ActiveSheet.OperationMode = OperationMode.Normal;
            //if (style == GridStyle.InPlaceEdit)
            //{
            //    fpSpread.ActiveSheet.SelectionUnit = SelectionUnit.Cell;
            //    fpSpread.ActiveSheet.SelectionPolicy = SelectionPolicy.Single;
            //}
            //else
            //{
            //    fpSpread.ActiveSheet.SelectionUnit = SelectionUnit.Row;
            //    fpSpread.ActiveSheet.SelectionPolicy = SelectionPolicy.Single;
            //}

            fpSpread.ActiveSheet.Rows.Default.Height = 22;

            // 그리드의 모든 행열 삭제
            fpSpread.ActiveSheet.ColumnCount = 0;
            fpSpread.ActiveSheet.RowCount = 0;
            //fpSpread.Enter += new EventHandler(fpSpread_Enter);

            //fpSpread.PreviewKeyDown += OnSpreadPreviewKeyDown;
            fpSpread.KeyDown += OnSpreadKeyDown;
        }

        private static void OnSpreadKeyDown(object sender, KeyEventArgs e)
        {
            FpSpread fpSpread = (FpSpread)sender;
            if (e.KeyCode == Keys.Enter)
            {
                if (fpSpread.ActiveSheet.ActiveRowIndex < fpSpread.ActiveSheet.Rows.Count - 1)
                {
                    fpSpread.ActiveSheet.ActiveRowIndex++;
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="cellAlignment"></param>
        /// <param name="enabled"></param>
        public static void AddColumn(FpSpread fpSpread, string fieldName, string label, int width, GridHorizontalAlignment cellAlignment, bool enabled)
        {
            fpSpread.ActiveSheet.Columns.Add(fpSpread.ActiveSheet.Columns.Count, 1);

            FarPoint.Win.Spread.Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            column.Tag = fieldName;
            column.DataField = fieldName;
            column.Label = label;
            column.Width = width;
            column.VerticalAlignment = CellVerticalAlignment.Center;
            column.HorizontalAlignment = ToCellHorizontalAlignment(cellAlignment);
            column.Locked = !enabled;
            column.BackColor = enabled ? GridBackColor.Edit : GridBackColor.Readonly;
        }

        /// <summary>
        /// 문자 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="maxLength"></param>
        /// <param name="enabled"></param>
        public static void AddTextColumn(FpSpread fpSpread, string fieldName, string label, int width, int maxLength, bool enabled)
        {
            AddTextColumn(fpSpread, fieldName, label, width, maxLength, GridHorizontalAlignment.Left, enabled);

        }

        /// <summary>
        /// 문자 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="maxLength"></param>
        /// <param name="cellAlignment"></param>
        /// <param name="enabled"></param>
        public static void AddTextColumn(FpSpread fpSpread, string fieldName, string label, int width, int maxLength, GridHorizontalAlignment cellAlignment, bool enabled)
        {
            AddColumn(fpSpread, fieldName, label, width, cellAlignment, enabled);

            FarPoint.Win.Spread.Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            TextCellType cellType = new TextCellType();
            cellType.MaxLength = maxLength;
            column.CellType = cellType;
        }

        /// <summary>
        /// 숫자 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="decimalPlaces"></param>
        /// <param name="showSeparator"></param>
        /// <param name="enabled"></param>
        public static void AddNumberColumn(FpSpread fpSpread, string fieldName, string label, int width, int decimalPlaces, bool showSeparator, bool enabled)
        {
            AddNumberColumn(fpSpread, fieldName, label, width, decimalPlaces, showSeparator, GridHorizontalAlignment.Right, enabled);
        }

        /// <summary>
        /// 숫자 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="decimalPlaces"></param>
        /// <param name="showSeparator"></param>
        /// <param name="cellAlignment"></param>
        /// <param name="enabled"></param>
        public static void AddNumberColumn(FpSpread fpSpread, string fieldName, string label, int width, int decimalPlaces, bool showSeparator, GridHorizontalAlignment cellAlignment, bool enabled)
        {
            AddColumn(fpSpread, fieldName, label, width, cellAlignment, enabled);

            FarPoint.Win.Spread.Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            NumberCellType cellType = new NumberCellType();
            cellType.DecimalPlaces = decimalPlaces;
            cellType.FixedPoint = false;
            cellType.DecimalSeparator = ".";
            cellType.Separator = ",";
            cellType.ShowSeparator = showSeparator;
            cellType.MaximumValue = 9999999999999.9999;
            column.CellType = cellType;
        }

        /// <summary>
        /// 날짜 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="enabled"></param>
        public static void AddDateColumn(FpSpread fpSpread, string fieldName, string label, int width, bool enabled)
        {
            AddDateTimeColumn(fpSpread, fieldName, label, width, DEFAULT_DATE_FORMAT, enabled);
        }

        /// <summary>
        /// 시간 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="enabled"></param>
        public static void AddTimeColumn(FpSpread fpSpread, string fieldName, string label, int width, bool enabled)
        {
            AddDateTimeColumn(fpSpread, fieldName, label, width, DEFAULT_TIME_FORMAT, enabled);
        }

        /// <summary>
        /// 날짜/시간 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="enabled"></param>
        public static void AddDateTimeColumn(FpSpread fpSpread, string fieldName, string label, int width, bool enabled)
        {
            AddDateTimeColumn(fpSpread, fieldName, label, width, DEFAULT_DATETIME_FORMAT, enabled);
        }

        /// <summary>
        /// 날짜/시간 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="dateTimeFormat"></param>
        /// <param name="enabled"></param>
        public static void AddDateTimeColumn(FpSpread fpSpread, string fieldName, string label, int width, string dateTimeFormat, bool enabled)
        {
            AddColumn(fpSpread, fieldName, label, width, GridHorizontalAlignment.Center, enabled);

            FarPoint.Win.Spread.Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            DateTimeCellType cellType = new DateTimeCellType();
            cellType.DateTimeFormat = DateTimeFormat.UserDefined;
            cellType.UserDefinedFormat = dateTimeFormat;
            column.CellType = cellType;
        }

        /// <summary>
        /// 체크박스 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="enabled"></param>
        public static void AddCheckBoxColumn(FpSpread fpSpread, string fieldName, string label, int width, bool enabled)
        {
            AddColumn(fpSpread, fieldName, label, width, GridHorizontalAlignment.Center, enabled);

            FarPoint.Win.Spread.Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            CheckBoxCellType cellType = new CheckBoxCellType();
            column.CellType = cellType;
        }

        /// <summary>
        ///  버튼 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="buttonText"></param>
        /// <param name="enabled"></param>
        public static void AddButtonColumn(FpSpread fpSpread, string fieldName, string label, int width, string buttonText, bool enabled)
        {
            AddColumn(fpSpread, fieldName, label, width, GridHorizontalAlignment.Center, enabled);

            FarPoint.Win.Spread.Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            ButtonCellType cellType = new ButtonCellType();
            cellType.Text = buttonText;
            column.CellType = cellType;
        }

        /// <summary>
        /// 콤보박스 컬럼 추가
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="label"></param>
        /// <param name="width"></param>
        /// <param name="dtCombo"></param>
        /// <param name="valueField"></param>
        /// <param name="displayField"></param>
        /// <param name="enabled"></param>
        public static void AddComboBoxColumn(FpSpread fpSpread, string fieldName, string label, int width, DataTable dtCombo, string valueField, string displayField, bool enabled)
        {
            AddColumn(fpSpread, fieldName, label, width, GridHorizontalAlignment.Center, enabled);

            Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            ComboBoxCellType cellType = new ComboBoxCellType();
            string[] valueList = new string[dtCombo.Rows.Count];
            string[] displayList = new string[dtCombo.Rows.Count];
            for (int i = 0; i < dtCombo.Rows.Count; i++)
            {
                //valueList[i] = ConvertUtil.ToString(dtCombo.Rows[i][valueField]);
                //displayList[i] = ConvertUtil.ToString(dtCombo.Rows[i][displayField]);
            }
            cellType.Items = displayList;
            cellType.ItemData = valueList;
            cellType.EditorValue = EditorValue.ItemData;
            column.CellType = cellType;
        }

        public static void AddImageColumn(FpSpread fpSpread, string fieldName, string label, int width)
        {
            AddColumn(fpSpread, fieldName, label, width, GridHorizontalAlignment.Center, false);

            Column column = fpSpread.ActiveSheet.Columns[fpSpread.ActiveSheet.Columns.Count - 1];

            ImageCellType cellType = new ImageCellType();
            //cellType.Style = FarPoint.Win.RenderStyle.Normal;
            cellType.TransparencyColor = Color.White;
            cellType.TransparencyTolerance = 20;
            column.CellType = cellType;
        }

        public static void SetColumnHeaders(FpSpread fpSpread, string[,] headers)
        {
            if (headers == null) throw new ArgumentException("Headers is null.");

            if (headers.Length == 0) return;

            // 배열 한 차원의 원소수, 즉 컬럼 수
            int columns = headers.GetLength(0);
            if (columns != fpSpread.ActiveSheet.Columns.Count) throw new ArgumentException("정의된 컬럼과 컬럼타이틀의 갯수가 일치하지 않습니다.");

            int rows = headers.Length / headers.GetLength(0);
            if (rows <= 1) return;

            fpSpread.ActiveSheet.ColumnHeader.Rows.Count = rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    string header = headers[j, i];
                    if (header == null) continue;

                    fpSpread.ActiveSheet.ColumnHeader.Cells[i, j].Text = header;

                    int rowSpan = 1;
                    while (i + rowSpan < rows && string.Equals(header, headers[j, i + rowSpan]))
                    {
                        headers[j, i + rowSpan] = null;
                        rowSpan++;
                    }
                    if (rowSpan > 1)
                    {
                        fpSpread.ActiveSheet.ColumnHeader.Cells[i, j].RowSpan = rowSpan;
                    }

                    int colSpan = 1;
                    while (j + colSpan < columns && string.Equals(header, headers[j + colSpan, i]))
                    {
                        headers[j + colSpan, i] = null;
                        colSpan++;
                    }
                    if (colSpan > 1)
                    {
                        fpSpread.ActiveSheet.ColumnHeader.Cells[i, j].ColumnSpan = colSpan;
                    }
                }
            }
        }

        public static int[] GetCheckedRows(FpSpread fpSpread, string columnName)
        {
            int column = GetColumnIndex(fpSpread, columnName);
            return GetCheckedRows(fpSpread, column);
        }

        public static int[] GetCheckedRows(FpSpread fpSpread, int column)
        {
            CheckColumnBounds(fpSpread, column);

            ArrayList list = new ArrayList();
            for (int i = 0; i < fpSpread.ActiveSheet.Rows.Count; i++)
            {
                object value = GetValue(fpSpread, i, column);
                if (value != null && "True".Equals(value))
                {
                    list.Add(i);
                }
            }
            int[] result = new int[list.Count];
            list.CopyTo(result);
            return result;
        }

        /// <summary>
        /// 데이터 소스 바인드
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="dataSource"></param>
        public static void SetDataSource(FpSpread fpSpread, object dataSource)
        {
            try
            {
                if (fpSpread.ActiveSheet.DataSource != null)
                {
                    object obj = fpSpread.ActiveSheet.DataSource;
                    if (obj != null && obj is IDisposable)
                    {
                        ((IDisposable)obj).Dispose();
                    }
                    fpSpread.ActiveSheet.Rows.Clear();
                }

                fpSpread.ActiveSheet.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 바인드된 데이터소스 클리어
        /// </summary>
        /// <param name="fpSpread"></param>
        public static void ClearDataSource(FpSpread fpSpread)
        {
            try
            {
                if (fpSpread.ActiveSheet.RowCount > 0)
                {
                    fpSpread.ActiveSheet.RowCount = 0;
                }
                if (fpSpread.ActiveSheet.DataSource != null)
                {
                    object obj = fpSpread.ActiveSheet.DataSource;
                    if (obj != null && obj is IDisposable)
                    {
                        ((IDisposable)obj).Dispose();
                    }
                    fpSpread.ActiveSheet.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// fieldName에 해당하는 컬럼의 컬럼인덱스 리턴
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int GetColumnIndex(FpSpread fpSpread, string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) return -1;

            Column column = fpSpread.ActiveSheet.Columns[columnName];

            if (column != null)
            {
                return column.Index;
            }
            else
            {
                return -1;
            }
        }

        public static string GetText(FpSpread fpSpread, int row, string columnName)
        {
            int column = GetColumnIndex(fpSpread, columnName);

            return GetText(fpSpread, row, column);
        }

        public static string GetText(FpSpread fpSpread, int row, int column)
        {
            CheckRowBounds(fpSpread, row);
            CheckColumnBounds(fpSpread, column);

            return fpSpread.ActiveSheet.Cells[row, column].Text.Trim();
        }

        //public static GridRowState GetRowState(FpSpread fpSpread, int row)
        //{
        //    if (row < 0 || row >= fpSpread.ActiveSheet.Rows.Count) throw new ArgumentException("Row index out of range");

        //    if (fpSpread.ActiveSheet.DataSource == null || !(fpSpread.ActiveSheet.DataSource is DataTable))
        //    {
        //        return GridRowState.Added;
        //    }

        //    DataTable dt = (DataTable)fpSpread.ActiveSheet.DataSource;
        //    DataRowState state = dt.Rows[row].RowState;
        //    switch (state)
        //    {
        //        case DataRowState.Added:
        //            return GridRowState.Added;
        //        case DataRowState.Deleted:
        //            return GridRowState.Deleted;
        //        case DataRowState.Modified:
        //            return GridRowState.Modified;
        //        default:
        //            return GridRowState.Unchanged;
        //    }
        //}

        public static void AddRow(FpSpread fpSpread)
        {
            int row = fpSpread.ActiveSheet.Rows.Count;
            AddRow(fpSpread, row);
        }

        public static void AddRow(FpSpread fpSpread, int iHeight, string sType)
        {
            int row = fpSpread.ActiveSheet.Rows.Count;
            AddRow(fpSpread, row);
            fpSpread.ActiveSheet.Rows[row].Height = iHeight;
        }

        public static void AddRow(FpSpread fpSpread, int row)
        {
            if (row < 0)
            {
                throw new ArgumentException("Row Index Out Of Range");
            }

            if (fpSpread.ActiveSheet.DataSource == null || !(fpSpread.ActiveSheet.DataSource is DataTable))
            {             
                fpSpread.ActiveSheet.Rows.Add(row, 1);
                fpSpread.ActiveSheet.Rows.Get(row).Height = 60F; // 새로 생성시 크기조절
            }
            else
            {
                DataTable dt = (DataTable)fpSpread.ActiveSheet.DataSource;
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, row);
                
            }
            //SetRowStatus(fpSpread, row, RowStatus.New);
        }

        public static void RemoveRows(FpSpread fpSpread, int[] rows)
        {
            for (int i = rows.Length - 1; i >= 0; i--)
            {
                RemoveRow(fpSpread, rows[i]);
            }
        }

        public static void RemoveRow(FpSpread fpSpread, int row)
        {
            CheckRowBounds(fpSpread, row);

            if (fpSpread.ActiveSheet.DataSource == null || !(fpSpread.ActiveSheet.DataSource is DataTable))
            {
                fpSpread.ActiveSheet.Rows.Remove(row, 1);
            }
            else
            {
                DataTable dt = (DataTable)fpSpread.ActiveSheet.DataSource;
                dt.Rows.RemoveAt(row);
            }
        }

        public static object GetValue(FpSpread fpSpread, int row, string columnName)
        {
            int column = GetColumnIndex(fpSpread, columnName);

            if (column < 0)
                throw new Exception(columnName + "열을 찾을 수 없습니다.");

            return GetValue(fpSpread, row, column);
        }

        public static object GetValue(FpSpread fpSpread, int row, int column)
        {
            CheckRowBounds(fpSpread, row);
            CheckColumnBounds(fpSpread, column);

            return fpSpread.ActiveSheet.Cells[row, column].Value;
        }

        public static void SetValue(FpSpread fpSpread, int row, string columnName, object value)
        {
            int column = GetColumnIndex(fpSpread, columnName);

            if (column < 0)
                throw new Exception(columnName + "열을 찾을 수 없습니다.");

            SetValue(fpSpread, row, column, value);
        }

        public static void SetValue(FpSpread fpSpread, int row, int column, object value)
        {
            CheckRowBounds(fpSpread, row);
            CheckColumnBounds(fpSpread, column);

            fpSpread.ActiveSheet.Cells[row, column].Value = value;
            //SetRowStatus(fpSpread, row, RowStatus.Modified);
        }

        public static void SetText(FpSpread fpSpread, int row, int column, string txt)
        {
            CheckRowBounds(fpSpread, row);
            CheckColumnBounds(fpSpread, column);

            fpSpread.ActiveSheet.Cells[row, column].Text = txt;
        }

        public static int GetActiveRow(FpSpread fpSpread)
        {
            return fpSpread.ActiveSheet.ActiveRowIndex;
        }

        public static int GetActiveColumn(FpSpread fpSpread, object toString)
        {
            return fpSpread.ActiveSheet.ActiveColumnIndex;
        }

        public static void MergeRowByColumn(FpSpread fpSpread, string columnName)
        {
            MergeRowByColumns(fpSpread, new string[] { columnName }, GridVerticalAlignment.Middle);
        }

        /// <summary>
        /// 그리드의 특정 컬럼의 값이 인접한 아래쪽 로우와 같다면 머지한다.
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        public static void MergeRowByColumn(FpSpread fpSpread, string columnName, GridVerticalAlignment vertAlignment)
        {
            MergeRowByColumns(fpSpread, new string[] { columnName }, vertAlignment);
        }

        public static void MergeRowByColumns(FpSpread fpSpread, string[] columnNames)
        {
            MergeRowByColumns(fpSpread, columnNames, GridVerticalAlignment.Top);
        }

        public static void MergeRowByColumns(FpSpread fpSpread, string[] columnNames, GridVerticalAlignment vertAlignment)
        {
            if (columnNames == null || columnNames.Length == 0) return;

            MergeRowByColumns(fpSpread, ToColumnIndex(fpSpread, columnNames), vertAlignment);
        }

        public static void MergeRowByColumns(FpSpread fpSpread, int[] columns, GridVerticalAlignment vertAlignment)
        {
            if (columns == null || columns.Length == 0) return;

            MergeRows(fpSpread, columns, 0, 0, fpSpread.ActiveSheet.Rows.Count, vertAlignment);
        }

        private static void MergeRows(FpSpread fpSpread, int[] columns, int colPos, int rowPos, int rowLength, GridVerticalAlignment vertAlignment)
        {
            if (colPos >= columns.Length) return;

            while (rowPos < rowLength)
            {
                int rowSpan = CountSameRows(fpSpread, columns[colPos], rowPos, rowLength);
                if (rowSpan > 1)
                {
                    Cell cell = fpSpread.ActiveSheet.Cells[rowPos, columns[colPos]];
                    cell.RowSpan = rowSpan;
                    cell.VerticalAlignment = ToCellVerticalAlignment(vertAlignment);
                }

                MergeRows(fpSpread, columns, colPos + 1, rowPos, rowPos + rowSpan, vertAlignment);

                rowPos += rowSpan;
            }
        }

        private static int CountSameRows(FpSpread fpSpread, int column, int start, int length)
        {
            object value1 = SpreadUtil.GetValue(fpSpread, start, column);

            int pos = 1;
            while (start + pos < length)
            {
                object value2 = SpreadUtil.GetValue(fpSpread, start + pos, column);
                if (!object.Equals(value1, value2))
                {
                    return pos;
                }
                pos++;
            }
            return pos;
        }

        /// <summary>
        /// 그리드의 특정 컬럼의 값이 인접한 아래쪽 열과 같다면 머지한다.
        /// 머지할 때 columnName을 기준으로 otherColumns까지 같이 머지한다.
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="otherFields"></param>
        public static void MergeRowByColumns(FpSpread fpSpread, string columnName, string[] otherColumns)
        {
            // columnName의 컬럼 인덱스 찾기
            int column = SpreadUtil.GetColumnIndex(fpSpread, columnName);
            CheckColumnBounds(fpSpread, column);

            // others의 컬럼 인덱스 찾기
            int[] columns = new int[otherColumns == null ? 0 : otherColumns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = SpreadUtil.GetColumnIndex(fpSpread, otherColumns[i]);
            }

            // 루프를 돌리면서 columnName이 같은 열을 찾는다.
            for (int i = 0; i < fpSpread.ActiveSheet.Rows.Count; i++)
            {
                object value1 = fpSpread.ActiveSheet.Cells[i, column].Value;
                for (int j = i + 1; j < fpSpread.ActiveSheet.Rows.Count; j++)
                {
                    object value2 = fpSpread.ActiveSheet.Cells[j, column].Value;
                    if (!object.Equals(value1, value2))
                    {
                        // 틀린 값을 찾을 경우 i를 j - 1로 변경한다.
                        // 즉, 내부 루프에서 진행한 열만큼 외부 루프도 진행시켜 버린다.
                        // 따라서 2중 루프를 돌리지만 결국 시간복잡도는 O(n)이다. ^^
                        i = j - 1;
                        break;
                    }
                    else
                    {
                        fpSpread.ActiveSheet.Cells[i, column].RowSpan++;
                        if (otherColumns != null)
                        {
                            // columnName을 머지할 때 otherFields도 같이 머지함
                            for (int k = 0; k < columns.Length; k++)
                            {
                                fpSpread.ActiveSheet.Cells[i, columns[k]].RowSpan++;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 그리드의 특정 컬럼을 머지한다.
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="colSpan"></param>
        public static void MergeColumn(FpSpread fpSpread, string columnName, int colSpan)
        {
            int column = SpreadUtil.GetColumnIndex(fpSpread, columnName);
            for (int i = 0; i < fpSpread.ActiveSheet.Rows.Count; i++)
            {
                MergeColumn(fpSpread, i, column, colSpan);
            }
        }

        public static void MergeColumn(FpSpread fpSpread, int row, string columnName, int colSpan)
        {
            int column = SpreadUtil.GetColumnIndex(fpSpread, columnName);
            MergeColumn(fpSpread, row, column, colSpan);
        }

        /// <summary>
        /// 그리드의 특정 컬럼을 머지한다.
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="fieldName"></param>
        /// <param name="colSpan"></param>
        public static void MergeColumn(FpSpread fpSpread, int row, int column, int colSpan)
        {
            CheckRowBounds(fpSpread, row);
            CheckColumnBounds(fpSpread, column);
            fpSpread.ActiveSheet.Cells[row, column].ColumnSpan = colSpan;
        }

        private static void CheckRowBounds(FpSpread fpSpread, int row)
        {
            if (row < 0 || row >= fpSpread.ActiveSheet.RowCount)
            {
                throw new ArgumentException(string.Format("Row Index[{0}] Out Of Range", row));
            }
        }

        private static void CheckColumnBounds(FpSpread fpSpread, int column)
        {
            if (column < 0 || column >= fpSpread.ActiveSheet.ColumnCount)
            {
                throw new ArgumentException(string.Format("Column Index[{0}] Out Of Range", column));
            }
        }

        private static CellVerticalAlignment ToCellVerticalAlignment(GridVerticalAlignment cellAlignment)
        {
            switch (cellAlignment)
            {
                case GridVerticalAlignment.Top:
                    return CellVerticalAlignment.Top;
                case GridVerticalAlignment.Middle:
                    return CellVerticalAlignment.Center;
                case GridVerticalAlignment.Bottom:
                    return CellVerticalAlignment.Bottom;
                default:
                    return CellVerticalAlignment.General;
            }
        }

        private static CellHorizontalAlignment ToCellHorizontalAlignment(GridHorizontalAlignment cellAlignment)
        {
            switch (cellAlignment)
            {
                case GridHorizontalAlignment.Left:
                    return CellHorizontalAlignment.Left;
                case GridHorizontalAlignment.Center:
                    return CellHorizontalAlignment.Center;
                case GridHorizontalAlignment.Right:
                    return CellHorizontalAlignment.Right;
                default:
                    return CellHorizontalAlignment.General;
            }
        }

        private static int[] ToColumnIndex(FpSpread fpSpread, string[] columnNames)
        {
            if (columnNames == null || columnNames.Length == 0) return new int[0];

            int[] result = new int[columnNames.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GetColumnIndex(fpSpread, columnNames[i]);
            }
            return result;
        }

        private static void GridRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataTable dt = (DataTable)sender;
            //Console.WriteLine(string.Format("Row Changed = {0}", e.Row.));
        }

        private static void SetTotal(FpSpread fpSpread, string[] keyColumns, string[] valueColumns)
        {
            if (keyColumns == null || keyColumns.Length == 0) return;
            if (valueColumns == null || valueColumns.Length == 0) return;

            SetTotal(fpSpread, ToColumnIndex(fpSpread, keyColumns), ToColumnIndex(fpSpread, valueColumns));
        }

        private static void SetTotal(FpSpread fpSpread, int[] keyColumns, int[] valueColumns)
        {
            CalcTotal(fpSpread, keyColumns, 0, 0, fpSpread.ActiveSheet.Rows.Count, valueColumns);
        }

        private static void CalcTotal(FpSpread fpSpread, int[] columns, int colPos, int rowPos, int rowLength, int[] valueColumns)
        {
            if (colPos >= columns.Length) return;

            while (rowPos < rowLength)
            {
                Cell cell = fpSpread.ActiveSheet.Cells[rowPos, columns[colPos]];
                if (cell.RowSpan > 1)
                {
                }

                CalcTotal(fpSpread, columns, colPos + 1, rowPos, rowPos + cell.RowSpan, valueColumns);

                rowPos += cell.RowSpan;
            }
        }

        //////public static void SetText(FpSpread spread, int rowInx, int colInx, string alignment, string strText)
        //////{
        //////    SetText(spread, rowInx, colInx, alignment, strText, Color.White);
        //////}

        //////public static void SetText(FpSpread spread, int rowInx, int colInx, string alignment, string strText, double colorNo)
        //////{
        //////    if (colorNo == 1)
        //////    {
        //////        SetText(spread, rowInx, colInx, alignment, strText, Color.Red);
        //////    }
        //////    else if (colorNo == -1)
        //////    {
        //////        SetText(spread, rowInx, colInx, alignment, strText, Color.Blue);
        //////    }
        //////    else
        //////    {
        //////        SetText(spread, rowInx, colInx, alignment, strText, Color.White);
        //////    }

        //////}

        //////public static void SetText(FpSpread spread, int rowInx, int colInx, string alignment, string strText, Color color)
        //////{
        //////    SheetView sv = spread.ActiveSheet;
        //////    FarPoint.Win.Spread.Cell cell = sv.Cells[rowInx, colInx];

        //////    cell.Text = strText;
        //////    if (alignment.Equals("C"))
        //////    {
        //////        cell.HorizontalAlignment = CellHorizontalAlignment.Center;
        //////    }
        //////    else if (alignment.Equals("L"))
        //////    {
        //////        cell.HorizontalAlignment = CellHorizontalAlignment.Left;
        //////    }
        //////    else if (alignment.Equals("R"))
        //////    {
        //////        cell.HorizontalAlignment = CellHorizontalAlignment.Right;
        //////    }
        //////    cell.BackColor = color;
        //////}

        public static void SetCellFocus(FpSpread spread, int rowInx, int colInx)
        {
            spread.ActiveSheet.ActiveRowIndex = rowInx;
            spread.ActiveSheet.ActiveColumnIndex = colInx;
            spread.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Center);

            spread.ActiveSheet.Models.Selection.SetSelection(rowInx, colInx, 1, 1);
        }

        public static void SetCellFocus(FpSpread spread, int rowInx, string colName)
        {
            int colInx = GetColumnIndex(spread, colName);

            if (colInx < 0)
                throw new Exception(colName + "열을 찾을 수 없습니다.(" + spread.Name + ")");

            SetCellFocus(spread, rowInx, colInx);
        }

        public static void SetCellLocked(FpSpread spread, int row, string colName, bool lockFlag)
        {
            int col = GetColumnIndex(spread, colName);

            if (col < 0)
                throw new Exception(colName + "열을 찾을 수 없습니다.(" + spread.Name + ")");

            spread.ActiveSheet.Cells[row, col].Locked = lockFlag;
        }

        public static void SetRowLocked(FpSpread spread, int row1, int row2, bool lockFlag)
        {
            spread.ActiveSheet.Rows[row1, row2].Locked = lockFlag;
        }

        public static void SetColLocked(FpSpread spread, int col1, int col2, bool lockFlag)
        {
            spread.ActiveSheet.Columns[col1, col2].Locked = lockFlag;
        }

        public static void SetColLocked(FpSpread spread, string colName, bool lockFlag)
        {
            int rowCount = spread.ActiveSheet.Rows.Count;
            int col = GetColumnIndex(spread, colName);

            if (col < 0)
                throw new Exception(colName + "열을 찾을 수 없습니다.(" + spread.Name + ")");

            spread.ActiveSheet.Cells[0, col, rowCount - 1, col].Locked = lockFlag;
        }

        public static void export2XLS(FpSpread pSpdList)
        {
            SaveFileDialog mDlg = new SaveFileDialog();
            mDlg.InitialDirectory = Application.StartupPath;
            mDlg.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            mDlg.FilterIndex = 1;
            if (mDlg.ShowDialog() == DialogResult.OK)
            {
                pSpdList.SaveExcel(mDlg.FileName, FarPoint.Win.Spread.Model.IncludeHeaders.BothCustomOnly);
                MessageBox.Show("저장이 완료 되었습니다.", "엑셀저장");
            }
        }

        public static void SetSpreadValue(FpSpread spr, DbDataReader dr)
        {
            int row = 0;
            while (dr.Read())
            {
                spr.ActiveSheet.Rows.Count += 1;
                row = spr.ActiveSheet.Rows.Count - 1;

                foreach (Column column in spr.ActiveSheet.Columns)
                {
                    if (column.Tag == null)
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    string colName = column.Tag.ToString();

                    if (string.IsNullOrEmpty(colName))
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    if (column.CellType is CheckBoxCellType)
                    {
                        if (dr[colName].ToString().Trim() == "Y")
                            SpreadUtil.SetValue(spr, row, column.Index, true);
                        else
                            SpreadUtil.SetValue(spr, row, column.Index, false);
                    }
                    else
                    {
                        SpreadUtil.SetValue(spr, row, column.Index, dr[colName].ToString().Trim());
                    }
                }
            }

            dr.Close();
        }

        public static void SetSpreadValue(FpSpread spr, DataSet ds)
        {
            int existsRowCount = spr.ActiveSheet.Rows.Count;
            int dsIndex = 0;

            for (int row = existsRowCount; row < existsRowCount + ds.Tables[0].Rows.Count; row++)
            {
                spr.ActiveSheet.Rows.Count += 1;

                foreach (Column column in spr.ActiveSheet.Columns)
                {
                    if (column.Tag == null)
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    string colName = column.Tag.ToString();

                    if (string.IsNullOrEmpty(colName))
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    if (column.CellType is CheckBoxCellType)
                    {
                        if (ds.Tables[0].Rows[dsIndex][colName].ToString().Trim() == "Y")
                            SpreadUtil.SetValue(spr, row, column.Index, true);
                        else
                            SpreadUtil.SetValue(spr, row, column.Index, false);
                    }
                    else
                    {
                        SpreadUtil.SetValue(spr, row, column.Index, ds.Tables[0].Rows[dsIndex][colName].ToString().Trim());
                    }
                }
                dsIndex += 1;
            }
        }

        public static void SetSpreadValue(FpSpread spr, DataTable dt)
        {
            int existsRowCount = spr.ActiveSheet.Rows.Count;
            int dsIndex = 0;

            

            for (int row = existsRowCount; row < existsRowCount + dt.Rows.Count; row++)
            {
                spr.ActiveSheet.Rows.Count += 1;

                foreach (Column column in spr.ActiveSheet.Columns)
                {
                    if (column.Tag == null)
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    string colName = column.Tag.ToString();

                    if (string.IsNullOrEmpty(colName))
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    if (column.CellType is CheckBoxCellType)
                    {
                        if (dt.Rows[dsIndex][colName].ToString().Trim() == "Y")
                        {
                            SpreadUtil.SetValue(spr, row, column.Index, true);
                        }
                        else
                        {
                            SpreadUtil.SetValue(spr, row, column.Index, false);
                        }
                    }
                    else
                    {
                        spr.ActiveSheet.Rows.Get(row).Height = 60F; // 새로 생성시 크기조절
                        SpreadUtil.SetValue(spr, row, column.Index, dt.Rows[dsIndex][colName].ToString().Trim());
                    }
                }
                dsIndex += 1;
            }
        }

        //김현준 VirtualMode 데이터 많을시 스크롤 속도 향상
        //////////public static void VirtualMode(FpSpread fpSpread, DataTable hmDT)
        //////////{
        //////////    string[,] a = new string[hmDT.Rows.Count, hmDT.Columns.Count];

        //////////    int colCount = hmDT.Columns.Count;
        //////////    int rowCount = hmDT.Rows.Count;

        //////////    fpSpread.ActiveSheet.RowCount = hmDT.Rows.Count;
        //////////    fpSpread.ActiveSheet.ColumnCount = colCount;

        //////////    FarPoint.Win.Spread.Model.CellRange virtualport = new FarPoint.Win.Spread.Model.CellRange(0, 0, rowCount, colCount);
        //////////    FarPoint.Win.Spread.Model.CellRange cr = virtualport;
        //////////    FillSpread(cr, a, fpSpread, hmDT);
        //////////}

        //////////public static void FillSpread(FarPoint.Win.Spread.Model.CellRange cr, string[,] count, FpSpread fpSpread, DataTable hmDT)
        //////////{
        //////////    int i, j;
        //////////    for (i = cr.Row; i < cr.Row + cr.RowCount; i++)
        //////////    {
        //////////        for (j = cr.Column; j < cr.Column + cr.ColumnCount; j++)
        //////////        {
        //////////            //fpSpread.ActiveSheet.SetValue(i, j, count);

        //////////            fpSpread.ActiveSheet.SetValue(i, j, hmDT.Rows[i][j].ToString());
        //////////        }
        //////////    }
        //////////}

        public static void SetSpreadValue(FpSpread spr, DataTable dt, int iHeight)
        {
            int existsRowCount = spr.ActiveSheet.Rows.Count;
            int dsIndex = 0;

            for (int row = existsRowCount; row < existsRowCount + dt.Rows.Count; row++)
            {
                spr.ActiveSheet.Rows.Count += 1;
                spr.ActiveSheet.Rows[spr.ActiveSheet.Rows.Count - 1].Height = iHeight;  //높이추가 HM.Lee

                foreach (Column column in spr.ActiveSheet.Columns)
                {
                    if (column.Tag == null)
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    string colName = column.Tag.ToString();

                    if (string.IsNullOrEmpty(colName))
                        throw new Exception((column.Index + 1).ToString() + "열의 컬럼ID가 없습니다.(" + spr.Name + ")");

                    if (column.CellType is CheckBoxCellType)
                    {
                        if (dt.Rows[dsIndex][colName].ToString().Trim() == "Y")
                            SpreadUtil.SetValue(spr, row, column.Index, true);
                        else
                            SpreadUtil.SetValue(spr, row, column.Index, false);
                    }
                    else
                    {
                        SpreadUtil.SetValue(spr, row, column.Index, dt.Rows[dsIndex][colName].ToString().Trim());
                    }
                }
                dsIndex += 1;
            }
        }

        public static void SetResizeColALL(FpSpread spr, int pExtWidth)
        {
            SheetView fpSheet = spr.ActiveSheet;

            int _headerRowCount = fpSheet.ColumnHeader.RowCount;
            fpSheet.RowCount += _headerRowCount;
            int _tmpIndex = 0;
            for (int rowIdx = 0; rowIdx < _headerRowCount; rowIdx++)
            {
                _tmpIndex = fpSheet.RowCount - rowIdx - 1;
                fpSheet.Rows[_tmpIndex].CellType = new GeneralCellType();
                for (int colIdx = 0; colIdx < fpSheet.ColumnCount; colIdx++)
                {
                    //     fpSheet.SetValue(_tmpIndex, colIdx, fpSheet.Columns[colIdx].Label);
                    fpSheet.SetValue(_tmpIndex, colIdx, fpSheet.ColumnHeader.Cells.Get(rowIdx, colIdx).Value);
                }
            }
            for (int k = 0; k < fpSheet.Columns.Count; k++)
            {
                fpSheet.Columns[k].Width = 0;
                fpSheet.Columns[k].Width = Math.Max(fpSheet.ColumnHeader.Columns[k].GetPreferredWidth(), fpSheet.Columns[k].GetPreferredWidth()) + pExtWidth;
                //    fpSheet.Columns[k].ColWidth = fpSheet.GetPreferredColumnWidth(k, true, true, true);
            }
            fpSheet.RowCount -= _headerRowCount;
        }

        public static void SetSubSumValue(FpSpread spr, string[] colName, Color[] colors, bool totalFlag)
        {
            if (spr.ActiveSheet.RowCount == 0) return;

            //sum 대상 컬럼 추려내기
            int sumColCount = 0;
            for (int col = 0; col < spr.ActiveSheet.ColumnCount; col++)
            {
                if (spr.ActiveSheet.Columns[col].CellType is NumberCellType)
                {
                    sumColCount += 1;
                }
            }

            if (sumColCount == 0) return;

            //스프레드에 컬럼추가하기
            SpreadUtil.AddColumn(spr, "__SUM_FLAG", "__SUM_FLAG", 200, SpreadUtil.GridHorizontalAlignment.Center, true);
            int lastColIndex = spr.ActiveSheet.ColumnCount - 1;

            for (int row = 0; row < spr.ActiveSheet.RowCount; row++)
            {
                //원시데이터임을 나타냄.
                spr.ActiveSheet.SetText(row, lastColIndex, "R");
            }

            double[,] sumData = new double[colName.Length, sumColCount];
            double[] totalSumData = new double[sumColCount];

            int sumColIndex = -1;

            string[] befStdData = new string[colName.Length];
            string[] nowStdData = new string[colName.Length];

            for (int inx = 0; inx < colName.Length; inx++)
            {
                befStdData[inx] = SpreadUtil.GetText(spr, 0, colName[inx]);
            }

            for (int row = 0; row < spr.ActiveSheet.RowCount; row++)
            {
                //Sub Total 행이 추가되기 전 체크해야하는 현재값
                for (int inx = 0; inx < colName.Length; inx++)
                {
                    nowStdData[inx] = SpreadUtil.GetText(spr, row, colName[inx]);
                }

                for (int inx = 0; inx < colName.Length; inx++)
                {
                    if (befStdData[inx] != nowStdData[inx])
                    {
                        if (inx != 0)
                            row += 1;

                        //행추가하여 찍어주기
                        spr.ActiveSheet.Rows.Add(row, 1);
                        spr.ActiveSheet.Rows[row].BackColor = colors[inx];
                        SpreadUtil.SetValue(spr, row, colName[inx], befStdData[inx].Trim());
                        SpreadUtil.SetValue(spr, row, "__SUM_FLAG", "N");

                        sumColIndex = -1;
                        for (int col = 0; col < spr.ActiveSheet.ColumnCount; col++)
                        {
                            if (spr.ActiveSheet.Columns[col].CellType is NumberCellType)
                            {
                                sumColIndex += 1;
                                SpreadUtil.SetValue(spr, row, col, sumData[inx, sumColIndex]);
                            }
                        }

                        //찍어주고 초기화 하기
                        for (int sumx = 0; sumx < sumColCount; sumx++)
                        {
                            sumData[inx, sumx] = 0;
                        }

                        befStdData[inx] = nowStdData[inx];
                    }
                    else
                    {
                        if (SpreadUtil.GetText(spr, row, lastColIndex) == "R")
                        {
                            sumColIndex = -1;
                            for (int col = 0; col < spr.ActiveSheet.ColumnCount; col++)
                            {
                                //숫자 컬럼이면 합계 구하기
                                if (spr.ActiveSheet.Columns[col].CellType is NumberCellType)
                                {
                                    sumColIndex += 1;
                                    sumData[inx, sumColIndex] += Convert.ToDouble(SpreadUtil.GetValue(spr, row, col));
                                    //totalSumData[sumColIndex] += Convert.ToDouble(SpreadUtil.GetValue(spr, row, col));
                                }
                            }
                        }
                    }
                }
                SpreadUtil.SetCellFocus(spr, row, 0);
            }

            //마지막 기준데이터 행추가하여 찍어주기
            for (int inx = 0; inx < colName.Length; inx++)
            {
                spr.ActiveSheet.Rows.Count += 1;
                SpreadUtil.SetValue(spr, spr.ActiveSheet.Rows.Count - 1, colName[inx], befStdData[inx].Trim());
                sumColIndex = -1;
                for (int col = 0; col < spr.ActiveSheet.ColumnCount; col++)
                {
                    if (spr.ActiveSheet.Columns[col].CellType is NumberCellType)
                    {
                        sumColIndex += 1;
                        SpreadUtil.SetValue(spr, spr.ActiveSheet.RowCount - 1, col, sumData[inx, sumColIndex]);
                    }
                }
                spr.ActiveSheet.Rows[spr.ActiveSheet.RowCount - 1].BackColor = colors[inx];
            }

            if (totalFlag)
            {
                //Total Sum 찍어주기
                for (int row = 0; row < spr.ActiveSheet.RowCount; row++)
                {
                    if (SpreadUtil.GetText(spr, row, lastColIndex) == "R")
                    {
                        sumColIndex = -1;
                        for (int col = 0; col < spr.ActiveSheet.ColumnCount; col++)
                        {
                            if (spr.ActiveSheet.Columns[col].CellType is NumberCellType)
                            {
                                sumColIndex += 1;
                                totalSumData[sumColIndex] += Convert.ToDouble(SpreadUtil.GetValue(spr, row, col));
                            }
                        }
                    }
                }

                spr.ActiveSheet.Rows.Count += 1;
                SpreadUtil.SetValue(spr, spr.ActiveSheet.Rows.Count - 1, colName[colName.Length - 1], "Total");
                sumColIndex = -1;
                for (int col = 0; col < spr.ActiveSheet.ColumnCount; col++)
                {
                    if (spr.ActiveSheet.Columns[col].CellType is NumberCellType)
                    {
                        sumColIndex += 1;
                        SpreadUtil.SetValue(spr, spr.ActiveSheet.RowCount - 1, col, totalSumData[sumColIndex]);
                    }
                }
                spr.ActiveSheet.Rows[spr.ActiveSheet.RowCount - 1].BackColor = Color.Lime;
            }

            //추가되었던 마지막 컬럼제거
            spr.ActiveSheet.Columns.Remove(lastColIndex, 1);
        }

        // 160616 정우영 추가부분

        //컬럼설정:SetColumn(스프레드, 시트인덱스, 컬럼인덱스, 태그, 라벨, 가로길이, 폰트, 락, 가로정렬, 세로정렬, 자동정렬, 셀타입, 소수점, 날짜포맷)
        public static int AddColunmDetail(FpSpread EditSpread, int SheetNumber, bool Hidden, string Tag, string Label, int Width, int FontSize, bool Lock, GridHorizontalAlignment HAlign, GridVerticalAlignment VAlign, bool AutoSort, CellType CellType, int DecimalPoint, DateFormatType DateFormat)
        {
            Font baseFont = new Font("맑은 고딕", 9);
            int baseWidth = 80;

            FpSpread Spread = EditSpread;

            if (Spread.Sheets.Count > SheetNumber + 1)
            {
                Spread.Sheets.Count = SheetNumber + 1;
            }

            //태그중복체크
            for (int i = 0; i < Spread.Sheets[SheetNumber].ColumnCount; i++)
            {
                if (Spread.Sheets[SheetNumber].Columns[i].Tag.ToString() != string.Empty
                    && Spread.Sheets[SheetNumber].Columns[i].Tag.ToString() == Tag)
                {
                    MessageBox.Show("중복되는 태그명이 존재합니다 : " + Tag);
                    return 0;
                }
            }
            if (Width == 0)
            {
                Width = baseWidth;
            }

            if (FontSize > 0)
            {
                baseFont = new Font("맑은 고딕", FontSize, System.Drawing.FontStyle.Bold);
            }
            Spread.Sheets[SheetNumber].AddColumns(Spread.Sheets[SheetNumber].ColumnCount, 1);
            Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].Tag = Tag;
            Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].Label = Label;
            Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].Width = Width;
            Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].Font = baseFont;
            Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].Locked = Lock;
            Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].AllowAutoSort = AutoSort;
            Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].Visible = Hidden;

            // HorizontalAlignment : 좌우정렬
            switch (HAlign)
            {
                case GridHorizontalAlignment.Center:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    break;

                case GridHorizontalAlignment.Left:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    break;

                case GridHorizontalAlignment.Right:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    break;

                case GridHorizontalAlignment.General:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
                    break;

                default:
                    MessageBox.Show("CENTER, LEFT, RIGHT 중 하나의 좌우정렬을 선택하십시오. : " + HAlign);
                    return 0;
            }

            // VerticalAlignment : 상하
            switch (VAlign)
            {
                case GridVerticalAlignment.Middle:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    break;

                case GridVerticalAlignment.Top:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
                    break;

                case GridVerticalAlignment.Bottom:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
                    break;

                case GridVerticalAlignment.General:
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                    break;

                default:
                    MessageBox.Show("CENTER, TOP, BOTTOM 중 하나의 상하정렬을 선택하십시오. : " + VAlign);
                    return 0;
            }

            //셀 타입
            switch (CellType)
            {
                case CellType.BARCODE:
                    FarPoint.Win.Spread.CellType.BarCodeCellType BarCodeType = new FarPoint.Win.Spread.CellType.BarCodeCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = BarCodeType;
                    break;

                case CellType.BUTTON:
                    FarPoint.Win.Spread.CellType.ButtonCellType ButtonType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = ButtonType;
                    break;

                case CellType.CHECKBOX:
                    FarPoint.Win.Spread.CellType.CheckBoxCellType CheckType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = CheckType;
                    break;

                case CellType.COLORPICKER:
                    FarPoint.Win.Spread.CellType.ColorPickerCellType ColorType = new FarPoint.Win.Spread.CellType.ColorPickerCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = ColorType;
                    break;

                case CellType.COMBOBOX:
                    FarPoint.Win.Spread.CellType.ComboBoxCellType ComboType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = ComboType;
                    break;

                case CellType.CURRENCY:
                    FarPoint.Win.Spread.CellType.CurrencyCellType CurType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = CurType;
                    break;

                case CellType.DATETIME:
                    FarPoint.Win.Spread.CellType.DateTimeCellType DateType = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                    switch (DateFormat)
                    {
                        case DateFormatType.LONG:
                            DateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.LongDate;
                            break;
                        case DateFormatType.LONGWITHTIME:
                            DateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.LongDateWithTime;
                            break;
                        case DateFormatType.SHORT:
                            DateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
                            break;
                        case DateFormatType.SHORTWITHTIME:
                            DateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
                            break;
                        case DateFormatType.TIME:
                            DateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
                            break;
                        default:
                            MessageBox.Show("LONG, LONGWITHTIME, SHORT, SHORTWITHTIME, TIME 타입중 하나를 선택하세요. : " + DateFormat);
                            return 0;
                    }
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = DateType;

                    break;

                case CellType.EMPTY:
                    FarPoint.Win.Spread.CellType.EmptyCellType EmptyType = new FarPoint.Win.Spread.CellType.EmptyCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = EmptyType;
                    break;

                case CellType.GENERAL:
                    FarPoint.Win.Spread.CellType.GeneralCellType GeType = new FarPoint.Win.Spread.CellType.GeneralCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = GeType;
                    break;

                case CellType.HYPERLINK:
                    FarPoint.Win.Spread.CellType.HyperLinkCellType HyperType = new FarPoint.Win.Spread.CellType.HyperLinkCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = HyperType;
                    break;

                case CellType.IMAGE:
                    FarPoint.Win.Spread.CellType.ImageCellType ImageType = new FarPoint.Win.Spread.CellType.ImageCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = ImageType;
                    break;

                case CellType.LISTBOX:
                    FarPoint.Win.Spread.CellType.ListBoxCellType ListType = new FarPoint.Win.Spread.CellType.ListBoxCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = ListType;
                    break;

                case CellType.MASK:
                    FarPoint.Win.Spread.CellType.MaskCellType MaskType = new FarPoint.Win.Spread.CellType.MaskCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = MaskType;
                    break;

                case CellType.MULTICOLUMNCOMBOBOX:
                    FarPoint.Win.Spread.CellType.MultiColumnComboBoxCellType MComboType = new FarPoint.Win.Spread.CellType.MultiColumnComboBoxCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = MComboType;
                    break;

                case CellType.MULTIOPTION:
                    FarPoint.Win.Spread.CellType.MultiOptionCellType MOpType = new FarPoint.Win.Spread.CellType.MultiOptionCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = MOpType;
                    break;

                case CellType.NUMBER:
                    FarPoint.Win.Spread.CellType.NumberCellType NumberType = new FarPoint.Win.Spread.CellType.NumberCellType();
                    NumberType.DecimalPlaces = DecimalPoint;
                    NumberType.Separator = ",";
                    NumberType.ShowSeparator = true;
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = NumberType;
                    break;

                case CellType.PERCENT:
                    FarPoint.Win.Spread.CellType.PercentCellType PerType = new FarPoint.Win.Spread.CellType.PercentCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = PerType;
                    break;

                case CellType.TEXT:
                    FarPoint.Win.Spread.CellType.TextCellType TextType = new FarPoint.Win.Spread.CellType.TextCellType();
                    Spread.Sheets[SheetNumber].Columns[Spread.Sheets[SheetNumber].ColumnCount - 1].CellType = TextType;
                    break;

                default:
                    MessageBox.Show("사용할 수 있는 형식 : BARCODE, BUTTON, CHECKBOX, COLORPICKER, COMBOBOX, CURRENCY, DATETIME, EMPTY, GENERAL, HYPERLINK, IMAGE, LISTBOX, MASK, MULTICOLUMNCOMBOBOX, MULTIOPTION, NUMBER, PERCENT, TEXT");
                    return 0;

            }
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Windows.Forms;

namespace CodeGen.Tool
{
    class MulitColumnsForGridView
    {
        public void SetSortView(DataGridView view)
        {
            if (view == null || this.view != null)
            {
                return;
            }

            this.view = view;
            this.view.Sorted += OnSort;
        }

        public int SortFieldMax
        {
            set
            {
                logic.SortFieldMax = value;
            }
        }

        protected virtual void SortImpl(DataGridView grid, MulitColumnsSortLogic logic)
        {
            string sort = logic.GetSortStr();
            System.Diagnostics.Debug.WriteLine("sort:{0}", sort);
            DataView dv = grid.DataSource as DataView;
            if (dv != null)
            {
                dv.Sort = sort;
                grid.DataSource = dv;
            }
        }

        private void OnSort(object sender, EventArgs e)
        {
            if (view == null)
            {
                return;
            }
            string key = view.SortedColumn.Name;
            MulitColumnsSortLogic.SortType type = view.SortOrder == SortOrder.Ascending ?
                MulitColumnsSortLogic.SortType.ASC : MulitColumnsSortLogic.SortType.DECS;
            logic.Sort(key, type);
            SortImpl(view, logic);
            /*
           logic.GetType().GetProperty("ss").GetValue(logic, null); 
            AutoCompleteMode arr = from it in view.DataSource orderby by sort;
            int i = 0;*/
            /*
            DataView dv = view.DataSource as DataView;
            if (dv != null)
            {
                dv.Sort = sort;
                view.DataSource = dv;
            }*/
        }

        private DataGridView view = null;
        private MulitColumnsSortLogic logic = new MulitColumnsSortLogic();
    }


    class MulitColumnsForGridView4List<T> : MulitColumnsForGridView
    {
        protected override void SortImpl(DataGridView grid, MulitColumnsSortLogic logic)
        {
            List<T> list = grid.DataSource as List<T>;
            if (list != null)
            {
                logic.SortLis<T>(list);
                grid.DataSource = list;
            }
        }
    }
}

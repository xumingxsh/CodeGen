using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CodeGen.Tool
{
    /// <summary>
    /// 多列排序逻辑类
    /// </summary>
    class MulitColumnsSortLogic
    {
        public enum SortType
        {
            ASC,
            DECS
        }

        public MulitColumnsSortLogic()
        {
            SortFieldMax = 2;
        }

        List<SortField> lst = new List<SortField>();

        /// <summary>
        /// 排序字段长度。
        /// </summary>
        public int SortFieldMax { get; set; }

        /// <summary>
        /// 排序，返回排序字符串。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public void Sort(string key, SortType type)
        {
            if (key != null && !key.Trim().Equals(""))
            {
                AddSortField(key, type);
            }
        }

        /// <summary>
        /// 清除排序信息
        /// </summary>
        public void Clear()
        {
            lst = new List<SortField>();
        }

        //public void Sort<T>(T t) where T: IList
        //{
        //    t.so
        //}

        /// <summary>
        /// 添加排序字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        private void AddSortField(string key, SortType type)
        {
            if (lst.Count >= SortFieldMax)
            {
                var i = from it in lst
                        where it.IsName(key)
                        select it;
                if (i.ToArray().Length > 0)
                {
                    lst.Remove(i.ToArray()[0]);
                }
                else
                {
                    lst.Remove(lst[0]);
                }
            }
            SortField field = new SortField();
            field.Field = key;
            field.Type = type;
            lst.Add(field);
        }

        /// <summary>
        /// 声场排序字符串
        /// </summary>
        /// <returns></returns>
        public string GetSortStr()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var i in lst)
            {
                if (sb.Length > 1)
                {
                    sb.Append(",");
                }
                sb.Append(i.GetSortStr());
            }
            return sb.ToString();
        }

        public void SortLis<T>(List<T> list)
        {
            list.Sort(delegate(T b, T a)
            {
                int result = 0;
                foreach (SortField i in lst)
                {
                    if (result != 0)
                    {
                        break;
                    }
                    object a_val = GetPropertyValue(a, i.Field);
                    object b_val = GetPropertyValue(b, i.Field);
                    result = CompareValue(a, b, i);                    
                }
                return result;
            });
        }

        private int CompareValue(object a, object b, SortField sort)
        {
            if (sort.Type == SortType.ASC)
            {
                if (b == null)
                {
                    return 0;
                }
                else if (b == null)
                {
                    return 1;
                }
                else
                {
                    if (a is IComparable)
                    {
                        return ((IComparable)a).CompareTo(b);
                    }
                    return 0;
                }
            }

            if (a == null)
            {
                return 1;
            }
            else if (b == null)
            {
                return 0;
            }
            else
            {
                if (a is IComparable)
                {
                    return ((IComparable)b).CompareTo(a);
                }
                return 0;
            }
        }

        public object GetPropertyValue(object obj, string field)
        {
            if (obj == null || obj.GetType().GetProperty(field) == null)
            {
                return null;
            }
            return obj.GetType().GetProperty(field).GetValue(obj, null);
        }

        public Type GetPropertType(object obj, string field)
        {
            if (obj == null || obj.GetType().GetProperty(field) == null)
            {
                return null;
            }
            return obj.GetType().GetProperty(field).PropertyType;
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        class SortField
        {
            public string Field { get; set; }

            public SortType Type { get;set; }

            public bool IsName(string name)
            {
                if (name == null)
                {
                    return false;
                }
                return name.Equals(Field);
            }

            public string GetSortStr()
            {
                if (Type == SortType.ASC)
                {
                    return string.Format(" {0} asc ", Field);
                }
                else
                {
                    return string.Format(" {0} desc ", Field);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.Models
{
    public static class CategoriasFilhas
    {

        private static List<List<int>> _Item;

        public static List<List<int>> GetAll()
        {
            if (_Item == null)
            {
                _Item = new List<List<int>>();

            }
            return _Item;
        }

        public static List<int> Get(int id)
        {
            if (_Item == null)
            {
                _Item = new List<List<int>>();

            }
            return _Item.Where(a => a.Count > 0 && a[0] == id).SingleOrDefault();
        }

        public static void Set(List<int> lst)
        {
            if (_Item == null)
            {
                _Item = new List<List<int>>();

            }
            if (lst.Count > 0)
            {
                _Item.Add(lst);
            }
            
        }


    }
}

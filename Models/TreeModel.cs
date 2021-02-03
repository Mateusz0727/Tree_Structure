using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TreeModel<T> : IEnumerable<TreeModel<T>>
    {
        public T Data { get; set; }
        public int ParentId { get; set; }

        public TreeModel<T> Parent { get; set; }

        public List<TreeModel<T>> Children { get; set; }

        public Boolean IsRoot
        {
            get { return Parent == null; }
        }

        public Boolean IsLeaf
        {
            get { return Children.Count == 0; }
        }

        public int Height{ get; set; }

        public TreeModel(T data,int ParentId, int height)
        {
            this.Data = data;
            this.ParentId = ParentId;
            this.Height = height;
            this.Children = new List<TreeModel<T>>();           
            this.ElementsIndex = new List<TreeModel<T>>();
            this.ElementsIndex.Add(this);
        }

        public TreeModel<T> AddChild(T Data, int parentId, int height)
        {
            TreeModel<T> childNode = new TreeModel<T>(Data,ParentId,height) { Parent = this,ParentId=ParentId,Height=height  };
            this.Children.Add(childNode);

            this.RegisterChildForSearch(childNode);

            return childNode;
        }

        private void RegisterChildForSearch(TreeModel<T> node)
        {
            ElementsIndex.Add(node);
            if (Parent != null)
                Parent.RegisterChildForSearch(node);
        }
        private ICollection<TreeModel<T>> ElementsIndex { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TreeModel<T>> GetEnumerator()
        {
            yield return this;
            foreach (var directChild in this.Children)
            {
                foreach (var anyChild in directChild)
                    yield return anyChild;
            }
        }
    }
}

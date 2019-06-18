using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.Extensions;

namespace UnityAtoms
{
    public abstract class ScriptableObjectList<T, E> : ScriptableObject, IList<T>, IListIcon
        where E : GameEvent<T>
    {
        public E Added;

        public E Removed;

        public VoidEvent Cleared;

        public int Count => list.Count;

        public bool IsReadOnly => false;

        [SerializeField]
        private List<T> list = new List<T>();

        public void Add(T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                if (null != Added)
                {
                    Added.Raise(item);
                }
            }
        }

        public bool Remove(T item)
        {
            var removed = list.Remove(item);
            if (!removed) return false;
            if (null != Removed)
            {
                Removed.Raise(item);
            }
            return true;
        }

        public void Clear()
        {
            list.Clear();
            if (null != Cleared)
            {
                Cleared.Raise();
            }
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public T Get(int i)
        {
            return list[i];
        }

        public List<T> List
        {
            get { return list; }
            set { list = value; }
        }

        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        public int IndexOf(T item) => list.IndexOf(item);

        public void RemoveAt(int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            if (null != Removed)
            {
                Removed.Raise(item);
            }
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
            if (Added != null)
            {
                Added.Raise(item);
            }
        }

        #region Observable
        public IObservable<T> ObserveAdd()
        {
            if (Added == null)
            {
                throw new Exception("You must assign an Added event in order to observe when adding to the list.");
            }

            return new ObservableEvent<T>(Added.Register, Added.Unregister);
        }

        public IObservable<T> ObserveRemove()
        {
            if (Removed == null)
            {
                throw new Exception("You must assign a Removed event in order to observe when removing from the list.");
            }

            return new ObservableEvent<T>(Removed.Register, Removed.Unregister);
        }

        public IObservable<Void> ObserveClear()
        {
            if (Cleared == null)
            {
                throw new Exception("You must assign a Cleared event in order to observe when clearing the list.");
            }

            return new ObservableEvent<Void>(Cleared.Register, Cleared.Unregister);
        }

        #endregion // Observable
    }
}
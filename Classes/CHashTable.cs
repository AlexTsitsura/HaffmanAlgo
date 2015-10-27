using System.Collections;
using System.Collections.Generic;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {
    internal class CHashTable : IHashTable {
        public Hashtable HashTable = new Hashtable();

        #region IHashTable Members

        public List<bool> this[byte index] {
            get { return (HashTable.Contains(index)) ? (List<bool>) HashTable[index] : null; }

            set { HashTable[index] = value; }
        }

        #endregion
    }
}
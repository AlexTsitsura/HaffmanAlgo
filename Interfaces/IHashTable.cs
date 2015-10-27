using System.Collections.Generic;

namespace HuffmanArch.Interfaces {

    public interface IHashTable {
        
        List<bool> this[byte index] {
            get;
            set;
        }

    }
}

using System.Collections.Generic;

namespace HuffmanArch.Interfaces {

    public interface IEncode {

        byte ConverToByte(int n);
        void AddRange(List<bool> list);
        int Count();

    }
}

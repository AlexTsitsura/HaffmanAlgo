using System.Collections.Generic;

namespace HuffmanArch.Interfaces {

    public interface IHuffmanTree {

        IEncode Encode(byte b);
        void Decode(bool bit, IDataProccess stream);
        void SetDecode();

    }
}

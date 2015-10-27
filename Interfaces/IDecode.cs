using HuffmanArch.Classes;

namespace HuffmanArch.Interfaces {

    public interface IDecode {

        void Set( CNode node );
        byte Get();
        CNode Decode(bool bit);

    }
}

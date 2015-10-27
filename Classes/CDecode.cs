using HuffmanArch.Interfaces;


namespace HuffmanArch.Classes {
    class CDecode : IDecode{

        public CNode Current;

        public void Set( CNode node ) {
            Current = node;
        }

        public byte Get() {
            return Current.Symbol;
        }

        public CNode Decode(bool bit) {

            if ( bit ) {
                if ( Current.Right != null ) {
                    Current = Current.Right;
                }
            }
            else {
                if ( Current.Left != null ) {
                    Current = Current.Left;
                }
            }

            return Current;
        }

    }
}

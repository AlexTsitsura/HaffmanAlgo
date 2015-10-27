using System.Collections.Generic;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {

    public class CHuffmanTree : IHuffmanTree {

        readonly IEncode _list = new CFactory().CreateEncode();
        readonly IDecode _current = new CFactory().CreateDecode();

        public IHashTable HashTable;
        public CNode Root;

        public IEncode Encode( byte b ) {
            _list.AddRange(HashTable[b] );
            return _list;
        }

        public void Decode (bool bit, IDataProccess stream) {
            if (!IsLeaf(_current.Decode(bit))) return;
            stream.OutByte( _current.Get() );
            _current.Set( Root );
        }

        public void SetDecode() {
            _current.Set( Root );
        }

        private static bool IsLeaf( CNode node ) {
            return ( node.Left == null && node.Right == null );
        }

    }

}

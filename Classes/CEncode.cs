using System.Collections.Generic;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {

    public class CEncode : IEncode {
     
        readonly List<bool> _encodedSymbols = new List<bool>();

        public void AddRange(List<bool> list) {
            _encodedSymbols.AddRange( list );
        }

        public int Count() {
            return _encodedSymbols.Count;
        }

        public byte ConverToByte( int n ) {

            byte result = 0, m = ( byte ) ( 1 << n - 1 ); 

            foreach ( var bit in _encodedSymbols.ToArray() ) {

                result += bit ? m : ( byte ) 0;
                if ((m = (byte) (m >> 1)) != 0) continue;
                _encodedSymbols.RemoveRange( 0, n );
                return result;
            }

            return result;
        }

    }

}

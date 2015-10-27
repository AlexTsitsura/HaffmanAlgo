using System.Collections.Generic;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {
   
    public class CNode {

        public byte Symbol;
        public ulong Frequency;
        public CNode Right;
        public CNode Left;

        public List<bool> MakeHash(List<bool> path, IHashTable hash) {

            if ( Right == null && Left == null ) {
                hash[ Symbol ] = path ;
                return null;
            }
            
            List<bool> left = null;
            List<bool> right = null;

            if ( Left != null ) {
                var leftPath = new List<bool>();
                leftPath.AddRange( path );
                leftPath.Add( false );
                left = Left.MakeHash( leftPath, hash );
            }

            if ( Right != null ) {
                var rightPath = new List<bool>();
                rightPath.AddRange( path );
                rightPath.Add( true );
                right = Right.MakeHash( rightPath, hash );
            }

            return  left ?? right;
        }
        
    }

}

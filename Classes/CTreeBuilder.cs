using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {
    public class CTreeBuilder : ITreeBuilder {

        public Dictionary<byte, ulong> Frequency;

        public IHuffmanTree CreateRoot( ) {

            var nodes = Frequency.Select(symbol => new CNode
                                                       {
                                                           Symbol = symbol.Key, Frequency = symbol.Value
                                                       }).ToList();

            while ( nodes.Count > 1 ) {
                var orderedNodes = nodes.OrderBy( node => node.Frequency ).ToList();

                if (orderedNodes.Count < 2) continue;
                var child = orderedNodes.Take( 2 ).ToList();

                var parent = new CNode {
                                             Symbol = 0x20,
                                             Frequency = child[0].Frequency + child[1].Frequency,
                                             Left = child[0],
                                             Right = child[1]
                                         };

                nodes.Remove( child[0] );
                nodes.Remove( child[1] );
                nodes.Add( parent );
            }

            IHashTable hash = new CHashTable();
            var firstOrDefault = nodes.FirstOrDefault();
            if (firstOrDefault != null) firstOrDefault.MakeHash( new List<bool>(), hash );

            return new CHuffmanTree {
                Root = nodes.FirstOrDefault(),
                HashTable = hash
            };

        }

        public StringBuilder OutTable() {
            var tb = new StringBuilder();
            tb.Append( "0 " ).Append( Frequency.Count );

            foreach ( var symbol in Frequency ) {
                tb.Append(" ").Append(symbol.Key).Append(" ").Append(symbol.Value);
            }

            return tb.Append("\n");
        }

    }
}

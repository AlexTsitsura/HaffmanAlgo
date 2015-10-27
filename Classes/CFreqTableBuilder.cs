using System.Collections.Generic;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {
    public class CFreqTableBuilder : IFreqTableBuilder {

        public Dictionary<byte, ulong> Frequency;

        public void AddByte( byte b ) {
            if ( !Frequency.ContainsKey( b ) ) {
                Frequency.Add( b, 0 );
            }
            Frequency[b]++;
        }

        public void AddPair(byte b, ulong freq) {
            Frequency.Add( b, freq );
        }

        public ITreeBuilder Create() {
            return new CTreeBuilder{
                Frequency = Frequency
            };
        }

        public CFreqTableBuilder() {
            Frequency = new Dictionary<byte, ulong>();
        }

    }
}

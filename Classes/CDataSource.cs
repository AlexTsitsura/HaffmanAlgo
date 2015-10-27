using System.IO;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {
    class CDataSource : IDataSource {

        private readonly BinaryReader _stream;

        public byte GetNext() {
            return _stream.ReadByte();
        }
        
        public bool IsFinished() {
            try
            {
                _stream.ReadByte();
                _stream.BaseStream.Position--;
            }
            catch ( EndOfStreamException ) {
                return true;
            }
            return false;
        }
        
        public void Reset() {
            _stream.BaseStream.Position = 0;
        }

        public CDataSource( string fileName ) {
            _stream = new BinaryReader( File.Open( fileName, FileMode.Open ) );
        }

        ~CDataSource() {
            _stream.Close();
        }

    }
}

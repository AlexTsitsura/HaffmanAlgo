using System.IO;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {
    public class CDataProccess : IDataProccess {

        private readonly BinaryWriter _stream;

        public void OutByte( byte b ) {
            _stream.Write( b );
        }

        public void OutString( string str ) {
            _stream.Write( str.ToCharArray() );
        }

        public void Reset() {
            _stream.BaseStream.Position = 0;
        }

        public CDataProccess( string fileName ) {
            _stream = new BinaryWriter( File.Open( fileName, FileMode.Create ) );
        }

        ~CDataProccess() {
            _stream.Close();
        }

    }
}

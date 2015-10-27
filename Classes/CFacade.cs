using System.Globalization;
using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {

    public static class Number {
       
        public static bool CheckBit( byte number, int iBit) {
            return ( ( number & ( 1 << iBit ) ) != 0 );
        }

    }

    internal class CFacade : IFacade {

        const byte BYTELENGHT = 0x8;
        const byte SPACE = 0x20;
        const byte ENTER = 0xA;
        const byte ZERO = 0x30;

        static ulong Get(IDataSource input) {
            byte b;

            while ( ( b = input.GetNext() ) == SPACE ){
                // Do nothing
            }
            var res = ( ulong ) b - ZERO;
            while ( ( b = input.GetNext() ) != SPACE && b != ENTER ) {
                res = res * 10 + b - ZERO;
            }

            return res;
        }

        public void EncodeData(IFactory factory, IDataSource istream, IDataProccess ostream, IFreqTableBuilder table) {
            while ( !istream.IsFinished() ) {
                table.AddByte( istream.GetNext() );
            }
            istream.Reset();
            var tree = table.Create();
            var root = tree.CreateRoot();
            ostream.OutString( tree.OutTable().ToString() );
            var list = factory.CreateEncode();
            while ( !istream.IsFinished() ) {

                list = root.Encode( istream.GetNext() );
                while ( list.Count() >= BYTELENGHT )
                    ostream.OutByte( list.ConverToByte( BYTELENGHT ) );

            }
            var listCount = ( byte ) list.Count();
            if (listCount == 0) return;
            ostream.OutByte( list.ConverToByte( listCount ) );
            ostream.Reset();
            ostream.OutString( listCount.ToString(CultureInfo.InvariantCulture) );
        }

        public void DecodeData(IFactory factory, IDataSource istream, IDataProccess ostream, IFreqTableBuilder table) {

            var tail = ( byte ) ( istream.GetNext() - ZERO );
            var count = ( int ) Get( istream );
            while ( ( count-- ) != 0 ) {
                table.AddPair( ( byte ) Get( istream ), Get( istream ) );
            }
            var tree = table.Create();
            var root = tree.CreateRoot();
            root.SetDecode();
            while ( !istream.IsFinished() ) {
                byte b = istream.GetNext(), i = BYTELENGHT;
                if ( istream.IsFinished() && tail != 0 ) {
                    i = tail;
                }
                while ( ( i-- ) != 0 ) {
                    root.Decode( Number.CheckBit( b, i ), ostream );
                }
            }
        }
    }
}
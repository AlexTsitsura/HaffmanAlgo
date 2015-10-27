using HuffmanArch.Interfaces;

namespace HuffmanArch.Classes {
    class CFactory : IFactory {

        public ITreeBuilder CreateTreeBuilder() {
            return new CTreeBuilder();
        }

        public IHuffmanTree CreateHuffmanTree() {
            return new CHuffmanTree();
        }

        public IHuffmanTree CreateHuffmanTree( CNode root, IHashTable hTable ) {
            return new CHuffmanTree {
                Root = root,
                HashTable = hTable
            };
        }

        public IHashTable CreateHashTable() {
            return new CHashTable();
        }

        public IFreqTableBuilder CreateFreqTableBuilder() {
            return new CFreqTableBuilder();
        }

        public IEncode CreateEncode() {
            return new CEncode();
        }

        public IDecode CreateDecode() {
            return new CDecode();
        }

        public IFacade CreateDecodeEncodeData() {
            return new CFacade();
        }

        public IDataSource CreateDataSource( string fileName ) {
            return new CDataSource( fileName );
        }

        public IDataProccess CreateDataProccess(string fileName ) {
            return new CDataProccess( fileName );
        }

    }
}

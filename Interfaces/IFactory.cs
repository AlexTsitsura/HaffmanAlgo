using HuffmanArch.Classes;

namespace HuffmanArch.Interfaces {
    internal interface IFactory {

        ITreeBuilder CreateTreeBuilder();
        IHuffmanTree CreateHuffmanTree();
        IHuffmanTree CreateHuffmanTree(CNode root, IHashTable hTable);
        IHashTable CreateHashTable();
        IFreqTableBuilder CreateFreqTableBuilder();
        IEncode CreateEncode();
        IDecode CreateDecode();
        IFacade CreateDecodeEncodeData();
        IDataSource CreateDataSource(string fileName);
        IDataProccess CreateDataProccess(string fileName);

    }
}

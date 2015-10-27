using System.Text;

namespace HuffmanArch.Interfaces {

    public interface ITreeBuilder {

        IHuffmanTree CreateRoot();
        StringBuilder OutTable();

    }
}

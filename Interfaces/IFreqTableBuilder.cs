namespace HuffmanArch.Interfaces {

    public interface IFreqTableBuilder {

        void AddByte(byte b);
        void AddPair(byte b, ulong freq);
        ITreeBuilder Create();

    }
}

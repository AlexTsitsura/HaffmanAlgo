namespace HuffmanArch.Interfaces {

    public interface IDataSource {

        byte GetNext();
        bool IsFinished();
        void Reset();

    }
}

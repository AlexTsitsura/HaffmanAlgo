namespace HuffmanArch.Interfaces {

    interface IFacade {

        void EncodeData(IFactory factory, IDataSource istream, IDataProccess ostream, IFreqTableBuilder table);
        void DecodeData(IFactory factory, IDataSource istream, IDataProccess ostream, IFreqTableBuilder table);

    }
}

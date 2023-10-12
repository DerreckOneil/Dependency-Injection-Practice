namespace NETDI {
    public interface ITextSerializer {
        public string Serialize<T>(object value);
    }
}

namespace Mock_EMR_Software.CustomExceptions
{
    [Serializable]
    public class NullJsonObjectException: Exception
    {
        public NullJsonObjectException() { }

        public NullJsonObjectException(string message) : base(message) { }

    }
}

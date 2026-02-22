namespace Domain.Exceptions
{
    public class MissingRequiredInformation : Exception
    {
        public MissingRequiredInformation()
            : base("Required information not provided.") { }
    }
}
namespace Domain.Exceptions
{
    public class MissingRequiredInformation : Exception
    {
        public MissingRequiredInformation()
            : base("Informações obrigatórias não preenchidas.") { }
    }
}
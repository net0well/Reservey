public class InvalidEmailException : Exception
{
    public InvalidEmailException()
        : base("Email inválido.") { }
}
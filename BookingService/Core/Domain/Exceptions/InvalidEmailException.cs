public class InvalidEmailException : Exception
{
    public InvalidEmailException()
        : base("Email is invalid.") { }
}
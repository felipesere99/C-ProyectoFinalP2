using System;

public class JugadorNoEncontradoException : Exception
{
    public JugadorNoEncontradoException() : base() { }

    public JugadorNoEncontradoException(string message) : base(message) { }

    public JugadorNoEncontradoException(string message, Exception innerException) : base(message, innerException) { }
}
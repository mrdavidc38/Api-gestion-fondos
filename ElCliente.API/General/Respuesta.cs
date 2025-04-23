namespace ElCliente.API.General
{
    public class Respuesta<T>
    {
        public bool status { get; set; }
        public T value { get; set; }
        public string msg { get; set; }
    }
}

namespace CursoIdiomas.API.Controllers {
    public class GenericCommandsResults<T> {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
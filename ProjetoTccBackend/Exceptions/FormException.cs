namespace ProjetoTccBackend.Exceptions
{
    public class FormException : Exception
    {
        public readonly IDictionary<string, string> FormData;

        public FormException(IDictionary<string, string> formData) : base()
        {
            this.FormData = formData;
        }

        public FormException(IDictionary<string, string> formData, string message) : base(message)
        {
            this.FormData = formData;
        }
    }
}

namespace ProjetoTccBackend.Exceptions
{
    public class FormException : Exception
    {
        public readonly IDictionary<string, string> FormData;

        public FormException(IDictionary<string, string> formData) : base()
        {
            this.FormData = formData;
        }
    }
}

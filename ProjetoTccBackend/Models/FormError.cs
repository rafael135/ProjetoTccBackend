using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Models
{
    /// <summary>
    /// Represents a form error, containing information about the target field and the associated error message.
    /// </summary>
    [NotMapped]
    public class FormError
    {
        /// <summary>
        /// Gets or sets the target field of the error.
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the error message associated with the target field.
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormError"/> class with the specified target field and error message.
        /// </summary>
        /// <param name="target">The target field of the error.</param>
        /// <param name="error">The error message associated with the target field.</param>
        public FormError(string target, string error)
        {
            this.Target = target;
            this.Error = error;
        }
    }
}

using System.Collections.Generic;

namespace RotaGeek.Services.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public OperationResult()
        {
            Success = true;
            Errors = new List<string>();
        }
    }
}
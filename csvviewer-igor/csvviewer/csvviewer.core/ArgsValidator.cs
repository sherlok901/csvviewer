using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvviewer.core
{
    public class ArgsValidator
    {
        public ValidationResult Validate(string[] args)
        {
            return ValidationResult.Valid;
        }

        public enum ValidationResult
        {
            NotChecked,
            NoFilePath,
            NotValid,
            Valid
        }
    }
}

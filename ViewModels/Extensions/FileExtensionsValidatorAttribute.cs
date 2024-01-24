// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public sealed class FileExtensionsValidatorAttribute : DataTypeAttribute
    {
        private string DefaultErrorMessage;


        private string _extensions = "png,jpg,jpeg,gif";

        

        public string Extensions
        {
            // Default file extensions match those from jquery validate.
            get => _extensions;
            set => _extensions = value;
        }

        private string ExtensionsFormatted => ExtensionsParsed.Aggregate((left, right) => left + ", " + right);

        private string ExtensionsNormalized =>
            Extensions.Replace(" ", string.Empty).Replace(".", string.Empty).ToLowerInvariant();

        private IEnumerable<string> ExtensionsParsed
        {
            get { return ExtensionsNormalized.Split(',').Select(e => "." + e); }
        }

        public FileExtensionsValidatorAttribute()
            : base(DataType.Upload)
        {
            
            DefaultErrorMessage = "Invalid File";
        }


        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, ExtensionsFormatted);

        public override bool IsValid(object? obj)
        {
            var file = obj as IFormFile;
            if (file != null)
            { 
                string filename = file.FileName;
                if (!string.IsNullOrEmpty(filename)) {
                    return ValidateExtension(filename);
                }
               
            }
            return false;
        }

        private bool ValidateExtension(string fileName)
        {
            return ExtensionsParsed.Contains(Path.GetExtension(fileName).ToLowerInvariant());
        }
    }
}

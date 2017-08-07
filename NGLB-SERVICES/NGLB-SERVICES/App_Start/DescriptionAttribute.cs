using System;

namespace NGLB_SERVICES
{
    /// <summary>
    ///     Descriptive Attribute used for Swagger
    /// </summary>
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        ///     Just stores the Description for the Swagger API
        /// </summary>
        /// <param name="description"></param>
        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        /// <summary>
        ///     Description used for Swagger
        /// </summary>
        public string Description { get; set; }
    }
}
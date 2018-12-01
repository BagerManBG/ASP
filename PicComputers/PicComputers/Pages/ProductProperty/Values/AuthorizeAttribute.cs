using System;

namespace PicComputers.Pages.ProductProperty.Values
{
    internal class AuthorizeAttribute : Attribute
    {
        public string Roles { get; set; }
    }
}
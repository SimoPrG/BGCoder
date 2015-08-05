namespace WarMachines.Common
{
    using System;

    public static class Validation
    {
        public static void CheckArgumentForNullReference(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}

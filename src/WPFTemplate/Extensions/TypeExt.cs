using System;
using System.Linq;

namespace WPFTemplate.Extensions
{
    public static class TypeExt
    {
        //https://learn.microsoft.com/en-us/dotnet/api/system.type.isassignableto?view=net-6.0
        /// <summary>
        /// Determines whether the current type can be assigned to a variable of the specified targetType.
        /// </summary>
        /// <param name="targetType">The type to compare with the current type.</param>
        /// <returns>
        /// true if any of the following conditions is true:
        ///     The current instance and targetType represent the same type.
        ///     The current type is derived either directly or indirectly from targetType.
        ///     The current type is derived directly from targetType if it inherits from targetType.
        ///     The current type is derived indirectly from targetType if it inherits from a succession of one or more classes that inherit from targetType.
        ///     targetType is an interface that the current type implements.
        ///     The current type is a generic type parameter, and targetType represents one of the constraints of the current type.
        ///     The current type represents a value type, and targetType represents Nullable<c> (Nullable(Of c) in Visual Basic).
        /// false if none of these conditions are true, or if targetType is null.
        /// </returns>
        public static bool IsAssignableTo(this Type self, Type targetType)
        {
            //False if ...targetType is null.
            if (targetType == null) return false;

            //The current instance and targetType represent the same type.
            if (self == targetType) return true;
            //The current type is derived either directly or indirectly from targetType.
            if (self.IsSubclassOf(targetType)) return true;
            //targetType is an interface that the current type implements.
            if (self.GetInterfaces().Contains(targetType)) return true;
            //The current type is a generic type parameter, and targetType represents one of the constraints of the current type.
            if (self.IsGenericParameter && self.GetGenericParameterConstraints().Contains(targetType)) return true;
            //The current type represents a value type, and targetType represents Nullable<c> (Nullable(Of c) in Visual Basic).
            if (self.IsValueType && targetType == typeof(Nullable<>)) return true;

            //false if none of these conditions are true...
            return false;
        }
    }
}

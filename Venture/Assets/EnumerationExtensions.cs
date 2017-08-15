using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class EnumerationExtensions
{
    /// <summary>
    /// Checks if the value contains the provided type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Has<T>(this Enum type, T value)
    {
        try
        {
            return (((int)(object)type & (int)(object)value) != 0);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if the value is only the provided type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Is<T>(this Enum type, T value)
    {
        try
        {
            return (int)(object)type == (int)(object)value;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Adds a value to this enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T Add<T>(this Enum type, T value)
    {
        try
        {
            return (T)(object)(((int)(object)type | (int)(object)value));
        }
        catch (Exception ex)
        {
            throw new ArgumentException(string.Format("Could not append value from enumerated type '{0}'.", typeof(T).Name), ex);
        }
    }

    // completely removes the value
    public static T Remove<T>(this Enum type, T value)
    {
        try
        {
            return (T)(object)(((int)(object)type & ~(int)(object)value));
        }
        catch (Exception ex)
        {
            throw new ArgumentException(string.Format("Could not remove value from enumerated type '{0}'.", typeof(T).Name), ex);
        }
    }
}


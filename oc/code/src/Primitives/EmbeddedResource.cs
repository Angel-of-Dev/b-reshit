// Copyright (c) Angel-of-Dev. All rights reserved.

using angelof.dev.Support;

namespace angelof.dev;

/// <summary> Provides methods for interacting with embedded resources. </summary>
public static class EmbeddedResource
{
    /// <summary> Gets the <see cref="string"/> corresponding to the specified resource embedded in the assembly. </summary>
    /// <remarks>
    ///     <para> The resource file name MUST end with ".resource". Example: "owner.text.resource. </para>
    /// </remarks>
    /// <param name="owner"> The type owning the embedded resource. </param>
    /// <param name="name"> The name of the resource, without ".resource". Example: "text". </param>
    /// <exception cref="ArgumentNullException"> <paramref name="owner"/> or <paramref name="name"/> is <see langword="null"/>. </exception>
    public static string GetString(Type owner, string name)
    {
        Guard.Argument.NotNull(owner);
        Guard.Argument.NotNull(name);

        var resourceName = $"{GetTypeName(owner)}.{name}.resource";
        using (var stream = owner.Assembly.GetManifestResourceStream(resourceName))
        {
            if (stream is null)
            {
                var assemblyName = owner.Assembly.GetName().Name ?? "unknown";
                var availableResources = Format.List(owner.Assembly.GetManifestResourceNames());
                throw new ExpectationException("embedded resource exists in assembly",
                                               "embedded resource was not found",
                                               new
                                               {
                                                   resourceName,
                                                   assemblyName,
                                                   availableResources
                                               });
            }

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    private static string GetTypeName(Type owner)
    {
        var name = owner.FullName ?? owner.Name;
        return name.Replace("+", ".", StringComparison.Ordinal);
    }
}

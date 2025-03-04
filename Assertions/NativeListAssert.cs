using NUnit.Framework;
using System;
using Unity.Collections;

namespace Core.Testing.Assertions
{
    public static class NativeListAssert
    {
        public static void AreEqual<T>(NativeList<T> expected, NativeList<T> actual) where T : unmanaged, IEquatable<T>
        {
            Assert.AreEqual(expected.Length, actual.Length, "NativeLists have different lengths.");

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], $"Elements at index {i} are not equal.");
            }

        }

    }

}
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace pHashTestApplication
{
    class Program
    {
        [DllImport(@"pHash.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ph_dct_imagehash(string file, ref ulong hash);
        [DllImport(@"pHash.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ph_hamming_distance(ulong hasha, ulong hashb);

        static void Main()
        {
            ulong hash1 = 0, hash2 = 0;
            ph_dct_imagehash(Path.Combine(Environment.CurrentDirectory, "image1.jpg"), ref hash1);
            ph_dct_imagehash(Path.Combine(Environment.CurrentDirectory, "image2.jpg"), ref hash2);
            var distance = ph_hamming_distance(hash1, hash2);
            Console.WriteLine("Hamming distance : {0}", distance);
        }
    }
}

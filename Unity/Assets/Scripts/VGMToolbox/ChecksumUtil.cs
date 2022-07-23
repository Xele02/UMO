// <copyright file="ChecksumUtil.cs" company="N/A">
// Copyright (c) 2008 All Rights Reserved
// </copyright>
// <author></author>
// <email></email>
// <date></date>
// <summary>Contains the ChecksumUtil class.</summary>
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;

// using ICSharpCode.SharpZipLib.Checksums;
// using Ionic.Zlib; 

namespace VGMToolbox.util
{              
    /// <summary>
    /// Class containing static functions related to checksum generation.
    /// </summary>
    public sealed class ChecksumUtil
    {
        /// <summary>
        /// Prevents a default instance of the ChecksumUtil class from being created.
        /// </summary>
        private ChecksumUtil() 
        { 
        }

        /// <summary>
        /// Get the CRC32 checksum of the input stream.
        /// </summary>
        /// <param name="stream">File Stream for which to generate the checksum.</param>
        /// <returns>String containing the hexidecimal representation of the CRC32 of the input stream.</returns>
        // public static string GetCrc32OfFullFile(FileStream stream)
        // {
        //     // get incoming stream position
        //     long initialStreamPosition = stream.Position;
            
        //     // move to zero position
        //     stream.Seek(0, SeekOrigin.Begin);
            
        //     // calculate CRC32
        //     CRC32 crc32 = new CRC32();
        //     int ret = crc32.GetCrc32(stream);

        //     // return stream to incoming position
        //     stream.Position = initialStreamPosition;

        //     return ret.ToString("X8", CultureInfo.InvariantCulture);
        // }

        /// <summary>
        /// Get the MD5 checksum of the input stream.
        /// </summary>
        /// <param name="stream">File Stream for which to generate the checksum.</param>
        /// <returns>String containing the hexidecimal representation of the MD5 of the input stream.</returns>
        public static string GetMd5OfFullFile(FileStream stream)
        {
            MD5CryptoServiceProvider hashMd5 = new MD5CryptoServiceProvider();

            stream.Seek(0, SeekOrigin.Begin);
            hashMd5.ComputeHash(stream);
            return ParseFile.ByteArrayToString(hashMd5.Hash);
        }

        public static byte[] GetSha1(byte[] dataBlock)
        {
            SHA1CryptoServiceProvider sha1Hash = new SHA1CryptoServiceProvider();
            sha1Hash.ComputeHash(dataBlock);
            return sha1Hash.Hash;
        }

        /// <summary>
        /// Get the SHA1 checksum of the input stream.
        /// </summary>
        /// <param name="stream">File Stream for which to generate the checksum.</param>
        /// <returns>String containing the hexidecimal representation of the SHA1 of the input stream.</returns>
        public static string GetSha1OfFullFile(FileStream stream)
        {
            SHA1CryptoServiceProvider sha1Hash = new SHA1CryptoServiceProvider();

            stream.Seek(0, SeekOrigin.Begin);
            sha1Hash.ComputeHash(stream);
            return ParseFile.ByteArrayToString(sha1Hash.Hash);
        }

        /// <summary>
        /// Get the SHA-512 checksum of the input stream.
        /// </summary>
        /// <param name="stream">File Stream for which to generate the checksum.</param>
        /// <returns>String containing the hexidecimal representation of the SHA-512 of the input stream.</returns>
        public static string GetSha512OfFullFile(FileStream stream)
        {
            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();

            stream.Seek(0, SeekOrigin.Begin);
            sha512.ComputeHash(stream);
            return ParseFile.ByteArrayToString(sha512.Hash);
        }

        /// <summary>
        /// Adds a chunk of data to the input CRC32 generator.
        /// </summary>
        /// <param name="stream">Stream to read data from.</param>
        /// <param name="startingOffset">Offset to begin reading from.</param>
        /// <param name="length">Number of bytes to read.</param>
        /// <param name="checksumGenerator">CRC32 generator.</param>
        // public static void AddChunkToChecksum(Stream stream, int startingOffset, int length, ref Crc32 checksumGenerator)
        // {
        //     int remaining = length;
        //     byte[] data = new byte[4096];
        //     int read;
        //     int offset = startingOffset;

        //     stream.Seek((long)startingOffset, SeekOrigin.Begin);

        //     while (remaining > 0)
        //     {
        //         if (remaining < 4096)
        //         {
        //             read = stream.Read(data, 0, remaining);
        //         }
        //         else
        //         {
        //             read = stream.Read(data, 0, 4096);
        //         }

        //         if (read <= 0)
        //         {
        //             throw new EndOfStreamException(
        //                 String.Format(
        //                     CultureInfo.CurrentCulture, 
        //                     "End of stream reached with {0} bytes left to read", 
        //                     remaining));
        //         }

        //         checksumGenerator.Update(data, 0, read);
        //         remaining -= read;
        //         offset += read;
        //     }
        // }

        /// <summary>
        /// Adds a chunk of data to the input CRC32/MD5/SHA1 generator.
        /// </summary>
        /// <param name="sourceStream">Stream to read data from.</param>
        /// <param name="startingOffset">Offset to begin reading from.</param>
        /// <param name="length">Number of bytes to read.</param>
        /// <param name="checksumGeneratorCrc32">CRC32 generator.</param>
        /// <param name="checksumStreamMd5">MD5 generator.</param>
        /// <param name="checksumStreamSha1">SHA1 generator.</param>
        // public static void AddChunkToChecksum(
        //     Stream sourceStream, 
        //     int startingOffset, 
        //     int length,
        //     ref Crc32 checksumGeneratorCrc32,
        //     ref CryptoStream checksumStreamMd5,
        //     ref CryptoStream checksumStreamSha1)
        // {
        //     int remaining = length;
        //     byte[] data = new byte[4096];
        //     int read;
        //     int offset = startingOffset;

        //     sourceStream.Seek((long)startingOffset, SeekOrigin.Begin);

        //     while (remaining > 0)
        //     {
        //         if (remaining < 4096)
        //         {
        //             read = sourceStream.Read(data, 0, remaining);
        //         }
        //         else
        //         {
        //             read = sourceStream.Read(data, 0, 4096);
        //         }

        //         if (read <= 0)
        //         {
        //             throw new EndOfStreamException(
        //                 String.Format(
        //                     CultureInfo.CurrentCulture, 
        //                     "End of stream reached with {0} bytes left to read", 
        //                     remaining));
        //         }

        //         checksumGeneratorCrc32.Update(data, 0, read);
        //         checksumStreamMd5.Write(data, 0, read);
        //         checksumStreamSha1.Write(data, 0, read);
        //         remaining -= read;
        //         offset += read;
        //     }
        // }
    }
}